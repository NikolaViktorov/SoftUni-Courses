/* globals Handlebars, cats */
window.addEventListener('load', async () => {
    const listString = await (await fetch('./list.hbs')).text();
    const listTemplate = Handlebars.compile(listString);
    Handlebars.registerPartial('cat', await (await fetch('./cat.hbs')).text());

    const mainEl = document.getElementById('allCats');

    const html = listTemplate({cats});
    mainEl.innerHTML = html;

    mainEl.addEventListener('click', function (e) {
        const target = e.target;
        if (!target.classList.contains('showBtn')) { return; }
        const div = target.parentNode.querySelector('.status');
        if (div.style.display === 'block') {
            div.style.display = 'none';
            target.textContent = 'Show status code';
        } else {
            div.style.display = 'block';
            target.textContent = 'Hide status code';
        }
    })
});