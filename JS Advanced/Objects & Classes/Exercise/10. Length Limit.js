class Stringer {
    constructor (string, length) {
        this.innerString = string;
        this.innerLength = length;
        this.curString = string;
        this.curLength = length;
    }

    decrease (length) {
        this.curLength = this.curLength - length < 0 ? 0 : this.curLength - length;
    }

    increase (length) {
        this.curLength += length;
    }

    toString () { // testa 3 - 5 = -2
        let diff = this.curLength - this.innerLength;
        let result = this.innerString;
        if (diff < 0 && result.length > this.curLength) {
            result = result.slice(0, result.length + diff + 1);
            
            result += '...';
        }

        return result;
    }
}


let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test