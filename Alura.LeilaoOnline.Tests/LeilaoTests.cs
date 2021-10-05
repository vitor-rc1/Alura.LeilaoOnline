using System;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTests
    {
        [Fact]
        public void LeilaoComVariosLances()
        {
            // Arrange
            var leilao = new Leilao("Mona Lisa");
            var tiago = new Interessada("Tiago", leilao);
            var vanessa = new Interessada("Vanessa", leilao);

            leilao.RecebeLance(tiago, 750);
            leilao.RecebeLance(vanessa, 800);
            leilao.RecebeLance(tiago, 1200);
            leilao.RecebeLance(vanessa, 950);

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComUmLance()
        {
            // Arrange
            var leilao = new Leilao("Mona Lisa");
            var tiago = new Interessada("Tiago", leilao);

            leilao.RecebeLance(tiago, 750);

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 750;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
