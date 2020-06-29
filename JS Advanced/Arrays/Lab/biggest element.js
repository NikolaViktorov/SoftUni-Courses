"use strict"

// 07. Biggest Element

function solve(matrix) {
    let max = -Infinity;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[0].length; j++) {
            if(matrix[i][j] > max) max = matrix[i][j];
        }
    }

    console.log(max);
}

solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]);