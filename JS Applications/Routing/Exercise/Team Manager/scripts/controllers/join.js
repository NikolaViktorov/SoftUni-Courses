import { joinTeam } from '../data.js';

export default async function join() {
    
    const teamId = this.params.id;

    const user = {
        id: this.app.userData.userId,
        username: this.app.userData.username
    }

    try {
        const result = await joinTeam(teamId, user);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.hasTeam = true;
        this.app.userData.teamId = result.objectId;

        this.redirect('#/catalog');
    } catch (err) {
        console.error(err);
        alert(err.message);
    }
}