import { beginReq, endReq } from './notification.js';
import API from './api.js'


const endpoints = {
    RECIPES: 'data/recipes',
    RECIPE: 'data/recipes/'
}

const api = new API(
    'B5065A50-310F-303A-FF14-A65AD8B53800',
    'A7C583A4-C8C4-4F3C-AF99-57591DC0090D',
    beginReq,
    endReq
)

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);


// get all recipes
export async function getAll() {
    return api.get(endpoints.RECIPES);
}

// create (share) recipe
export async function createRecipe(recipe) {
    return api.post(endpoints.RECIPES, recipe);
}

// get recipe by id 
export async function getRecipeById(id) {
    return api.get(endpoints.RECIPE + id);
}

// edit recipe by id
export async function editRecipe(id, recipe) {
    return api.put(endpoints.RECIPE + id, recipe);
}

// delete recipe by id
export async function deleteRecipe(id) {
    return api.delete(endpoints.RECIPE + id);
}

// like recipe by id
export async function likeRecipe(id) {
    // retrieve original object
    const recipe = await getRecipeById(id);
    // modify object
    return editRecipe(id, { likes: +recipe.likes + 1 })
}

export function checkResult(result) {
    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error
    }
}