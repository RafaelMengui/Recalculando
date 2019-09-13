using System;

namespace Version2
{
    public class Atributos
    {
        public string Clave { get; set; }
        public string Valor { get; set; }

        public Atributos(string clave, string valor)
        {
            this.Clave = clave;
            this.Valor = valor;
        }
    }
}