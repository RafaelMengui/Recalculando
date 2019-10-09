//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Niveles 
    /// </summary>
    public class Level : Space
    {
        public Level(string name, int width, int height)
        : base(name, width, height)
        {
        }
    }
}