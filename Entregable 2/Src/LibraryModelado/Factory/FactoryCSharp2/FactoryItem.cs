using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.FactoryCSharp2
{
    public class FactoryItem
    {
        private FactoryButton factoryButton;
        private FactoryImage factoryImage;
        private FactoryDraggableItem factoryDraggableItem;
        private FactoryDragContainer factoryDragContainer;

        public IComponent MakeItems(Tag tag)
        {
            switch (tag.Nombre)
            {
                case "Button":
                    IComponent button = factoryButton.MakeButton(tag);
                    return button;

                case "Image":
                    IComponent image = factoryImage.MakeImage(tag);
                    return image;

                case "DraggableItem":
                    IComponent draggableItem = factoryDraggableItem.MakeDraggableItem(tag);
                    return draggableItem;

                case "DragContainer":
                    IComponent dragContainer = factoryDragContainer.MakeDragContainer(tag);
                    return dragContainer;

                default: throw new System.Exception($"Invalid Tag Name {tag.Nombre}");
            }
        }
    }
}