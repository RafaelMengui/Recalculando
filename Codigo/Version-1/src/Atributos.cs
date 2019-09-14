using System;

namespace Version1
{
        /// <summary>
        /// Clase atributo, nos permite guardar el atributo en clave y valor.
        /// </summary>

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