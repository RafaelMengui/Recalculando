using System;

namespace Modelado
{
    /// <summary>
    /// Clase abstracta de Items.
    /// </summary>
    public abstract class Item
    {
        private string Name;
        private string Position_X;
        private string Position_Y;
        private string Size;
        private string Level;
        private bool Draggable;

        public string name { get; set; }
        public string position_x { get; set; }
        public string position_y { get; set; }
        public string size { get; set; }
        public string level { get; set; }
        public bool draggable { get; set; }

        public Item(string name, string level, string position_x, string position_y, string size, bool draggable)
        {
            this.Name = name;
            this.Level = level;
            this.Position_X = position_x;
            this.Position_Y = position_y;
            this.Size = size;
            this.Draggable = draggable;
        }
    }
}
