function subtract() {
    const first = Number(document.getElementById('firstNumber').value);
    const second = Number(document.getElementById('secondNumber').value);

    const result = first - second;

    const resultDiv = document.getElementById('result');
    resultDiv.textContent = result;
}