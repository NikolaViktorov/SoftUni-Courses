function host(endpoint) {
    return `https://api.backendless.com/EF20FEF0-4A3F-A1C7-FF2D-03D300226200/865189C8-0F3B-49DE-956B-5E92FB4A1A78/${endpoint}`;
}

const endpoints = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    TEAMS: 'data/teams',
    UPDATE_USER: 'users/',
    LOGOUT: 'users/logout'
}

export async function register(username, password) {
    return (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
             username: username,
             password: password
        })
    })).json();
}

export async function login(username, password) {
    return (await fetch(host(endpoints.LOGIN), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
             login: username,
             password: password
        })
    })).json();
}

async function setUserTeamId(userId, teamId) {
    const token = localStorage.getItem('userToken');
    if (!token) {
        throw new Error('User is not logged in!');
    }

    return (await fetch(host(endpoints.UPDATE_USER + userId), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify({
            teamId
        })
    })).json();
}

export async function createTeam(team) {
    const token = localStorage.getItem('userToken');
    
    if (!token) {
        throw new Error('User is not logged in!');
    }

    const result = await (await fetch(host(endpoints.TEAMS), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(team)
    })).json();

    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }

    const userUpdateResult = await setUserTeamId(result.ownerId, result.objectId);
    
    if (userUpdateResult.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, userUpdateResult);
        throw error;
    }

    return result;
}

export async function editTeam(team, teamId) {
    const token = localStorage.getItem('userToken');
    
    if (!token) {
        throw new Error('User is not logged in!');
    }

    const result = await (await fetch(host(endpoints.TEAMS + '/' + teamId), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(team)
    })).json();

    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }
}

export async function getTeamById(id) {
    return ( await fetch(host(endpoints.TEAMS + '/' + id))).json();
}

export async function getTeams() {
    return ( await fetch(host(endpoints.TEAMS))).json();
}

export async function logout() {
    const token = localStorage.getItem('userToken');
    
    if (!token) {
        throw new Error('User is not logged in!');
    }

    return fetch(host(endpoints.LOGOUT), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    });
}

export async function leaveTeam(username, userId) {
    const res = setUserTeamId(userId, '')

    const team = await getTeamByMemberName(username);
    
    team[0].members = team[0].members.replace(` ${username}`, '');
    team[0].ownerId = '';

    const result = await editTeam(team[0], team[0].objectId);

    return res;
}

async function getTeamByMemberName(name) {
    const result = await (await fetch(host(endpoints.TEAMS + `?where=${escape(`members LIKE '%${name}%'`)}`))).json();

    return result;
}

export async function joinTeam(teamId, user) {
    const result = await setUserTeamId(user.id, teamId);

    const team = await getTeamById(teamId);

    team.members = team.members !== null ? team.members += ' ' + user.username : team.members = ' ' + user.username;
    const editedTeam = await editTeam(team, teamId);

    return team;
}
