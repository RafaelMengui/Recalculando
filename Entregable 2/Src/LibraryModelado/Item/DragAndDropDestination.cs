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
    public class DragAndDropDestination : Items
    {
        public DragAndDropDestination(string name, Space level, int positionX, int positionY, int width, int height, string image) :
        base(name, level, positionX, positionY, width, height, image)
        {
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
            unityItem = adapter.CreateDragAndDropDestination(this.PositionX, this.PositionY, this.Width, this.Height);
            this.ID = unityItem;
            adapter.SetImage(unityItem, this.Image);
            return this.Name;
        }
    }
}