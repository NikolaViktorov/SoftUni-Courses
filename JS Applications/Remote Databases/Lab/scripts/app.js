(function() {
    const userEmailEl = document.getElementById('user-email');
    const logoutBtn = document.getElementById('logout-btn');

    let loggedOut = false;

    logoutBtn.addEventListener('click', function logoutHandler(e) {
        e.preventDefault();
        firebase.auth().signOut()
        .then(function () {
            const currentHref = window.location.href;
            const lastSlash = currentHref.lastIndexOf('/');
            const nextHref = currentHref.substring(lastSlash + 1, -1) + 'index.html';
            window.location.href = nextHref;
            loggedOut = true;
        })
        .catch(function (error) {
            console.error(error);
        });
    });

    function init() {
        firebase.auth().onAuthStateChanged(function(user) {
            if (user) {
                userEmailEl.textContent = user.email;
            } else {
                if (loggedOut === false) {
                    alert('Къде отиваш а?')

                    setTimeout(function () {
                        const currentHref = window.location.href;
                        const lastSlash = currentHref.lastIndexOf('/');
                        const nextHref = currentHref.substring(lastSlash + 1, -1) + 'index.html';
                        window.location.href = nextHref;
                    }, 100)
                }
            }
          });
    }

    init();
})();

