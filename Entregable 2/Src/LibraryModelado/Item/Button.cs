//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Botones
    /// </summary>
    public class Button : Items, IButton
    {
        public Button(string Name, Level Level, int PositionX, int PositionY, int Width, int Height, bool Draggable, string color) : base(Name, Level, PositionX, PositionY, Width, Height, Draggable)
        {
            this.Color = color;
        }

        private string color;
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public void Click()
        {
            throw new System.NotImplementedException();
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
            adapter.CreateButton(this.PositionX, this.PositionY, this.Width, this.Height, this.Color , this.Click);

            return this.Name;
        }
    }
}