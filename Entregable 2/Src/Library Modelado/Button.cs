//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using  System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Botones
    /// </summary>
    public class Button : Items
    {
        public Button(string Name, Level Level, string PositionX, string PositionY, string Width, string Height, bool Draggable) : base(Name, Level, PositionX, PositionY, Width, Height, Draggable)
        {
        }
        
    }
}