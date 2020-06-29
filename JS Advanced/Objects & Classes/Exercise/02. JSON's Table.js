"use strict"

function solve (input) {
    let people = [];

    for (let line of input) {
        const person = JSON.parse(line);
        people.push(person);
    }

    let result = '<table>\n';

    for (let person of people) {
        result += '    <tr>\n';
        result += `        <td>${person.name}</td>\n`
        result += `        <td>${person.position}</td>\n`
        result += `        <td>${person.salary}</td>\n`
        result += '    </tr>\n';
    }

    result += '</table>';

    console.log(result);

}


solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']);