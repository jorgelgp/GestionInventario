using GestionInventario.Domain.Entities;
using NUnit.Framework;
using NUnitGestionInventario.Mocks;
using System;
using System.Linq;

namespace NUnitGestionInventario
{
    public class TipoElementoTest
    {
        private RepositorioTipoElementoMock repositorioElementoMock;
        private TipoElemento tipoElemento;
        [SetUp]
        public void Setup()
        {
            repositorioElementoMock = new RepositorioTipoElementoMock();
            tipoElemento = new TipoElemento(repositorioElementoMock);
        }

        [Test]
        public void ObtenerTodosTest()
        {
            var retornoTiposElementos = tipoElemento.ObtenerTodos();
            var TipoElementoLacteo = retornoTiposElementos.Where(t => t.Descripcion == "Lacteo").FirstOrDefault();
            var TipoElementoCarnico = retornoTiposElementos.Where(t => t.Descripcion == "Carnico").FirstOrDefault();
            var TipoElementoVerdura = retornoTiposElementos.Where(t => t.Descripcion == "Verdura").FirstOrDefault();
            var TipoElementoFruta = retornoTiposElementos.Where(t => t.Descripcion == "Fruta").FirstOrDefault();
            if (TipoElementoLacteo == null || TipoElementoCarnico == null ||
               TipoElementoVerdura == null || TipoElementoFruta == null)
                Assert.Fail();
            else
                Assert.Pass();
        }
    }
}
