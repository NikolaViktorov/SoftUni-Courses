"use strict"

// 05. Extract Increasing Subsequence from Array

function solve(arr) {

    let start = arr[0];
    console.log(start);
    for (let i = 1; i < arr.length; i++) {
        if(arr[i] >= start) {
            console.log(arr[i]);
            start = arr[i];
        }
    }
}

solve([20, 
    3, 
    2, 
    15,
    6, 
    1]);