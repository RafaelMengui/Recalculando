using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    public class FactoryItem : IFactoryComponent
    {
        private FactoryButton factoryButton = new FactoryButton();
        private FactoryImage factoryImage = new FactoryImage();
        private FactoryDraggableItem factoryDraggableItem = new FactoryDraggableItem();
        private FactoryDragContainer factoryDragContainer = new FactoryDragContainer();

        public override IComponent MakeComponent(Tag tag)
        {
            switch (tag.Nombre)
            {
                case "Button":
                    IComponent button = factoryButton.MakeComponent(tag);
                    return button;

                case "Image":
                    IComponent image = factoryImage.MakeComponent(tag);
                    return image;

                case "DraggableItem":
                    IComponent draggableItem = factoryDraggableItem.MakeComponent(tag);
                    return draggableItem;

                case "DragContainer":
                    IComponent dragContainer = factoryDragContainer.MakeComponent(tag);
                    return dragContainer;

                default: throw new System.Exception($"Invalid Tag Name {tag.Nombre}");
            }
        }
    }
}