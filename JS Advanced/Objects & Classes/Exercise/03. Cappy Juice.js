"use strict"

function solve(input) {

    let juices = [];
    let bottles = [];
 
    for (let i = 0; i < input.length; i++) {
        let currentPair = input[i].split(' => ');
        let currentJuice = currentPair[0];
        let currentQuantity = Number(currentPair[1]);
 
        if(juices[currentJuice] != undefined){
 
            juices[currentJuice] += currentQuantity;
        }
        else{
            juices[currentJuice] = currentQuantity;
        }
 
        if(juices[currentJuice] >= 1000){
            if(bottles[currentJuice] != undefined){
                bottles[currentJuice] += currentQuantity;
            }
            else{
                bottles[currentJuice] = juices[currentJuice];
            }
        }
    }
 
    for (const bottle in bottles) {
        console.log(`${bottle} => ${Math.floor(bottles[bottle] / 1000)}`)
    }

}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']);