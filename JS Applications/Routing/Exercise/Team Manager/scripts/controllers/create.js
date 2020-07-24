import { createTeam } from '../data.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/create/createForm.hbs')
    }

    this.partial('./templates/create/createPage.hbs');
}

export async function createPost() {
    const newTeam = {
        name: this.params.name,
        comment: this.params.comment,
        members: this.app.userData.username
    };

    if (Object.values(newTeam).some(v => v.length === 0)) {
        alert('All fields are required!');
        return;
    }

    try {
        const result = await createTeam(newTeam);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.hasTeam = true;
        this.app.userData.teamId = result.objectId;
        this.redirect(`#/catalog/${result.objectId}`);
    } catch (err) {
        console.error(err);
        alert(err.message);
    }

}