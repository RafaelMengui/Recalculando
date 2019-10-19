//--------------------------------------------------------------------------------
// <copyright file="CreatorU.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.Item;
using Proyecto.Common;
using System.Linq;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Creator de objetos en unity.
    /// </summary>
    public class CreatorU
    {
        World world = Singleton<World>.Instance;
        /// <summary>
        /// Tipos utilizados para castear los items.
        /// </summary>
        Button button; ButtonAudio buttonAudio; ButtonGoToPage buttonGoToPage; Image image; DraggableItem draggableItem;
        DragContainer dragSource;

        /// <summary>
        /// Metodo para crear todos los objetos en unity.
        /// </summary>
        /// <param name="adapter"></param>
        public void CreateUnityItems(IMainViewAdapter adapter)
        {
            foreach (Space level in this.world.SpaceList)
            {
                level.ID = adapter.AddPage();
                string backgroundID = adapter.CreateImage(0, 0, level.Width, level.Height);
                adapter.SetImage(backgroundID, ((Level)level).Image);

                foreach (Items item in level.ItemList)
                {
                    string[] itemType = Convert.ToString(item.GetType()).Split('.');
                    switch (itemType.Last())
                    {
                        case "Image":
                            this.image = (Image)item;
                            this.image.ID = adapter.CreateImage(this.image.PositionX, this.image.PositionY, this.image.Width, this.image.Height);
                            adapter.SetImage(this.image.ID, this.image.Image);
                            break;

                        case "ButtonGoToPage":
                            this.buttonGoToPage = (ButtonGoToPage)item;
                            this.buttonGoToPage.Event = adapter.ShowPage;
                            this.buttonGoToPage.ID = adapter.CreateButton(this.buttonGoToPage.PositionX, this.buttonGoToPage.PositionY, this.buttonGoToPage.Width, this.buttonGoToPage.Height, this.buttonGoToPage.Color, this.buttonGoToPage.Click);
                            adapter.SetImage(this.buttonGoToPage.ID, this.buttonGoToPage.Image);
                            adapter.SetText(this.buttonGoToPage.ID, "");
                            break;

                        case "DragContainer":
                            this.dragSource = (DragContainer)item;
                            this.dragSource.ID = adapter.CreateImage(this.dragSource.PositionX, this.dragSource.PositionY, this.dragSource.Width, this.dragSource.Height);
                            adapter.SetImage(this.dragSource.ID, this.dragSource.Image);
                            break;

                        case "DraggableItem":
                            this.draggableItem = (DraggableItem)item;
                            this.draggableItem.ID = adapter.CreateImage(this.draggableItem.PositionX, this.draggableItem.PositionY, this.draggableItem.Width, this.draggableItem.Height);
                            adapter.MakeDraggable(this.draggableItem.ID, this.draggableItem.Draggable);
                            adapter.Center(this.draggableItem.ID, this.draggableItem.Container.ID);
                            adapter.SetImage(this.draggableItem.ID, this.draggableItem.Image);
                            break;
                        default :
                            adapter.Debug("ASasssssssssssssssssssssssssssssssssssss" + itemType.Last());
                            break;
                    }
                }
            }
        }
    }
}