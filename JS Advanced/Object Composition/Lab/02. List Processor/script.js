function solve(cmds) {
    function processor() {
        const list = {
            content: [],
            add: function(text) {
                this.content.push(text);
            },
            remove: function(text) {
                this.content = this.content.filter(function(value, index, arr){ return value !== text;})
            },
            print: function() {
                console.log(this.content.join(','));
            }
        }
        
        return list;
    }
    const p = processor(); 

    for (let tokens of cmds) {
        let cmd = tokens.split(' ')[0];
        let value = tokens.split(' ')[1];
        if (value !== undefined) {
            p[cmd](value);
        } else {
            p[cmd]();
        }
    }
}


solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);