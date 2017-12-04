function validarCorreo(email) {
  var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  if(re.test(email))
  { 
  }
  else
  {
	alert("Formato incorrecto en correo");
	return false;
  }
}

function validarNombre(evt)
{
	evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
    }
	else
	{
	alert ("Uno de los campos no puede ingresar números.");
    return false;
	}
	
	if(evt == "") 
	{
		alert ("Llene campos vacíos");
		return false;
	}	
}

function validarValor(Valor)
{
	if (Number(Valor)) {}
	else {
		alert("Ingrese sólo números (0-9)");
		return false;
	}
	if(Number(Valor) == 0) 
	{
		alert ("Ingrese un número mayor a 0");
		return false;
	}
}

function validarCarrito()
{
	var Nombre, Valor, Productor, Stock;
	Nombre = document.getElementById("Label1").value;
	Valor = document.getElementById("Label2").value;
	Productor = document.getElementById("Label3").value;
	Stock = document.getElementById("Label5").value;

	validarNombre(Nombre);
	validarValor(Valor);
	
	if(Productor == "")
	{
		alert ("Ingrese campo 'Productor'");
		return false;
	}	
	if (Number(Stock))
	{
		alert(Stock);
		return false;
	}
	else 
	{
		alert("Ingrese sólo números (0-9)");
		return false;
	}	
		if(Stock == "") 
	{
		alert ("Ingrese campo 'Stock'");
		return false;
	}	

function validarClave()
{
	var ClaveActual, ClaveNueva, ClaveConfirmar;
	ClaveActual = document.getElementById("txtCActual").value;
	ClaveNueva = document.getElementById("txtCNueva").value;
	ClaveConfirmar = document.getElementById("txtConfirmarCNueva").value;
	
	if (ClaveActual == ClaveNueva)
	{
		alert ("No se puede renovar la clave usando la clave actual.");
		return false;
	}
	if (ClaveNueva == ClaveConfirmar)
	{
		alert ("La clave nueva no se ha escrito correctamente. Intente de nuevo.")
		return false;
	}
}

function validarMensaje()
{
	var Para, CC, Asunto, Comentario;
	Para = document.getElementById("txtPara").value;
	CC = document.getElementById("txtCC").value;
	Asunto = document.getElementById("txtAsunto").value;
	Comentario = document.getElementById("txtComentario").value;
	Terminos = document.getElementById("cbxTerminos").value;
	
	if(Para == "")
	{
		alert ("Ingrese un remitente.");
		return false;
	}	
	if(Asunto == "")
	{
		alert ("Debe especificar un mensaje.");
		return false;
	}
	
	return Terminos;
}

function validarCierre()
{
	var Clave = document.getElementById("TextBox1").value;
	if (Clave == "")
	{
		alert("No puede ingresar el campo vacío.");
		return false;
	}
}

function validarIngreso()
{
	var Clave = document.getElementById("txtIngrese").value;
	if (Clave == "")
	{
		alert("No puede ingresar el campo vacío.");
		return false;
	}
}

function validarBoleta()
{
	var Boleta, Rut, Valor;
	
	Boleta = document.getElementById("txtnumerob").value;
	if (Boleta == "")
	{
		alert("No puede ingresar el campo 'Boleta' vacío.");
		return false;
	}
	
	Rut = document.getElementById("txtRutC").value;
	if (Rut == "")
	{
		alert("No puede ingresar el campo 'Rut' vacío.");
		return false;
	}
	validarRut(Rut);

	validarValor(Valor);
}

function validarRut(Rut)
{
	var rexp = new RegExp(/^([0-9])+\-([kK0-9])+$/);
    if(Rut.match(rexp)){
        var RUT		= rut.split("-");
        var elRut	= RUT[0].toArray();
        var factor	= 2;
        var suma	= 0;
        var dv;
        for(i=(elRut.length-1); i>=0; i--){
            factor = factor > 7 ? 2 : factor;
            suma += parseInt(elRut[i])*parseInt(factor++);
        }
        dv = 11 -(suma % 11);
        if(dv == 11){
            dv = 0;
        }else if (dv == 10){
            dv = "k";
        }

        if(dv == RUT[1].toLowerCase()){
        }else{            
            alert("El RUT no es válido.");
            return false;
        }
    }else{        
        alert("Formato incorrecto. El formato correcto es 12345678-9");
        return false;
    }
}

function validarCuenta()
{
	var Rut, Nombre, Paterno, Materno, Correo, Contacto;
	Rut = document.getElementById("txtRut").value;
	Nombre = document.getElementById("txtNombre").value;
	Paterno = document.getElementById("txtApellidoP").value;
	Materno = document.getElementById("txtApellidoM").value;
	Correo = document.getElementById("txtCorreo").value;
	Contacto = document.getElementById("txtContacto").value;
	
	validarRut(Rut);
	validarNombre(Nombre);
	validarNombre(Paterno);
	validarNombre(Materno);
	validarCorreo(Correo);

	if (Number(Contacto)) {}
	else {
		alert("Ingrese sólo números (0-9)");
		return false;
	}
}

function validarNombreyValor()
{
	var Nombre, Valor
	Nombre = document.getElementById("txtNombreP").value;
	Valor = document.getElementById("txtValor").value;

	validarNombre(Nombre);
	validarValor(Valor);
}

function validarAlCarrito()
{
    var Cantidad = document.getElementById("txtCarrito").value;

    validarValor(Cantidad);
}

}