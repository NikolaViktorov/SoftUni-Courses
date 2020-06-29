"use strict"

// 03. Negative / Positive Numbers

function solve(arr) {
    arr.sort();

    for(let i = 0; i < arr.length; i++) {
        if(arr[i] === 0) {
            const swap = arr[arr.length - 1];
            arr[arr.length - 1] = 0;
            arr[i] = swap;
        }
    }

    console.log(arr);
}

solve([7, -2, 8, 9]);

solve([3, -2, 0, -1]);