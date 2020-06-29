"use strict"

function solve(params) {

    function checkWinner(arr) {
        if (arr[0][0] === arr[0][1] && arr[0][1] === arr[0][2] && arr[0][0] !== false) {
            return true;
        } else if (arr[1][0] === arr[1][1] && arr[1][1] === arr[1][2] && arr[1][0] !== false) {
            return true;
        } else if (arr[2][0] === arr[2][1] && arr[2][1] === arr[2][2] && arr[2][0] !== false) {
            return true;
        } else if (arr[0][0] === arr[1][0] && arr[1][0] === arr[2][0] && arr[0][0] != false) {
            return true;
        } else if (arr[0][1] === arr[1][1] && arr[1][1] === arr[2][1] && arr[0][1] !== false) {
            return true;
        } else if (arr[0][2] === arr[1][2] && arr[1][2] === arr[2][2] && arr[0][2] !== false) {
            return true;
        } else if (arr[0][0] === arr[1][1] &&  arr[1][1] === arr[2][2] && arr[0][0] !== false) {
            return true;
        } else if (arr[0][2] === arr[1][1] && arr[1][1] === arr[2][0] && arr[0][2] !== false) {
            return true;
        } 
        return false;
        
    }

    let players = ['X', 'O'];
    let player = 0;
    let winner = [false, ''];
    let tie = false;

    const t = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    params.forEach(e => {
        let row = e[0];
        let col = e[2];

        if (winner[0] === false && tie === false) {
            if (t[row][col] !== false) {
                console.log('This place is already taken. Please choose another!');
            } else {
                t[row][col] = players[player];
                if (player === 0) player++;
                else player--;
            }
            
        }
       
        
        if (checkWinner(t)) {
            if (player === 0) player++;
            else player--;
            winner = [true, players[player]];
        } else {
           t.forEach(element => {
               element.forEach(n => {
                if(n === false)
                {
                    tie = false;
                } else {
                    tie = true;
                }
               })
           });
        }
    });

    if (winner[0]) {
        console.log(`Player ${winner[1]} wins!`);
    } else {
        console.log('The game ended! Nobody wins :(');
    }
    for (let i = 0; i < 3; i++) {
        let cur = '';
        for (let j = 0; j < 3; j++) {
            cur += `${t[i][j]}\t`;
        }
        console.log(cur);
    }
}


solve(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]);