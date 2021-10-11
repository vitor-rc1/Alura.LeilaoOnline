using System;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoCLienteRealizouUltimoLance()
        {
            // Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Mona Lisa", modalidade);
            var tiago = new Interessada("Tiago", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(tiago, 500);


            // Act
            leilao.RecebeLance(tiago, 1000);

            // Assert

            var qtdEsperada = 1;
            var qtdObtida = leilao.Lances.Count();

            Assert.Equal(qtdEsperada, qtdObtida);
        }

        [Theory]
        [InlineData(4, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(1, new double[] { 800 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(
            int qtdEsperado,
            double[] ofertas)
        {
            // Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Mona Lisa", modalidade);
            var tiago = new Interessada("Tiago", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(tiago, valor);
                    continue;
                }
                
                leilao.RecebeLance(maria, valor);
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
