//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.Item
{
    /// <summary>
    /// Botones
    /// </summary>
    public class Button : Items, IButton
    {
        public Button(string name, Space level, int positionX, int positionY, int width, int height, string image,string color)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Color = color;
        }

        private string color;
        public string Color { get; set; }

        public void Click()
        {
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
            unityItem = adapter.CreateButton(this.PositionX, this.PositionY, this.Width, this.Height, this.Color, this.Click);
            this.ID = unityItem;
            adapter.SetImage(unityItem, this.Image);
            return this.Name;
        }
    }
}