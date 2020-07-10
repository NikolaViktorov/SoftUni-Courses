const appId = `69FC81D7-CA52-3E69-FFAD-4F7400E6EA00`;
const apiKey = `D8F332E1-E43A-4C5B-AECC-4D23BC99986C`;

function host(endpoint) {
    return `https:/api.backendless.com/${appId}/${apiKey}/data/${endpoint}`;
}

export async function getBooks() {
    const res = await fetch(host(`books`));
    const data = await res.json();
    return data;
}

export async function createBook(book) {
    const res = await fetch(host('books'), {
        method: 'POST',
        body: JSON.stringify(book),
        headers: {
            'Content-Type': 'application/json'
        }  
    });
    const data = await res.json();
    return data;
}

export async function updateBook(book) {
    const id = book.objectId;
    const res = await fetch(host(`books/${id}`), {
        method: 'PUT',
        body: JSON.stringify(book),
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const data = await res.json();
    return data;
}

export async function deleteBook(id) {
    const res = await fetch(host(`books/${id}`), {
        method: 'DELETE'
    });
    const data = await res.json();
    return data;
}