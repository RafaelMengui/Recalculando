//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using  System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Niveles 
    /// </summary>
    public class Level : Espacio
     {
         public Level(string Name, string Submundo, string Size, System.Collections.Generic.IList ListaDeEspacios) : base(Name, Submundo, Size, ListaDeEspacios)
        {
        }
     }
}