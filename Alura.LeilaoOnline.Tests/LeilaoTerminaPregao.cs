using System;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            // Arrange
            var leilao = new Leilao("Mona Lisa");

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaComPeloMenosUmLance(
            double valorEsperado,
            double[] ofertas)
        {
            // Arrange
            var leilao = new Leilao("Mona Lisa");
            var tiago = new Interessada("Tiago", leilao);
            
            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(tiago, valor);
            }

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);


        }
    }
}
