import el from './dom.js';
import * as api from './data.js';

const tBody = document.querySelector('table tbody'); 

const input = {
    FirstName: document.querySelector('#first-name'),
    LastName: document.querySelector('#last-name'),
    FacultyNumber: document.querySelector('#faculty-number'),
    Grade: document.querySelector('#grade')
}

const submitBtn = document.querySelector('#submit-btn');
const loadBtn = document.querySelector('#load-btn');

window.addEventListener('load', () => {
    submitBtn.addEventListener('click', AddStudent);
    loadBtn.addEventListener('click', LoadStudents);

    async function AddStudent(e) {
        e.preventDefault();

        if (validateInput(input) === false) {
            alert(`All fields are required!`)
            return;
        }

        const students = await api.getStudents();
        const id = Object.keys(students).length + 1;

        const student = {
            ID: id,
            FirstName: input.FirstName.value,
            LastName: input.LastName.value,
            FacultyNumber: input.FacultyNumber.value,
            Grade: Number(input.Grade.value)
        };

        try {
            toggleInput(false, ...Object.values(input), submitBtn);
            const created = await api.createStudent(student);
            LoadStudents();
            Object.entries(input).forEach(([k, v]) => v.value = '');
        } catch (err) {
            alert(err);
            console.error(err);
        } finally {
            toggleInput(true, ...Object.values(input), submitBtn);
        }
    }

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

    async function LoadStudents() {
        tBody.innerHTML = '<tr><td colspan="4">Loading...</td></tr>';
        const studentsObj = await api.getStudents();
        clearTable();
        studentsObj.sort(compareStudents);

        Object.keys(studentsObj).forEach(key => {
            renderStudent(studentsObj[key]);
        });
    }

    function renderStudent(student) {
        const deleteBtn = el('button', 'Delete');

        deleteBtn.addEventListener('click', deleteBook);
        
        // not ready yet (the deleted button)
        const element = el('tr', [
            el('td', student.ID),
            el('td', student.FirstName),
            el('td', student.LastName),
            el('td', student.FacultyNumber),
            el('td', student.Grade),
        ]);

        async function deleteBook() {
            try {
                deleteBtn.disabled = true;
                deleteBtn.textContent = 'Please wait...';
                const result = await api.deleteBook(student.objectId);
                element.remove();
            } catch (err) {
                console.error(err);                
            } finally {
                deleteBtn.disabled = false;
                deleteBtn.textContent = 'Delete';
            }
        }
        
        tBody.appendChild(element);
    }

    function compareStudents(student1, student2) {
        if (student1.ID > student2.ID) {
            return 1;
        } if (student2.ID > student1.ID) {
            return -1;
        }

        return 0;
    }

    function clearTable() {
        tBody.innerHTML = '';
    }

    function toggleInput(active, ...list) {
        list.forEach(e => e.disabled = !active);
    }
});