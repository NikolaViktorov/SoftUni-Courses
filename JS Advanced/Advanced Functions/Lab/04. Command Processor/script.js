function solution() {
    let curString = '';
    return {
        append: (str) => {curString += str},
        removeStart: (n) => {curString = curString.substring(n)},
        removeEnd: (n) => {curString = curString.substring(0, curString.length - n)},
        print: () => {console.log(curString)},
    }
}
let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();

