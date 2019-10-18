//--------------------------------------------------------------------------------
// <copyright file="DragAndDropSource.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LibraryModelado;
using System.Collections.Generic;


namespace Proyecto.Item
{
    /// <summary>
    /// Clase de Botones. Hereda de <see cref="Items"/>.
    /// </summary>
    public class DragAndDropSource : Items
    {
        /// <summary>
        /// Constructor. Instancia Objetos DragAndDropSource.
        /// </summary>
        /// <param name="name">Nombre del container.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del container.</param>
        public DragAndDropSource(string name, Space level, int positionX, int positionY, int width, int height, string image)
        : base(name, level, positionX, positionY, width, height, image)
        {

        }
    }
}