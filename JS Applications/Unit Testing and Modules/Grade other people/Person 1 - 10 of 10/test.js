expect = require("chai").expect;
assert = require("chai").assert;

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};
class StringBuilder {
    constructor(string) {
      if (string !== undefined) {
        StringBuilder._vrfyParam(string);
        this._stringArray = Array.from(string);
      } else {
        this._stringArray = [];
      }
    }
  
    append(string) {
      StringBuilder._vrfyParam(string);
      for(let i = 0; i < string.length; i++) {
        this._stringArray.push(string[i]);
      }
    }
  
    prepend(string) {
      StringBuilder._vrfyParam(string);
      for(let i = string.length - 1; i >= 0; i--) {
        this._stringArray.unshift(string[i]);
      }
    }
  
    insertAt(string, startIndex) {
      StringBuilder._vrfyParam(string);
      this._stringArray.splice(startIndex, 0, ...string);
    }
  
    remove(startIndex, length) {
      this._stringArray.splice(startIndex, length);
    }
  
    static _vrfyParam(param) {
      if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }
  
    toString() {
      return this._stringArray.join('');
    }
}

class PaymentPackage {
    constructor(name, value) {
        this.name = name;
        this.value = value;
        this.VAT = 20;      // Default value    
        this.active = true; // Default value
    }

    get name() {
        return this._name;
    }

    set name(newValue) {
        if (typeof newValue !== 'string') {
        throw new Error('Name must be a non-empty string');
        }
        if (newValue.length === 0) {
        throw new Error('Name must be a non-empty string');
        }
        this._name = newValue;
    }

    get value() {
        return this._value;
    }

    set value(newValue) {
        if (typeof newValue !== 'number') {
        throw new Error('Value must be a non-negative number');
        }
        if (newValue < 0) {
        throw new Error('Value must be a non-negative number');
        }
        this._value = newValue;
    }

    get VAT() {
        return this._VAT;
    }

    set VAT(newValue) {
        if (typeof newValue !== 'number') {
        throw new Error('VAT must be a non-negative number');
        }
        if (newValue < 0) {
        throw new Error('VAT must be a non-negative number');
        }
        this._VAT = newValue;
    }

    get active() {
        return this._active;
    }

    set active(newValue) {
        if (typeof newValue !== 'boolean') {
        throw new Error('Active status must be a boolean');
        }
        this._active = newValue;
    }

    toString() {
        const output = [
        `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
        `- Value (excl. VAT): ${this.value}`,
        `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
        ];
        return output.join('\n');
    }
}
  

//UnitTests

