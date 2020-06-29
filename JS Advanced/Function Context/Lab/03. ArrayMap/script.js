function arrayMap(arr, fn) {
    return arr.reduce((acc, curr) => {
        return acc.concat(fn(curr));
    }, []); 
};

let letters = ["a","b","c"];
console.log(arrayMap(letters,(l)=>l.toLocaleUpperCase())) // [ 'A', 'B', 'C' ]
