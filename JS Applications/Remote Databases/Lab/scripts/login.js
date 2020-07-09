(function() {
    const loginContainer = document.getElementById('login-container');
    const loginError = document.getElementById('login-error');
    
    const loginBtn = document.getElementById('login-btn');
    //const logoutBtn = document.getElementById('logout-btn');
    //const registerBtn = document.getElementById('register-btn');
    
    const userEmailEl = document.getElementById('user-email');
    
    const emailInput = document.getElementById('email');
    const passwordInput = document.getElementById('password');

    loginBtn.addEventListener('click', function loginHandler() {
        loginError.textContent = '';
        const email = emailInput.value;
        const password = passwordInput.value;
        
        if (!email || !password) {
            loginError.textContent = 'Please enter valid credentials';
            return;
        }

        firebase.auth().signInWithEmailAndPassword(email, password)
        .then(function () {
            const currentHref = window.location.href;
            const lastSlash = currentHref.lastIndexOf('/');
            const nextHref = currentHref.substring(lastSlash + 1, -1) + 'app.html';
            window.location.href = nextHref;
        })
        .catch(function(error) {
            loginError.textContent = error.message;
        });
    })

    // logoutBtn.addEventListener('click', function logoutHandler(e) {
    //     e.preventDefault();
    //     firebase.auth().signOut().catch(function (error) {
    //         console.error(error);
    //     });
    // });

    // registerBtn.addEventListener('click', function registerHandler(e) {
    //     loginError.textContent = '';
    //     const email = emailInput.value;
    //     const password = passwordInput.value;
        
    //     if (!email || !password) {
    //         alert('Please enter valid credentials');
    //         return;
    //     }


    //     firebase.auth().createUserWithEmailAndPassword(email, password)
    //     .then(function () {
    //     })
    //     .catch(function(error) {
    //         loginError.textContent = error.message;
    //     });
    // });
})();

