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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="image"></param>
        /// <param name="draggable"></param>
        public DraggableItem(string name, Space level, int positionX, int positionY, int width, int height, string image, bool draggable)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Draggable = draggable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool Draggable { get; set; }
    }
}