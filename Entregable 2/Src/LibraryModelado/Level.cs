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
        public Level(string Name, int Width, int Height, List<Items> ItemList, World world) 
        : base(Name, Width, Height, ItemList, world)
        {
        }
    }
}