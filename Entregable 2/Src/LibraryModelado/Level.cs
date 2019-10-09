//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Niveles 
    /// </summary>
    public class Level : Space
    {
        public string Image{get;set;}
        private string image;
        public string unityItem { get; set; }

        public Level(string name, int width, int height, string image)
        : base(name, width, height)
        {
            this.Image = image;
        }

        public override string CreateUnityLevel(IMainViewAdapter adapter)
        {
            unityItem = adapter.AddPage();
            this.ID = unityItem;

            string backgroundID = adapter.CreateImage(0,0, 1270, 540);
            adapter.SetImage(backgroundID, this.Image);

            return this.Name;
        }
    }
}