"use strict"

// 05. Road Radar

function solve(args) {
    const speed = Number(args[0]);
    const area = args[1];

    const limits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    };

    let output = (speed, limit) => {
        if (speed > limit + 40) {
            console.log('reckless driving');
        } else if (speed > limit + 20) {
            console.log('excessive speeding');
        } else if (speed > limit) {
            console.log('speeding');
        }
    }

    output(speed, limits[area]);
}

solve([40, 'city']);