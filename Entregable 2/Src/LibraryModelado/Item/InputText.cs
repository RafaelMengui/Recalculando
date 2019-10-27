//--------------------------------------------------------------------------------
// <copyright file="InputText.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase responsable de crear InputText en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class InputText : Items
    {
        /// <summary>
        /// Método a ejecutar cuando se cambia el texto de la entrada de texto.
        /// </summary>
        private Action<string, string> onChange;

        /// <summary>
        /// Método a ejecutar cuando se termina de editar el texto de la entrada de texto.
        /// </summary>
        private Action<string, string> onEdited;
        
        /// <summary>
        /// Initializes a new instance of InputText.
        /// </summary>
        /// <param name="name">Nombre de la imagen.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del input.</param>
        public InputText(string name, Space level, float positionX, float positionY, float width, float height, string image)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.OnChange = onChange;
            this.OnEdited = onEdited;
        }

        /// <summary>
        /// Gets or sets del método a ejecutar cuando se termina de editar el texto de la entrada de texto.
        /// </summary>
        /// <value>Action.</value>
        public Action<string, string> OnEdited { get; set; }

        /// <summary>
        /// Gets or sets del método a ejecutar cuando se cambia el texto de la entrada de texto.
        /// </summary>
        /// <value>Action.</value>
        public Action<string, string> OnChange { get; set; }
    }
}