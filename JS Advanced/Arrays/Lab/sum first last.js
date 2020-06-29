"use strict"

// 01. Sum First Last

function solve(params) {
    const first = Number(params[0]);
    const last = Number(params[params.length - 1]);

    const sum = first + last;

    console.log(sum);
}


solve(['20', '30', '40']);