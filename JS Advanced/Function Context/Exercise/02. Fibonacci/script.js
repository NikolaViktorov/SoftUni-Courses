function getFibonator() {
    let prev = 0;
    let cur = 1;
    let a = 0;

    return () =>  {
        if (a === 0) return a = 1;
        let num = prev + cur;
        prev = cur;
        cur = num;

        return num;
    };
};

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
