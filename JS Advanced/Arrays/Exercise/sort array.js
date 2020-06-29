"use strict"

// 06. Sort Array

function solve(arr) {
    arr = arr.sort(function (l, a) {
        if (l.length < a.length) return -1;
        if (l.length > a.length) return 1;
        else if (l < a) return -1;
    });

    arr.forEach(element => {
        console.log(element);
    });
}

solve(['test', 
'Deny', 
'omen', 
'Default']);