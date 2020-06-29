function focus() {
    function fIn(e) {
        e.target.parentElement.classList.add('focused');
    }
    function fOut(e) {
        e.target.parentElement.classList.remove('focused');
    }

    const inputs = document.querySelectorAll('input[type="text"]');

    for(let i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener('focus', fIn);
        inputs[i].addEventListener('blur', fOut);
    }
}