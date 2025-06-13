// js/main.js

document.addEventListener("DOMContentLoaded", function () {
    // Asegurarse de que la función 'cambiarMetodoContacto' exista antes de llamarla
    if (typeof cambiarMetodoContacto === "function") {
        cambiarMetodoContacto();
    } else {
        console.warn("La función cambiarMetodoContacto no está definida.");
    }
});

