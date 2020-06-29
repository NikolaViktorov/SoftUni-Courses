const lib = require('./app');
const expect = require('chai').expect;

describe('Lesson tests', function() {
    describe('Sum test', function() {
        it('should return the sum', function() {
            const arg = [1, 2, 3, 4];
            const expected = 10;
            const result = lib.sum(arg);
            expect(result).to.eq(expected);
        });
    });
    
    describe('Check for symmetry', function() {
        it('should return false for any input that isn’t of the correct type', function () {
            const arg = 123;
            const result = lib.isSymmetric(arg);
            expect(result).to.be.false;
        })

        it('should return true if the input array is symmetric', function() {
            const arg = [1, 2, 3, 2, 1];
            const result = lib.isSymmetric(arg);
            expect(result).to.be.true;
        })

        it('should return false if the input array is not symmetric', function() {
            const arg = [1, 2, 3];
            const result = lib.isSymmetric(arg);
            expect(result).to.be.false;
        })
    });

    describe('RGB to hex', function() {
        it('should return undefined if first arg is not an int', function() {
            const input = ['afw', 200, 200];
            const result = lib.rgbToHexColor(...input);
            expect(result).to.be.undefined;
        });
        it('should return undefined if second arg is not an int', function() {
            const input = [200, 'efwa', 200];
            const result = lib.rgbToHexColor(...input);
            expect(result).to.be.undefined;
        });
        it('should return undefined if third arg is not an int', function() {
            const input = [200, 200, 'fa'];
            const result = lib.rgbToHexColor(...input);
            expect(result).to.be.undefined;
        });        
        it('should return the same color in hexadecimal format as a string', function () {
            const input = [66, 135, 245];
            const expected = '#4287F5';
            const result = lib.rgbToHexColor(...input);
            expect(result).to.eq(expected);
        })
    });
    
    describe('Calculator', function() {
        it('should return a module (object), containing the functions add(), subtract() and get() as properties', function() {
            const result = lib.createCalculator();
            expect(result).to.exist;
        });
        it('should return correct value after adding numbers', function () {
            const numbers = [5, 7];
            const expected = numbers.reduce((acc, curr) => acc + +curr, 0);

            const result = lib.createCalculator();
            result.add(numbers[0]);
            result.add(numbers[1]);

            expect(result.get()).to.eq(expected);
        });
        it('should return correct value after substracting numbers', function () {
            const numbers = [5, 7];
            const expected = numbers.reduce((acc, curr) => acc - +curr, 0);

            const result = lib.createCalculator();
            result.subtract(numbers[0]);
            result.subtract(numbers[1]);

            expect(result.get()).to.eq(expected);
        });
    })
});

