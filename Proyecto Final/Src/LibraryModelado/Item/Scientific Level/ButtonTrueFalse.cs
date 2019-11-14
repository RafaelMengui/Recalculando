//--------------------------------------------------------------------------------
// <copyright file="ButtonTrueFalse.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Item.ScientistLevel
{
    /// <summary>
    /// Clase responsable de crear botones true false, utilizados en un ejercicio multipleopcion, solamente un boton
    /// sera el true (correcto).
    /// Hereda de la clase abstracta <see cref="Items"/>, e implementa la interfaz <see cref="IButton"/>.
    /// </summary>
    public class ButtonTrueFalse : Items, IButton
    {
        /// <summary>
        /// Accion del boton.
        /// </summary>
        private Action<string> evento;

        /// <summary>
        /// Initializes a new instance of Button.
        /// </summary>
        /// <param name="name">Nombre del boton.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del boton.</param>
        /// <param name="color">Color del boton en Hexadecimal.</param>
        /// <param name="value">Opcion de verdadero o falso.</param>
        public ButtonTrueFalse(string name, Space level, float positionX, float positionY, float width, float height, string image, string color, bool value)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Color = color;
            this.Event = this.evento;
            this.Value = value;
            this.Pushable = true;
        }

        /// <summary>
        /// Gets or sets del Color del Boton.
        /// </summary>
        /// <value>string codigo en hexadecimal.</value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets indicating whether el boton es presionable.
        /// Por defecto es true.
        /// </summary>
        /// <value>Bool.</value>
        public bool Pushable { get; set; }

        /// <summary>
        /// Gets or sets del valor bool del boton.
        /// </summary>
        /// <value>Bool.</value>
        public bool Value { get; set; }

        /// <summary>
        /// Gets or sets del evento del boton.
        /// </summary>
        /// <value>Action.</value>
        public Action<string> Event { get; set; }

        /// <summary>
        /// Accion realizada por el boton.
        /// </summary>
        /// <param name="text">Sin funcionalidad.</param>
        public void Click(string text)
        {
            if (this.Pushable)
            {
                EngineGame engineGame = Singleton<EngineGame>.Instance;
                if (engineGame.LevelEngines[this.Level] is EngineScientificExercise2)
                {
                    (engineGame.LevelEngines[this.Level] as EngineScientificExercise2).VerifyExercise(this);
                }
                if (engineGame.LevelEngines[this.Level] is EngineScientificExercise3)
                {
                    (engineGame.LevelEngines[this.Level] as EngineScientificExercise3).VerifyExercise(this);
                }
                else if((engineGame.LevelEngines[this.Level] is EngineScientificExercise4))
                {
                    (engineGame.LevelEngines[this.Level] as EngineScientificExercise4).VerifyExercise(this);
                }
            }
        }
    }
}