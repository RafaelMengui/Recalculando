//--------------------------------------------------------------------------------
// <copyright file="FactoryDragContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Container.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryDragContainer : IFactoryComponent
    {
        /// <summary>
        /// Nombre del container.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen del container.
        /// </summary>
        private string image;

        /// <summary>
        /// Ancho del container.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del container.
        /// </summary>
        private int height;

        /// <summary>
        /// Posicion en X del container.
        /// </summary>
        private int positionX;

        /// <summary>
        /// Posicion en Y del container.
        /// </summary>
        private int positionY;

        /// <summary>
        /// Nivel al que pertenece el item.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;
        
        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="DragContainer"/>.
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
            this.image = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            Items dragContainer = new DragContainer(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image);
            this.level.ItemList.Add(dragContainer);
            return dragContainer;
        }
    }
}