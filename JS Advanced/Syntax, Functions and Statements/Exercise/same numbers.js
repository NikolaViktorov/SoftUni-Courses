"use strict"

// 03. Same Numbers

function solve(num) {
    const numText = num.toFixed(0);
    let same = true;
    let sum = 0;

    for(let i = 0;i < numText.length - 1;i++) {
        if(numText[i] !== numText[i + 1]) {
            same = false;
        }
        sum += Number(numText[i]);
    }
    sum += Number(numText[numText.length-1]);

    console.log(same);
    console.log(sum);
}

solve(22222);