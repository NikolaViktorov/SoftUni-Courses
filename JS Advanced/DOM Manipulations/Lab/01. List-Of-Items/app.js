function addItem() {
    const text = document.querySelector('#newItemText').value;
    const li = document.createElement('li');
    li.appendChild(document.createTextNode(text));
    document.getElementById('items').appendChild(li);
    document.getElementById('newItemText').value = '';
}