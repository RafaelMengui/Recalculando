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

            string XMLfile = @"C:\Users\nicop\Desktop\git\pii_2019_2_equipo4\Entregable 2\Src\ArchivosHTML\MartinitoX.xml";
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(XMLfile));
            Creator Creator = new Creator();

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
                foreach (Items unityItem in Creator.Level.ItemList)
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
            //this.adapter.PlayAudio("Speech On.wav");
        }

        private void GoToNextPage()
        {
            this.adapter.ShowPage(this.nextPageName);
            //his.adapter.PlayAudio("Speech Off.wav");
        }
    }
}