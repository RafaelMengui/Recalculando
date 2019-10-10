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
        private string firstPageName;
        private IMainViewAdapter adapter;
        private string nextPageName;     
        Creator Creator = new Creator(); 

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir
        /// una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));
            adapter.ToDoAfterBuild(this.AfterBuildShowFirstPage);

            const string XMLfile = @"C:\Users\nicop\OneDrive - Universidad Católica del Uruguay\Codigos\C#\Entregables\Entregable 2\Code\Entregable 2\Src\ArchivosHTML\Codigo1.xml";
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(XMLfile));

            foreach (Tag tag in tags) //Se crean los objetos C#
            {
                switch (tag.Nombre)
                {
                    case "World":
                        Creator.World = Creator.AddWorld(tag);
                        break;
                    case "Level":
                        Creator.Level = Creator.AddLevel(tag);
                        break;
                    case "Button":
                        Items button = Creator.AddButton(tag);
                        break;
                    case "Image":
                        Items image = Creator.AddImage(tag);
                        break;
                    case "DragAndDropSource":
                        Items dragAndDropSource = Creator.AddDragAndDropSource(tag);
                        break;
                    case "DragAndDropDestination":
                        Items DragAndDropDestination = Creator.AddDragAndDropDestination(tag);
                        break;
                    case "DragAndDropItem":
                        Items DragAndDropItem = Creator.AddDragAndDropItem(tag);
                        break;
                }
            }

            //Crear los objetos Unity            
            foreach (Space level in Creator.World.SpaceList)
            {
                level.CreateUnityLevel(adapter);
                foreach (Items unityItem in Creator.Level.ItemList)
                {
                    unityItem.CreateUnityItem(adapter);
                }
            }
        }

        /// <summary>
        /// Actions
        /// </summary>
        public void AfterBuildShowFirstPage()
        {
            firstPageName = Creator.World.SpaceList[0].ID;
            adapter.ChangeLayout(Layout.ContentSizeFitter); 
            adapter.ShowPage(firstPageName);
        }

        private void GoToFirstPage()
        {
            adapter.ShowPage(firstPageName);
            adapter.PlayAudio("p.wav");
        }

        private void GoToNextPage()
        {
            adapter.ShowPage(nextPageName);
            adapter.PlayAudio("p.wav");
        }
    }
}