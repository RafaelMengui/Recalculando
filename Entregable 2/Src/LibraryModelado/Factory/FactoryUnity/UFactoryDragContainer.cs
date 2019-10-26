//--------------------------------------------------------------------------------
// <copyright file="UFactoryDragContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes DragContainer al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryDragContainer : IFactoryUnity
    {
        /// <summary>
        /// Objeto DragContainer que se agregara a Unity.
        /// </summary>
        private DragContainer dragContainer;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="DragContainer"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como DragContainer.
            this.dragContainer = component as DragContainer;
            }

            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as DragContainer");
            }

            // Crear objeto en unity y obtener el UnityID.
            this.dragContainer.ID = adapter.CreateImage(this.dragContainer.PositionX, this.dragContainer.PositionY, this.dragContainer.Width, this.dragContainer.Height);

            // Asignarle su imagen al container.
            adapter.SetImage(this.dragContainer.ID, this.dragContainer.Image);
        }
    }
}