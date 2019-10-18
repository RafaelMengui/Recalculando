//--------------------------------------------------------------------------------
// <copyright file="DragAndDropDestination.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase DragAndDropDestination. Hereda de <see cref="Items"/>.
    /// </summary>
    public class DragAndDropDestination : Items
    {
        /// <summary>
        /// Constructor. Instancia Objetos DragAndDropDestination.
        /// </summary>
        /// <param name="name">Nombre del Item.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Item.</param>
        public DragAndDropDestination(string name, Space level, int positionX, int positionY, int width, int height, string image)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.SavedItems = new List<DragAndDropItem>();
        }

        /// <summary>
        /// Gets or sets de los objetos DragAndDropItem guardados en el container.
        /// </summary>
        /// <value><see cref="DragAndDropItem"/>.</value>
        public List<DragAndDropItem> SavedItems {get; set;}     

        /// <summary>
        /// Metodo para crear DragAndDropDestination en Unity.
        /// </summary>
        /// <param name="adapter">Adapter del tipo.<see cref="IMainViewAdapter"/>.</param>
        public override void CreateUnityItem(IMainViewAdapter adapter)
        {
            this.ID = adapter.CreateDragAndDropDestination(this.PositionX, this.PositionY, this.Width, this.Height);
            adapter.SetImage(this.ID, this.Image);
        }
    }
}