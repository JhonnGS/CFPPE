//esta es la funcion que contiene la condicion del cual se evaluara y enviara el mensaje a la vista de contratos 
function mensaje() {
	if ($("#mensaje").val() == "1") {
		InfoTime("Mensaje", "Información enviada");
	} if ($("#mensaje").val == "0") {
		InfoTime("Mensaje", "Error información no enviada");
	}
}

function comprueba_extension(archivo) {
	
	var file = document.getElementById(archivo).value;
	extensiones_permitidas = new Array(".jpg");//arreglo que define las extensiones que se permiten

	mierror = "";
	if (!file) {//si file es diferente no hace nada es decir que si file no tiene nada no hara nada pero si no
	} else {//entra a evaluar

		extension = (file.substring(file.lastIndexOf("."))).toLowerCase();//para obtener la extencion del archivo
		permitida = false;// de tipo booleano pero sei inicializa con faLSE
		for (var i = 0; i < extensiones_permitidas.length; i++) {
			if (extensiones_permitidas[i] == extension) {
				permitida = true;
			}
		}
		if (!permitida) {//evalua si partida es diferente es decir si tiene un valor entrara al mensaje sino pasa al else
			InfoTime("Alerta", 'Sólo se permiten cargar archivos con extensiones: ".pdf"');
			var vacio = document.getElementById(archivo).value = "";//pone en blanco el textbox
		} else {
			return 1;
		}
	}
	return 0;

}

function ValidarNomDesc(input, id) {
	var valor = input;
	const re = /^[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]*)(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]*)+$/g;
	var validado = valor.match(re);
	if (!validado) {
		document.getElementById(id).value = "";
		InfoTime("Advertencia", "El campo solo acepta letras, numeros y letras con acentos, no debe ir vacío, no acepta signos, ni puntuaciones($#%.,;)");
		return false;
	} else {

	}
}

function Tel(input, id) {
	var tel = input;
	const re = /^([0-9])*$/;
	var validado = tel.match(re);

	if (tel.length == 10 && validado || tel.length == 12 && validado || tel.length == 13 && validado) {

	} else {
		document.getElementById(id).value = "";
		InfoTime("Advertencia", "Debe de ingresar un teléfono correcto");
		return false;
	}
}
//function Tel (inputtxt) {
//	var phoneno = /^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/;
//	if (inputtxt.value.match(phoneno)) {
//		return true;
//	}
//	else {
//		alert("message");
//		return false;
//	}
//} 

//function ValidarEmpresa(input, id) {
//	var valor = input;
//	const re = /^[a-z0-9A-ZÀ-ÿ\u00f1\u00d1\.]+(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1○\.]*)(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1\.]*)+$/g;
//	var validado = valor.match(re);
//	if (!validado) {
//		document.getElementById(id).value = "";
//		InfoTime("Advertencia", "El campo solo acepta letras, numeros y letras con acentos, no debe ir vacío, no acepta signos, ni puntuaciones($#%.,;)");
//		return false;
//	} else {

//	}
//}


//ni idea donde se utiliza checar bien con precision antes de hacerle algo
//function ValidarResponsable(input, id) {
//	var valor = input;
//	const re = /^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)+$/g;
//	var validado = valor.match(re);
//	if (!validado) {
//		document.getElementById(id).value = "";
//		InfoTime("Advertencia", "El campo solo acepta letras y letras con acentos, no debe ir vacío, no acepta signos ni puntuaciones($#%.,;)");
//		return false;
//	} else {

//	}
//}

function ValidaCorreo(input, id) {
	var valor = input;
	const re = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/ ;
	var validado = valor.match(re);
	if (!validado) {
		document.getElementById(id).value = "";
		InfoTime("Advertencia", " correo incorrecto");
		return false;
	} else {

	}
}

//function validarEmail(valor) {
//	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3,4})+$/.test(valor)) {
//		alert("La dirección de email " + valor + " es correcta.");
//	} else {
//		alert("La dirección de email es incorrecta.");
//	}
//}
function ValidarClave(input, id) {
	var valor = input;
	const re = /^[A-Z0-9a-zñÑ\&]*$/;
	var validado = valor.match(re);
	if (!validado) {
		document.getElementById(id).value = "";
		InfoTime("Advertencia", "El campo solo acepta letras y numeros, no debe ir vacío, no acepta espacios en blanco, ni signos ni puntuaciones($#%.,;)");
		return false;
	}
	else {

	}
}
// en uso pero cambiar nombre
function calle(e) {
	tecla = (document.all) ? e.keyCode : e.which;
	if (tecla == 8) { return true; }
	patron = /[A-Za-z0-9ñÑ\u0020\À-ÿ]/;
	tecla_final = String.fromCharCode(tecla);
	return patron.test(tecla_final);
}

//en uso pero cambia nombre
//function calleEmpresa(e) {
//	tecla = (document.all) ? e.keyCode : e.which;
//	if (tecla == 8) { return true; }
//	patron = /[A-Za-z0-9ñÑ\u0020\À-ÿ\.]/;
//	tecla_final = String.fromCharCode(tecla);
//	return patron.test(tecla_final);
//}

