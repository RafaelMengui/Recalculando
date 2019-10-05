using System;

namespace LeerHTML
{
    /// <summary>
    /// Clase atributo, nos permite guardar el atributo en clave y valor.
    /// </summary>
    public class Atributos
    {
        public string clave { get; set; }
        public string valor { get; set; }

        public Atributos(string clave, string valor)
        {
            this.clave = clave;
            this.valor = valor;
        }
    }
}