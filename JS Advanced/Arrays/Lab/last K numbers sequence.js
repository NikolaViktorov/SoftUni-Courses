"use strict"

// 04. Last K Numbers Sequence

function solve(n, k) {
    const arr = Array(n).fill(0);
    arr[0] = 1;
    for(let i = 1; i < n; i++) {
        for(let j = 1; j <= k; j++) {
            arr[i] += arr[i - j] ? arr[i - j] : 0;
        }
        
    }

    console.log(arr.join(' '));
}

solve(6, 3);

solve(8, 2);