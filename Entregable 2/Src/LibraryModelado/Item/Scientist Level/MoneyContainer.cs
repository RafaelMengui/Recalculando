//--------------------------------------------------------------------------------
// <copyright file="MoneyContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.LibraryModelado;

namespace Proyecto.Item.ScientistLevel
{
    /// <summary>
    /// Clase responsable de crear containers de dinero arrastrable en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class MoneyContainer : Items
    {
        /// <summary>
        /// Objeto Money guardado.
        /// </summary>
        private Money savedItem;

        /// <summary>
        /// Valor monetario aceptado por el container.
        /// </summary>
        private int acceptableValue;

        /// <summary>
        /// Initializes a new instance of MoneyContainer.
        /// </summary>
        /// <param name="name">Nombre del container.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del container.</param>
        public MoneyContainer(string name, Space level, int positionX, int positionY, int width, int height, string image)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.SavedItem = savedItem;
            this.AcceptableValue = acceptableValue;
        }

        /// <summary>
        /// Gets or sets del valor monetario aceptado por el container.
        /// </summary>
        /// <value>Int valor aceptado.</value>
        public int AcceptableValue { get; set; }

        /// <summary>
        /// Gets or sets de objetos Money soltado dentro del container.
        /// </summary>
        /// <value>Money.</value>
        public Money SavedItem { get; set; }

        /// <summary>
        /// Compara el valor del item soltado dentro del container, con el que acepta el mismo.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool CompareValue()
        {
            return (this.AcceptableValue == this.SavedItem.Value);
        }
    }
}