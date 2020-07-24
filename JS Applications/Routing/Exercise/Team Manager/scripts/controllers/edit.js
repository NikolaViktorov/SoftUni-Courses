import { editTeam }  from '../data.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs')
    }

    this.partial('./templates/edit/editPage.hbs', this.app.userData);
}


export async function editPost() {
    const editedTeam = {
        name: this.params.name,
        comment: this.params.comment
    };

    const teamId = this.params.id;

    if (Object.values(editedTeam).some(v => v.length === 0)) {
        alert('All fields are required!');
        return;
    }

    const result = await editTeam(editedTeam, teamId);
    this.redirect(`#/catalog`);
}