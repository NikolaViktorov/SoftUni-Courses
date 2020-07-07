const expect = require('chai').expect;

// Tests for 1.Even or Odd

const one = require('./one/evenOrOdd.js');

describe('Even or odd length of a string tests:',function(){
    it('should return undefined when the argument is a number',function(){
        expect(one.isOddOrEven(4)).to.be.equal(undefined);
    });
    it('should return undefined when the argument is an array',function(){
        expect(one.isOddOrEven([4,'four'])).to.be.equal(undefined);
    });
    it('should return \'even\' if you pass a srting with even lenght',function(){
        expect(one.isOddOrEven('tyga')).to.be.equal('even');
    });
    it('should return \'odd\' if you pass a srting with off lenght',function(){
        expect(one.isOddOrEven('tiger')).to.be.equal('odd');
    });
});

//Tests for 2.CharLookUp

const two = require('./two/charLookUp.js');

describe('Char look up in a string tests:',function(){
    it('should return undefined when the index is not a number',function(){
        expect(two.lookupChar('Tyga','Vacation')).to.be.equal(undefined);
    });
    it('should return undefined when the string is not a string',function(){
        expect(two.lookupChar({name:'Tyga'},0)).to.be.equal(undefined);
    });
    it('should return \'Incorrect index\' when the index of the string does not exist',function(){
        expect(two.lookupChar('Tyga',4)).to.be.equal('Incorrect index');
    });
    it('should return \'Incorrect index\' when the index of the string is a negative number',function(){
        expect(two.lookupChar('Tyga',(-4))).to.be.equal('Incorrect index');
    });
    it('should return the correct index if both args are valid',function(){
        expect(two.lookupChar('Tyga',0)).to.be.equal('T');
    });

});

//Tests for 3.Math Enforcer

const three = require('./three/mathEnforcer.js');

describe('Test some simple math functions:',function(){
    describe('Test a function that adds 5 to a given number:',function(){
        it('should return undefined if the given arg is not a number',function(){
            expect(three.mathEnforcer.addFive('Tyga')).to.be.equal(undefined);
        });
        it('should return 10 if the given number is 5',function(){
            expect(three.mathEnforcer.addFive(5)).to.be.equal(10);
            //a little too hard coded but for such a simple test it is great :)
        });
    })
    describe('Test a function that subtracts 10 from a given number',function(){
        it('should return undefined if the given arg is not a number',function(){
            expect(three.mathEnforcer.subtractTen('6LACK')).to.be.equal(undefined);
        });
        it('should return undefined if the given arg is not a number',function(){
            expect(three.mathEnforcer.subtractTen('6LACK')).to.be.equal(undefined);
        });
    })
    describe('Test a function that takes two numbers as args and returns their sum',function(){
        it('should return undefined if the first given arg is not a number',function(){
            expect(three.mathEnforcer.sum('5366',2)).to.be.equal(undefined);
        });
        it('should return undefined if the second given arg is not a number',function(){
            expect(three.mathEnforcer.sum(2,'6635')).to.be.equal(undefined);
        });
        it('should return 420 if the given args are 400 and 20',function(){
            expect(three.mathEnforcer.sum(400,20)).to.be.equal(420);
        });
    })

});



//Tests on 4.String Builder 

const four = require('./four/sb.js');

describe('Test a StringBuilder class:',function(){
    describe('Test initializion of SB:',function(){
        it('shoule be able to initialize a SB with no args',function(){
            function initEmptySb(){
                return new four.StringBuilder();
            }
            expect(initEmptySb).to.not.throw();
        });
        it('should be able to be initialized with a string as arg and the toString should return this string',function(){
            const exampleString = 'I am getting high after writing all those useless tests :)';
            let builder = new four.StringBuilder(exampleString);
            expect(builder.toString()).to.be.equal(exampleString);
        });
        it('should not be able to be initialiez with a non-string arg',function(){
            const exampleNumber = 73;
            function initializeSbWithWrongArg(){
                return new four.StringBuilder(exampleNumber);
            }
            expect(initializeSbWithWrongArg).to.throw(TypeError,'Argument must be string');
        });
    }) 
    describe('Test the append function of the SB:',function(){
        it('should convert the arg to char arr and append it an the end of the SB',function(){
            const exampleString = 'foo';
            let builder = new four.StringBuilder('bar');
            builder.append(exampleString);
            expect(builder.toString().substr(3,3)).to.be.equal(exampleString);
        });
        it('should throw a Type Error is the arg is not a string',function(){
            const exampleArg = {name:'foo'};
            let builder = new four.StringBuilder('bar');
            expect(()=>{builder.append(exampleArg)}).to.throw(TypeError,/string/);
        });
    })
    describe('Test the prepend function of the SB:',function(){
        it('should convert the arg to char arr and append it at the beggining of the SB',function(){
            const exampleString = 'foo';
            let builder = new four.StringBuilder('bar');
            builder.prepend(exampleString);
            expect(builder.toString().substr(0,3)).to.be.equal(exampleString);
        });
        it('should throw a Type Error is the arg is not a string',function(){
            const exampleArg = {name:'foo'};
            let builder = new four.StringBuilder('bar');
            expect(()=>{builder.prepend(exampleArg)}).to.throw(TypeError,/string/);
        });
    })
    describe('Test the insertAt function of the SB:',function(){
        it('should inster foo between bar',function(){
            const exampleString = 'foo';
            let builder = new four.StringBuilder('bar');
            builder.insertAt(exampleString,0);
            expect(builder.toString().substr(0,3)).to.be.equal(exampleString);

        });
        it('should throw a Type Error is the arg is not a string',function(){
            const exampleArg = {name:'foo'};
            let builder = new four.StringBuilder('bar');
            expect(()=>{builder.insertAt(exampleArg,2)}).to.throw(TypeError,/string/);
        });
    })
    describe('Test the remove function of the SB:',function(){
        it('should remove foo from foobar',function(){
            let builder = new four.StringBuilder('foobar');
            builder.remove(0,3);
            expect(builder.toString()).to.be.equal('bar');
        });
    })
    describe('Test the toString function of the SB:',function(){
        it('should return a string from the array joined by nothing',function(){
            let builder = new four.StringBuilder('foobar');
            builder.append('foo');
            builder.prepend('bar');
            expect(builder.toString()).to.be.equal('barfoobarfoo');
        });
    })
});