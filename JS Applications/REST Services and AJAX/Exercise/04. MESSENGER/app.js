function attachEvents() {
    const url = 'http://localhost:3000';

    const messages = [

    ];

    const submitBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');

    const authorInput = document.getElementById('author');
    const contentInput =  document.getElementById('content');
    const messageArea = document.getElementById('messages');

    submitBtn.addEventListener('click', createMessage);
    refreshBtn.addEventListener('click', loadMessages);

    function createMessage(e) {
        const author = authorInput.value;
        const content = contentInput.value;

        fetch(url, { 
            method: 'POST',
            body: JSON.stringify({ author, content })
         })
            .then(res => res.json())
            .then(data => {
                messages.push(data);
                authorInput.value = '';
                contentInput.value = '';
            })
    }

    function loadMessages(e) {
        messageArea.textContent = '';

        fetch(url)
            .then(res => res.json())
            .then(data => {
                console.log(data);
                const keys = Object.keys(data);
                keys.forEach(k => {
                    const author = data[k].author;
                    const content = data[k].content;
                    messageArea.textContent += `${author}: ${content}\n`;
                })
            })
    }
}

attachEvents();