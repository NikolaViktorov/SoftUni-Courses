const symbols = {
    'Sunny': '&#x2600;',
    'Partly sunny': '&#x26C5;',
    'Overcast': '&#x2601;',
    'Rain': '&#x2614;',
    'Degress': '&#176;'
}

const locationInput = document.getElementById('location');
const submitBtn = document.getElementById('submit');
const todayDiv = document.getElementById('current');
const upcommingDiv = document.getElementById('upcoming');
const mainDiv = document.getElementById('forecast');

function attachEvents() {
    submitBtn.addEventListener('click', getForecast);
}

attachEvents();


function getForecast(e) {
    const name = locationInput.value;
    (async() => {
        let code = undefined;
        try {
            code = await getCode(name);
        } catch (err) {
            locationInput.value = 'Error';
            return;
        }
        
        const todayP = getToday(code);
        const upcommingP = getUpcomming(code);
    
        const [today, upcomming] = [
            await todayP,
            await upcommingP
        ];

        clear();

        const symbolSpan = el('span', '', { className: 'condition symbol' });
        symbolSpan.innerHTML = symbols[today.forecast.condition];

        todayDiv.appendChild(el('div', [
            symbolSpan,
            el('span', [
                el('span', today.name, { className: 'forecast-data'} ),
                el('span', `${today.forecast.low}/${today.forecast.high}`, { className: 'forecast-data'} ),
                el('span', today.forecast.condition, { className: 'forecast-data'} ),
            ], { className: 'condition' })
        ], { className: 'forecast'} )
        );

        const forecastInfoDiv = el('div', upcomming.forecast.map(renderUpcoming), { className: 'forecast-info'});
        upcommingDiv.appendChild(forecastInfoDiv);

        mainDiv.style.display = 'block';
    })();
}

function clear() {
    while(todayDiv.children.length > 0) {
        todayDiv.children[0].remove();
    }

    while(upcommingDiv.children.length > 0) {
        upcommingDiv.children[0].remove();
    }
}

function renderUpcoming(forecast) {
    const symbolSpan = el('span', '', { className: 'symbol' });
    symbolSpan.innerHTML = symbols[forecast.condition];


    const tempSpan = el('span', '', { className: 'forecast-data'} );
    tempSpan.innerHTML = `${forecast.low}${symbols.Degress}/${forecast.high}${symbols.Degress}`;

    const result = el('span', [
        symbolSpan,
        tempSpan,
        el('span', forecast.condition, { className: 'forecast-data'})
    ], { className: 'upcoming' });

    return result;
}


function host(endpoint) {
    return `https://judgetests.firebaseio.com/${endpoint}.json`;
}

const api = {
    locations: 'locations',
    today: 'forecast/today/',
    upcoming: 'forecast/upcoming/'
};

async function getCode(name) {
    const data = await (await fetch(host(api.locations))).json();

    return data.find(l => l.name == name).code;
}

async function getToday(code) {
    const data = await (await fetch(host(api.today + code))).json();
    
    return data;
}

async function getUpcomming(code) {
    const data = await (await fetch(host(api.upcoming + code))).json();
    
    return data;
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
        if (typeof node === 'string' || typeof node === 'number') {
            node = document.createTextNode(node);
        }
        result.appendChild(node);
    }

    return result;
}