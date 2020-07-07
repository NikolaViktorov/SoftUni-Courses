const app = require('./charLookUp');
const expect = require('chai').expect;

describe('Look up a char by index', function(){
    it('accepts only valid integers', function(){
        
        expect(app.lookupChar('test', 6)).to.equal("Incorrect index");
        
    });
    it('accepts only string as a first parameter and int as a second parameter', function(){
        expect(app.lookupChar(true,'test')).to.equal(undefined, "Invalid input");
    });
    it('returns the correct char when the input is valid', function(){
    expect(app.lookupChar('test',2)).to.equal('s',"The correct char at position 2 is e");    
    });
})