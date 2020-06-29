function solution() {
    const apple = {protein: 0, carbohydrate: 1, fat: 0, flavour: 2};
    const lemonade = {protein: 0, carbohydrate: 10, fat: 0, flavour: 20};
    const burger = {protein: 0, carbohydrate: 5, fat: 7, flavour: 3};
    const eggs = {protein: 5, carbohydrate: 0, fat: 1, flavour: 1};
    const turkey = {protein: 10, carbohydrate: 10, fat: 10, flavour: 10};
    const availableIngredients = {protein: 0, carbohydrate: 0, fat: 0, flavour: 0};
    const receipts = {apple, lemonade, burger, eggs, turkey};

    return function cook() {

        if (arguments[0].indexOf('restock') >= 0) {
            return restock(arguments[0]);
        } else if (arguments[0].indexOf('prepare') >= 0) {
            return prepare(arguments[0]);
        } else if (arguments[0].indexOf('report') >= 0) {
            return report();
        }
        
        return cook;
    };


    function restock(command) {
        let [cmd, ingredient, qty] = command.split(' ');
        availableIngredients[ingredient] += +qty;

        return 'Success';
    }

    function prepare(command) {
        let [cmd, receipt, qty] = command.split(' ');
        qty = +qty;

        let neededProtein = receipts[receipt].protein * qty;
        let neededCarb = receipts[receipt].carbohydrate * qty;
        let neededFat = receipts[receipt].fat * qty;
        let neededFlavour = receipts[receipt].flavour * qty;

        if (neededProtein > availableIngredients.protein) {
            return `Error: not enough protein in stock`;
        } else if (neededCarb > availableIngredients.carbohydrate) {
            return `Error: not enough carbohydrate in stock`;
        } else if (neededFat > availableIngredients.fat) {
            return `Error: not enough fat in stock`;
        } else if (neededFlavour > availableIngredients.flavour) {
            return `Error: not enough flavour in stock`;
        } else {
            availableIngredients.protein -= neededProtein;
            availableIngredients.carbohydrate -= neededCarb;
            availableIngredients.fat -= neededFat;
            availableIngredients.flavour -= neededFlavour;

           return 'Success';
        }
    }

    function report() {
        return `protein=${availableIngredients.protein} carbohydrate=${availableIngredients.carbohydrate} fat=${availableIngredients.fat} flavour=${availableIngredients.flavour}`;
    }
}