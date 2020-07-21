import { beginReq, endReq } from './notification.js';

function host(endpoint) {
    return `https://api.backendless.com/63DD5CB5-5F5F-39BE-FFA5-50183D493D00/32957967-D837-43B3-B973-B49E5F908EEB/${endpoint}`;
}

const endpoints = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    LOGOUT: 'users/logout',
    MOVIES: 'data/movies',
    MOVIE: 'data/movies/'
}

export async function register(username, password) {
    beginReq();
    const result = (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username,
            password
        })
    })).json();

    endReq();

    return result;
}

export async function login(username, password) {
    beginReq();
    const result = await (await fetch(host(endpoints.LOGIN), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            login: username,
            password
        })
    })).json();

    localStorage.setItem('userToken', result['user-token']);
    localStorage.setItem('username', result.username);
    localStorage.setItem('userId', result.objectId);

    endReq();

    return result;
}

export async function logout() {
    beginReq();
    const token = localStorage.getItem('userToken');

    localStorage.removeItem('userToken');
    localStorage.removeItem('userId'); // ME
    localStorage.removeItem('username'); // ME

    const result = fetch(host(endpoints.LOGOUT), {
        headers: {
            'user-token': token
        }
    });

    endReq();

    return result;
}

export async function getAllMovies(search) {
    beginReq();
    const token = localStorage.getItem('userToken');

    let result;

    if (search !== '') {
        result = (await fetch(host(endpoints.MOVIES + `?where=${escape(`genres LIKE '%${search}%'`)}`), {
            headers: {
                'user-token': token
            }
        })).json();
    } else {
        result = (await fetch(host(endpoints.MOVIES), {
            headers: {
                'user-token': token
            }
        })).json();
    }

    

    endReq();

    return result;
}

export async function getMovieById(id) {
    beginReq();
    const token = localStorage.getItem('userToken');

    const result = (await fetch(host(endpoints.MOVIE + id), {
        headers: {
            'user-token': token
        }
    })).json();

    endReq();

    return result;
}

export async function updateMovie(id, updatedProps) {
    beginReq();
    const token = localStorage.getItem('userToken');

    const result = (await fetch(host(endpoints.MOVIE + id), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(updatedProps)
    })).json();

    endReq();

    return result;
}

export async function createMovie(movie) {
    beginReq();
    const token = localStorage.getItem('userToken');

    const result = (await fetch(host(endpoints.MOVIES), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(movie)
    })).json();

    endReq();

    return result;
}

export async function deleteMovie(id) {
    beginReq();
    const token = localStorage.getItem('userToken');

    const result = (await fetch(host(endpoints.MOVIE + id), {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
    })).json();

    endReq();

    return result;
}

export async function getMoviesByUserId() {
    beginReq();
    const token = localStorage.getItem('userToken');
    const userId = localStorage.getItem('userId');
    
    const result = (await fetch(host(endpoints.MOVIES + `?where=ownerId%3D%27${userId}%27`), {
        headers: {
            'user-token': token
        }
    })).json();

    endReq();

    return result;
}

export async function buyTicket(movie) {
    const newTickets = movie.tickets - 1;
    // validation in front-end : check if less than 0
    const movieId = movie.objectId;

    return updateMovie(movieId, { tickets: newTickets});
}

