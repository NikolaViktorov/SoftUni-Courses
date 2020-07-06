function getInfo() {
    const baseUrl = 'https://judgetests.firebaseio.com/businfo/{stopId}.json';
    const stopIdInput = document.querySelector('#stopId');
    const stopName = document.querySelector('#stopName');
    const buses = document.querySelector('#buses');

    const validIds = ['1287', '1308', '1327', '2334'];
    
    const stopId = stopIdInput.value;
    if (validIds.includes(stopId) === false) {
        stopName.textContent = 'Error';
        clearBuses();
        return;
    }

    const url = baseUrl.replace('{stopId}', stopId);
    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            showInfo(data);
        });


    function showInfo(data) {
        stopName.textContent = data.name;

        clearBuses();
        const keys = Object.keys(data.buses);
        for(let i = 0; i < keys.length; i++) {
            const li = document.createElement('li');
            li.textContent = `Bus ${keys[i]} arrives in ${data.buses[keys[i]]} minutes`;
            buses.appendChild(li);
        }
    }

    function clearBuses() {
        while(buses.children.length > 0) {
            buses.children[0].remove();
        }
    }
}