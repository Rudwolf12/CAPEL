// js/contacto-switcher.js

function cambiarMetodoContacto() {
    const metodo = document.getElementById("metodo").value;
    const formulario = document.getElementById("formulario-contacto");
    const whatsapp = document.getElementById("whatsapp-contacto");

    // Verificar que los elementos existen antes de intentar manipularlos
    if (formulario && whatsapp) {
        // Ocultar o mostrar los elementos dependiendo del valor seleccionado
        if (metodo === "whatsapp") {
            formulario.style.display = "none";
            whatsapp.style.display = "block";
            // Enfocar el enlace de WhatsApp para mejorar la accesibilidad
            whatsapp.querySelector('a').focus();
        } else {
            formulario.style.display = "block";
            whatsapp.style.display = "none";
            // Enfocar el primer campo del formulario para que el usuario pueda empezar a escribir
            formulario.querySelector('input').focus();
        }
    } else {
        console.warn("Faltan elementos en el DOM: 'formulario-contacto' o 'whatsapp-contacto'");
    }
}
