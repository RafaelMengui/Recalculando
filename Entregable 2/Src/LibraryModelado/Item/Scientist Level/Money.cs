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
        /// <summary>
        /// Valor del dinero.
        /// </summary>
        private float valor;

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
        public Money(string name, Space level, float positionX, float positionY, float width, float height, string image, bool draggable, MoneyContainer container, float valor)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Value = valor;
            this.Draggable = draggable;
            this.Container = container;
            this.OnDropMoney = this.onDropMoney;
        }

        /// <summary>
        /// Gets or sets del valor de la moneda.
        /// En caso que, la moneda sea de un valor negativo, se ejecuta la exepción.
        /// </summary>
        /// <value>float valor de la moneda.</value>
        public float Value
        {
            get
            {
                return this.valor;
            }
            set
            {
                this.valor = Math.Abs(value);
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
                EngineScientificExercise1 engineScientific = Singleton<EngineScientificExercise1>.Instance;
                if (engineScientific.VerifyExercise(moneyContainer, this))
                {
                    this.OnDropMoney(this.Name, this.PositionX, this.PositionY);
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }
}