//--------------------------------------------------------------------------------
// <copyright file="Money.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Item.ScientistLevel
{
    /// <summary>
    /// Clase responsable de crear dinero arrastrable en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class Money : Items
    {
        private int valor;
        /// <summary>
        /// Accion que se ejecutara al soltar el dinero.
        /// </summary>
        private Action<string, float, float> onDropMoney;

        /// <summary>
        /// Initializes a new instance of Money.
        /// </summary>
        /// <param name="name">Nombre de la moneda.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen de la moneda.</param>
        /// <param name="draggable">Bool que define si es arrastrable.</param>
        /// <param name="container">Container Source en donde es creado.</param>
        /// <param name="valor">Valor de la moneda.</param>
        public Money(string name, Space level, int positionX, int positionY, int width, int height, string image, bool draggable, MoneyContainer container, int valor)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Value = valor;
            this.Draggable = draggable;
            this.Container = container;
            this.OnDropMoney = this.onDropMoney;
        }

        /// <summary>
        /// Gets or sets del valor de la moneda.
        /// </summary>
        /// <value>int valor de la moneda.</value>
        public int Value
        {
            get
            {
                return this.valor;
            }
            set
            {
                if (value < 0)
                {
                    try
                    {
                        throw new ArithmeticException($"Invalid Money Value: {this.Name} has negative value.");
                    }
                    finally
                    {
                        this.valor = Math.Abs(value);
                    }
                }
                else
                {
                    this.valor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets del container en el que se encuentra.
        /// </summary>
        /// <value><see cref="DragContainer"/>.</value>
        public MoneyContainer Container { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether el item es arrastrable.
        /// </summary>
        /// <value>Bool arrastrable.</value>
        public bool Draggable { get; set; }

        /// <summary>
        /// Gets or sets de la accion a realizar al soltar el dinero.
        /// </summary>
        /// <value>Action.</value>
        public Action<string, float, float> OnDropMoney { get; set; }

        /// <summary>
        /// Accion realizada al soltar el dinero.
        /// </summary>
        public bool Drop(MoneyContainer moneyContainer)
        {
            if (this.Draggable)
            {
                EngineScientific engineScientific = Singleton<EngineScientific>.Instance;
                return engineScientific.VerifyExercise(moneyContainer, this);
            }
            else
            {
                try
                {
                    throw new ArgumentException($"Invalid action: Object not draggable {this.Name}.");
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
        }
    }
}


// this.OnDropMoney(this.Name, this.Positionx, this.PositionY);