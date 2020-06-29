(function solve() {
    String.prototype.ensureStart = function(str) {
        if (!this.startsWith(str)) {
            return str + this;
        } else {
            return this.toString();
        }
    }

    String.prototype.ensureEnd = function(str) {
        if (!this.endsWith(str)) {
            return this + str;
        } else {
            return this.toString();
        }
    }

    String.prototype.isEmpty = function() {
        return this.length === 0 ? true : false;
    }

    String.prototype.truncate = function(n) {
        if (n <= 3) {
            return '.'.repeat(n);
        }
        if (n >= this.length) {
            return this.toString();
        }
        let spaceIndex = this.substring(0, n - 1).lastIndexOf(' ');
        if (spaceIndex >= 0) {
            return this.substring(0, spaceIndex) + '...';
        } else {
            return this.substring(0, n - 3) + '...';
        }
    }

    String.format = function(str, ...params) {
        params.forEach((el, i) => {
            str = str.replace(`{${i}}`, el);
        });
        return str;
    }
}())

solve();
let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');