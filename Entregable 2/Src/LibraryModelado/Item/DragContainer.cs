//--------------------------------------------------------------------------------
// <copyright file="DragContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase DragContainer. Hereda de <see cref="Items"/>.
    /// </summary>
    public class DragContainer : Items
    {
        /// <summary>
        /// Constructor. Instancia Objetos DragContainer.
        /// </summary>
        /// <param name="name">Nombre del container.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del container.</param>
        public DragContainer(string name, Space level, int positionX, int positionY, int width, int height, string image)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.SavedItems = new List<Items>();
        }

        /// <summary>
        /// Lista de objetos items que son soltados dentro del container.
        /// </summary>
        /// <value>Lista de items.</value>
        public List<Items> SavedItems { get; set; }
    }
}