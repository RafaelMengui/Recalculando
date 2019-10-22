//--------------------------------------------------------------------------------
// <copyright file="UFactory.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la responsable de delegar la responsabilidad de agregar los componentes al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactory : IFactoryUnity
    {
        /// <summary>
        /// Instancia de la fabrica responsable de agregar los objetos <see cref="Space"/> a unity.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactorySpace factorySpace = new UFactorySpace();

        /// <summary>
        /// Instancia de la fabrica responsable de delegar la responsabilidad de agregar los Items al juego.
        /// </summary>
        /// <returns>Void.</returns>
        private UFactoryItem factoryItems = new UFactoryItem();

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Delega la responsabilidad de agregar el componente en unity, al respectivo Unity Factory del componente.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            string[] componentType = Convert.ToString(component.GetType()).Split('.');
            switch (componentType.Last())
            {
                case "World":
                {
                    break;
                }

                case "Level":
                {
                    this.factorySpace.MakeUnityItem(adapter, component);
                    break;
                }

                default:
                {
                    this.factoryItems.MakeUnityItem(adapter, component);
                    break;
                }
            }
        }
    }
}