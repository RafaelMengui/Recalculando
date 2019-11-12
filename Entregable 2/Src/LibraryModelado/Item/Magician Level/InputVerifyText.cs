//--------------------------------------------------------------------------------
// <copyright file="InputVerifyText.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase responsable de crear InputVerifyText en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>.
    /// </summary>
    public class InputVerifyText : Items
    {
        /// <summary>
        /// Initializes a new instance of InputVerifyText.
        /// </summary>
        /// <param name="name">Nombre de la imagen.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del input.</param>
        public InputVerifyText(string name, Space level, float positionX, float positionY, float width, float height, string image, string acceptableValue)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.AcceptableValue = acceptableValue;
            this.CurrentText = string.Empty;
        }

        public string AcceptableValue { get; set; }

        /// <summary>
        /// Gets or sets del texto que se encuentra actualmente en el input text.
        /// </summary>
        /// <value></value>
        public string CurrentText { get; set; }

        public void Edit(string itemID, string text)
        {
            EngineGame engineGame = Singleton<EngineGame>.Instance;
            this.CurrentText = text;

            if (engineGame.LevelEngines[this.Level] is EngineMagician)
            {
                EngineMagician magicianLevel = engineGame.LevelEngines[this.Level] as EngineMagician;
                magicianLevel.VerifyExercise(this, text);
            }
        }

        public void Change(string itemID, string text)
        {

        }
    }
}