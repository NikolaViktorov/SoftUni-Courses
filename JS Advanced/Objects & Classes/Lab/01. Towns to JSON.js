"use strict"

function solve(string) {

    let towns = [];

    let i = 0;
    for (let town of string) {
        if (i > 0) {
            let cur = town.split("|").toString().toString().split(",").filter(Boolean);
            towns[i - 1] = {
                Town: cur[0],
                Latitude: (Number(cur[1])),
                Longitude: Number(cur[2])
            };
            i++;
        } else {
            i++;
        }
    }
    console.log(JSON.stringify(towns, null, null))
}


solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);