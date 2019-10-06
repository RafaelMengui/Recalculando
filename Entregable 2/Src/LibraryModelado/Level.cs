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
        public Level(string Name, string Size, List<Space> SpaceList, World world) : base(Name, Size, SpaceList, world)
        {
        }
    }
}