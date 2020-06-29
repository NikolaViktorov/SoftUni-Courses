"use strict"

// 02. Even Position Elements

function solve (arr) {
    console.log(arr.filter((n, i) => i % 2 == 0).join(' '));
}


solve(['20', '30', '40']);