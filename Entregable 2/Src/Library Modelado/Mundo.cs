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
    public class Mundo : Espacio
    {
        public Mundo(string Name, string Submundo, string Size, System.Collections.Generic.IList ListaDeEspacios) : base(Name, Submundo, Size, ListaDeEspacios)
        {
        }
    }
}