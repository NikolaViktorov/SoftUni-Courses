"use strict"

// 03. Add and Remove Elements

function solve(cmds) {
    const numbers = [];
    let numberToAdd = 1;
    let i = 0;

    for (let cmd of cmds) {
        if (cmd === 'add') {
            numbers[i] = numberToAdd;
            i++;
            numberToAdd++;
        } else {
            let l = numbers.pop();
            if (l !== undefined) {
                i--;
            }
            numberToAdd++;
        }
    }
    if (numbers.length === 0) {
        console.log('Empty');
    } else {
        numbers.forEach(n => {
            console.log(n);
        });
    }
}


solve(['remove', 
'remove', 
'remove']);