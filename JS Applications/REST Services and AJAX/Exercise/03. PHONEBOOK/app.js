function attachEvents() {
    const url = 'http://localhost:3000';

    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    const personInput = document.getElementById('person');
    const phoneInput = document.getElementById('phone');

    const peopleList = document.getElementById('phonebook');

    loadBtn.addEventListener('click', loadPeople);
    createBtn.addEventListener('click', createPerson);

    const contacts = [

    ];

    function loadPeople(e) {
        while (peopleList.children.length > 0) {
            peopleList.children[0].remove();
        }
        contacts.forEach(c => {
            const li = document.createElement('li');
            li.textContent = `${c[Object.keys(c)[0]].person}: ${c[Object.keys(c)[0]].phone}`;

            const deleteBtn = document.createElement('button');
            deleteBtn.addEventListener('click', deletePerson);
            deleteBtn.textContent = 'Delete';

            li.appendChild(deleteBtn);
            peopleList.appendChild(li);

            function deletePerson(e) {
                li.remove();
                const index = contacts.indexOf(c);
                contacts.splice(index, 1);
            }
        })

        
    }

    function createPerson(e) {
        const person = personInput.value;
        const phone = phoneInput.value;

        fetch(url, { 
            method: 'POST',
            body: JSON.stringify({ person, phone })
         })
            .then(res => res.json())
            .then(data => {
                contacts.push(data);
                personInput.value = '';
                phoneInput.value = '';
            })
    }

    
}

attachEvents();