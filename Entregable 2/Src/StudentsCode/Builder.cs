//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using Proyecto.Common;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Clase que implementa la interfaz IBuilder.
    /// Tiene la responsabilidad de generar los archivos 'StudentsCode.dll' y 'Common.dll'.
    /// </summary>
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
            FilterWorld WorldCreator = new FilterWorld();
            
            WorldCreator.World
        }

    }
}
