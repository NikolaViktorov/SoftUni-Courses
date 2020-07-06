const lib = require('./app');
const expect = require('chai').expect;

describe('Exercise tests', function() {
    describe('Odd or Even tests', function() {
        it('should return undefined if passed argument other than string', function() {
            const argument = 123123;
            const result = lib.isOddOrEven(argument);
            expect(result).to.be.undefined;
        })
        it('should return even if passed string length is even', function() {
            const argument = '2323';
            const expectedResult = 'even';
            const result = lib.isOddOrEven(argument);
            expect(result).to.be.eq(expectedResult);
        })
        it('should return odd if passed string length is odd', function() {
            const argument = '123';
            const expectedResult = 'odd';
            const result = lib.isOddOrEven(argument);
            expect(result).to.be.eq(expectedResult);
        })
    })
    describe('Look up chairs tests', function() {
        it('should return undefined if first argument is not a string', function() {
            const result = lib.lookupChar(123, 123);
            expect(result).to.be.undefined;
        })
        it('should return undefined if second argument is not a number', function() {
            const result = lib.lookupChar('string', 'not number');
            expect(result).to.be.undefined;
        })
        it('should return undefined if second argument is a negative number', function() {
            const result = lib.lookupChar('some', -1);
            expect(result).to.be.eq('Incorrect index');
        })
        it('should return undefined if second argument is number bigger than first arg length', function() {
            const result = lib.lookupChar('some', 10);
            expect(result).to.be.eq('Incorrect index');
        })
        it('should return the character at the given index', function() {
            const result = lib.lookupChar('some', 1);
            expect(result).to.be.eq('o');
        })
    })
    describe('Math Enforcer tests', function() {
        describe('addFive', function() {
            it('should return correct result with a non-number argument', function() {
                const result = lib.mathEnforcer.addFive('string');
                expect(result).to.be.undefined;
            })
            it('should return correct result with a number argument', function() {
                const result = lib.mathEnforcer.addFive(10);
                expect(result).to.be.eq(15);
            })
        })
        describe('subtractTen', function() {
            it('should return correct result with a non-number argument', function() {
                const result = lib.mathEnforcer.subtractTen('string');
                expect(result).to.be.undefined;
            })
            it('should return correct result with a number argument', function() {
                const result = lib.mathEnforcer.subtractTen(10);
                expect(result).to.be.eq(0);
            })
        })
        describe('sum', function() {
            it('should return correct result with a non-number first argument', function() {
                const result = lib.mathEnforcer.sum('string', 10);
                expect(result).to.be.undefined;
            })
            it('should return correct result with a non-number second argument', function() {
                const result = lib.mathEnforcer.sum(10, 'string');
                expect(result).to.be.undefined;
            })
            it('should return correct result with a number argument', function() {
                const result = lib.mathEnforcer.sum(10, 10);
                expect(result).to.be.eq(20);
            })
        })
    })
    describe('String builder tests', function() {
        it('should throw error if a number is passed in constructor', function() {
            function createSB() {
                const strB = lib.StringBuilder;
                const builder = new strB(20);
            }

            expect(createSB).to.throw(TypeError);
        }),
        it('should return a string correctly', function() {
            const input = 'some text';

            const strB = lib.StringBuilder;
            const builder = new strB(input);

            const output = builder.toString();
            expect(output).to.be.eq(input);
        }),
        it('should append text correctly', function() {
            const input = 'some text';
            const appendText = 'some'
            const expected = input + appendText;

            const strB = lib.StringBuilder;
            const builder = new strB(input);

            builder.append(appendText);

            expect(builder.toString()).to.eq(expected);
        }),
        it('should prepend text correctly', function() {
            const input = 'some text';
            const prependText = 'some'
            const expected = prependText + input;

            const strB = lib.StringBuilder;
            const builder = new strB(input);

            builder.prepend(prependText);

            expect(builder.toString()).to.be.eq(expected);
        }),
        it('should insert text correctly', function() {
            const input = 'hex';
            const text = 'a'
            const expected = input + text;

            const strB = lib.StringBuilder;
            const builder = new strB(input);

            builder.insertAt(text, 3);

            expect(builder.toString()).to.be.eq(expected);
        }),
        it('should remove text correctly', function() {
            const input = 'hello';
            const expected = 'he';

            const strB = lib.StringBuilder;
            const builder = new strB(input);

            builder.remove(2, 3);

            expect(builder.toString()).to.be.eq(expected);
        })
    })
    describe('PaymentPackage tests', function() {
        it('should return name correctly', function() {
            const pp = lib.PaymentPackage;
            const paypac = new pp('some', 20);

            expect(paypac.name).to.be.eq('some');
        }),
        it('should return value correctly', function() {
            const pp = lib.PaymentPackage;
            const paypac = new pp('some', 20);

            expect(paypac.value).to.be.eq(20);
        }),
        it('should return VAT correctly', function() {
            const pp = lib.PaymentPackage;
            const paypac = new pp('some', 30);

            expect(paypac.VAT).to.be.eq(20); // default value for VAT
        }),
        it('should return active correctly', function() {
            const pp = lib.PaymentPackage;
            const paypac = new pp('some', 20);

            expect(paypac.active).to.be.true; // default value for active
        }),
        it('should throw error if name length is 0', function() {
            function createPp() {
                const pp = lib.PaymentPackage;
                const a = new pp('', 20);
            }

            expect(createPp).to.throw(Error); // default value for
        }),
        it('should throw error if value is less than 0', function() {
            function createPp() {
                const pp = lib.PaymentPackage;
                const a = new pp('some', -1);
            }

            expect(createPp).to.throw(Error); // default value for
        }),
        it('should throw error if active is not boolean', function() {
            function createPp() {
                const pp = lib.PaymentPackage;
                const a = new pp('some', 20);
                a.active = 23;
            }

            expect(createPp).to.throw(Error); // default value for
        }),
        it('should throw error if VAT is less than 0', function() {
            function createPp() {
                const pp = lib.PaymentPackage;
                const a = new pp('some', 20);
                a.VAT = -2;
            }

            expect(createPp).to.throw(Error); // default value for
        }),
        it('should return correct string when toString func is called', function() {
            const name = 'Hax';
            const value = 32;

            const pp = lib.PaymentPackage;
            const paypac = new pp(name, value);

            const expected = `Package: ${name}\n- Value (excl. VAT): ${value}\n- Value (VAT 20%): ${value * (1 + 20 / 100)}`;
            const result = paypac.toString();

            expect(result).to.be.eq(expected);
        })
    })
});

