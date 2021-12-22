using System;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Não é possível dar um lance negativo.");
            }
            Cliente = cliente;
            Valor = valor;
            Console.WriteLine("Teste");
        }
    }
}
