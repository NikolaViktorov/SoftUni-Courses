"use strict"

function solve(input) {
    let result = "<table>\n";
    let items = JSON.parse(input);

    let keys = Object.keys(items[0]);
    
    result += "    <tr>";
    keys.forEach(element => {
        result += `<th>${element}</th>`;
    });
    result += "</tr>\n";


    items.reduce(function(acc, cur) {
        result += acc;
        keys.forEach(k => {
            result += `<td>${cur[k]}</td>`;
        });
        result += acc === '    <tr>' ? '</tr>\n' : '    <tr>'
        return acc;
    }, '    <tr>');   

     result += "</table>";
     return result;
}


solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']);