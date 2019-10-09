//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Botones
    /// </summary>
    public class DragAndDropItem : Items
    {
        public Items Container { get; set; }
        private Items container;
        public DragAndDropItem(string name, Space level, int positionX, int positionY, int width, int height,
            string image, Items container) :
        base(name, level, positionX, positionY, width, height, image)
        {
            this.Container = container;
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
            unityItem = adapter.CreateDragAndDropItem(this.PositionX, this.PositionY, this.Width, this.Height);
            this.ID = unityItem;
            adapter.SetImage(unityItem, this.Image);
            adapter.AddItemToDragAndDropSource(this.Container.ID, unityItem);
            return this.Name;

        }
    }
}