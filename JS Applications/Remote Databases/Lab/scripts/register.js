(function() {
    const registerContainer = document.getElementById('register-container');
    const registerError = document.getElementById('register-error');
    
    const registerBtn = document.getElementById('register-btn');
    
    const emailInput = document.getElementById('email');
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirm-password');

    registerBtn.addEventListener('click', function registerHandler(e) {
        registerError.textContent = '';
        const email = emailInput.value;
        const password = passwordInput.value;
        const confirmedPassword = confirmPasswordInput.value;
        
        if (!email || !password) {
            registerError.textContent = 'Please enter valid credentials';
            toggleError(0);
            return;
        } else if (password !== confirmedPassword) {
            registerError.textContent = "Your passwords don't match";
            toggleError(0);
            return;
        }

        firebase.auth().createUserWithEmailAndPassword(email, password)
        .then(function () {
            const currentHref = window.location.href;
            const lastSlash = currentHref.lastIndexOf('/');
            const nextHref = currentHref.substring(lastSlash + 1, -1) + 'app.html';
            window.location.href = nextHref;
        })
        .catch(function(error) {
            registerError.textContent = error.message;
            toggleError(0);
        });
    });

    function toggleError(option) {
        if (option === 1 && registerError.classList.contains('hidden') === false) {
            registerError.classList.add('hidden');
        } else if(option === 0 && registerError.classList.contains('hidden') === true) {
            registerError.classList.remove('hidden');
        }
    }
})();

