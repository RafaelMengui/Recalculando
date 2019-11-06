//--------------------------------------------------------------------------------
// <copyright file="ButtonGoToPage.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Item
{
    /// <summary>
    /// Clase responsable de crear botones, con la funcionalidad de mostrar una pagina diferente en el modelado.
    /// Hereda de la clase abstracta <see cref="Items"/>, e implementa la interfaz <see cref="IButton"/>.
    /// </summary>
    public class ButtonStartLevel : Items, IButton
    {
        /// <summary>
        /// Accion de mostrar otra pagina.
        /// </summary>
        private Action<string> evento;

        /// <summary>
        /// CInitializes a new instance of ButtonGoToPage.
        /// </summary>
        /// <param name="name">Nombre del boton.</param>
        /// <param name="level">Nivel al que pertence.</param>
        /// <param name="positionX">Posicion en eje horizontal en pixeles.</param>
        /// <param name="positionY">Posicion en eje vertical en pixeles.</param>
        /// <param name="width">Ancho en pixeles.</param>
        /// <param name="height">Altura en pixeles.</param>
        /// <param name="image">Imagen del boton.</param>
        /// <param name="color">Color del boton en Hexadecimal.</param>
        /// <param name="levelName">Pagina para mostrar.</param>
        public ButtonStartLevel(string name, Space level, float positionX, float positionY, float width, float height, string image, string color, string levelName)
        : base(name, level, positionX, positionY, width, height, image)
        {
            this.Color = color;
            this.LevelName = levelName;
            this.Event = this.evento;
        }

        /// <summary>
        /// Gets or sets del Color del Boton.
        /// </summary>
        /// <value>string codigo en hexadecimal.</value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets de la pagina a mostrar.
        /// </summary>
        /// <value>string nombre del la pagina.</value>
        public string LevelName { get; set; }

        /// <summary>
        /// Gets or sets del evento del boton.
        /// </summary>
        /// <value>Action.</value>
        public Action<string> Event { get; set; }

        /// <summary>
        /// Acciones realizadas por el boton.
        /// Busca el nivel que coincida con el nivel que mostrara al ser apretado, y obtiene su ID.
        /// </summary>
        /// <param name="text">Sin funcionalidad.</param>
        public void Click(string text)
        {
            EngineGame engineGame = Singleton<EngineGame>.Instance;
            Space level = this.Level.World.SpaceList.Find(delegate(Space space) { return space.Name == this.LevelName; });
            foreach (var engine in engineGame.LevelEngines)
            {
                if (engine.Value == engineGame.LevelEngines[level])
                {
                    engine.Value.StartLevel();
                    engineGame.CurrentPage = level;
                }
            }
            this.Event(level.ID);
        }
    }
}