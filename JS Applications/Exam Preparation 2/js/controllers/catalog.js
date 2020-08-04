import { getAll, createRecipe, checkResult, getRecipeById, editRecipe, likeRecipe, deleteRecipe as apiDelete } from '../data.js';
import { showInfo, showError } from '../notification.js';

export default async function home() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        catalog: await this.load('./templates/catalog/catalog.hbs'),
        recipe: await this.load('./templates/catalog/recipe.hbs')
    }

    const ctx = Object.assign({ }, this.app.userData);

    if (this.app.userData.username) {
        const recipes = await getAll();

        ctx.recipes = recipes;
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

export async function editPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    const recipe = await getRecipeById(this.params.id);

    recipe.ingredients = recipe.ingredients.join(', ');
    const ctx = Object.assign({recipe}, this.app.userData);

    await this.partial('./templates/catalog/edit.hbs', ctx);

    document.querySelectorAll('select[name=category]>option').forEach(o => {
        if (o.textContent === recipe.category) {
            o.selected = true;
        }
    });
}

export async function detailsPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }
    const id = this.params.id;

    const recipe = await getRecipeById(id);
    const ctx = Object.assign({recipe}, this.app.userData);

    if (recipe.ownerId === this.app.userData.userId) {
        recipe.canEdit = true;
    }

    await this.partial('./templates/catalog/details.hbs', ctx);
}

export async function like() {
    const id = this.params.id;
    
    try {
        const result = await likeRecipe(id);
        checkResult(result);

        showInfo('Recipe successfuly liked!');
        this.redirect(`#/details/${id}`);
    } catch (error) {
        showError(error.message);
    }
}

export async function deleteRecipe() {
    const id = this.params.id;
    
    try {
        const result = await apiDelete(id);
        checkResult(result);

        showInfo('Recipe successfuly deleted!');
        this.redirect(`#/home`);
    } catch (error) {
        showError(error.message);
    }
}

const categories = {
    'Vegetables and legumes/beans': 'https://cdn.pixabay.com/photo/2017/10/09/19/29/eat-2834549__340.jpg',
    'Fruits': 'https://cdn.pixabay.com/photo/2017/06/02/18/24/fruit-2367029__340.jpg',
    'Grain Food': 'https://snackymatz.com/wp-content/uploads/2017/03/corn-syrup-563796__340-300x200.jpg',
    'Milk, cheese, eggs and alternatives': 'https://image.shutterstock.com/image-photo/assorted-dairy-products-milk-yogurt-260nw-530162824.jpg',
    'Lean meats and poultry, fish and alternatives': 'https://t3.ftcdn.net/jpg/01/18/84/52/240_F_118845283_n9uWnb81tg8cG7Rf9y3McWT1DT1ZKTDx.jpg'
};

export async function createPost() {
    const { meal, ingredients, prepMethod, description, foodImageURL, category} = this.params;

    const recipe = {
        meal,
        ingredients: ingredients.split(', ').map(i => i.trim()),
        prepMethod,
        description,
        foodImageURL,
        category,
        categoryImageUrl: categories[category],
        likes: 0
    }

    try {
        if (recipe.meal.length < 4) {
            throw new Error('Meal name must be at least 4 characters long!');
        }
        if (recipe.ingredients.length < 2) {
            throw new Error('There must be at least 2 ingredients!');
        }
        if (recipe.prepMethod.length < 10) {
            throw new Error('Preperation method must be at least 10 characters long!');
        }
        if (recipe.description.length < 10) {
            throw new Error('Description must be at least 10 characters long!');
        }
        if (recipe.foodImageURL.slice(0, 7) !== 'http://' && recipe.foodImageURL.slice(0, 8) !== 'https://') {
            throw new Error('Invalid image url!');
        }
        if (recipe.category === 'Select category...') {
            throw new Error('Please select category from the list!');
        }

        const result = await createRecipe(recipe);
        checkResult(result);

        showInfo('Recipe successfuly shared!');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
}

export async function editPost() {
    const id = this.params.id;

    const recipe = await getRecipeById(id);

    recipe.meal = this.params.meal;
    recipe.ingredients = this.params.ingredients.split(', ').map(i => i.trim());
    recipe.prepMethod = this.params.prepMethod;
    recipe.description = this.params.description;
    recipe.foodImageUrl = this.params.foodImageURL;
    recipe.category = this.params.category;
    recipe.categoryImageUrl = categories[this.params.category];

    try {
        if (recipe.meal.length < 4) {
            throw new Error('Meal name must be at least 4 characters long!');
        }
        if (recipe.ingredients.length < 2) {
            throw new Error('There must be at least 2 ingredients!');
        }
        if (recipe.prepMethod.length < 10) {
            throw new Error('Preperation method must be at least 10 characters long!');
        }
        if (recipe.description.length < 10) {
            throw new Error('Description must be at least 10 characters long!');
        }
        if (recipe.foodImageUrl.slice(0, 7) !== 'http://' && recipe.foodImageUrl.slice(0, 8) !== 'https://') {
            throw new Error('Invalid image url!');
        }
        if (recipe.category === 'Select category...') {
            throw new Error('Please select category from the list!');
        }

        const result = await editRecipe(id, recipe);
        checkResult(result);

        showInfo('Recipe successfuly edited!');
        this.redirect('#/home');
    } catch (error) {
        showError(error.message);
    }
}