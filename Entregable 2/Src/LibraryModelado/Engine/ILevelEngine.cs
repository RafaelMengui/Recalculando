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

        Feedback LevelFeedback { get; set; }

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
        /// Al finalizar el nivel, se creara en pantalla un boton que permitira ir al siguiente nivel.
        /// </summary>
        void ButtonGoToNextLevel();
    }
}