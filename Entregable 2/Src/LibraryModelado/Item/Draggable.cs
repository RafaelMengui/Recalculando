using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    public class DraggableItem : Items
    {
        DropEvent onDrop;
        private bool draggable;

        public DraggableItem(string name, Space level, int positionX, int positionY, int width, int height, string image, bool draggable)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Draggable = draggable;
        }
        public bool Draggable { get; set; }

        public override void CreateUnityItem(IMainViewAdapter adapter)
        {
            this.ID = adapter.CreateImage(this.PositionX, this.PositionY, this.Width, this.Height);
            adapter.SetImage(this.ID, this.Image);
            adapter.MakeDraggable(this.ID, this.Draggable);
        }
    }
}