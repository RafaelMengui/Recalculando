//--------------------------------------------------------------------------------
// <copyright file="FactoryMoney.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using Proyecto.Item.ScientistLevel;
using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    /// Esta clase es la responsable de crear objetos Money arrastables.
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryMoney : IFactoryComponent
    {
        /// <summary>
        /// Nombre del dinero.
        /// </summary>
        private string name;

        /// <summary>
        /// Imagen del dinero.
        /// </summary>
        private string image;

        /// <summary>
        /// Container del dinero.
        /// </summary>
        private string containerName;

        /// <summary>
        /// Ancho del dinero.
        /// </summary>
        private float width;

        /// <summary>
        /// Altura del dinero.
        /// </summary>
        private float height;

        /// <summary>
        /// Posicion en X del dinero.
        /// </summary>
        private float positionX;

        /// <summary>
        /// Posicion en Y del dinero.
        /// </summary>
        private float positionY;

        /// <summary>
        /// Define si el dinero es arrastrable.
        /// </summary>
        private bool draggable;

        /// <summary>
        /// Nivel al que pertenece el dinero.
        /// </summary>
        private Space level;

        /// <summary>
        /// Valor del dinero.
        /// </summary>
        private float value;

        /// <summary>
        /// Contenedor en donde sera creado el dinero.
        /// </summary>
        private MoneyContainer container;

        /// <summary>
        /// Instancia del mundo.
        /// </summary>
        private World world = Singleton<World>.Instance;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryComponent.
        /// Tiene la responsabilidad de crear el componente de tipo <see cref="Money"/>.
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
                this.value = Convert.ToSingle(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Value"; }).Valor);
                this.container = this.level.ItemList.Find(delegate(Items item) { return item.Name == this.containerName; }) as MoneyContainer;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Missing attribute in tag \"{tag.Nombre}\".");
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException($"Failed cast operation in tag \"{tag.Nombre}\".");
            }
            catch (FormatException)
            {
                throw new FormatException($"Invalid attribute format in tag \"{tag.Nombre}\".");
            }

            Items draggabledinero = new Money(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.draggable, this.container, this.value);
            this.level.ItemList.Add(draggabledinero);
            return draggabledinero;
        }
    }
}