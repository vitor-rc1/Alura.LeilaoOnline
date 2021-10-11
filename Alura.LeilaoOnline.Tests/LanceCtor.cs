using System;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            // Arrange
            var valorNegativo = -100;

            // Assert
            Assert.Throws<ArgumentException>(
                // Act
                () => new Lance(null, valorNegativo)
            );
        }
    }
}
