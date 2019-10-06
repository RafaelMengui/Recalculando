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
        public DragAndDropSource(string Name, Space Level, int PositionX, int PositionY, int Width, int Height, bool Draggable) :
        base(Name, Level, PositionX, PositionY, Width, Height, Draggable)
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