//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="mio Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Clase abstracta de Espacio.
    /// </summary>
    public abstract class Espacio
    {
        /// <summary>
        /// Nombre del Espacio.
        /// </summary>
        private string name;

        /// <summary>
        /// Submundo al que pertenece el espacio.
        /// </summary>
        private string submundo;

        /// <summary>
        /// Tamaño del espacio.
        /// </summary>
        private string size;

        /// <summary>
        /// Lista de espacios.
        /// </summary>
        internal IList ListaDeEspacios = new List<T>(); //Tipo Genérico
 

        /// <summary>
        /// Inicializa una instancia de Espacios.
        /// </summary>
        /// <param name="Name">Nombre del Espacio.</param>
        /// <param name="Submundo">Submundo al que pertence.</param>
        /// <param name="Size">Tamaño del espacio.</param>
        /// <param name="ListaDeEspacios">Lista de espacios.</param>
        public Espacio(string Name, string Submundo, string Size, IList ListaDeEspacios)
        {
            this.name      = Name;
            this.submundo  = Submundo;
            this.size      = Size;

        }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del Submundo al que pertenece el Espacio.
        /// </summary>
        /// <value>String Submundo al que pertence.</value>
        public string Submundo { get; set; }

        /// <summary>
        /// Gets or sets del tamaño del espacio.

        /// </summary>
        /// <value>Tamaño del Espacio.</value>
        public string Size { get; set; }
    }
}