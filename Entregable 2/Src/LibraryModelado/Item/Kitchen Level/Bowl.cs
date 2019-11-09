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
    public class Bowl : Items, IContainer
    {
        /// <summary>
        /// Initializes a new instance of Bowl.
        /// </summary>
        /// <param name="name">Nombre del Item.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Item.</param>
        /// <param name="recipe">Recipe del Item.</param>
        public Bowl(string name, Space level, float positionX, float positionY, float width, float height, string image, Recipe recipe)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Recipe = recipe;
            this.SavedItems = new List<Items>();   
        }
        /// <summary>
        /// Receta del bowl
        /// </summary>
        private Recipe recipe;

        /// <summary>
        /// Gets de la recipe perteneciente .
        /// </summary>
        /// <value>Alimentos <see cref="Food"/>.</value>
        public Recipe Recipe { get; }

        /// <summary>
        /// Gets lista de objetos Food, que seran soltados dentro del container.
        /// </summary>
        /// <value>Alimentos <see cref="Food"/>.</value>
        public List<Items> SavedItems { get; }
    }
}