"use strict"

// 02. Print every N-th Element from an Array

function solve(params) {
    let step = params.pop();

    params = params.filter((x, i) => i % step == 0);
    params.forEach(element => {
        console.log(element);
    });
}

solve(['5', 
'20', 
'31', 
'4', 
'20', 
'2']);