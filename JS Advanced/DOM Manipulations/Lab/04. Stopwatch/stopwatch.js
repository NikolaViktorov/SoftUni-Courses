function stopwatch() {
    let [seconds, minutes] = [0, 0];
    let timeout;
    const timer = document.querySelector('#time');
    const startBtn = document.querySelector('#startBtn');
    const stopBtn = document.querySelector('#stopBtn');

    function add() {
        seconds++
        if (seconds >= 60) {
            seconds = 0
            minutes++
        }

        timer.textContent = (minutes ? (minutes > 9 ? minutes : "0" + minutes) : "00")
            + ":" + (seconds > 9 ? seconds : "0" + seconds)

    }

    startBtn.addEventListener('click', e => {
        // timer start
        timer.textContent = "00:00";
        stopBtn.disabled = false;
        startBtn.disabled = true;
        timeout = setInterval(add, 1000);
    });

    stopBtn.addEventListener('click', e => {
        // timer stop
        startBtn.disabled = false;
        stopBtn.disabled = true;
        clearInterval(timeout);
        seconds = 0;
        minutes = 0;
    });
}