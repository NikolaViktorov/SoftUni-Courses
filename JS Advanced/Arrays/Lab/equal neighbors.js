"use strict"

// 09. Equal Neighbors

function solve(matrix) {
    let equal = 0;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[0].length; j++) {
            if (matrix[i][j] === matrix[i][j + 1]) equal++;
            if (i + 1 < matrix.length) {
                if (matrix[i][j] === matrix[i + 1][j]) equal++;
            }
        }
    }

    console.log(equal);
    //console.table(matrix);
}

solve([['2', '4', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '5']])