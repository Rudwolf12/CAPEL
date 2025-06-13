// js/contact-form.js

function enviarFormulario(event) {
    event.preventDefault();

    const nombre = document.getElementById("nombre").value;
    const telefono = document.getElementById("telefono").value;
    const email = document.getElementById("email").value;
    const mensaje = document.getElementById("mensaje").value;

    // Validación de campos
    if (!nombre || !email || !mensaje) {
        mostrarMensajeError("Por favor, completa todos los campos requeridos.");
        return;
    }

    if (email && !validarEmail(email)) {
        mostrarMensajeError("Por favor, ingresa un correo electrónico válido.");
        return;
    }

    // Mostrar mensaje de éxito
    document.getElementById("respuesta-formulario").innerText =
        `Gracias por tu mensaje, ${nombre}. Te responderemos pronto.`;

    // Limpiar el formulario
    document.querySelector("form").reset();
}

// Función para validar el formato de un correo electrónico
function validarEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}

// Función para mostrar mensajes de error
function mostrarMensajeError(mensaje) {
    const respuestaFormulario = document.getElementById("respuesta-formulario");
    respuestaFormulario.style.color = "red";
    respuestaFormulario.innerText = mensaje;
}
