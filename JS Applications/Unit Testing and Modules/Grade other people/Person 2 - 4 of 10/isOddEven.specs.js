const isOddEven = require('./isOddEven.js');
const expect = require('chai').expect;


describe("Is the length odd or even", function () {
    it('returns undefined if the input is not a string', function () {
        expect(isOddEven.isOddOrEven(15)).to.equal(undefined, "The function did not return the correct result!");
    });
    it('should return undefined with an object parameter', function () {
        expect(isOddEven.isOddOrEven({ name: "Georgi" })).to.equal(undefined, "The function did not return the correct result");
    });
    it('should return correct result with input of even length', function(){
        expect(isOddEven.isOddOrEven("test")).to.equal('even', "The output is not correct");
    });
    it('should return correct result when using odd length for input', function(){
       expect(isOddEven.isOddOrEven('testt')).to.equal('odd', "The output is not correct"); 
    });
});