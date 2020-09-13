const connection = new signalR.HubConnectionBuilder()
    .withUrl("/elementoHub").build();

var conectionStarted = false;

document.getElementById("deleteButton").disabled = true;

connection.on("BajaElementoMensaje", function (nombreElemento) {
    var msg = nombreElemento.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;
    var li = document.createElement("li",);
    li.textContent = encodedMsg;
    li.classList.add("list-group-item");
    document.getElementById("mensajeBaja").appendChild(li);    
});

connection.on("CaducadoElementoMensaje", function (nombreElemento) {
    var msg = nombreElemento.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;
    var li = document.createElement("li");
    li.classList.add("list-group-item");
    li.textContent = encodedMsg;
    document.getElementById("mensajeCaducado").appendChild(li);
});

connection.on("LimpiarCaducadosElementoMensaje", function () {
    var elemento = document.getElementById("mensajeCaducado");
    while (elemento.firstChild) {
        document.getElementById("mensajeCaducado").removeChild(elemento.firstChild);
    }
});

connection.start().then(function () {
    document.getElementById("deleteButton").disabled = false;
    conectionStarted = true;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("deleteButton").addEventListener("click", function (event) {
    var elemento = document.getElementById("elementoInput").value;
    connection.invoke("SendBaja", elemento).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function ComprobarCaducados() {
    setTimeout('ComprobarCaducados()', 5000);
    if (conectionStarted == true)
        connection.invoke("GetCaducados").catch(function (err) {
            return console.error(err.toString());
        });
}

function addElemento() {
    const uri = 'api/inventario';
    const addNombreTextbox = document.getElementById('nombreAdd');
    const addCaducidadTextbox = document.getElementById('caducidadAdd');
    const addTipoCmb = document.getElementById('cmbTipo');

    const item = {
        nombre: addNombreTextbox.value.trim(),
        caducidad: addCaducidadTextbox.value.trim(),
        tipo: parseInt(addTipoCmb.options[addTipoCmb.selectedIndex].value.trim(), 10)
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            addNombreTextbox.value = '';
            addCaducidadTextbox.value = '';
            addTipoCmb.selectedIndex = 0;
        })
        .catch(error => console.error('Error añadiendo el elemento al inventario.', error));
}

function GetTipoElemento() {
    const uri = 'api/tipoelemento';
    fetch(uri)
        .then(response => response.json())
        .then(data => fillComboTipo(data))
        .catch(error => console.error('Error obteniendo todos los tipos de elementos.', error));
}

function fillComboTipo(data) {
    var select = document.getElementById("cmbTipo");
    select.options[0] = new Option("Seleccione un tipo", "");
    select.options[0].disabled;
    for (var i = 0; i < data.length; i++) {
        select.options[i + 1] = new Option(data[i].descripcion, data[i].id);
    }
}


