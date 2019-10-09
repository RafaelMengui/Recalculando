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
    public class DragAndDropSource : Items
    {
        public DragAndDropSource(string name, Space level, int positionX, int positionY, int width, int height, bool draggable) :
        base(name, level, positionX, positionY, width, height, draggable)
        {
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
            unityItem = adapter.CreateDragAndDropSource(this.PositionX, this.PositionY, this.Width, this.Height);
            adapter.SetImage(unityItem, this.Name);
            return this.Name;
        }
    }
}