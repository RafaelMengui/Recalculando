//--------------------------------------------------------------------------------
// <copyright file="EngineUnity.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Factory.Unity;
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Motor resposable de conocer y asignar los metodos relacionados a Unity.
    /// Hereda de la clase <see cref="IEngine"/>.
    /// </summary>
    public class EngineUnity : IEngine
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
        /// </summary>
        /// <param name="draggableItemID"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void OnDrop(string draggableItemID, float x, float y)
        {
            IContainer destination;
            IDraggable draggableItem;
            this.Adapter.Debug($"Drop '{draggableItemID}' {x}@{y}");
            try
            {
                destination = this.FindDragContainer(x, y);
                draggableItem = FindItem(draggableItemID) as IDraggable;
            }
            catch (System.InvalidCastException)
            {
                throw new System.InvalidCastException($"Failed cast operation of \"{draggableItemID}\" as DraggableItem.");
            }

            if (destination != null && draggableItem.Drop(destination))
            {
                // Mueve el elemento arrastrado al destino si se suelta arriba del destino.
                // Se actualiza el container del item.
                draggableItem.Container.SavedItems.Remove(draggableItem as Items);
                destination.SavedItems.Add(draggableItem as Items);
                this.Adapter.Center((draggableItem as Items).ID, (destination as Items).ID);
                this.Adapter.MakeDraggable((draggableItem as Items).ID, false);
            }
            else
            {
                this.Adapter.Center((draggableItem as Items).ID, (draggableItem.Container as Items).ID);
            }
        }

        /// <summary>
        /// Si existe un container en esas coordenadas, lo devolvera.
        /// </summary>
        /// <param name="x">Coordenada en X en donde se solto el item.</param>
        /// <param name="y">Coordenada en Y en donde se solto el item.</param>
        /// <returns>IContainer.</returns>
        private IContainer FindDragContainer(float x, float y)
        {
            foreach (Items item in Singleton<EngineGame>.Instance.CurrentPage.ItemList)
            {
                if (item is IContainer && this.Adapter.Contains(item.ID, x, y))
                {
                    return item as IContainer;
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo responnsable de buscar en la pagina en la que se encuentre el usuario,
        /// un Item que tenga el mismo UnityID que el entrante por parametro.
        /// </summary>
        /// <param name="unityID">ID de unity del item.</param>
        /// <returns>Devuelve el item encontrado.</returns>
        private static Items FindItem(string unityID)
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
        /// <param name="component">Component.</param>
        public void CreateInUnity(IComponent component)
        {
            this.unityFactory.MakeUnityItem(this.Adapter, component);
        }

        /// <summary>
        /// Metodo responsable de actualizar el mensaje de feedback mostrado en pantalla.
        /// </summary>
        /// <param name="feedback">Feedback que se vaya a actualizar.</param>
        /// <param name="text">Nuevo texto.</param>
        public void UpdateFeedback(Feedback feedback, string text)
        {
            this.Adapter.SetText(feedback.ID, text, true);
        }

        /// <summary>
        /// Metodo responsable de actualizar el texto de un objeto.
        /// </summary>
        /// <param name="item">Item que se vaya a actualizar.</param>
        /// <param name="text">Nuevo texto.</param>
        public void UpdateText(Items item, string text)
        {
            this.Adapter.SetText(item.ID, text, true);
        }

        /// <summary>
        /// Metodo responsable de Centrar un IDraggable en su IContainer.
        /// </summary>
        /// <param name="item">IDraggableItem.</param>
        /// <param name="container">IContainer.</param>
        public void CenterInUnity(Items item, Items container)
        {
            this.Adapter.Center(item.ID, container.ID);
        }

        /// <summary>
        /// Metodo responsable actualizar un item para que sea arrastrable o no.
        /// Si el item ya es arrastrable, no se ejecutara el metodo de unity para evitar errores.
        /// </summary>
        /// <param name="item">Item que se va a actualizar.</param>
        /// <param name="isDraggable">Bool que indica si va a ser arrastrable.</param>
        public void SetItemDraggable(Items item, bool isDraggable)
        {
            if (item is IDraggable)
            {
                this.Adapter.MakeDraggable(item.ID, isDraggable);
            }
        }

        /// <summary>
        /// Metodo responsable de actualizar si un item es mostrado por pantalla u ocultado.
        /// </summary>
        /// <param name="item">Componente que se va a actualizar.</param>
        /// <param name="active">Bool que indica si se va a mostrar u ocultar.</param>
        public void SetActive(Items item, bool active)
        {
            this.Adapter.SetActive(item.ID, active);
        }
    }
}