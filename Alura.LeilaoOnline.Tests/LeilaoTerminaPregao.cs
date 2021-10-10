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
            leilao.IniciaPregao();
            // Act
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoInciado()
        {
            // Arrange
            var leilao = new Leilao("Mona Lisa");
            
            // Assert
            var exececaoObtida = Assert.Throws<System.InvalidOperationException>(
                // Act
                () => leilao.TerminaPregao()
                );
            var msgEsperada = "Não é possivel finalizar o pregão sem ter inicializa-lo";
            Assert.Equal(msgEsperada, exececaoObtida.Message);
            
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

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);


        }
    }
}
