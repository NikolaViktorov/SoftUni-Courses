import { leaveTeam } from '../data.js';

export default async function leave() {
    const userId = this.app.userData.userId;
    const username = this.app.userData.username;

    try {
        const result = await leaveTeam(username, userId);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.hasTeam = false;
        this.app.userData.teamId = undefined;
        this.app.userData.isAuthor = false;
        this.redirect(`#/catalog`);
    } catch (err) {
        console.error(err);
        alert(err.message);
    }
}