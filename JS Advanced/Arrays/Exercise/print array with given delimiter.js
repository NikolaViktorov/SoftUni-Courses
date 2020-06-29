"use strict"

// 01. Print Array with Given Delimiter


function solve(params) {
    const del = params.pop();

    console.log(params.join(del));
}

solve(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']);