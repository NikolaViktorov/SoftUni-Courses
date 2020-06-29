function deleteByEmail() {
    const email = document.getElementsByName('email')[0].value;
    const table = document.querySelector('#customers').children[1].children;
    const result = document.querySelector('#result');

    for (let i = 0; i < table.length; i++) {
        const curEmail = table[i].textContent.split(' ').map(t => t.replace('\n','')).filter(function (e) {
            return e != '';
        })[1];
        if (email === curEmail) {
            table[i].remove();
            document.getElementsByName('email')[0].value = '';
            result.textContent = 'Deleted.';
            break;
        }
        result.textContent = 'Not found.';
    }

}