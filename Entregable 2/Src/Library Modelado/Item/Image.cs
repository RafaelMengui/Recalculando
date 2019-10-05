//--------------------------------------------------------------------------------
// <copyright file="Image.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using  System.Collections.Generic;

namespace Proyecto.Item
{
    /// <summary>
    /// Imagenes
    /// </summary>
    public class Image : Items
    {
        public Image(string Name, Level Level, string PositionX, string PositionY, string Width, string Height, bool Draggable) : base(Name, Level, PositionX, PositionY, Width, Height, Draggable)
        {
        }
    }
}