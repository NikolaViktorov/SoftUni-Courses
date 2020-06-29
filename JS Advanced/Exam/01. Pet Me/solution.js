function solve() {
    const container = document.querySelector('#container');
    const adoptionList = document.querySelector('#adoption > ul');
    const adoptedList = document.querySelector('#adopted > ul');

    const nameInput = container.querySelectorAll('input').item(0);
    const ageInput = container.querySelectorAll('input').item(1);
    const kindInput = container.querySelectorAll('input').item(2);
    const curOwnerInput = container.querySelectorAll('input').item(3);
    
    container.querySelector('button').addEventListener('click', addPet);

    function addPet(e) {
        e.preventDefault();
        console.log(this);
        const name = nameInput.value;
        const age = ageInput.value === '' ? '' : Number(ageInput.value);
        const kind = kindInput.value;
        const curOwner = curOwnerInput.value;

        if (name.trim().length <= 0 || typeof age !== 'number' || isNaN(age)
         || kind.trim().length <= 0 || curOwner.trim().length <= 0) {
             return;
        }

        const contactBtn = el('button', 'Contact with owner');
        const takeBtn = el('button', 'Yes! I take it!');
        const checkedBtn = el('button', 'Checked');

        const takeDiv = el('div', [
            el('input', '', { placeholder: 'Enter your names'}),
            takeBtn
        ])


        let newPet = el('li', [
            el('p', [
                el('strong', `${name}`),
                ' is a ',
                el('strong', `${age}`),
                ' year old ',
                el('strong', `${kind}`)
            ]),
            el('span', `Owner: ${curOwner}`),
            contactBtn
        ]);

        contactBtn.addEventListener('click', contactOwner);
        takeBtn.addEventListener('click', takeIt);
        checkedBtn.addEventListener('click', removePet)

        function contactOwner(e) {
            contactBtn.remove();
            newPet.remove();
            newPet = el('li', [
                el('p', [
                    el('strong', `${name}`),
                    ' is a ',
                    el('strong', `${age}`),
                    ' year old ',
                    el('strong', `${kind}`)
                ]),
                el('span', `Owner: ${curOwner}`),
                takeDiv
            ]);
            adoptionList.appendChild(newPet);
        }

        function takeIt(e) {
            let newOwner = newPet.querySelector('input').value;
            if (newOwner.trim() !== '') {
                newPet.remove();
                newPet = el('li', [
                    el('p', [
                        el('strong', `${name}`),
                        ' is a ',
                        el('strong', `${age}`),
                        ' year old ',
                        el('strong', `${kind}`)
                    ]),
                    el('span', `New Owner: ${newOwner}`),
                    checkedBtn
                ]);
                adoptedList.appendChild(newPet);
            }
        }

        function removePet(e) {
            newPet.remove();
        }

        adoptionList.appendChild(newPet);

        nameInput.value = '';
        ageInput.value = '';
        kindInput.value = '';
        curOwnerInput.value = '';
        }


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

