let emp = {};

Object.defineProperty(emp, 'id', {
    configurable : false,
    enumerable : true,
    value : 5100
});

console.log(emp);