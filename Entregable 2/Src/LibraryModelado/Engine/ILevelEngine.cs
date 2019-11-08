using System.Collections.Generic;
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Interfaz para los motores de los niveles.
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
        /// Metodo que crea y devuelve un boton prefabricado que al presionarlo mostrara la pantalla principal.
        /// </summary>
        /// <returns>IComponent</returns>
        IComponent ButtonGoToMain();

        /// <summary>
        /// Metodo responsable de asignarle a un motor, su respectivo objeto feedback.
        /// </summary>
        /// <param name="feedback">Feedback.</param>
        void SetFeedback(Feedback feedback);

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        bool GoodFeedback();

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        bool BadFeedback();

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del juego.
        /// </summary>
        void StartLevel();

        /// <summary>
        /// Al finalizar el nivel, se creara en pantalla un boton que permitira ir al siguiente nivel.
        /// </summary>
        void ButtonGoToNextLevel();
    }
}