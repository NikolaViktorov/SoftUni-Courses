import { register, checkResult, login, logout as apiLogout } from '../data.js'; 
import { showInfo, showError } from '../notification.js';

export async function registerPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/user/register.hbs', this.app.userData);
}

export async function loginPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }


    this.partial('./templates/user/login.hbs', this.app.userData);
}

export async function logout() {


    try {
        await apiLogout();
        
        this.app.userData.email = '';
        this.app.userData.userId = '';
        
        showInfo('Successful logout');
        this.redirect('#/login');
    } catch (error) {
        showError(error.message);
    }
}

export async function loginPost() {
    const { email, password } = this.params;
    console.log(this.params);

    try {
        const result = await login(email, password);

        checkResult(result);

        this.app.userData.email = result.email;
        this.app.userData.userId = result.objectId;

        showInfo('Login successful.');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
}

export async function registerPost() {
    const { email, password, repeatPassword } = this.params;

    try {
        if (email.length <= 0) {
            throw new Error('Enter Email!');
        }
        if (password.length < 6) {
            throw new Error('Password should be at least 6 characters long!');
        }
        if (password !== repeatPassword) {
            throw new Error('Passwords do not match!');
        }

        const result = await register(email, password);

        checkResult(result);
        
        const loginResult = await login(email, password);
        
        checkResult(loginResult);
        
        this.app.userData.email = result.email;
        this.app.userData.userId = result.objectId;
        
        showInfo('Successful registration!');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
}
