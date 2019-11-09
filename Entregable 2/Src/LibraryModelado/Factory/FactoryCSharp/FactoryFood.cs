//--------------------------------------------------------------------------------
// <copyright file="FactoryDraggableItem.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Item.KitchenLevel;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear items que van a ser arrastables.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryFood : IFactoryComponent
    {
        /// <summary>
        /// Nombre del item.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen del item.
        /// </summary>
        private string image;

        /// <summary>
        /// Container del item.
        /// </summary>
        private string containerName;

        /// <summary>
        /// Ancho del item.
        /// </summary>
        private float width;

        /// <summary>
        /// Altura del item.
        /// </summary>
        private float height;

        /// <summary>
        /// Posicion en X del item.
        /// </summary>
        private float positionX;

        /// <summary>
        /// Posicion en Y del item.
        /// </summary>
        private float positionY;

        /// <summary>
        /// Define si el item es arrastrable.
        /// </summary>
        private bool draggable;

        /// <summary>
        /// Nivel al que pertenece el item.
        /// </summary>
        private Space level;

        IContainer container;

        string type;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Food"/>.
        /// </summary>
        /// <param name="tag">Tag <see cref="Tag"/>.</param>
        /// <returns>Componente <see cref="IComponent"/>.</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            try
            {
                this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
                this.level = this.world.SpaceList.Last();
                this.width = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Width"; }).Valor);
                this.height = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Height"; }).Valor);
                this.positionX = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
                this.positionY = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
                this.image = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
                this.containerName = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Container"; }).Valor;
                this.draggable = Convert.ToBoolean(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Draggable"; }).Valor);
                this.container = this.level.ItemList.Find(delegate(Items item) { return item.Name == this.containerName; }) as IContainer;
                this.type = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Type"; }).Valor;
            }
            catch(NullReferenceException)
            {
                throw new NullReferenceException($"Missing attribute in tag \"{tag.Nombre}\".");
            }
            catch(InvalidCastException)
            {
                throw new InvalidCastException($"Failed cast operation in tag \"{tag.Nombre}\".");
            }
            catch(FormatException)
            {
                throw new FormatException($"Invalid attribute format in tag \"{tag.Nombre}\".");
            }

            Food food = new Food(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.draggable, this.container, this.type);
            this.level.ItemList.Add(food);
            this.container.SavedItems.Add(food);
            return food;
        }
    }
}