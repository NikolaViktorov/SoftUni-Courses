function solve() {
    const proto = {};

    const inst = Object.create(proto);

    inst.extend = function(template) {
        for (let prop in template) {
            if (typeof template[prop] === 'function') {
                proto[prop] = template[prop];
            } else {
                inst[prop] = template[prop];
            }
        }
    }


    return inst;
}