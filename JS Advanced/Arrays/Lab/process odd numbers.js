"use strict"

// 05. Process Odd Numbers

function solve(arr) {
    console.log(arr.filter((n, i) => i % 2 !== 0)
    .map(x => x * 2)
    .reverse()
    .join(' '));

}

solve([10, 15, 20, 25]);