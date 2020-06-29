function solve() {
    document.querySelector('button').addEventListener('click', convert)

    const toList = document.querySelector('#selectMenuTo');
    const binaryOpt = document.createElement('option');
    binaryOpt.value = 'binary';
    binaryOpt.textContent = 'Binary';
    toList.appendChild(binaryOpt);

    const decOpt = document.createElement('option');
    decOpt.value = 'hexadecimal';
    decOpt.textContent = 'Hexadecimal';
    toList.appendChild(decOpt);

    function convert(e) {
        const output = document.querySelector('#result');
        const number = Number(document.querySelector('#input').value);
        const to = toList.options[toList.selectedIndex].value;

        if(to === 'binary') {
            output.value = number.toString(2);
        } else if(to === 'hexadecimal') {
            output.value = number.toString(16).toLocaleUpperCase();
        } else {
            return;
        }
    }
}