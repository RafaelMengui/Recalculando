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
        /// Gets or sets Nivel asociado al motor.
        /// </summary>
        /// <value></value>
        Space Level { get; set; }

        Feedback LevelFeedback { get; set;}

        IComponent ButtonGoToMain();

        void SetOperations(IComponent component);

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