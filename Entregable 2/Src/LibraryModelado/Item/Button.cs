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
        public Button(string name, Space level, int positionX, int positionY, int width, int height, bool draggable, string color)
        : base(name, level, positionX, positionY, width, height, draggable)
        {
            this.Color = color;
        }

        private string color;
        public string Color { get; set; }

        public void Click()
        {
            // No hay que implementar comportamiento.
            throw new System.NotImplementedException();
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
            unityItem = adapter.CreateButton(this.PositionX, this.PositionY, this.Width, this.Height, this.Color, this.Click);
            adapter.SetImage(unityItem, this.Name);
            return this.Name;
        }
    }
}