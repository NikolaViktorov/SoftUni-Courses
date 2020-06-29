"use strict"

function solve(input) {
    const result = [];

    for (let line of input) {
        let [name, level, items] = line.split(' / ');
        items = items ? items.split(', ') : [];

        result.push({name: name, level: Number(level), items: items});
    }

    console.log(JSON.stringify(result));
}


solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']);