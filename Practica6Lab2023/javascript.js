




ObtenerLocalStorage();
var NumeroAleatorio;
var ContadorPuntaje = 15; // ya sabemos que tiene 15 intentos
const canvas = document.getElementById('confetti');

function ValidarNombre() {

    let isValid = false;
    const pattern = new RegExp('^[A-Z]+$', 'i');
    const maxLength = 15;
    MostrarMensaje = '';


    var inputNombre = document.getElementById('nombre');
    if (!inputNombre.value) {
        nombre.style.borderColor = 'red'
        isValid = false;
        MostrarMensaje = '<h3>' + 'Ingresa Un Nombre Para Jugar' + '</h3>';
    } else if (inputNombre.value.length > maxLength) {
        isValid = false;
        inputNombre.style.borderColor = 'sal'
        MostrarMensaje = '<h3>' + 'Se supero el numero maximo de caracteres(1-15)' + '</h3>';
    }
    else if (!pattern.test(nombre.value)) {
        inputNombre.style.borderColor = 'red'
        isValid = false;
        MostrarMensaje = '<h3>' + 'Solo se permiten Letras' + '</h3>';

    }
    else {
        document.getElementById('Juego').style.display = '';
        document.getElementById('OcultarContenedor').style.display = 'none';
        isValid = true;
        inputNombre.style.borderColor = 'green'

        NumeroAleatorio = Numeroaleatorio(1, 15);

        let ocultarBotonReiniciar = document.getElementById('boton-reiniciar');
        ocultarBotonReiniciar.style.display = 'none';
        let botonReiniciar = document.getElementById('boton-reiniciar');
        botonReiniciar.addEventListener('click', ReiniciarJuego);

    }
    MensajesForm(MostrarMensaje);
}

function AdivinarNumero(e) {

    let spanVidasJugador = document.getElementById('contador_vidas_jugador');
    let inputNumero = document.getElementById('numero');

    if (inputNumero.value == '' || parseInt(inputNumero.value) < 1 || parseInt(inputNumero.value) > 15) {
        mensajeResultado = MensajesJuego('Ingresa un numero entre 1 - 15');
    }
    else if (inputNumero.value > NumeroAleatorio) {
        mensajeResultado = MensajesJuego('Tu numero es Menor');
        ContadorPuntaje--;
        spanVidasJugador.innerHTML = ContadorPuntaje;

    } else if (inputNumero.value < NumeroAleatorio) {
        mensajeResultado = MensajesJuego('Tu numero es Mayor');
        ContadorPuntaje--;
        spanVidasJugador.innerHTML = ContadorPuntaje;
    }
    else {

        let highscore = parseInt(localStorage.getItem("highscore"));
        if (highscore < ContadorPuntaje) {
            localStorage.setItem('highscore', ContadorPuntaje);
            ObtenerLocalStorage();
        }

        document.body.style.backgroundColor = "green";
        mensajeResultado = MensajesJuego('Adivinaste el numero, Felicitaciones Ganaste' + ' ' + (nombre.value).toUpperCase());
        let ocultarBotonReiniciar = document.getElementById('boton-reiniciar');
        ocultarBotonReiniciar.style.display = 'block'; // NONE PARA OCULTAR BOTON REINICIAR QUE LUEGO MOSTRAREMOS AL FINALIZAR EL COMBATE

        const jsConfetti = new JSConfetti({ canvas })
        jsConfetti.addConfetti({
            emojis: ['🎉', '1️⃣', '2️⃣', '💥', '3️⃣', '9️⃣', '6️⃣', '🎉'],
        })

    }

    if (ContadorPuntaje == 0) {

        mensajeResultado = MensajesJuego('Perdiste, Vuelve a intentarlo' + ' ' + (nombre.value));
        document.body.style.backgroundColor = "crimson";
        let ocultarBotonReiniciar = document.getElementById('boton-reiniciar');
        ocultarBotonReiniciar.style.display = 'block'; // NONE PARA OCULTAR BOTON REINICIAR QUE LUEGO MOSTRAREMOS AL FINALIZAR EL COMBATE

        const jsConfetti = new JSConfetti({ canvas })
        jsConfetti.addConfetti({
            emojis: ['😭', '😭', '😓', '😭', '😭', '😭', '😪', '😭'],
        })
    }


}


function MensajesForm(Contenido) {
    document.getElementById('Mensajes').innerHTML = Contenido;
}

function MensajesJuego(mensajeResultado) {

    let contenedorMensajes = document.getElementById('Mensajes2')
    let parrafo = document.createElement('p');

    parrafo.classList.add('animate__animated', 'animate__fadeInTopLeft');
    parrafo.innerHTML = mensajeResultado;
    contenedorMensajes.appendChild(parrafo)
}


function Numeroaleatorio(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min)
}

function ObtenerLocalStorage() {
    var PuntajeSuperar = document.getElementById('highscore');
    let PuntajeFinal = localStorage.getItem("highscore")

    if (PuntajeFinal === null) {
        localStorage.setItem('highscore', 0);
    }

    PuntajeSuperar.innerHTML = PuntajeFinal;
}

function ReiniciarJuego() {
    location.reload();
}

