function solve() {
    const input = document.querySelector('input');
    const list = document.querySelectorAll('li');

    document
        .querySelector('button')
        .addEventListener('click', registerUser);

    function registerUser() {

        if (input.value === '') {
            return;
        }

        const name = input.value[0].toUpperCase() + input.value.slice(1).toLowerCase();
        const position = name.charCodeAt(0) - 65;
        const people = list[position].textContent
                                    .split(', ')
                                    .filter(Boolean);

        people.push(name);
        list[position].textContent = people.join(', ');
        input.value = '';
    }
}