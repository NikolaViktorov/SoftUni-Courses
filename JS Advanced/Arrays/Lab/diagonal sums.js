"use strict"

// 08. Diagonal Sums

function solve(matrix) {
    let leftSum = 0;
    let rightSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[0].length; j++) {
            if (i === j) leftSum += matrix[i][j];
            if (i + j === matrix[0].length - 1) rightSum += matrix[i][j];
        }
    }

    console.log(leftSum + ' ' + rightSum);
}


solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]);