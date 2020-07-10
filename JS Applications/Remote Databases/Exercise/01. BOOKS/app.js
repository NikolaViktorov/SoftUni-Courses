import el from './dom.js';
import * as api from './data.js';

const loadBtn = document.getElementById('loadBooks');
const tBody = document.querySelector('table tbody'); 

const input = {
    title: document.querySelector('#title'),
    author: document.querySelector('#author'),
    isbn: document.querySelector('#isbn')
}

const submitBtn = document.querySelector('#submit-btn')

window.addEventListener('load', () => {
    loadBtn.addEventListener('click', displayBooks);
    submitBtn.addEventListener('click', createBook);


    function validateInput(input) {
        let valid = true;
        Object.entries(input).forEach(([k, v]) => {
            if (v.value.length === 0) {
                v.classList.add('inputError');
                valid = false;
            } else {
                v.classList.remove('inputError');
            }
        });
        return valid;
    }

    function toggleInput(active, ...list) {
        list.forEach(e => e.disabled = !active);
    }

    async function displayBooks(e) {
        tBody.innerHTML = '<tr><td colspan="4">Loading...</td></tr>';
        const books = await api.getBooks();
        tBody.innerHTML = '';
        books.forEach(b => {
            tBody.appendChild(renderBook(b));
        });
    }

    async function createBook(e) {
        e.preventDefault();

        if (validateInput(input) === false) {
            alert(`All fields are required!`)
            return;
        }

        const book = {
            title: input.title.value,
            author: input.author.value,
            isbn: input.isbn.value
        };

        try {
            toggleInput(false, ...Object.values(input), submitBtn);
            const created = await api.createBook(book);
            tBody.appendChild(renderBook(created));
            Object.entries(input).forEach(([k, v]) => v.value = '');
        } catch (err) {
            alert(err);
            console.error(err);
        } finally {
            toggleInput(true, ...Object.values(input), submitBtn);
        }
    }

    function renderBook(book) {
        const deleteBtn = el('button', 'Delete');
        const editBtn = el('button', 'Edit');

        deleteBtn.addEventListener('click', deleteBook);
        editBtn.addEventListener('click', toggleEditor);

        const element = el('tr', [
            el('td', book.title),
            el('td', book.author),
            el('td', book.isbn),
            el('td', [
                editBtn,
                deleteBtn
            ])
        ]);

        return element;

        function toggleEditor() {
            const confirmBtn = el('button', 'Save');
            const cancelBtn = el('button', 'Cancel');

            cancelBtn.addEventListener('click', () => {
                tBody.replaceChild(element, editor);
            })

            confirmBtn.addEventListener('click', async () => {
                if (validateInput(edit) === false) {
                    alert(`All fields are required!`)
                    return;
                }
        
                const edited = {
                    objectId: book.objectId,
                    title: edit.title.value,
                    author: edit.author.value,
                    isbn: edit.isbn.value
                };
        
                try {
                    toggleInput(false, ...Object.values(edit), confirmBtn, cancelBtn);
                    confirmBtn.textContent = 'Please wait...';
                    const result = await api.updateBook(edited);
                    tBody.replaceChild(renderBook(result), editor);
                } catch (err) {
                    alert(err);
                    console.error(err);
                    toggleInput(true, ...Object.values(edit), confirmBtn, cancelBtn);
                    confirmBtn.textContent = 'Save';
                } 
            })

            const edit = {
                title: el('input', null, { type: 'text', value: book.title}),
                author: el('input', null, { type: 'text', value: book.author}),
                isbn: el('input', null, { type: 'text', value: book.isbn})
            }

            const editor = el('tr', [
                el('td', edit.title),
                el('td', edit.author),
                el('td', edit.isbn),
                el('td', [
                    confirmBtn,
                    cancelBtn
                ])
            ]);

            tBody.replaceChild(editor, element);
        }

        async function deleteBook() {
            try {
                deleteBtn.disabled = true;
                deleteBtn.textContent = 'Please wait...';
                const result = await api.deleteBook(book.objectId);
                element.remove();
            } catch (err) {
                console.error(err);                
            } finally {
                deleteBtn.disabled = false;
                deleteBtn.textContent = 'Delete';
            }
        }
    }
})