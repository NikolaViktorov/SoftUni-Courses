import { logout as apiLogout} from '../data.js';
import { showInfo, showError } from '../notification.js';

export default async function logout() {
    const username = this.params.username;
    const password = this.params.password;

    try {
        const result = await apiLogout(username, password);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showInfo('Successfully logged out!');

        this.app.userData.username = '';
        this.app.userData.userId = '';

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}