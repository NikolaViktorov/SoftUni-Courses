"use strict"

// 04. Rotate Array

function solve(params) {
    let rotations = Number(params.pop());
    if(rotations % params.length == 0) {
        rotations = rotations / (rotations / params.length);
    }
    
    for (let i = 0; i < rotations; i++) {
        params.unshift(params.pop());
    }

    console.log(params.join(' '));
}

solve(['1', 
'2', 
'3', 
'4', 
'2']);