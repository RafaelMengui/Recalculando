//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Clase que implementa la interfaz IBuilder.
    /// Tiene la responsabilidad de generar los archivos 'StudentsCode.dll' y 'Common.dll'.
    /// </summary>
    /// 
    public class Builder : IBuilder
    {
        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando.
        /// un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="adapter">Un <see cref="IMainViewAdapter"/> que permite construir
        /// una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter adapter)
        {
            string XMLfile = @"..\..\..\Archivos HTML\Ejemplo.xml";
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(XMLfile));

            foreach (Tag tag in tags)
            {
                switch (tag.Nombre)
                {
                    case "World":
                        var world = Creator.AddWorld(tag);
                    break;
                    case "Level":
                        Console.WriteLine("The color is green");
                        break;
                    case "Items":
                        Console.WriteLine("The color is blue");
                        break;
                }
            }
        }
    }
}