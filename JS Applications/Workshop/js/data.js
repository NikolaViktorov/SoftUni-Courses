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

async function register(username, password) {
    return (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username,
            password
        })
    })).json();
}

async function login(username, password) {
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

    return result;
}

function logout() {
    const token = localStorage.getItem('userToken');

    return fetch(host(endpoints.LOGOUT), {
        headers: {
            'user-token': token
        }
    });
}

async function getAllMovies() {
    const token = localStorage.getItem('userToken');

    return (await fetch(host(endpoints.MOVIES), {
        headers: {
            'user-token': token
        }
    })).json();
}

async function getMovieById(id) {
    const token = localStorage.getItem('userToken');

    return (await fetch(host(endpoints.MOVIE + id), {
        headers: {
            'user-token': token
        }
    })).json();
}

async function updateMovie(id, updatedProps) {
    const token = localStorage.getItem('userToken');

    return (await fetch(host(endpoints.MOVIE + id), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(updatedProps)
    })).json();
}

async function createMovie(movie) {
    const token = localStorage.getItem('userToken');

    return (await fetch(host(endpoints.MOVIES), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(movie)
    })).json();
}

async function deleteMovie(id) {
    const token = localStorage.getItem('userToken');

    return (await fetch(host(endpoints.MOVIE + id), {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
    })).json();
}

async function getMoviesByUserId(userId) {
    const token = localStorage.getItem('userToken');
    
    return (await fetch(host(endpoints.MOVIES + `?where=ownerId%3D%27${userId}%27`), {
        headers: {
            'user-token': token
        }
    })).json();
}

async function buyTicket(movie) {
    const newTickets = movie.tickets - 1;
    // validation in front-end : check if less than 0
    const movieId = movie.objectId;

    return updateMovie(movieId, { tickets: newTickets});
}

