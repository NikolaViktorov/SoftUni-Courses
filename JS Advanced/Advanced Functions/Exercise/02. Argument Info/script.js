function solve() {
    const args = {};

    for(let arg of arguments) {
        let type = typeof arg;
        console.log(`${type}: ${arg}`);
        if (args[type] === undefined) {
            args[type] = 1;
        } else {
            args[type]++;
        }
    }

    Object.entries(args).sort((a, b) => b[1] - a[1]).forEach(e => {
        console.log(`${e[0]} = ${e[1]}`);
    });
}

solve('cat', 42, function () { console.log('Hello world!'); });