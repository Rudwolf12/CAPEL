// js/header.js
function toggleMenu() {
    const menu = document.getElementById('nav-links');

    if (menu.style.display == 'none') {
        menu.style.display = 'block';
    } else {
        menu.style.display = 'none';
    }
}
