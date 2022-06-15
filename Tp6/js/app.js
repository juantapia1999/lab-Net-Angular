
document.getElementById("fechaNacimiento").addEventListener("change", calcularEdad);

function calcularEdad() {

    getEdad();

    let fechaNacimiento = new Date(document.getElementById("fechaNacimiento").value);
    let fechaHoy = new Date();

    let años = fechaHoy.getFullYear() - fechaNacimiento.getFullYear();

    let meses = (fechaHoy.getMonth() + 1) - (fechaNacimiento.getMonth() + 1);

    let dias = (fechaHoy.getDate() + 1) - (fechaNacimiento.getDate() + 1);

    let horas = (fechaHoy.getHours() + 1) - (fechaNacimiento.getHours() + 1);

    let minutos = (fechaHoy.getMinutes() + 1) - (fechaNacimiento.getMinutes() + 1);

    let edad = { año: 0, mes: 0, dia: 0, hora: 0, min: 0 };
    if (años >= 0) {
        edad.año = años;
        if (meses >= 0) {
            edad.mes = meses;
            if (dias >= 0) {
                edad.dia = dias;
                if (horas >= 0) {
                    edad.hora = horas;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = horas - 1;
                        edad.min = 60 + minutos;
                    }
                } else {
                    edad.dia = ((fechaHoy.getDate()) + (fechaNacimiento.getDate())) - 1;
                    edad.hora = fechaHoy.getHours() + 1;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = fechaHoy.getHours();
                        edad.min = fechaHoy.getMinutes() + fechaNacimiento.getMinutes();
                    }
                }
            } else {
                edad.año = años - 1;
                edad.mes = ((fechaHoy.getMonth()) + (fechaNacimiento.getMonth())) + 1;
                edad.dia = ((fechaHoy.getDate()) + (fechaNacimiento.getDate())) - 1;
                if (edad.dia > 31) {
                    edad.dia = edad.dia + dias;
                    edad.mes = meses;
                    edad.año = años;
                }
                if (horas >= 0) {
                    edad.hora = horas;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = fechaHoy.getHours();
                        edad.min = fechaHoy.getMinutes() + fechaNacimiento.getMinutes();
                    }
                } else {
                    edad.dia = ((fechaHoy.getDate()) + (fechaNacimiento.getDate())) - 1;
                    edad.hora = fechaHoy.getHours() + 1;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = fechaHoy.getHours();
                        edad.min = fechaHoy.getMinutes() + fechaNacimiento.getMinutes();
                    }
                }
            }
        } else {
            edad.año = años - 1;
            edad.mes = ((fechaHoy.getMonth()) + (fechaNacimiento.getMonth()));
            if (dias >= 0) {
                edad.dia = dias;
                if (horas >= 0) {
                    edad.hora = horas;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = horas - 1;
                        edad.min = (minutos * -1);
                    }
                } else {
                    edad.dia = dias - 1;
                    edad.hora = (horas * -1);
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = horas - 1;
                        edad.min = (minutos * -1);
                    }
                }
            } else {
                edad.mes = ((fechaHoy.getMonth()) + (fechaNacimiento.getMonth()));
                edad.dia = (fechaHoy.getDate()) + (fechaNacimiento.getDate());
                if (horas >= 0) {
                    edad.hora = horas;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = horas - 1;
                        edad.min = (minutos * -1);
                    }
                } else {
                    edad.dia = (fechaHoy.getDate()) + (fechaNacimiento.getDate()) - 1;
                    edad.hora = horas * -1;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = 60 + horas;
                        edad.min = (minutos * -1);
                    }
                }
            }
        }
    }

    if (edad.año < 0 && edad.mes < 0 && edad.dia < 0 && edad.min < 0) {
        alert("¿Vienes del futuro eh?")
        return;
    }
    //console.log(`${fechaHoy.getFullYear()} ${fechaHoy.getMonth()} ${fechaHoy.getDate()} ${fechaHoy.getHours()} ${fechaHoy.getMinutes()}`);
    //console.log(`${fechaNacimiento.getFullYear()} ${fechaNacimiento.getMonth()} ${fechaNacimiento.getDate()} ${fechaNacimiento.getHours()} ${fechaNacimiento.getMinutes()}`);
    //console.log(`${años} ${meses} ${dias} ${horas} ${minutos}`)
    //console.log("calculado: ")
    //console.log(edad)
    document.getElementById("edadExperimental").textContent = `años: ${edad.año}, meses: ${edad.mes}, dias: ${edad.dia}, horas: ${edad.hora}, minutos: ${edad.min}`;
}

function getEdad() {
    let hoy = new Date()
    let fechaNacimiento = new Date(document.getElementById("fechaNacimiento").value);
    let edad = hoy.getFullYear() - fechaNacimiento.getFullYear()
    let diferenciaMeses = hoy.getMonth() - fechaNacimiento.getMonth()
    if (diferenciaMeses < 0 || (diferenciaMeses === 0 && hoy.getDate() < fechaNacimiento.getDate())) {
        edad--
    }
    document.getElementById("edadExacta").textContent = edad + " años";
}

function submitForm(event) {
    event.preventDefault();
    let nombre = document.getElementById("nombre").value;
    let apellido = document.getElementById("apellido").value;
    let fechaNacimiento = (document.getElementById("fechaNacimiento").value).replace('T', '  ');
    let edadExacta = document.getElementById("edadExacta").textContent;
    let edadExperimental = document.getElementById("edadExperimental").textContent;
    let empresa = document.getElementById("empresa").value;
    let op = {
        m: document.getElementById("op1").checked,
        f: document.getElementById("op2").checked,
        o: document.getElementById("op3").checked
    }
    let sexo = op.m ? "masuclino" : (op.f ? "femenino" : "otro");
    let message = `Nombre: ${nombre}\nApellido: ${apellido}\nFecha de Nacimiento: ${fechaNacimiento}\nEdad exacta: ${edadExacta}\nEdad experimental: ${edadExperimental}\nSexo: ${sexo}\nEmpresa: ${empresa}`;
    alert(message);
}

function resetForm() {
    document.getElementById("nombre").value="";
    document.getElementById("apellido").value="";
    document.getElementById("fechaNacimiento").value="";
    document.getElementById("edadExacta").textContent="";
    document.getElementById("edadExperimental").textContent="";
    document.getElementById("empresa").value="";
    document.getElementById("op1").checked=true;
    document.getElementById("op2").checked=false;
    document.getElementById("op3").checked=false;
}