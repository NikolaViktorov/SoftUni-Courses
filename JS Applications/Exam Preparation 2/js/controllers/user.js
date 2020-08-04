import { showError, showInfo } from '../notification.js';
import { checkResult, register, login, logout as apiLogout } from '../data.js';

export async function registerPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/user/register.hbs');
}

export async function loginPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/user/login.hbs');
}

export async function logout() {
    try {
        await apiLogout();

        showInfo('Logout successful');

        this.app.userData.username = '';
        this.app.userData.userId = '';
        this.app.userData.names = '';

        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
}

export async function registerPost() {
    const { firstName, lastName, username, password, repeatPassword } = this.params;

    try {
        if (firstName.length < 2) {
            throw new Error('First name must be at least 2 characters long!');
        }
        if (lastName.length < 2) {
            throw new Error('Last name must be at least 2 characters long!');
        }
        if (username.length < 3) {
            throw new Error('Username must be at least 3 characters long!');
        }
        if (password.length < 6) {
            throw new Error('Password must be at least 6 characters long!');
        }
        if (password !== repeatPassword) {
            throw new Error('Passwords must match!');
        }

        const result = await register(firstName, lastName, username, password);

        checkResult(result);

        const loginResult = await login(username, password);

        checkResult(loginResult);

        this.app.userData.username = loginResult.username;
        this.app.userData.userId = loginResult.objectId;
        this.app.userData.names = `${loginResult.firstName} ${loginResult.lastName}`;

        showInfo('User registration successful');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
    
}

export async function loginPost() {
    const { username, password } = this.params;

    try {  
        const result = await login(username, password);

        checkResult(result);

        this.app.userData.username = result.username;
        this.app.userData.userId = result.objectId;
        this.app.userData.names = `${result.firstName} ${result.lastName}`;
 
        showInfo('Login successful');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
    
}

