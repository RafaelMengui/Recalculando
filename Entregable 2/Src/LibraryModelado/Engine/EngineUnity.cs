using Proyecto.Common;
using Proyecto.Factory.Unity;
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Motor resposable de conocer y asignar los metodos relacionados a Unity.
    /// </summary>
    public class EngineUnity
    {
        /// <summary>
        /// Instancia de la UnityFactory.
        /// </summary>
        private UFactory unityFactory = Singleton<UFactory>.Instance;

        /// <summary>
        /// Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario interactiva.
        /// </summary>
        private IMainViewAdapter adapter;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EngineUnity()
        {
            this.Adapter = adapter;
        }

        /// <summary>
        /// Gets or sets del adaptador.
        /// </summary>
        /// <value>Adaptador del tipo <see cref="IMainViewAdapter"/>.</value>
        public IMainViewAdapter Adapter { get; set; }
 
        /// <summary>
        /// Metodo Drop de un draggableItem.
        /// ARREGLAR ESTE METODO.
        /// </summary>
        /// <param name="draggableItemID"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void OnDrop(string draggableItemID, float x, float y)
        {
            this.Adapter.Debug($"Drop '{draggableItemID}' {x}@{y}");
            Items destination = this.FindDragContainer(x, y);
            DraggableItem dragItem = this.FindItem(draggableItemID) as DraggableItem;
            if (destination != null)
            {
                // Mueve el elemento arrastrado al destino si se suelta arriba del destino
                this.Adapter.Center(dragItem.ID, destination.ID);
            }
            else
            {
                this.Adapter.Center(dragItem.ID, dragItem.Container.ID);
            }
        }

        /// <summary>
        /// Si existe un container en esas coordenadas, lo devolvera.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Items FindDragContainer(float x, float y)
        {
            foreach (Items item in Singleton<EngineGame>.Instance.CurrentPage.ItemList)
            {
                if (item is IContainer && this.Adapter.Contains(item.ID, x, y))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo responnsable de buscar en la pagina en la que se encuentre el usuario,
        /// un Item que tenga el mismo UnityID que el entrante por parametro.
        /// </summary>
        /// <param name="unityID"></param>
        /// <returns>Devuelve el item encontrado.</returns>
        private Items FindItem(string unityID)
        {
            foreach (Items item in Singleton<EngineGame>.Instance.CurrentPage.ItemList)
            {
                if (unityID == item.ID)
                {
                    return item;
                }
            }
            throw new System.ArgumentNullException($"Item \"{unityID}\" not found.");
        }

        /// <summary>
        /// Metodo responsable de enviar un IComponent a la UnityFactory.
        /// </summary>
        /// <param name="component"></param>
        public void SendComponentToUFactory(IComponent component)
        {
            this.unityFactory.MakeUnityItem(this.Adapter, component);
        }
    }
}