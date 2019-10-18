//--------------------------------------------------------------------------------
// <copyright file="CreatorU.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.Item;
using Proyecto.Common;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Creator de objetos en unity.
    /// </summary>
    public class CreatorU
    {
        /// <summary>
        /// SINGLETON.
        /// </summary>
        private CreatorC creatorC = Singleton<CreatorC>.Instance;

        /// <summary>
        /// Tipos utilizados para castear los items.
        /// </summary>
        Button button; ButtonAudio buttonAudio; ButtonGoToPage buttonGoToPage; Image image; DraggableItem draggableItem;
        DragAndDropDestination dragAndDropDestination; DragAndDropSource dragAndDropSource; DragAndDropItem dragAndDropItem;

        /// <summary>
        /// Metodo para crear todos los objetos en unity.
        /// </summary>
        /// <param name="adapter"></param>
        public void CreateUnityItems(IMainViewAdapter adapter)
        {
            foreach (Space level in creatorC.World.SpaceList)
            {
                level.CreateUnityLevel(adapter);
                foreach (Items item in level.ItemList)
                {
                    string[] itemType = Convert.ToString(item.GetType()).Split('.');
                    switch (itemType[itemType.Length - 1])
                    {
                        case "Button":
                            button = (Button)item;
                            button.ID = adapter.CreateButton(button.PositionX, button.PositionY, button.Width, button.Height, button.Color, button.Click);
                            adapter.SetImage(button.ID, button.Image);
                            break;

                        case "Image":
                            image = (Image)item;
                            image.ID = adapter.CreateImage(image.PositionX, image.PositionY, image.Width, image.Height);
                            adapter.SetImage(image.ID, image.Image);
                            break;

                        case "ButtonAudio":
                            buttonAudio = (ButtonAudio)item;
                            buttonAudio.Event = adapter.PlayAudio;
                            buttonAudio.ID = adapter.CreateButton(buttonAudio.PositionX, buttonAudio.PositionY, buttonAudio.Width, buttonAudio.Height, buttonAudio.Color, buttonAudio.Click);
                            adapter.SetImage(buttonAudio.ID, buttonAudio.Image);
                            adapter.SetText(buttonAudio.ID, "");
                            break;

                        case "ButtonGoToPage":
                            buttonGoToPage = (ButtonGoToPage)item;
                            buttonGoToPage.Event = adapter.ShowPage;
                            buttonGoToPage.ID = adapter.CreateButton(buttonGoToPage.PositionX, buttonGoToPage.PositionY, buttonGoToPage.Width, buttonGoToPage.Height, buttonGoToPage.Color, buttonGoToPage.Click);
                            adapter.SetImage(buttonGoToPage.ID, buttonGoToPage.Image);
                            adapter.SetText(buttonGoToPage.ID, "");
                            break;

                        case "DragAndDropSource":
                            dragAndDropSource = (DragAndDropSource)item;
                            dragAndDropSource.ID = adapter.CreateDragAndDropSource(dragAndDropSource.PositionX, dragAndDropSource.PositionY, dragAndDropSource.Width, dragAndDropSource.Height);
                            adapter.SetImage(dragAndDropSource.ID, dragAndDropSource.Image);
                            break;

                        case "DragAndDropDestination":
                            dragAndDropDestination = (DragAndDropDestination)item;
                            dragAndDropDestination.ID = adapter.CreateDragAndDropDestination(dragAndDropDestination.PositionX, dragAndDropDestination.PositionY, dragAndDropDestination.Width, dragAndDropDestination.Height);
                            adapter.SetImage(dragAndDropDestination.ID, dragAndDropDestination.Image);
                            break;

                        case "DragAndDropItem":
                            dragAndDropItem = (DragAndDropItem)item;
                            dragAndDropItem.ID = adapter.CreateDragAndDropItem(dragAndDropItem.PositionX, dragAndDropItem.PositionY, dragAndDropItem.Width, dragAndDropItem.Height);
                            adapter.AddItemToDragAndDropSource(dragAndDropItem.Container.ID, dragAndDropItem.ID);
                            adapter.SetImage(dragAndDropItem.ID, dragAndDropItem.Image);
                            break;

                        case "DraggableItem":
                            draggableItem = (DraggableItem)item;
                            draggableItem.ID = adapter.CreateImage(draggableItem.PositionX, draggableItem.PositionY, draggableItem.Width, draggableItem.Height);
                            adapter.MakeDraggable(draggableItem.ID, draggableItem.Draggable);
                            adapter.SetImage(draggableItem.ID, draggableItem.Image);
                            break;
                    }
                }
            }
        }
    }
}