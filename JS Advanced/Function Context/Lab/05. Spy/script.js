function Spy(obj, fnName){
        const spy = { count: 0};
        const fn = obj[fnName];
        if (!fn) { throw new Error('No such method!'); }
        obj[fnName] = function (...args) {
            this.count++;
            return fn.apply(obj, args);
        }.bind(spy);
        return spy; 
}

let spy = Spy(console,"log");

console.log(spy); // { count: 1 }
console.log(spy); // { count: 2 }
console.log(spy); // { count: 3 }


