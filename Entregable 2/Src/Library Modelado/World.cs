//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using  System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Modelo del mundo.
    /// </summary>
    public class World : Space
    {
        public World(string Name, string Size, List<Space> SpaceList) : base(Name, Size, SpaceList)
        {
        }
    }
}