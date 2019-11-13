//--------------------------------------------------------------------------------
// <copyright file="Food.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Item.KitchenLevel
{
    /// <summary>
    /// Clase responsable de crear objetos de alimentos arrastrables en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class Food : Items, IDraggable
    {
        /// <summary>
        /// Tipo de Food
        /// </summary>        
        private string type;

        /// <summary>
        /// Initializes a new instance of Food.
        /// </summary>
        /// <param name="name">Nombre del Food.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del Food.</param>
        /// <param name="draggable">Bool que define si es arrastrable.</param>
        /// <param name="container">Container Source en donde es creado.</param>
        /// <param name="type">String del tipo de Food.</param>
        public Food(string name, Space level, float positionX, float positionY, float width, float height, string image, bool draggable, IContainer container, string type)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Type = type;
            this.Draggable = draggable;
            this.Container = container;
        }

        /// <summary>
        /// Gets or sets del type.
        /// </summary>
        /// <value>Tipo de fruta.</value>
        public string Type {get; set;}

        /// <summary>
        /// Gets or sets del container.
        /// </summary>
        /// <value><see cref="Items"/>.</value>
        public IContainer Container { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether el item es arrastrable.
        /// </summary>
        /// <value>Bool arrastrable.</value>
        public bool Draggable { get; set; }

        /// <summary>
        /// Accion realizada al soltar el alimento.
        /// </summary>
        public bool Drop(IContainer container)
        {
            EngineGame engineGame = Singleton<EngineGame>.Instance;
            Bowl bowl;

            try
            {
                bowl = container as Bowl;
            }
            catch(System.InvalidCastException)
            {
                throw new System.InvalidCastException($"Invalid cast operation as MoneyContainer.");
            }

            return (engineGame.LevelEngines[this.Level] as EngineKitchenExercise1).VerifyExercise(bowl, this);
        }
    }
}