import { showInfo, showError } from "../notification.js";
import { createMovie, checkResult, getAll, getMovieById, editMovie, deleteMovie as apiDelete, likeMovie } from '../data.js';

export default async function home() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        catalog: await this.load('./templates/catalog/catalog.hbs'),
        movie: await this.load('./templates/catalog/movie.hbs')
    }

    const ctx = Object.assign({ }, this.app.userData);
    
    if (this.app.userData.email) {
        const search = this.params.search || '';
    
        const movies = await getAll(search);
        
        ctx.movies = movies;
        ctx.search = search;
    }

    this.partial('./templates/home/home.hbs', ctx);
}

export async function createPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/catalog/create.hbs', this.app.userData);
}

export async function detailsPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    const id = this.params.id;

    const movie = await getMovieById(id);

    if (movie.likedBy) {
        const likedIds = movie.likedBy.split(', ');
    
        if (likedIds.includes(this.app.userData.userId)) {
            movie.liked = true;
        }
    }

    if (movie.ownerId === this.app.userData.userId) {
        movie.isOwner = true;
    }

    const ctx = Object.assign({ movie }, this.app.userData);


    this.partial('./templates/catalog/details.hbs', ctx);
}

export async function editPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    const id = this.params.id;

    const movie = await getMovieById(id);

    const ctx = Object.assign({ movie }, this.app.userData);

    this.partial('./templates/catalog/edit.hbs', ctx);
}

export async function like() {
    const id = this.params.id;

    try {
        const result = await likeMovie(id, this.app.userData.userId);

        checkResult(result);

        showInfo('Liked successfully');
        this.redirect(`#/details/${id}`);
    } catch (error) {
        showError(error.message);
    }
}

export async function deleteMovie() {
    const id = this.params.id;

    try {
        const result = await apiDelete(id);

        checkResult(result);    

        showInfo('Deleted successfully');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
}

export async function editPost() {
    const id = this.params.id;

    const { title, description, imageUrl } = this.params;

    const movie = {
        title,
        description,
        imageUrl
    }

    try {
        if (title.length === 0) {
            throw new Error('Invalid inputs!');
        }
        if (description.length === 0) {
            throw new Error('Invalid inputs!');
        }
        if (imageUrl.length === 0) {
            throw new Error('Invalid inputs!');
        }
        
        const result = await editMovie(id, movie);

        checkResult(result);

        showInfo('Eddited successfully!');
        this.redirect(`#/details/${result.objectId}`);
    } catch (error) {
        showError(error.message);
    }
}

export async function createPost() {
    const { title, description, imageUrl } = this.params;

    const movie = {
        title,
        description,
        imageUrl,
        creator: this.app.userData.email,
        likes: 0
    }

    try {
        if (title.length === 0) {
            throw new Error('Invalid inputs!');
        }
        if (description.length === 0) {
            throw new Error('Invalid inputs!');
        }
        if (imageUrl.length === 0) {
            throw new Error('Invalid inputs!');
        }

        const result = await createMovie(movie);

        checkResult(result);

        showInfo('Created successfully!');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
}