import { match } from './node_modules/path-to-regexp/dist.es2015/index.js';

function Sammy(selector, initFn) {

    const mainEl = document.querySelector(selector);
    const collection = [];
    let currentPath = undefined;

    function onAnchorClickHandler(e) {
        e.preventDefault();
        const target = e.target;
        const path = target.getAttribute('href');
        core.redirect(path);
        window.history.pushState(null, '', path);
    }

    function setUpListeners() {
        Array.from(document.querySelectorAll('a'))
            .forEach(i => i.addEventListener('click', onAnchorClickHandler));

        window.addEventListener('popstate', function(data) {
            core.redirect(window.location.pathname);
        })
    }

    const core = {
        get(path, fn) {
            const matchFn = match(path, { decode: decodeURIComponent})
            collection.push({ path, fn, matchFn });
        },
        redirect(path) {
            currentPath = path;
            const pathObj = collection.find(i => {
                const data = i.matchFn(currentPath);

                return !!data;
            });
            if (!pathObj) {
                console.error(`body 404 Not Found! get ${currentPath}`);
                return;
            }
            pathObj.fn.call(core);
        },
        swap(content) {
            mainEl.innerHTML = content;
        }
    }

    const app = {
        run(path) {
            setUpListeners();
            initFn.call(core);

            core.redirect(path);
        }
    };

    return app;
}

const app = Sammy('#main', function() { 
    this.get('/', function() {
        this.swap('<h1> Home </h1>');
    })

    this.get('/user/:id', function() {
        this.swap('<h1> User </h1>');
    })

    this.get('/about', function() {
        this.swap('<h1> About </h1>');
    })
});

app.run('/');