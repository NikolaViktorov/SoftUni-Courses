"use strict"

// 07. Magic Matrices

function solve(matrix) {
    function sumRow(row) {
        return row.reduce((a, b) => a + b);

    }

    const transposedMatrix = matrix.map((col, i) => matrix.map(row => row[i]));

    const firstRowSum = sumRow(matrix[0]);
    let magickMatrix = true;

    for (let i = 0; i < matrix.length; i++) {
        if (sumRow(matrix[i]) !== firstRowSum || sumRow(transposedMatrix[i]) !== firstRowSum) {
            magickMatrix = false;
            break;
        }
    }

    console.log(magickMatrix)
}

solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]);

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]);

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]);