import * as data from './data.js';
import el from './dom.js';

const catchesList = document.getElementById('catches');

const loadBtn = document.getElementsByClassName('load')[0];
const addBtn = document.getElementsByClassName('add')[0];
const addForm = document.getElementById('addForm');
const deleteLoadedBtn = document.getElementsByClassName('delete')[0];
const updateLoadedBtn = document.getElementsByClassName('delete')[0];

const anglerInput = addForm.getElementsByClassName('angler')[0];
const weightInput = addForm.getElementsByClassName('weight')[0];
const speciesInput = addForm.getElementsByClassName('species')[0];
const locationInput = addForm.getElementsByClassName('location')[0];
const baitInput = addForm.getElementsByClassName('bait')[0];
const captureTimeInput = addForm.getElementsByClassName('captureTime')[0];

function attachEvents() {
    addBtn.addEventListener('click', addCatch);
    loadBtn.addEventListener('click', loadCatches);
    deleteLoadedBtn.addEventListener('click', deleteCatch);
    updateLoadedBtn.addEventListener('click', updateCatch);
}

async function updateCatch(e) {
    const curDiv = e.path[1];
    const id = curDiv.getAttribute('data-id');

    const angler = curDiv.getElementsByClassName('angler')[0].value;
    const weight = curDiv.getElementsByClassName('weight')[0].value;
    const species = curDiv.getElementsByClassName('species')[0].value;
    const location = curDiv.getElementsByClassName('location')[0].value;
    const bait = curDiv.getElementsByClassName('bait')[0].value;
    const captureTime = curDiv.getElementsByClassName('captureTime')[0].value;  

    const obj = {
        angler: angler,
        weight: weight,
        species: species,
        location: location,
        bait: bait,
        captureTime: captureTime
    }

    data.updateCatch(id, obj);
}

async function deleteCatch(e) {
   const div = e.path[1];
    const id = div.getAttribute('data-id');

    data.deleteCatch(id);
    div.remove();
}

async function addCatch() {
    const angler = anglerInput.value;
    const weight = weightInput.value;
    const species = speciesInput.value;
    const location = locationInput.value;
    const bait = baitInput.value;
    const captureTime = captureTimeInput.value;

    const obj = {
        angler: angler,
        weight: weight,
        species: species,
        location: location,
        bait: bait,
        captureTime: captureTime
    }

    data.addCatch(obj);

    const catches = await data.getCatches();
    const keys = Object.keys(catches);
    const id = keys[keys.length - 1];

    const div = el('div', 
        createInputFields(angler, weight, species, location, bait, captureTime)
        , { className: 'catch'})
    div.setAttribute('data-id', id);

    catchesList.appendChild(div);

    anglerInput.value = '';
    weightInput.value = '';
    speciesInput.value = '';
    locationInput.value = '';
    baitInput.value = '';
    captureTimeInput.value = '';
}

async function loadCatches() {
    const catches = await data.getCatches();

    Object.keys(catches).forEach(k => {
        const angler = catches[k].angler;
        const weight = catches[k].weight;
        const species = catches[k].species;
        const location = catches[k].location;
        const bait = catches[k].bait;
        const captureTime = catches[k].captureTime;

        const div = el('div', 
            createInputFields(angler, weight, species, location, bait, captureTime)
        , { className: 'catch' })

        catchesList.appendChild(div);
    })
}

function createInputFields(angler, weight, species, location, bait, captureTime) {
    // add buttons
    const updateBtn = el('button', 'Update', { className: 'update'} );
    const deleteBtn = el('button', 'Delete', { className: 'delete'} );

    updateBtn.addEventListener('click', updateCatch);
    deleteBtn.addEventListener('click', deleteCatch);

    return [
        el('label', 'Angler'),
        el('input', '', { className: 'angler', value:  angler, type:  'text' }),
        el('hr', ''),
        el('label', 'Weight'),
        el('input', '', { className:  'weight', value:  weight, type:  'number' }),
        el('hr', ''),
        el('label', 'Species'),
        el('input', '', { className:  'species', value: species, type: 'text' }),
        el('hr', ''),
        el('label', 'Location'),
        el('input', '', { className:  'location', value:  location, type:  'text' }),
        el('hr', ''),
        el('label', 'Bait'),
        el('input', '', { className:  'bait', value:  bait, type: 'text' }),
        el('hr', ''),
        el('label', 'Capture Time'),
        el('input', '', { className: 'captureTime', value: captureTime, type: 'number' }),
        el('hr', ''),
        updateBtn,
        deleteBtn
    ];


    /* <div class="catch" data-id="<id-goes-here>">
                <button class="update">Update</button>
                <button class="delete">Delete</button>
            </div> */
}

attachEvents();



