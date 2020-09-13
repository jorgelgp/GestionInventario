using GestionInventario.Domain.IEntities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.MVC.Hubs
{
    public class ElementoHub: Hub
    {
        private readonly IElemento _elemento;
        public ElementoHub(IElemento elemento)
        {
            _elemento = elemento;
        }
        public async Task SendBaja(string nombreElemento)
        {
            //Debería de llamar al Api (InventarioController) para eliminar un elemento pero voy a utilizar un atajo.
            if(_elemento.Eliminar(nombreElemento) > 0)
                await Clients.All.SendAsync("BajaElementoMensaje", nombreElemento);
        }

        public async Task GetCaducados()
        {
            //Debería de llamar al Api (InventarioController) para obtener los caducados pero voy a utilizar un atajo.
            var caducados = _elemento.Caducados();

            _ = Clients.All.SendAsync("LimpiarCaducadosElementoMensaje");

            foreach (var elemento in caducados)
            {
                await Clients.All.SendAsync("CaducadoElementoMensaje", String.Format("Elemento: {0} ha caducado", elemento.Nombre));
            }
        }
    }
}
