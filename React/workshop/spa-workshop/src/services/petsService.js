export const getAll = (category = '') => {
    let str = category[0];
    if (category) {
        category = str.toUpperCase() + category.slice(1, category.length);
        category[category.length - 1] == 's' ? category = category.slice(0, category.length - 1) : category = category;
    } 

    let url = 'http://localhost:3000/pets';
    
    url += (category && category != 'All' )
    ? `?category=${category}` 
    : ''; 

    return fetch(url)
        .then(res => res.json())
        .catch(err => console.log(err));
}

export const getOne = (petId) => {
    let url = `http://localhost:3000/pets/${petId}`;
    
    return fetch(url)
        .then(res => res.json())
        .catch(err => console.log(err));
}