"use strict"

// 08. * Calorie Object

function solve(params) {
    const claorie = {};


    for(let i = 0; i < params.length; i += 2) {
        const propName = params[i];
        const value = Number(params[i + 1]);

        claorie[propName] = value;
    }

    console.log(claorie);
}

solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);