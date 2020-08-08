import home, { createPage, createPost, detailsPage, editPage, editPost, deleteMovie, like } from './controllers/catalog.js';
import { registerPage, registerPost, loginPage, loginPost, logout } from './controllers/user.js';

window.addEventListener('load', () => {
    const app = Sammy('#container', function() {
        this.use('Handlebars', 'hbs');

        this.userData = {
            email: sessionStorage.getItem('email') || '',
            userId: sessionStorage.getItem('userId') || '',
            movies: []
        }

        this.get('/', home);
        this.get('#/home', home);
        this.get('index.html', home);
        
        this.get('#/register', registerPage)
        this.post('#/register', (ctx) => { registerPost.call(ctx); });

        this.get('#/login', loginPage)
        this.post('#/login', (ctx) => { loginPost.call(ctx); });

        this.get('#/logout', logout);
        
        this.get('#/create', createPage);
        this.post('#/create', (ctx) => { createPost.call(ctx); });

        this.get('#/edit/:id', editPage);
        this.post('#/edit/:id', (ctx) => { editPost.call(ctx); });

        this.get('#/details/:id', detailsPage);

        this.get('#/like/:id', like)

        this.get('#/delete/:id', deleteMovie);
    });

    app.run();
});