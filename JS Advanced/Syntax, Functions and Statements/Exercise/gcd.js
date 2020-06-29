"use strict"

// 02. Greatest Common Divisor – GCD

function solve(num1, num2) {
    const small = Math.min(num1, num2);
    let divider = 1;

    for(let i = 1;i <= small; i++) {
        if(num1 % i == 0 && num2 % i == 0 && i > divider) {
            divider = i;
        }
    }

    console.log(divider);
}

solve(2154, 458);