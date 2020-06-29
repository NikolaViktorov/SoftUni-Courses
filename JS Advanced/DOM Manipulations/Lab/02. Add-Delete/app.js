function addItem() {
    const text = document.querySelector('#newText').value;
    const li = document.createElement('li');
    const deleteLink = document.createElement('a');
    const items = document.getElementById('items');

    deleteLink.innerHTML = '[Delete]';
    deleteLink.setAttribute('href', '#')
    

    li.appendChild(document.createTextNode(text + ' '));
    li.appendChild(deleteLink);

    deleteLink.addEventListener('click', () => {
        items.removeChild(li);
    });

    document.getElementById('items').appendChild(li);
    document.getElementById('newText').value = '';


    
}