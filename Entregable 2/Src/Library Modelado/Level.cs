//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Niveles 
    /// </summary>
    public class Level : Space
    {
        public Level(string Name, string Size, List<Space> SpaceList) : base(Name, Size, SpaceList)
        {
        }
    }
}