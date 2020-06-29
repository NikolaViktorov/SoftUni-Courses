function attachEventsListeners() {
    const ratios = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    };

    function convert(value, from) {
        return {
            days: value / ratios[from] * ratios.days,
            hours: value / ratios[from] * ratios.hours,
            minutes: value / ratios[from] * ratios.minutes,
            seconds: value / ratios[from] * ratios.seconds
        }
    }
    function display(values) {
        days.value = values.days;
        hours.value = values.hours;
        minutes.value = values.minutes;
        seconds.value = values.seconds;
    }


    const days = document.querySelector('#days');
    const hours = document.querySelector('#hours');
    const minutes = document.querySelector('#minutes');
    const seconds = document.querySelector('#seconds');

    document.querySelector('#daysBtn').addEventListener('click', e => {
        const daysV = Number(days.value);
        const converted = convert(daysV, 'days');
        display(converted);
    });
    const hoursBtn = document.querySelector('#hoursBtn').addEventListener('click', e => {
        const hoursV = Number(hours.value);
        const converted = convert(hoursV, 'hours');
        display(converted);
    });
    const minutesBtn = document.querySelector('#minutesBtn').addEventListener('click', e => {
        const minutesV = Number(minutes.value);
        const converted = convert(minutesV, 'minutes');
        display(converted);
    });
    const secondsBtn = document.querySelector('#secondsBtn').addEventListener('click', e => {
        const secondsV = Number(seconds.value);
        const converted = convert(secondsV, 'seconds');
        display(converted);
    });
    




}