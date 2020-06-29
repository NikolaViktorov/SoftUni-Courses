"use strict"

function solve(input) {
    let towns = input.map(t => t.split(" <-> "));   

    let result = {};

    for (let [town, pop] of towns) {
        if (result[town] === undefined) {
            result[town] = Number(pop);
        } else {
            result[town] += Number(pop);
        }
    }

    

}

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);