//--------------------------------------------------------------------------------
// <copyright file="Image.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.LibraryModelado;


namespace Proyecto.Item
{
    /// <summary>
    /// Imagenes
    /// </summary>
    public class Image : Items
    {
        public Image(string Name, Level Level, int PositionX, int PositionY, int Width, int Height, bool Draggable) : base(Name, Level, PositionX, PositionY, Width, Height, Draggable)
        {
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
              adapter.CreateImage(PositionX, PositionY, Width, Height);
              
              return Name;
        }
    }
}