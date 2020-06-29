function addItem() {
    let text = document.querySelector('#newItemText').value;
    let value = document.querySelector('#newItemValue').value;

    const option = document.createElement('option');
    option.textContent = text;
    option.value = value;

    const menu = document.querySelector('#menu');
    menu.appendChild(option);

    document.querySelector('#newItemText').value = '';
    document.querySelector('#newItemValue').value = '';
}