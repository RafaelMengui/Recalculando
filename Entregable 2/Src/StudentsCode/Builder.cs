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
        private string firstPageName;
        private IMainViewAdapter adapter;
        private string nextPageName;      

        static World world;  
//////////////////////////////////////////////////////////////////////////////
        /// /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando.
        /// un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir
        /// una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {

            this.adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));

            this.adapter.ToDoAfterBuild(this.AfterBuildShowFirstPage);

            this.firstPageName = this.adapter.AddPage();

            this.adapter.ChangeLayout(Layout.ContentSizeFitter);         

            


            string XMLfile = @"..\..\..\Archivos HTML\Ejemplo.xml";
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(XMLfile));

            foreach (Tag tag in tags) //Se crean los objetos C#
            {
                switch (tag.Nombre)
                {
                    case "World":
                        world = Creator.AddWorld(tag);
                        break;
                    case "Level":
                        Space level = Creator.AddLevel(tag);
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
            foreach (Space level in world.SpaceList)
            {
                foreach (Items unityItem in level.ItemList)
                {
                    unityItem.CreateUnityItem(adapter);
                }
            }


        }

        /// <summary>
        /// After Build Show First Page
        /// </summary>
        public void AfterBuildShowFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
        }

        private void GoToFirstPage()
        {
            this.adapter.ShowPage(this.firstPageName);
            this.adapter.PlayAudio("Speech On.wav");
        }

        private void GoToNextPage()
        {
            this.adapter.ShowPage(this.nextPageName);
            this.adapter.PlayAudio("Speech Off.wav");
        }


    }
}