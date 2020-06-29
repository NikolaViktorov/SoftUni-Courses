function solve() {
    const sections = document.querySelectorAll('section');
    const openDiv = sections.item(1).querySelectorAll('div').item(1);
    const progressDiv = sections.item(2).querySelectorAll('div').item(1);
    const completeDiv = sections.item(3).querySelectorAll('div').item(1);

    const taskInput = document.querySelector('#task');
    const descInput = document.querySelector('#description');
    const dateInput = document.querySelector('#date');

    document.querySelector('#add').addEventListener('click', addTask);

    function addTask(e) {
        e.preventDefault();
        const task = taskInput.value;
        const desc = descInput.value;
        const date = dateInput.value;

        if (task.length <= 0 || desc.length <= 0 || date.length <= 0) {
            return;
        }

        const startBtn = el('button', 'Start', { className: 'green'} );
        const deleteBtn = el('button', 'Delete', { className: 'red'} );
        const finishBtn = el('button', 'Finish', { className: 'orange'} );

        const btnDiv = el('div', [
            startBtn,
            deleteBtn
        ], { className: 'flex' } );

        const newTask = el('article', [
            el('h3', task),
            el('p', `Description: ${desc}`),
            el('p', `Due Date: ${date}`),
            btnDiv
        ]);
        
        startBtn.addEventListener('click', startTask);
        deleteBtn.addEventListener('click', deleteTask);
        finishBtn.addEventListener('click', finishTask);

        function startTask(e) {
            progressDiv.appendChild(newTask);
            startBtn.remove();
            btnDiv.appendChild(finishBtn);
        }

        function deleteTask(e) {
            newTask.remove();
        }

        function finishTask(e) {
            completeDiv.appendChild(newTask);
            btnDiv.remove();
        }

        openDiv.appendChild(newTask);
    }

    el('button', 'Finish', { className: 'green' });

function el(type, content, attributes) {
	const result = document.createElement(type);
	
    if (attributes !== undefined) {
        Object.assign(result, attributes);
    }

    if (Array.isArray(content)) {
        content.forEach(append);
    } else {
        append(content);
    }

    function append(node) {
        if (typeof node === 'string') {
            node = document.createTextNode(node);
        }
        result.appendChild(node);
    }

    return result;
}
}