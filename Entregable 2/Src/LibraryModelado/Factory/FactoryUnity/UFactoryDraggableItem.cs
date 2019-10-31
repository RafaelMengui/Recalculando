//--------------------------------------------------------------------------------
// <copyright file="UFactoryDraggableItem.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes DraggableItem al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryDraggableItem : IFactoryUnity
    {
        /// <summary>
        /// Objeto DraggableItem que se agregara a Unity.
        /// </summary>
        private DraggableItem draggableItem;

        // private EngineUnity engineUnity = Singleton<EngineUnity>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de agregar el componente de tipo <see cref="DraggableItem"/> a Unity.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como DraggableItem.
                this.draggableItem = component as DraggableItem;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as DraggableItem");
            }

            // adapter.OnDrop = this.engineUnity.OnDrop;

            // Crear objeto en unity y obtener el UnityID.
            this.draggableItem.ID = adapter.CreateImage(this.draggableItem.PositionX, this.draggableItem.PositionY, this.draggableItem.Width, this.draggableItem.Height);

            // Se define el objeto como arrastrable.
            adapter.MakeDraggable(this.draggableItem.ID, this.draggableItem.Draggable);

            // Se centra el objeto en su respectivo container.
            adapter.Center(this.draggableItem.ID, this.draggableItem.Container.ID);

            // Asignarle su imagen al item.
            adapter.SetImage(this.draggableItem.ID, this.draggableItem.Image);
        }
    }
}