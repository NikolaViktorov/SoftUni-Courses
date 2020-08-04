export default function notify(message, selector) {
    const notification = document.querySelector(selector);
    notification.textContent = message;
    notification.style.display = 'block';

    if (selector === '#successBox')
    notification.addEventListener('click', () => {
        notification.style.display = 'none';
    })
}