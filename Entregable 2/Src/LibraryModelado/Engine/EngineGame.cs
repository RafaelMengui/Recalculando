//--------------------------------------------------------------------------------
// <copyright file="EngineGame.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Motor general del juego.
    /// Tiene la responsabilidad de conocer y controlar la funcionalidad de los demas motores del juego.
    /// Para realizar los diferentes motores utilizamos el patrón SINGLETON, este nos permite garantizar
    /// la existencia de una sola instancia de clase. Además el acceso a esa única instancia tiene
    /// que ser global. Esto es de mucha utilidad debido a que vamos a necesitar llamar a los motores
    /// de los juego desde diferentes partes del código. Como se ejecuta una única vez nos aseguramos
    /// de que solo haya un motor de este juego.
    /// Hereda de la clase abstracta <see cref="IEngine"/>.
    /// </summary>
    public class EngineGame : IEngine
    {
        /// <summary>
        /// Diccionario en donde se le asocia a un nivel, su respectivo Motor.
        /// </summary>
        private Dictionary<Space, IEngine> levelEngines = new Dictionary<Space, IEngine>();

        /// <summary>
        /// Motor generico <see cref="IEngine"/>.
        /// </summary>
        private IEngine engine;

        /// <summary>
        /// Pagina principal del juego, el motor la conoce para poder viajar a ella en cualquier momento.
        /// </summary>
        private Space mainPage;

        private Space currentPage;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EngineGame()
        {
            this.MainPage = mainPage;
            this.LevelEngines = levelEngines;
            this.CurrentPage = mainPage;
        }

        /// <summary>
        /// Gets or sets del diccionario de motores y niveles.
        /// </summary>
        /// <value>Dictionario de clave <see cref="Space"/> y valor <see cref="IEngine"/>.</value>
        public Dictionary<Space, IEngine> LevelEngines { get; set; }

        public Space CurrentPage;

        /// <summary>
        /// Gets or sets de la pagina principal.
        /// </summary>
        /// <value>Space.</value>
        public Space MainPage { get; set; }

        /// <summary>
        /// Metodo responsable de asociarle a cada nivel su respectivo motor, y agregarlo al diccionario this.LevelEngines.
        /// </summary>
        /// <param name="componentList">Lista de componentes creados.</param>
        public void Asociate(List<IComponent> componentList)
        {
            foreach (IComponent component in componentList)
            {
                if (component is Space)
                {
                    Space level = component as Space;
                    try
                    {
                        this.engine = Activator.CreateInstance(Type.GetType("Proyecto.LibraryModelado.Engine.Engine" + level.Name)) as IEngine;
                    }
                    catch (System.Exception)
                    {
                        throw new Exception($"Engine \"{"Engine" + level.Name}\" does not exist.");
                    }

                    this.LevelEngines.Add(level, this.engine);
                }
            }
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, en donde ejecuta para cada
        /// motor de los niveles el metodo de crear un boton que muestre la pagina principal.
        /// </summary>
        public override void ButtonGoToMain()
        {
            foreach (var engine in this.levelEngines)
            {
                engine.Value.ButtonGoToMain();
            }
        }
    }
}