"use strict"

// 01. Fruit

function solve(fruit, weightGrams, price) {

    const weightKilos = weightGrams / 1000;

    const totalPrice = weightKilos * price;

    console.log('I need $'+ totalPrice.toFixed(2) +' to buy '+ weightKilos.toFixed(2) +' kilograms '+ fruit +'.');
}

solve('orange', 2500, 1.80)