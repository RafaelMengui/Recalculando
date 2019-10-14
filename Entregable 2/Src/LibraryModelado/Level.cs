//--------------------------------------------------------------------------------
// <copyright file="Level.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase Nivel. Hereda de <see cref="Space"/>.
    /// </summary>
    public class Level : Space
    {
        /// <summary>
        /// Imagen de fondo del nivel.
        /// </summary>
        private string image;

        /// <summary>
        /// Constructor. Inicializa una instancia de Level.
        /// </summary>
        /// <param name="name">Nombre del nivel.</param>
        /// <param name="width">Ancho del nivel.</param>
        /// <param name="height">Altura del nivel.</param>
        /// <param name="image">Nombre de la imagen de fondo del nivel.</param>
        public Level(string name, int width, int height, string image)
        : base(name, width, height)
        {
            this.Image = image;
        }

        /// <summary>
        /// Gets or sets del nombre de la imgen de fondo del nivel.
        /// </summary>
        /// <value>string nombre de imagen.</value>
        public string Image { get; set; }

        /// <summary>
        /// Metodo para crear Niveles en Unity. Le asigna el UnityID del nivel al objeto.
        /// Crea una imagen de fondo del nivel en unity.
        /// </summary>
        /// <param name="adapter">Adapter del tipo <see cref="IMainViewAdapter"/></param>
        public override void CreateUnityLevel(IMainViewAdapter adapter)
        {
            this.ID = adapter.AddPage();
            string backgroundID = adapter.CreateImage(0, 0, 1280, 550);
            adapter.SetImage(backgroundID, this.Image);
        }

        /// <summary>
        /// Metodo que crea los items pertenecientes al nivel.
        /// </summary>
        /// <param name="adapter">Adapter del tipo <see cref="IMainViewAdapter"/></param>
        public override void ShowLevelItems(IMainViewAdapter adapter)
        {
            foreach (Items unityItem in this.ItemList)
            {
                unityItem.CreateUnityItem(adapter);
            }
        }
    }
}