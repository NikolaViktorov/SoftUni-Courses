function solve() {

    const baseUrl = 'https://judgetests.firebaseio.com/schedule/';
    let busStopId = 'depot';
    let busStopName = 'depot';
    const stopInfo = document.getElementById('info');
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');


    function depart() {
        fetch(baseUrl + `${busStopId}.json`)
            .then(res => res.json())
            .then(data => {
                showInfo(data);;
            })

        function showInfo(data) {
            stopInfo.textContent = `Next stop ${data.name}`;
            busStopId = data.next;
            busStopName = data.name;
            switchState();
        }
    }

    function switchState() {
        if (departBtn.disabled) {
            departBtn.disabled = false;
            arriveBtn.disabled = true;
        } else {
            arriveBtn.disabled = false;
            departBtn.disabled = true;
        }
    }
    

    function arrive() {
        stopInfo.textContent = `Arriving at ${busStopName}`;
        switchState();
    }

    return {
        depart,
        arrive
    };
}

let result = solve();