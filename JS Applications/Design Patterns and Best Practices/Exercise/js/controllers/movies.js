import { showInfo, showError } from '../notification.js';
import { createMovie, getAllMovies, buyTicket as apiBuyTicket, getMovieById, getMoviesByUserId, updateMovie, deleteMovie as apiDelete } from '../data.js';

export default async function catalog() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        movie: await this.load('./templates/movie/movie.hbs')
    }; 

    const search = this.params.search || '';

    const movies = await getAllMovies(search);
    this.app.userData.movies = movies;
    const context = Object.assign({ origin: encodeURIComponent('#/catalog'), search}, this.app.userData);

    this.partial('./templates/movie/catalog.hbs', context);
}

export async function myMovies() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        movie: await this.load('./templates/movie/movie.hbs'),
        ownMovie: await this.load('./templates/movie/ownMovie.hbs')
    }; 

    const movies = await getMoviesByUserId();
    this.app.userData.movies = movies;

    const context = Object.assign({ myMovies: true, origin: encodeURIComponent('#/my_movies')}, this.app.userData);

    this.partial('./templates/movie/catalog.hbs', context);
}

export async function create() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }
    this.partial('./templates/movie/createForm.hbs', this.app.userData);
}

export async function createPost() {
    try {
        if (this.params.title.length === 0) {
            throw new Error('Title is required!');
        }

        const tickets = Number(this.params.tickets);

        const movie = {
            title: this.params.title,
            image: this.params.imageUrl,
            description: this.params.description,
            genres: this.params.genres,
            tickets: tickets
        }

        const result = await createMovie(movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showInfo('Movie Created!');

        this.redirect('#/details/' + result.objectId);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function details() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }
    const movieId = this.params.id;
    let movie = this.app.userData.movies.find(m => m.objectId == movieId);

    if (movie === undefined) {
        movie = await getMovieById(movieId);
    }

    const context = Object.assign({ movie, origin: encodeURIComponent('#/details/' + movieId) }, this.app.userData);

    this.partial('./templates/movie/details.hbs', context);
}

export async function edit() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }
    const movieId = this.params.id;

    let movie = this.app.userData.movies.find(m => m.objectId == movieId);
    if (movie === undefined) {
        movie = await getMovieById(movieId);
    }

    const context = Object.assign( { movie }, this.app.userData);

    this.partial('./templates/movie/editForm.hbs', context);
}

export async function editPost() {
    const movieId = this.params.id;

    try {
        if (this.params.title.length === 0) {
            throw new Error('Title is required!');
        }

        const tickets = Number(this.params.tickets);

        const movie = {
            title: this.params.title,
            image: this.params.imageUrl,
            description: this.params.description,
            genres: this.params.genres,
            tickets: tickets
        }

        const result = await updateMovie(movieId, movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        for (let i = 0; i < this.app.userData.movies.length; i++) {
            if (this.app.userData.movies[i].objectId == movieId) {
                this.app.userData.movies.splice(i, 1, result);
                break;
            }
        }

        showInfo('Movie Edited!');

        this.redirect('#/details/' + result.objectId);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function buyTicket() {
    const movieId = this.params.id;

    let movie = this.app.userData.movies.find(m => m.objectId == movieId);
    if (movie === undefined) {
        movie = await getMovieById(movieId);
    }

    try {
        const result = await apiBuyTicket(movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showInfo(`Successfully bought ticket for ${movie.title}!`);

        this.redirect(this.params.origin);  
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function deleteMovie() {
    if (confirm('Are you sure you want to delete this movie?') === false) {
        return this.redirect('#/my_movies');
    }

    const movieId = this.params.id;

    try {
        const result = await apiDelete(movieId);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showInfo(`Successfully deleted movie!`);

        this.redirect('#/my_movies');  
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}