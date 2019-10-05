//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.Common;
using Proyecto.Filters;
using Proyecto.Pipes;
using Proyecto.Item;

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
            string XMLfile = @"..\..\..\Archivos HTML\Ejemplo.xml";
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(XMLfile));

            IFilter World = new FilterWorld();
            IFilter Level = new FilterLevel();
            IFilter Button = new FilterButton();
            IFilter Image = new FilterImage();
            IFilter Destination = new FilterDestination();
            IFilter Source = new FilterSource();

            IPipe pipeNull = new PipeNull();
            IPipe pipeSix = new PipeSerial(Source, pipeNull);
            IPipe pipeFive = new PipeSerial(Destination, pipeSix);
            IPipe pipeFour = new PipeSerial(Image, pipeFive);
            IPipe pipeThree = new PipeSerial(Button, pipeFour);
            IPipe pipeTwo = new PipeSerial(Level, pipeThree);
            IPipe pipeOne = new PipeSerial(World, pipeTwo);

            foreach (Tag tag in tags)
            {
                pipeOne.Send(tag);
            }
        }
    }
}