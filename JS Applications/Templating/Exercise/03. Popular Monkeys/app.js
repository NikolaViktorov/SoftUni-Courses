/* globals Handlebars */

import monkeys from './monkeys.js';

window.addEventListener('load', async () => {
    const mainEl = document.querySelector('section')

    const mainString = await (await fetch('./main.hbs')).text();
    const mainTemplate = Handlebars.compile(mainString);
    Handlebars.registerPartial('monkey', await (await fetch('./monkey.hbs')).text());

    const html = mainTemplate({ monkeys });
    mainEl.innerHTML = html;

    const monkeysEl = document.querySelector('.monkeys');

    monkeysEl.addEventListener('click', function (e) {
        const target = e.target;
        if (target.tagName !== 'BUTTON') { return; }
        const p = target.parentNode.querySelector('p');

        if (p.style.display === 'block') {
            p.style.display = 'none';
            target.textContent = 'Info';
        } else {
            p.style.display = 'block';
            target.textContent = 'Hide Info';
        }

    })
});