describe ( "Test functions in Exercises Unit Testing" , function() {
    describe("Test isOddOrEven function", function (){ // 100 %
        it("should return undefined if arg is not a string", function (){
            const result = isOddOrEven(5);
            expect(result).to.equal(undefined);
        });
        it("should return even when arg is a string with even length", function (){
            const actual = isOddOrEven("brum");
            expect(actual).to.equal("even");
        });
        it("should return odd when arg is a string with odd length", function (){
            const actual = isOddOrEven("brumm");
            expect(actual).to.equal("odd");
        });
        it("should return undefined if arg is boolen", function (){
            const bool = true;
            const result = isOddOrEven(bool);
            assert.equal(result, undefined, "The function did not return the correct value!");
        });
    });
    describe("Test lookupChar function ", function (){ // 100 %
        it("should return undefined when first arg is not a string but a number", function (){
            const actual = lookupChar(5, 6);
            assert.equal(actual, undefined);
        });
        it("should return undefined when second arg is a floating num", function (){
            const actual = lookupChar("Pesho", 2.3);
            assert.equal(actual, undefined, "The function did not return the correct value!");
        });
        it("should return undefined when second arg is a string", function (){
            const actual = lookupChar("Pesho", "P");
            assert.equal(actual, undefined, "The function did not return the correct value!");
        });
        it("should return \"Incorrect Index\" when second arg is negative number", function (){
            const actual = lookupChar("Pesho", -1);
            assert.equal(actual, "Incorrect index", "The function did not return the correct value!");
        });
        it("should return \"Incorrect Index\" when second arg is equal to string.length", function (){
            const actual = lookupChar("Pesho", 5);
            assert.equal(actual, "Incorrect index", "The function did not return the correct value!");
        });
        it("should return \"Incorrect Index\" when second arg is bigger than string.length", function (){
            const actual = lookupChar("Pesho", 6);
            assert.equal(actual, "Incorrect index", "The function did not return the correct value!");
        });

        it("should return \"Incorrect Index\" when first arg is empty string", function (){
            const actual = lookupChar("", 0);
            assert.equal(actual, "Incorrect index", "The function did not return the correct value!");
        });

        it("should return correct char when args are of correct type and value", function (){
            const actual = lookupChar("Pesho", 0);
            assert.equal(actual, "P", "The function did not return the correct value!");
        });

    });
    describe("Test object mathEnforcer", function(){ // 100 %
        describe("Test addFive", function(){ // 100 %
            it("should return undefined when arg is not a number", function (){
                const actual = mathEnforcer.addFive("5");
                expect(actual).to.equal(undefined);
            });
            it("should return undefined when arg is not a number", function (){
                const actual = mathEnforcer.addFive({num: 6});
                expect(actual).to.equal(undefined);
            });
            it("should return 15 if arg is 10", function (){
                const actual = mathEnforcer.addFive(10);
                expect(actual).to.equal(15);
            });
            it("should return -5 if arg is -10", function (){
                const actual = mathEnforcer.addFive(-10);
                expect(actual).to.equal(-5);
            });
            it("should return 5 if arg is 0", function (){
                const actual = mathEnforcer.addFive(0);
                expect(actual).to.equal(5);
            });
        });
        describe("Test subtractTen", function(){ // 100 %
            it("should return undefined when arg is not a number", function (){
                const actual = mathEnforcer.subtractTen("5");
                expect(actual).to.equal(undefined);
            });
            it("should return undefined when arg is not a number", function (){
                const actual = mathEnforcer.subtractTen({num: 6});
                expect(actual).to.equal(undefined);
            });
            it("should return 0 if arg is 10", function (){
                const actual = mathEnforcer.subtractTen(10);
                expect(actual).to.equal(0);
            });
            it("should return -20 if arg is -10.99984", function (){
                const actual = mathEnforcer.subtractTen(-10.99984);
                expect(actual).closeTo(-20.99984, 0.01);
            });
            it("should return -10 if arg is 0", function (){
                const actual = mathEnforcer.subtractTen(0);
                expect(actual).to.equal(-10);
            });
        });
        describe("Test sum", function(){ // 100 %
            it("should return undefined when first arg is not a number", function (){
                const actual = mathEnforcer.sum("5", 0);
                expect(actual).to.equal(undefined);
            });
            it("should return undefined when second arg is not a number", function (){
                const actual = mathEnforcer.sum(5, {num: 6});
                expect(actual).to.equal(undefined);
            });
            it("should return correct sum if both args are numbers", function (){
                const actual = mathEnforcer.sum(10, 7.8);
                expect(actual).closeTo(+17.8, 0.01);
            });
            it("should return correct sum if first arg is 0 and second is negative number", function (){
                const actual = mathEnforcer.sum(0, -9.4210);
                expect(actual).closeTo(-9.4210, 0.01)
            });
        });
    })
    describe("Test Class StringBuilder", function(){ // 100 %
        describe("Test constructor", function(){ // 100 %
            it("should throw error if not instantiate with a string", function(){
                expect(() => new StringBuilder(()=> "P" + "z")).to.throw(TypeError, "Argument must be string");
            });
            
            it("should create property _stringArray equals [] if class instantiate with empty string", function(){
                const obj = new StringBuilder("");
                const actual = obj._stringArray;
                expect(obj).instanceOf(StringBuilder);
                expect(actual).instanceOf(Array);
                expect(actual.length).to.equal(0);
            });
            it("should create property _stringArray as array from string when arg is not undefined", function(){
                const obj = new StringBuilder("Brum");
                const actual = obj._stringArray;
                const expected = Array.from("Brum");
                expect(actual).to.eql(expected);
            });
        });
        describe("Test toString method", function() { // 100 %
            it("should throw error if not instantiate with a string", function(){
                expect(() => new StringBuilder(true)).to.throw(TypeError, "Argument must be string");
            });

            it("returns a string with all elements joined by an empty string", function (){
                const obj = new StringBuilder("hello");
                expect(obj._stringArray).to.eql(["h", "e", "l", "l", "o"]);
                expect(obj.toString()).to.eql("hello");
            });
        });
        describe("Test append method", function() { // 100 %

            it("should throw error if not instantiate with a string", function(){
                expect(() => new StringBuilder([3, 6, 7, 9])).to.throw(TypeError, "Argument must be string");
            });

            it("converts the passed in string argument to an array and adds it to the end of the storage", function (){
                const obj = new StringBuilder("hello");
                obj.append(', there');
                expect(obj._stringArray.length).to.equal(12);
                expect(obj.toString()).to.eql("hello, there");
            });
        });
        describe("Test prepend method", function() { // 100 %

            it("should throw error if not instantiate with a string", function(){
                expect(() => new StringBuilder({})).to.throw(TypeError, "Argument must be string");
            });

            it("converts the passed in string argument to an array and adds it to the beginning of the storage", function (){
                const obj = new StringBuilder("hello");
                obj.prepend(', there');
                expect(obj._stringArray.length).to.equal(12);
                expect(obj.toString()).to.eql(", therehello");
            });
        });
        describe("Test insertAt method", function() { // 100 %

            it("should throw error if not instantiate with a string", function(){
                expect(() => new StringBuilder(["Hello", "John"])).to.throw(TypeError, "Argument must be string");
            });

            it("converts the passed in string argument to an array and adds it at the given index", function (){
                const obj = new StringBuilder("hello");
                obj.append('! How are you?');
                obj.insertAt(", Tom", 5)
                expect(obj.toString()).to.eql("hello, Tom! How are you?");
            });
        });
        describe("Test remove method", function() { // 100 %

            it("should throw error if not instantiate with a string", function(){
                expect(() => new StringBuilder([])).to.throw(TypeError, "Argument must be string");
            });

            it("removes elements from the storage, starting at the given index (inclusive), length number of characters", function (){
                const obj = new StringBuilder("hello");
                obj.remove(0, 2);
                expect(obj.toString()).to.eql("llo");
            });
        });
    });
    describe("Test Class PaymentPackage", function (){ // 100 %
        describe("Test constructor", function () { // 100 %
            it("should create obj of instance PaymentPackage", function () {
                const obj = new PaymentPackage("HR Services", 2000);
                expect(obj).instanceof(PaymentPackage);
                expect(obj.name).to.eql("HR Services");
                expect(obj.value).to.eql(2000);
                expect(obj.VAT).to.eql(20);
                expect(obj.active).to.eql(true);

            });
            it("should throw error when instantiated with negative value", function (){
                expect(() => new PaymentPackage("HR Services", -2000)).to.throw(Error, "Value must be a non-negative number");
            });
            it("should throw error when instantiated with a string for value", function (){
                expect(() => new PaymentPackage("HR Services", "Not a number")).to.throw(Error, "Value must be a non-negative number");
            });
            it("should throw error when instantiated with empty string for name", function (){
                expect(() => new PaymentPackage("", 2000)).to.throw(Error, "Name must be a non-empty string");
            });
            it("should throw error when instantiated with obj for a name", function (){
                expect(() => new PaymentPackage({name: "HR Services"}, 2000)).to.throw(Error, "Name must be a non-empty string");
            });
            
            it("should throw error when VAT is set to negative number", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                expect(() => {obj.VAT = -10}).to.throw(Error, "VAT must be a non-negative number");
            });
            it("should throw error when 30 is deducted from initial value of VAT", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                expect(() => {obj.VAT -= 30}).to.throw(Error, "VAT must be a non-negative number");
            });
            it("should throw error when VAT is set to not a number", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                expect(() => {obj.VAT = "Not a number"}).to.throw(Error, "VAT must be a non-negative number");
            });
            it("should throw error when active is set to non-boolen", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                expect(() => {obj.active = "false"}).to.throw(Error, "Active status must be a boolean");
            });

        });
        describe("Test new attribute values when new valid values are provided", function () { // 100 %
            it("should change the name with new value when valid name provided", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                obj.name = "Pesho";
                expect(obj.name).to.eql("Pesho");
            });
            it("should change the value with new value when non-negative number is provided", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                obj.value = 3000;
                expect(obj.value).to.eql(3000);
            });
            it("should change the VAT with new value when non-negative number is provided", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                obj.VAT = 50;
                expect(obj.VAT).to.eql(50);
            });
            it("should change VAT value to zero when new value equals zero", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                obj.VAT = 0;
                expect(obj.VAT).to.eql(0);
            });
            it("should change active status to false when set to false", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                obj.active = false;
                expect(obj.active).to.eql(false);
            });
            it("should change active status back to active after being set to false and then to active", function (){
                const obj = new PaymentPackage("HR Services", 2000);
                obj.active = false;
                obj.active = true;
                expect(obj.active).to.eql(true);
            });
        });
        describe("Test toString method", function (){
            const obj = new PaymentPackage("HR Services", 1500);
            const actual = obj.toString();
            const expected = "Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800";
            expect(actual).to.eql(expected);
        })
    });
});

