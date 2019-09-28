//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using LeerHTML;
using Modelado;

namespace App
{
    /// <summary>
    /// Punto de Entrada al programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Prueba Main.
        /// </summary>
        public static void Main()
        {
            const string Filename = @"../../../../Archivos HTML/Ejemplo.xml";

            Console.WriteLine(Imprimir.Formato(Filename));
        }
    }
}