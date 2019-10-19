using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    ///  Esta clase es la responsable de crear objetos Items. 
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryItem : IFactoryComponent
    {
        private FactoryButton factoryButton = new FactoryButton();
        private FactoryImage factoryImage = new FactoryImage();
        private FactoryDraggableItem factoryDraggableItem = new FactoryDraggableItem();
        private FactoryDragContainer factoryDragContainer = new FactoryDragContainer();

        /// <summary>
        /// Se sobreescribe el método de la clase IFactoryComponent
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>IComponent</returns>
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