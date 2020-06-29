"use strict"

// 07. Validity Checker

function solve([x1, y1, x2, y2]) {
    IsValid(x1, y1, 0, 0);
    IsValid(x2, y2, 0, 0);
    IsValid(x1, y1, x2, y2);


    function IsValid(x1, y1, x2, y2) {
        let distH = x1 - x2;
        let distY = y1 - y2;
        const result = Math.sqrt(distH ** 2 + distY ** 2);

        if (Number.isInteger(result)) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
        } else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
        }

        return ;
    }
}

solve([3, 0, 0, 4]);