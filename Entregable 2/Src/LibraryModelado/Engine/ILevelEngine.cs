//--------------------------------------------------------------------------------
// <copyright file="ILevelEngine.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Interfaz implementada por los motores especificos de niveles.
    /// Contiene todos los metodos, atributos y herramientas utilizadas para el funcionamiento de cada uno.
    /// </summary>
    public interface ILevelEngine
    {
        /// <summary>
        /// Gets de la lista de operaciones propias de cada nivel.
        /// </summary>
        /// <value>Lista de operaciones.</value>
        List<Operations> Operations { get; }

        /// <summary>
        /// Gets or sets Nivel asociado al motor.
        /// </summary>
        /// <value>Space.</value>
        Space Level { get; set; }

        /// <summary>
        /// Gets or sets del feedback asociado al motor.
        /// </summary>
        /// <value>Feedback.</value>
        Feedback LevelFeedback { get; set; }

        /// <summary>
        /// Gets or sets del boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        ButtonGoToPage ButtonGoToMain { get; set; }

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        void GoodFeedback();

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        void BadFeedback();

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del juego.
        /// </summary>
        void StartLevel();

        /// <summary>
        /// Metodo que crea un boton prefabricado que al presionarlo mostrara la pantalla principal.
        /// </summary>
        /// <returns>IComponent</returns>
        void CreateButtonGoToMain();

        /// <summary>
        /// Metodo responsable de asignarle a un motor, su respectivo objeto feedback.
        /// </summary>
        void CreateFeedback();
    }
}