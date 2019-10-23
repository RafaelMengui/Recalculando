//--------------------------------------------------------------------------------
// <copyright file="FactoryItem.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de delegar la responsabilidad de crear objetos Items.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryItem : IFactoryComponent
    {
        /// <summary>
        /// Instancia de la fabrica responsable de delegar la responsabilidad de Crear los componentes Botones.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryButton factoryButton = new FactoryButton();

        /// <summary>
        /// Instancia de la fabrica responsable de crear Imagenes en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryImage factoryImage = new FactoryImage();

        /// <summary>
        /// Instancia de la fabrica responsable de crear DraggableItems en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryDraggableItem factoryDraggableItem = new FactoryDraggableItem();

        /// <summary>
        /// Instancia de la fabrica responsable de crear DragContainers en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryDragContainer factoryDragContainer = new FactoryDragContainer();

        /// <summary>
        /// Instancia de la fabrica responsable de crear InputText en el modelado.
        /// </summary>
        /// <returns>Componentes del tipo <see cref="IComponent"/>.</returns>
        private FactoryInputText factoryInputText = new FactoryInputText();

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Es responsable de delegar la responsabilidad de crear objetos Items, a sus respectivos Factorys.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            switch (tag.Nombre)
            {
                case "Button":
                    {
                        IComponent button = this.factoryButton.MakeComponent(tag);
                        return button;
                    }

                case "Image":
                    {
                        IComponent image = this.factoryImage.MakeComponent(tag);
                        return image;
                    }

                case "DraggableItem":
                    {
                        IComponent draggableItem = this.factoryDraggableItem.MakeComponent(tag);
                        return draggableItem;
                    }

                case "DragContainer":
                    {
                        IComponent dragContainer = this.factoryDragContainer.MakeComponent(tag);
                        return dragContainer;
                    }

                case "InputText":
                    {
                        IComponent input = this.factoryInputText.MakeComponent(tag);
                        return input;
                    }
                
                default:
                    {
                        throw new System.Exception($"Invalid Tag Name {tag.Nombre}");
                    }
            }
        }
    }
}