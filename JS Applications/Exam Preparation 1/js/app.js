import getHome from './controllers/home.js';
import { getCreate, postCreate, getDetails, getEdit, postEdit, getClose, getJoin } from './controllers/event.js'; 
import { getLogin, getRegister, getProfile, postRegister, postLogin, getLogout } from './controllers/user.js';

const app = Sammy("body", function () {
    this.use("Handlebars", "hbs");

    this.get('#/home', getHome);
    this.get('/', getHome);

    this.get('#/profile', getProfile);

    this.get('#/login', getLogin);

    this.get('#/register', getRegister);

    this.post('#/register', postRegister);

    this.post('#/login', postLogin);

    this.get('#/logout', getLogout);

    this.get('#/create', getCreate)
    
    this.post('#/create', postCreate);

    this.get('#/details/:id', getDetails)

    this.get('#/edit/:id', getEdit)

    this.post('#/edit/:id', postEdit);

    this.get('#/close/:id', getClose);

    this.get('#/join/:id', getJoin);

});
app.run('#/home');