import commonPartials from './partials.js';
import { registerUser, login, logout } from '../../models/user.js'
import { saveUserInfo, setHeader } from './auth.js'
import notify from './notification.js';

export function getLogin(ctx) {
    setHeader(ctx);
    ctx.loadPartials(commonPartials).partial('./view/user/login.hbs');
}

export function getRegister(ctx) {
    setHeader(ctx);
    ctx.loadPartials(commonPartials).partial('./view/user/register.hbs');
}

export function getProfile(ctx) {
    setHeader(ctx);
    ctx.loadPartials(commonPartials).partial('./view/user/profile.hbs');
}

export function postRegister(ctx) {
    const username = ctx.params.username;
    const password = ctx.params.password;
    const repeatPassword = ctx.params.rePassword;
    
    if (password !== repeatPassword) {
        // error
        alert('Password should match!');
        return;
    }

    registerUser(username, password)
        .then(res => {
            saveUserInfo(res.user.email)
            ctx.redirect('#/home');
        })
        .catch(e => {
            console.error(e);
        });

}

export function postLogin(ctx) {
    const username = ctx.params.username;
    const password = ctx.params.password;

    login(username, password)
        .then(res => {
            saveUserInfo(res.user.email);
            notify('Successfully Logged In!', '#successBox');

            setTimeout(() => {
                ctx.redirect('#/home');
            }, 1000);
            
        })
        .catch(e => {
            notify('Error Logging In!', '#errorBox');
            console.error(e);
        });
}

export function getLogout(ctx) {
    logout()
        .then( () => {
            sessionStorage.clear();
            ctx.redirect('#/home');
        })
        .catch(e => {
            console.error(e);
        })
}