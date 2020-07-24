/* globals $, Sammy */
import home from './controllers/home.js';
import about from './controllers/about.js';
import register, { registerPost } from './controllers/register.js';
import login, { loginPost, logout } from './controllers/login.js';
import catalog from './controllers/catalog.js';
import details from './controllers/details.js';
import create, { createPost } from './controllers/create.js';
import edit, { editPost } from './controllers/edit.js';
import leave from './controllers/leave.js';
import join from './controllers/join.js';

$(() => {
    const app = Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.userData = {
            hasTeam: false,
            loggedIn: false
        }

        this.get('index.html', home);
        this.get('#/home', home);
        this.get('/', home);
        
        this.get('#/about', about);

        this.get('#/register', register);

        this.get('#/login', login);

        this.get('#/login', login);

        this.get('#/catalog', catalog);

        this.get('#/catalog/:id', details);

        this.get('#/create', create);

        this.get('#/leave', leave);

        this.get('#/join/:id', join);

        this.get('#/logout', logout);
        
        this.get('#/edit/:id', edit);

        this.post('#/register', (context) => { registerPost.call(context); });

        this.post('#/login', (context) => { loginPost.call(context); });

        this.post('#/create', (context) => { createPost.call(context); });

        this.post('#/edit/:id', (context) => { editPost.call(context); });
    });

    app.run();
});
