function encodeAndDecodeMessages() {
    // event handlers
    document.querySelector('button').addEventListener('click', encode);
    document.querySelectorAll('button')[1].addEventListener('click', decode);
    // input output
    const [input, output] = document.querySelector('#main').querySelectorAll('textarea');

    function encode(e) {
    const encoded = [...input.value].map(l => String.fromCharCode(l.charCodeAt() + 1));
    output.value = encoded.join('');
    document.querySelector('#main').querySelectorAll('textarea')[0].value = '';
    }

    function decode(e) {
        const decoded = [...output.value].map(l => String.fromCharCode(l.charCodeAt() - 1));
        output.value = decoded.join('');
    }
}