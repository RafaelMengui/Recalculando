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

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Clase que implementa la interfaz IBuilder.
    /// Tiene la responsabilidad de generar los archivos 'StudentsCode.dll' y 'Common.dll'.
    /// </summary>
    public class Builder : IBuilder
    {
        private IMainViewAdapter adapter;
        private CreatorC creatorC = Singleton<CreatorC>.Instance;
        private CreatorU creatorU = Singleton<CreatorU>.Instance;
        private Space firstPage;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            this.adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));
            this.adapter.AfterBuild = Setup;

            const string XMLfile = @"..\..\..\Code\Entregable 2\Src\ArchivosHTML\Prueba.xml";
            List<Tag> tags = Parser.ParserHTML(LeerHtml.RetornarHTML(XMLfile));

            //Se crean los objetos C#
            foreach (Tag tag in tags)
            {
                switch (tag.Nombre)
                {
                    case "World":
                        this.creatorC.World = this.creatorC.AddWorld(tag);
                        break;
                    case "Level":
                        this.creatorC.Level = this.creatorC.AddLevel(tag);
                        break;
                    case "Button":
                        Items button = this.creatorC.AddButton(tag);
                        break;
                    case "ButtonAudio":
                        Items buttonAudio = this.creatorC.AddButtonAudio(tag);
                        break;
                    case "ButtonGoToPage":
                        Items buttonGoTo = this.creatorC.AddButtonGoToPage(tag);
                        break;
                    case "DraggableItem":
                        Items draggable = this.creatorC.AddDraggableItem(tag);
                        break;
                    case "Image":
                        Items image = this.creatorC.AddImage(tag);
                        break;
                    case "DragAndDropSource":
                        Items dragAndDropSource = this.creatorC.AddDragAndDropSource(tag);
                        break;
                    case "DragAndDropDestination":
                        Items dragAndDropDestination = this.creatorC.AddDragAndDropDestination(tag);
                        break;
                    case "DragAndDropItem":
                        Items dragAndDropItem = this.creatorC.AddDragAndDropItem(tag);
                        break;
                }
            }
            this.firstPage = this.creatorC.World.SpaceList[0];
            this.creatorU.CreateUnityItems(this.adapter);
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