//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using  System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Imagenes
    /// </summary>
    public class Imagen : Items
    {
        public Imagen(string Name, string Level, string PositionX, string PositionY, string Width, string Height, bool Draggable) : base(Name, Level, PositionX, PositionY, Width, Height, Draggable)
        {
        }
    }
}