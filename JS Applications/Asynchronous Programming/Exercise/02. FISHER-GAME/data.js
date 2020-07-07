function host(endpoint) {
    return `https://fisher-game.firebaseio.com/${endpoint}.json`;
}

const api = {
    catches: 'catches'
};


export async function updateCatch(id, data) {
    fetch(host(api.catches + `/${id}`), {
        method: 'PUT',
        body: JSON.stringify(data)
    }).then(res => res.json())
      .then(data => {
          console.log('Success', data);
      })
      .catch(err => {
          console.error('Error', err);
      });
}

export async function getCatches() {
    const data = await ( await fetch(host(api.catches))).json();

    return data;
}

export async function deleteCatch(id) {
    fetch(host(api.catches + `/${id}`), {
        method: 'DELETE'
    }).then(res => res.json())
      .then(data => {
          console.log('Succes', data);
      })
      .catch(err => {
          console.error('Error', err);
      })
}

export async function addCatch(data) {
    fetch(host(api.catches), {
        method: 'POST',
        body: JSON.stringify(data)
    }).then(res => res.json())
      .then(data => {
          console.log('Success', data);
      })
      .catch(err => {
          console.error('Error', err);
      })
}