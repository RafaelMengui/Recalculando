//--------------------------------------------------------------------------------
// <copyright file="FactoryImage.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using System.Linq;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear las imagenes.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryImage : IFactoryComponent
    {
        /// <summary>
        /// Nombre de la imagen.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen de la imagen.
        /// </summary>
        private string photo;

        /// <summary>
        /// Ancho de la imagen.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura de la imagen.
        /// </summary>
        private int height;

        /// <summary>
        /// Posicion en X de la imagen.
        /// </summary>
        private int positionX;

        /// <summary>
        /// Posicion en Y de la imagen.
        /// </summary>
        private int positionY;

        /// <summary>
        /// Nivel al que pertenece.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Image"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = this.world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.photo = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            Items image = new Image(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.photo);
            this.level.ItemList.Add(image);
            return image;
        }
    }
}