function lockedProfile() {
    const people = document.getElementsByClassName('profile');

    for(let i = 0; i < people.length; i++) {
        people[i].addEventListener('click', e => {
            const target = e.target;
            if(target.nodeName === 'BUTTON') {
                const isLocked = people[i].getElementsByTagName('input')[0].checked;
                if(!isLocked) {
                    const info = people[i].getElementsByTagName('div')[0];
                    if(info.style.display === 'block') {
                        people[i].getElementsByTagName('div')[0].style.display = 'none';
                        e.target.textContent = 'Show more';
                    } else {
                        people[i].getElementsByTagName('div')[0].style.display = 'block';
                        e.target.textContent = 'Hide it';
                    }
                    console.log();
                }
            }
        });
    }
    
}