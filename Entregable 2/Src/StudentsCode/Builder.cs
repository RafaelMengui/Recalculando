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
    public class Builder : IBuilder
    {
        private IMainViewAdapter adapter;
        Creator creator = Singleton<Creator>.Instance;
        private Space firstPage;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));
            adapter.AfterBuild = Setup;

            const string XMLfile = @"..\..\..\Code\Entregable 2\Src\ArchivosHTML\Prueba.xml";
            List<Tag> tags = Parser.ParserHTML(LeerHtml.RetornarHTML(XMLfile));

            //Se crean los objetos C#
            foreach (Tag tag in tags)
            {
                switch (tag.Nombre)
                {
                    case "World":
                        creator.World = creator.AddWorld(tag);
                        break;
                    case "Level":
                        creator.Level = creator.AddLevel(tag);
                        break;
                    case "Button":
                        Items button = creator.AddButton(tag);
                        break;
                    case "ButtonAudio":
                        Items buttonAudio = creator.AddButtonAudio(tag);
                        break;
                    case "ButtonGoToPage":
                        Items buttonGoTo = creator.AddButtonGoToPage(tag);
                        break;
                    case "DraggableItem":
                        Items draggable = creator.AddDraggableItem(tag);
                        break;
                    case "Image":
                        Items image = creator.AddImage(tag);
                        break;
                    case "DragAndDropSource":
                        Items dragAndDropSource = creator.AddDragAndDropSource(tag);
                        break;
                    case "DragAndDropDestination":
                        Items dragAndDropDestination = creator.AddDragAndDropDestination(tag);
                        break;
                    case "DragAndDropItem":
                        Items dragAndDropItem = creator.AddDragAndDropItem(tag);
                        break;
                }
            }
            firstPage = creator.World.SpaceList[0];

            //Crear los objetos en el juego.
            foreach (Space level in creator.World.SpaceList)
            {
                level.CreateUnityLevel(adapter);
                foreach (Items unityItem in level.ItemList)
                {
                    unityItem.CreateUnityItem(adapter);
                }
            }
            adapter.AfterBuild();
        }

        /// <summary>
        /// Accion a realizar luego de Compilar el programa. Muestra la primera pagina en Unity.
        /// </summary>
        private void Setup()
        {
            adapter.ChangeLayout(Layout.ContentSizeFitter);
            adapter.ShowPage(firstPage.ID);
        }
    }
}

/*
Action

DragAndDrop -> makedraggable

DropEvent del makedraggable

Motor...

*/