import API from './api.js'


const endpoints = {
    MOVIES: 'data/movies',
    MOVIE: 'data/movies/'
}

const api = new API(
    'E05103BB-2B1A-BE74-FFA8-A48053007600',
    '67931369-67FF-4473-805D-C71CAF59BB74'
)

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);


// get all Movies
export async function getAll(search) {
    if (search !== '') {
        return api.get(endpoints.MOVIES + `?where=${escape(`title LIKE '%${search}%'`)}`);
    } else {
        return api.get(endpoints.MOVIES);
    }
}

// create (share) Movie
export async function createMovie(Movie) {
    return api.post(endpoints.MOVIES, Movie);
}

// get Movie by id 
export async function getMovieById(id) {
    return api.get(endpoints.MOVIE + id);
}

// edit Movie by id
export async function editMovie(id, Movie) {
    return api.put(endpoints.MOVIE + id, Movie);
}

// delete Movie by id
export async function deleteMovie(id) {
    return api.delete(endpoints.MOVIE + id);
}

// like Movie by id
export async function likeMovie(id, userId) {
    // retrieve original object
    const movie = await getMovieById(id);
    // modify object
    let likedByT = userId;
    if (movie.likedBy) {
        likedByT = movie.likedBy + ', ' + userId;
    } else {
        likedByT = userId;
    }
    const newMovie = { 
        likedBy: likedByT,
        likes: +movie.likes + 1
     }

    return editMovie(id, newMovie);
}

export function checkResult(result) {
    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error
    }
}