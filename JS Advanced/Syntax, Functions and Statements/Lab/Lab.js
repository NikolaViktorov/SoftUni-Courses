//'use strict'

// 01. String Length

function stringLength(a, b, c) {
    const sum = a.length + b.length + c.length;
    const average = Math.round(sum / 3);
    console.log(sum);
    console.log(average);
}

//stringLength('pasta', '5', '22.3');

// 02. Math Operations

function solve(num1, num2, op) {
    const calc = {
        '+': (a, b) => a + b,
        '-': (a, b) => a - b,
        '*': (a, b) => a * b,
        '/': (a, b) => a / b,
        '%': (a, b) => a % b,
        '**': (a, b) => a ** b,
    };

    console.log(calc[op](num1, num2));
};

//solve(3, 5.5, '*');

// 03. Sum of Numbers N…M

function sumOfNumbers(start, end) {
    start = Number(start);
    end = Number(end);
    let sum = 0;
    for(let i = start; i <= end; i++) {
        sum += i;
    }
    console.log(sum);
};

//sumOfNumbers('-8', '20');

// 04. Largest Number

function largetstNumber(...arguments){
    let max = Math.max(...arguments);
    console.log('The largest number is ' + max + '.');
};

//largetstNumber(5, -3, 16);

// 05. Circle Area

function circleArea(a) {
    let type = typeof(a);
    if(type === 'number') {
        let area = Math.PI * (a * a);
        console.log(area.toFixed(2));
    }
    else {
        console.log('We can not calculate the circle area, because we receive a ' + type + '.');
    }
}

//circleArea(5);

// 06. Square of Stars

function squareOfStars(a = 5) {
    const star = '* ';
    for(let i = 0; i < a;i++){
        console.log(star.repeat(a));
    }
}

//squareOfStars(8);

// 07. Day of Week

function dayOfWeek(day) {
    let nameOfDay = "error"
    switch(day) {
        case "Monday":
            nameOfDay = '1';
            break;
        case "Tuesday":
            nameOfDay = '2';
            break;
        case "Wednesday":
            nameOfDay = '3';
            break;
        case "Thursday":
            nameOfDay = '4';
            break;
        case "Friday":
            nameOfDay = '5';
            break;
        case "Saturday":
            nameOfDay = '6';
            break;
        case "Sunday":
            nameOfDay = '7';
            break;
    }
    console.log(nameOfDay);
}

//dayOfWeek('Friday')

// 08. Aggregate Elements

function aggregateEls (arguments) {
    let sum = 0;
    let invSum = 0;
    let concat = '';
    
    for(let values of arguments) {
        sum += values;
        invSum += 1 / values;
        concat += values;
    }
    
    console.log(sum);
    console.log(invSum);
    console.log(concat);
}

//aggregateEls([2, 4, 8, 16])

// 09. * Words Uppercase

function upperWords(text) {
    let result = text.toUpperCase()
      .match(/\w+/g)
      .join(', ');
    
    console.log(result);
  }

//upperWords('Hi, how are you?');
