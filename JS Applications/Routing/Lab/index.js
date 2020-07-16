(function () {
    const templates = {};
    const loadingBoxEl = document.getElementById('loadingBox');
    const infoBoxEl = document.getElementById('infoBox');
    const errorBoxEl = document.getElementById('errorBox');

    const firebaseConfig = {
        apiKey: "AIzaSyDwOIsB2xaZ-1801J5_KaHzjPpzeHrpxYQ",
        authDomain: "routing-lab-6c675.firebaseapp.com",
        databaseURL: "https://routing-lab-6c675.firebaseio.com",
        projectId: "routing-lab-6c675",
        storageBucket: "routing-lab-6c675.appspot.com",
        messagingSenderId: "459225612276",
        appId: "1:459225612276:web:14151d84a0fcdc8f7dc3a1"
    };

    firebase.initializeApp(firebaseConfig);

    toggleLoader(true);


    function toggleLoader(active) {
        if (active) {
            loadingBoxEl.style.display = 'inline';
            return;
        }
        loadingBoxEl.style.display = 'none';     
    }

    function getTemplate(url) {
        const existingTemplate = templates[url];
        if (existingTemplate) {
            return Promise.resolve(existingTemplate);
        }
        return fetch(`/templates/${url}.hbs`).then(res => res.text()).then(tempString => {
            const templateFn = Handlebars.compile(tempString);
            templates[url] = templateFn;
            return templateFn;
        });
    }

    function renderTemplate(templatePath, templateContext, swapFn) {
        getTemplate(templatePath).then(templateFn => {
            const content = templateFn(templateContext);
            swapFn(content);
        });
    }

    function loadRegisterPartialTemplate(templatePath, templateName) {
        return fetch(`/templates/partials/${templatePath}.hbs`).then(res => res.text())
        .then(temp => {
            Handlebars.registerPartial(
                templateName,
                temp
            )
            return temp;
        })
    }

    function loadFurniture() {
        return fetch(`${firebaseConfig.databaseURL}/furniture.json`)
            .then(res => res.json())
            .then(data => {
                return Object.keys(data).reduce((acc, currId) => {
                    const currItem = data[currId];
                    return acc.concat( { id: currId, ...currItem});
                }, []);
            })
    }

    function loadFurnitureWithId(id) {
        return fetch(`${firebaseConfig.databaseURL}/furniture/${id}.json`)
            .then(res => res.json())
    }

    function onCreateFurnitureLoaded(createHandlerFn) {   
        const createBtn = document.getElementById('create-btn');

        createBtn.addEventListener('click', createHandlerFn);
    }

    const app = Sammy(function() {

        this.before({}, function() {
            toggleLoader(true);
        })

        this.get('#/', function() {
            Promise.all([loadFurniture, loadRegisterPartialTemplate('furniture-item', 'furnitureItem')])
            .then(([items]) => {
                renderTemplate('home', { items }, this.swap.bind(this))
            }).then(() => {
                toggleLoader(false);
            });
            
        })
    
        this.get('#/profile', function() {
            renderTemplate('profile', {}, this.swap.bind(this)).then(() => {
                toggleLoader(false);
            });;
        })

        this.get('#/create-furniture', function() {
            renderTemplate('create-furniture', {}, this.swap.bind(this)).then(() => {
                toggleLoader(false);
                const onCreateHandler = () => {
                    const makeEl = document.getElementById('new-make');
                    const modelEl = document.getElementById('new-model');
                    const yearEl = document.getElementById('new-year');
                    const descriptionEl = document.getElementById('new-description');
                    const priceEl = document.getElementById('new-price');
                    const imageEl = document.getElementById('new-image');
                    const materialEl = document.getElementById('new-material');

                    const inputs = [
                        makeEl,
                        modelEl,
                        yearEl,
                        descriptionEl,
                        priceEl,
                        imageEl,
                        materialEl
                    ];
        
                    const values = inputs.map(input => input.value);
                    const missingInputValue = values.findIndex(v => !v);
                    if (missingInputValue !== -1) {
                        console.error('MISSING DATA', inputs[missingInputValue]);
                        return;
                    }

                    const body = values.reduce((acc, curr, index) => {
                        const currInputEl = inputs[index];
                        acc[currInputEl.name] = curr;
                        return acc;
                    }, {})
        
                    const url = `${firebaseConfig.databaseURL}/furniture.json`;
                    fetch(url, {
                        method: 'POST',
                        body: JSON.stringify(body)
                    }).then(() => {
                        this.redirect('#/');
                    })
                }
                onCreateFurnitureLoaded(onCreateHandler);
            });
        })

        this.get('#/furniture-detail/:id', function(context) {
            const id = context.params.id;
            loadFurnitureWithId(id)
            .then(data => renderTemplate('furniture-detail', {}, this.swap.bind(this)))
            .then(() => {
                toggleLoader(false);
            });
        })
    });
    
    app.run('#/');
}());

