using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class DraggableItem : Items
    {
        DropEvent onDrop;
        private bool draggable;
        private Items container;

        /// <summary>
        /// Constructor, instancia un objeto DraggableItem.
        /// </summary>
        /// <param name="name">Nombre del Item.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Item.</param>
        /// <param name="draggable">Bool que identifica si es arrastrable.</param>
        /// <param name="container">Container en donde es creado el item.</param>
        public DraggableItem(string name, Space level, int positionX, int positionY, int width, int height, string image, bool draggable, Items container)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Draggable = draggable;
            this.Container = container;
        }

        /// <summary>
        /// Gets or sets del container.
        /// </summary>
        /// <value><see cref="Items"/>.</value>
        public Items Container { get; set; }

        /// <summary>
        /// Gets or sets de si el item es arrastrable.
        /// </summary>
        /// <value>bool arrastrable.</value>
        public bool Draggable { get; set; }
    }
}