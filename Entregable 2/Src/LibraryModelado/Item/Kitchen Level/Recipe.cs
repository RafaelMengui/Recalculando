//--------------------------------------------------------------------------------
// <copyright file="Bowl.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.LibraryModelado;

namespace Proyecto.Item.KitchenLevel
{
    /// <summary>
    /// Clase responsable de crear containers para alimentos en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class Recipe : Items
    {
        /// <summary>
        /// Initializes a new instance of Recipe.
        /// </summary>
        /// <param name="name">Nombre del Item.</param>
        /// <param name="level">Receta que contiene los items Food.</param>

        public Recipe(string name, Food food)
        {
            this.Recipe = new List<Food>();
        }

        /// <summary>
        /// Gets lista de objetos Food, que seran soltados dentro del container para ganar el juego.
        /// </summary>
        /// <value>Alimentos<see cref="Food"/>.</value>
        public List<Food> Recipe { get; }
    }
}