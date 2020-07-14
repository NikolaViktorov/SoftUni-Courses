/* globals Handlebars */
(function () {
    const divRoot = document.getElementById('root');

    const loadBtn = document.getElementById('btnLoadTowns');
    const townsInput = document.getElementById('towns'); `Sofia, Lom, Montana, ...`

    const templateString = document.getElementById('main-template').innerHTML;
    const templateFn = Handlebars.compile(templateString);

    loadBtn.addEventListener('click', function(e) {
        e.preventDefault();
        const towns = townsInput.value.split(', ');

        const genHtml = templateFn({towns});

        divRoot.innerHTML = genHtml;
    })
}());