using GestionInventario.Domain.Entities;
using NUnit.Framework;
using NUnitGestionInventario.Mocks;
using System;
using System.Linq;

namespace NUnitGestionInventario
{
    public class ElementoTest
    {
        private RepositorioElementoMock repositorioElementoMock;
        private Elemento elemento;

        [SetUp]
        public void Setup()
        {
            repositorioElementoMock = new RepositorioElementoMock();
            elemento = new Elemento(repositorioElementoMock);
        }

        [Test]
        public void AnadirTest()
        {
            Assert.AreEqual(5,elemento.Anadir());
        }

        [Test]
        public void ObtenerTest()
        {
            var retornoElemento = elemento.Obtener("Platano").FirstOrDefault();
            if (2 == retornoElemento.Id &&
               "Platano" == retornoElemento.Nombre &&
                4 == retornoElemento.TipoElementoId &&
                DateTime.Now.AddDays(2) == retornoElemento.Caducidad)
                Assert.Pass();
        }

        [Test]
        public void CaducadosTest()
        {
            var retornoElemento = elemento.Caducados().FirstOrDefault();
            if (retornoElemento.Id == 1 &&
               retornoElemento.Nombre == "Mango" &&
               retornoElemento.TipoElementoId == 4 &&
               retornoElemento.Caducidad <= DateTime.Now)
                Assert.Pass();
        }

        [Test]
        public void EliminarTest()
        {
            if(elemento.Eliminar("Platano") == 1 &&
               elemento.Eliminar("Banana") == 0)
                Assert.Pass();
        }
    }
}
