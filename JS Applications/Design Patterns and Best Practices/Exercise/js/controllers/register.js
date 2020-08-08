import { register as apiRegister } from '../data.js';
import { showInfo, showError } from '../notification.js';

export default async function register() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('./templates/user/registerForm.hbs')
    }
    this.partial('./templates/user/register.hbs', this.app.userData);
}

export async function registerPost() {
    const username = this.params.username;
    const password = this.params.password;
    const repeatedPassword = this.params.repeatPassword;
    try {
        if (password !== repeatedPassword) {
            throw new Error('Passwords do not match!');
        }

        if (username.length < 3) {
            throw new Error('Username must be at least 3 letters long!')
        }

        if (password.length < 6) {
            throw new Error('Password must be at least 6 characters long!')
        }

        const result = await apiRegister(username, password);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }
        showInfo('Successfully registered!');
        this.redirect('#/login');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }

    
}