//// en uso pero modificar para que me regrese el valor que tenia por default
//function ValidarClaveEditar(input, id) {
//	var valor = input;
//	const re = /^[A-Z0-9a-zñÑ\&]*$/;
//	var validado = valor.match(re);
//	if (!validado) {
//		document.getElementById(id).value = valor;
//		InfoTime("Advertencia", "El campo solo acepta letras y numeros, no debe ir vacío, no acepta espacios en blanco, ni signos ni puntuaciones($#%.,;)");
//		return false;
//	}
//	else {

//	}
//}

//// en uso pero modificar para que me regrese el valor que tenia por default
//function ValidarNombreDescripcionE(input, id) {
//	var valor = input;
//	const re = /^[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]*)(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]*)+$/g;
//	var validado = valor.match(re);
//	if (!validado) {
//		document.getElementById(id).value = descripcion;
//		InfoTime("Advertencia", "El campo solo acepta letras, numeros y letras con acentos, no debe ir vacío, no acepta signos, ni puntuaciones($#%.,;)");
//		return false;
//	} else {

//	}
//}
//en uso pero creo que esta funcion es para editar para lo mismo que en las otras funciones que son de editar
//function ValidarEmpresa(input, id) {
//	var valor = input;
//	const re = /^[a-z0-9A-ZÀ-ÿ\u00f1\u00d1\.]+(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1○\.]*)(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1\.]*)+$/g;
//	var validado = valor.match(re);
//	if (!validado) {
//		document.getElementById(id).value = "";
//		InfoTime("Advertencia", "El campo solo acepta letras, numeros y letras con acentos, no debe ir vacío, no acepta signos, ni puntuaciones($#%.,;)");
//		return false;
//	} else {

//	}
//}
//en uso
//solo numeros
function numero(input, id) {
	var valor = input;
	const re = /^([0-9])*$/;
	var validado = valor.match(re);
	if (!validado) {
		document.getElementById(id).value = "";
		InfoTime("Advertencia", "Este campo solo acepta nùmeros($#%.,;)");
		return false;
	} else {

	}
}
////en uso
//function ValidarNombre(input, id) {
//	var valor = input;
//	const re = /^[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]*)(\s*[a-z0-9A-ZÀ-ÿ\u00f1\u00d1]*)+$/g;
//	var validado = valor.match(re);
//	if (!validado) {
//		document.getElementById(id).value = "";
//		InfoTime("Advertencia", "El campo solo acepta letras, numeros y letras con acentos, no debe ir vacío, no acepta signos, ni puntuaciones($#%.,;)");
//		return false;
//	} else {

//	}
//}

//en uso
function Password(input, id) {
	var valor = input;
	const re = /^[a-z0-9_-]{6,8}$/
	var validado = valor.match(re);
	if (!validado) {
		document.getElementById(id).value = "";
		InfoTime("Advertencia", "Este campo solo permite de 6 a 8 csrscteres, no permite espacios en blancos($#%.,;)");
		return false;
	} else {
	}
}

//en uso
function valusuario(input, id) {
	//Consultar en la BD si existe este usuario
	var usuario = $("#usuario").val();//Obtenemos el valor ingresado del input
	//Buscamos en la base de datos el valor
	$.getJSON('/Usuarios/obtenerUsuario', { usuario: usuario }, function (data) {
		$.each(data, function () {
			console.log(data.usuario);
			if (data != null) {
				InfoTime("Advertencia", "Usuario existente, ingrese otro nombre de usuario");
				document.getElementById(id).value = "";
			}

		});
	}).fail(function (jqXHR, textStatus, errorThrown) {
		InfoTime("Advertencia", "Error al consultar datos");
	});


	console.log(usuario);
}

//esta es la funcion que contiene la condicion del cual se evaluara y enviara el mensaje a la vista de contratos 
function mensaje() {
	if ($("#mensaje").val() == "1") {
		InfoTime("Mensaje", "Información enviada, Por el momento no cuenta con Home se notificara cuando este listo");
	} if ($("#mensaje").val == "0") {
		InfoTime("Mensaje", "Error información no enviada");
	}
}

////esta es la funcion que contiene la condicion del cual se evaluara y enviara el mensaje 
//function mensaje() {

//}

//en uso
var activadoMostrar = false;
$('#btn-mostrar-pass').click(function () {
	if (activadoMostrar) {
		activadoMostrar = false; //La cambiamos a 0
		$('#txtPass').removeAttr("type", "text"); //Removemos el atributo de Tipo Texto
		$('#txtPass').prop("type", "password"); //Agregamos el atributo de Tipo Contraseña
	} else {
		activadoMostrar = true;
		$('#txtPass').removeAttr("type", "password"); //Removemos el atributo de Tipo Contraseña
		$('#txtPass').prop("type", "text"); //Agregamos el atributo de Tipo Texto(Para que se vea la Contraseña escribida)
	}
});


