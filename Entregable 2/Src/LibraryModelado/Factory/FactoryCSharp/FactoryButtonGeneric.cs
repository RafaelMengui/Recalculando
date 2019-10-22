<<<<<<< HEAD
using System;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
using System.Linq;

=======
//--------------------------------------------------------------------------------
// <copyright file="FactoryButtonGeneric.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Item;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;
>>>>>>> e3c183023df7a3ba0f9d45240444cd3108cd750e

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Botones Genéricos.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryButtonGeneric : IFactoryComponent
    {
        /// <summary>
        /// Nombre del boton.
        /// </summary>
        private string name;

        /// <summary>
        /// Color del boton.
        /// </summary>
        private string color;

        /// <summary>
        /// Imagen del boton.
        /// </summary>
        private string image;

        /// <summary>
        /// Ancho del boton.
        /// </summary>
        private int width;

        /// <summary>
        /// Altura del boton.
        /// </summary>
        private int height;

        /// <summary>
        /// Posicion en X del boton.
        /// </summary>
        private int positionX;

        /// <summary>
        /// Posicion en Y del boton.
        /// </summary>
        private int positionY;

        /// <summary>
        /// Nivel del boton.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Button"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.color = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Color"; }).Valor;
            this.image = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            this.level = this.world.SpaceList.Last();
            Items button = new Button(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.color);
            this.level.ItemList.Add(button);
            return button;
        }
    }
}