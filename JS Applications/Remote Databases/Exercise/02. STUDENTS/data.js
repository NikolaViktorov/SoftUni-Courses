const appId = `69FC81D7-CA52-3E69-FFAD-4F7400E6EA00`;
const apiKey = `D8F332E1-E43A-4C5B-AECC-4D23BC99986C`;

function host(endpoint) {
    return `https:/api.backendless.com/${appId}/${apiKey}/data/${endpoint}`;
}

export async function getStudents() {
    const res = await fetch(host(`students`));
    const data = await res.json();
    return data;
}

export async function createStudent(student) {
    const res = await fetch(host('students'), {
        method: 'POST',
        body: JSON.stringify(student),
        headers: {
            'Content-Type': 'application/json'
        }  
    });
    const data = await res.json();
    return data;
}

export async function deleteBook(id) {
    const res = await fetch(host(`students/${id}`), {
        method: 'DELETE'
    });
    const data = await res.json();
    return data;
}
