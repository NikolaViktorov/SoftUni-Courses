function toggle() {
    const div = document.querySelector('#extra');
    const but = document.getElementsByClassName('button')[0];
    
    if (div.style.display === 'block') {
        but.textContent = 'More';
        div.style.display = 'none';
    } else {
        div.style.display = 'block';
        but.textContent = 'Less';
    }
}