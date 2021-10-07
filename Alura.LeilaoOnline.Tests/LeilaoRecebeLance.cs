using System;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(4, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(1, new double[] { 800 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(
            int qtdEsperado,
            double[] ofertas)
        {
            // Arrange
            var leilao = new Leilao("Mona Lisa");
            var tiago = new Interessada("Tiago", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(tiago, valor);
            }

            leilao.TerminaPregao();

            // Act
            leilao.RecebeLance(tiago, 1000);

            // Assert
            
            var qtdObtida = leilao.Lances.Count();

            Assert.Equal(qtdEsperado, qtdObtida);
        }
    }
}
