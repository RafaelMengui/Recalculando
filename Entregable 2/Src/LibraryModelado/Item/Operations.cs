//--------------------------------------------------------------------------------
// <copyright file="Operations.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Las objetos Operations son utilizados como herramienta en donde en un lista
    /// se almacenan los objetos que esten presentes en una operacion de un juego.
    /// Por ejemplo: En el nivel ScientificExercise1 los Operations se utilizan para
    /// almacenar todos los containers utilizados en una sola cuenta.
    /// </summary>
    public class Operations : IComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="level">Nivel al que pertenece la operacion.</param>
        /// <param name="components">Lista de componentes.</param>
        public Operations(Space level, List<Items> components)
        {
            this.Level = level;
            this.Components = components;
        }

        /// <summary>
        /// Gets or sets del nivel a que pertenece la operacion.
        /// </summary>
        /// <value>Space.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Gets or sets de la lista de componentes.
        /// </summary>
        /// <value></value>
        public List<Items> Components { get; set; }

        /// <summary>
        /// Gets or sets del ID del objeto, siempre tendra valor null debido a que la Operation no sera un
        /// objeto unity, sino que solamente una herramienta.
        /// </summary>
        /// <value></value>
        public string ID { get; set; }
    }
}