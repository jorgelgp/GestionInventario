using GestionInventario.Domain.Entities;
using GestionInventario.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitGestionInventario.Mocks
{
    public class RepositorioTipoElementoMock : RepositorioMock<TipoElemento>, IRepositorioTipoElemento
    {
    }
}
