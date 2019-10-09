//--------------------------------------------------------------------------------
// <copyright file="Image.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Common;
using Proyecto.LibraryModelado;


namespace Proyecto.Item
{
    /// <summary>
    /// Imagenes
    /// </summary>
    public class Image : Items
    {
        public Image(string name, Space level, int positionX, int positionY, int width, int height, bool draggable)
        : base(name, level, positionX, positionY, width, height, draggable)
        {
        }

        public override string CreateUnityItem(IMainViewAdapter adapter)
        {
              unityItem = adapter.CreateImage(this.PositionX, this.PositionY, this.Width, this.Height);
              adapter.SetImage(unityItem, this.Name);
              return this.Name;
        }
    }
}