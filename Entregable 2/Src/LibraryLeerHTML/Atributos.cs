using System;

namespace Proyecto.LeerHTML
{
    /// <summary>
    /// Clase atributo, nos permite guardar el atributo en clave y valor.
    /// </summary>
    public class Atributos
    {
        /// <summary>
        /// Clave del atributo.
        /// </summary>
        private string clave;

        /// <summary>
        /// Valor del atributo.
        /// </summary>
        private string valor;

        /// <summary>
        /// Constructor de Atributos.
        /// </summary>
        /// <param name="clave">String clave.</param>
        /// <param name="valor">String Valor.</param>
        public Atributos(string clave, string valor)
        {
            this.Clave = clave;
            this.Valor = valor;
        }

        /// <summary>
        /// Gets or sets de Clave del Atributo.
        /// </summary>
        /// <value>string clave.</value>
        public string Clave { get; set; }

        /// <summary>
        /// Gets or sets del valor del atributo.
        /// </summary>
        /// <value></value>
        public string Valor { get; set; }
    }
}