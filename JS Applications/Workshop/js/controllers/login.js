import { login as apiLogin} from '../data.js';
import { showInfo, showError } from '../notification.js';

export default async function login() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/user/loginForm.hbs')
    }
    this.partial('./templates/user/login.hbs', this.app.userData);
}

export async function loginPost() {
    const username = this.params.username;
    const password = this.params.password;

    try {
        const result = await apiLogin(username, password);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showInfo(`Successfully logged in as ${result.username}!`);

        this.app.userData.username = result.username;
        this.app.userData.userId = result.objectId;
        
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}