"use strict"

// 06. Smallest Two Numbers

function solve(arr) {
    console.log(arr.sort((a, b) => {return a - b}).splice(0,2).join(' '));
}

solve([30, 15, 50, 5]);