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
        private int width;

        /// <summary>
        /// Altura del dinero.
        /// </summary>
        private int height;

        /// <summary>
        /// Posicion en X del dinero.
        /// </summary>
        private int positionX;

        /// <summary>
        /// Posicion en Y del dinero.
        /// </summary>
        private int positionY;

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
        private int value;

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
            this.name = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Name"; }).Valor;
            this.level = this.world.SpaceList.Last();
            this.width = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Width"; }).Valor);
            this.height = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Height"; }).Valor);
            this.positionX = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionX"; }).Valor);
            this.positionY = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "PositionY"; }).Valor);
            this.image = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Photo"; }).Valor;
            this.containerName = tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Container"; }).Valor;
            this.draggable = Convert.ToBoolean(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Draggable"; }).Valor);
            this.value = Convert.ToInt32(tag.Atributos.Find(delegate(Atributos atr) { return atr.Clave == "Value"; }).Valor);

            if (this.value < -10)
            {
                try
                {
                    throw new ArithmeticException($"Invalid Money Value: {this.name} has negative value.");
                }
                catch (ArithmeticException)
                {
                    this.value = Math.Abs(this.value);
                }
            }

            Items container = this.level.ItemList.Find(delegate(Items item) { return item.Name == this.containerName; });
            Items draggabledinero = new Money(this.name, this.level, this.positionX, this.positionY, this.width, this.height, this.image, this.draggable, (MoneyContainer)container, this.value);
            this.level.ItemList.Add(draggabledinero);
            return draggabledinero;
        }
    }
}