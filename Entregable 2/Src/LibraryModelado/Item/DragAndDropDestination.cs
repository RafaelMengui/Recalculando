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
        public DragAndDropDestination(string Name, Space Level, int PositionX, int PositionY, int Width, int Height, bool Draggable) :
        base(Name, Level, PositionX, PositionY, Width, Height, Draggable)
        {
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
            adapter.CreateDragAndDropDestination(this.PositionX, this.PositionY, this.Width, this.Height);

            return this.Name;
        }
    }
}