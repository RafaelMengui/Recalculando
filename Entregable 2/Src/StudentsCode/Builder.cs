//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using System;
using System.Collections.Generic;
using Proyecto.Factory.CSharp;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Clase que implementa la interfaz IBuilder.
    /// Tiene la responsabilidad de generar los archivos 'StudentsCode.dll' y 'Common.dll'.
    /// </summary>
    public class Builder : IBuilder
    {
        private IMainViewAdapter adapter;
        private Space firstPage;
        World world = Singleton<World>.Instance;
        CreatorU c = new CreatorU();
        FactoryComponent factoryComponent = new FactoryComponent();

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            this.adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));
            this.adapter.AfterBuild += Setup;

            const string XMLfile = @"..\..\..\Code\Entregable 2\Src\ArchivosHTML\Prueba.xml";
            List<Tag> tags = Parser.ParserHTML(LeerHtml.RetornarHTML(XMLfile));

            foreach (Tag tag in tags)
            {
                this.factoryComponent.MakeComponent(tag);
            }

            c.CreateUnityItems(this.adapter);




            
            this.firstPage = this.world.SpaceList[0];
            this.adapter.AfterBuild();
        }

        /// <summary>
        /// Accion a realizar luego de Compilar el programa. Muestra la primera pagina en Unity.
        /// </summary>
        private void Setup()
        {
            this.adapter.ChangeLayout(Layout.ContentSizeFitter);
            this.adapter.ShowPage(firstPage.ID);
        }
    }
}

/*

Builder-Factory

Action

DragAndDrop -> makedraggable

DropEvent del makedraggable

Motor...

*/