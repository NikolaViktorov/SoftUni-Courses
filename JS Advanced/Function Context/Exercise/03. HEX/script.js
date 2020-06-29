class Hex {
    constructor(value) {
        this.value = value;
    }

    static parse(string) {
        return Number(string.toString(10));
    };

    minus(hex) {
        return new Hex(this.value - hex);
    };

    plus(hex) {
        return new Hex(this.value + hex);
    };

    valueOf() {
        return this.value;
    };

    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    };
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
