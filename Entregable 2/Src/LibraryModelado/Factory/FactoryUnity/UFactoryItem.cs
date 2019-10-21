//--------------------------------------------------------------------------------
// <copyright file="UFactoryItem.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la responsable de delegar la responsabilidad de agregar los Items al juego, a sus respectivos UnityFactorys.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryItem : IFactoryUnity
    {
        /// <summary>
        /// Instancia de la fabrica responsable de agregar los objetos <see cref="ButtonGoToPage"/> a unity.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactoryButtonGoToPage factoryButtonGoToPage = new UFactoryButtonGoToPage();

        /// <summary>
        /// Instancia de la fabrica responsable de agregar los objetos <see cref="ButtonAudio"/> a unity.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactoryButtonAudio factoryButtonAudio = new UFactoryButtonAudio();

        /// <summary>
        /// Instancia de la fabrica responsable de agregar los objetos <see cref="Image"/> a unity.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactoryImage factoryImage = new UFactoryImage();

        /// <summary>
        /// Instancia de la fabrica responsable de agregar los objetos <see cref="DraggableItem"/> a unity.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactoryDraggableItem factoryDraggableItem = new UFactoryDraggableItem();

        /// <summary>
        /// Instancia de la fabrica responsable de agregar los objetos <see cref="DragContainer"/> a unity.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactoryDragContainer factoryDragContainer = new UFactoryDragContainer();

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Delega la responsabilidad de agregar el item en unity, al respectivo Unity Factory del item.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            string[] componentType = Convert.ToString(component.GetType()).Split('.');
            switch (componentType.Last())
            {
                case "ButtonGoToPage":
                {
                    this.factoryButtonGoToPage.MakeUnityItem(adapter, component);
                    break;
                }

                case "ButtonAudio":
                {
                    this.factoryButtonAudio.MakeUnityItem(adapter, component);
                    break;
                }

                case "Image":
                {
                    this.factoryImage.MakeUnityItem(adapter, component);
                    break;
                }

                case "DraggableItem":
                {
                    this.factoryDraggableItem.MakeUnityItem(adapter, component);
                    break;
                }

                case "DragContainer":
                {
                    this.factoryDragContainer.MakeUnityItem(adapter, component);
                    break;
                }

                default:
                {
                    throw new System.Exception($"Invalid Unity Item Type {componentType.Last()}");
                }
            }
        }
    }
}