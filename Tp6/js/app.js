
document.getElementById("fechaNacimiento").addEventListener("change", calcularEdad);

function calcularEdad() {
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
                        edad.min = (minutos * -1);
                    }
                } else {
                    edad.dia = dias - 1;
                    edad.hora = fechaHoy.getHours() +1;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = fechaHoy.getHours();
                        edad.min = fechaHoy.getMinutes() + fechaNacimiento.getMinutes() ;
                    }
                }
            } else {
                edad.mes = meses - 1;
                edad.dia = ((fechaHoy.getDate()) + (fechaNacimiento.getDate())) - 1;
                if (horas >= 0) {
                    edad.hora = horas;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = fechaHoy.getHours();
                        edad.min = fechaHoy.getMinutes() + fechaNacimiento.getMinutes() ;
                    }
                } else {
                    edad.dia = ((fechaHoy.getDate()) + (fechaNacimiento.getDate()))-1;
                    edad.hora = fechaHoy.getHours() +1;
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = fechaHoy.getHours();
                        edad.min = fechaHoy.getMinutes() + fechaNacimiento.getMinutes() ;
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
                    edad.dia = dias - 1;
                    edad.hora = (horas * -1);
                    if (minutos >= 0) {
                        edad.min = minutos;
                    } else {
                        edad.hora = horas - 1;
                        edad.min = (minutos * -1);
                    }
                }
            }
        }
    } else {
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
                        edad.min = (minutos * -1);
                    }
                } else {
                    edad.dia = dias - 1;
                    edad.hora = (horas * -1);
                }
            } else {
                edad.mes = meses - 1;
                edad.dia = (dias * -1);
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
            }
        } else {
            edad.año = años - 1;
            edad.mes = (meses * -1);
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
                edad.mes = meses - 1;
                edad.dia = (dias * -1);
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
            }
        }
    }
    console.log(`${fechaHoy.getFullYear()} ${fechaHoy.getMonth()} ${fechaHoy.getDate()} ${fechaHoy.getHours()} ${fechaHoy.getMinutes()}`);
    console.log(`${fechaNacimiento.getFullYear()} ${fechaNacimiento.getMonth()} ${fechaNacimiento.getDate()} ${fechaNacimiento.getHours()} ${fechaNacimiento.getMinutes()}`);
    console.log(`${años} ${meses} ${dias} ${horas} ${minutos}`)
    console.log("calculado: ")
    console.log(edad)
    document.getElementById("edad").textContent;
}