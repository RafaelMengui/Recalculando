using Proyecto.Common;
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    public class EngineUnity
    {
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        private IMainViewAdapter adapter;

        public EngineUnity()
        {
            this.Adapter = adapter;
        }

        public IMainViewAdapter Adapter { get; set; }
 
        public void OnDrop(string draggableItemID, float x, float y)
        {
            this.Adapter.Debug($"Drop '{draggableItemID}' {x}@{y}");
            Items destination = this.FindDragContainer(x, y);

            if (destination != null)
            {
                // Mueve el elemento arrastrado al destino si se suelta arriba del destino
                this.Adapter.Center(draggableItemID, destination.ID);
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
            foreach (Items item in this.engineGame.CurrentPage.ItemList)
            {
                if (item is IContainer && this.Adapter.Contains(item.ID, x, y))
                {
                    return item;
                }
            }
            return null;
        }
    }
}