//--------------------------------------------------------------------------------
// <copyright file="IEngine.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Interfaz implementada por los motores generales del juego (<see cref="EngineGame"/> y <see cref="EngineUnity"/>).
    /// Contiene todos los metodos utilizados para el funcionamiento del juego, y para la comunicacion
    /// entre motores.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Metodo responsable de enviar un IComponent a la UnityFactory.
        /// </summary>
        /// <param name="component">Component.</param>
        void CreateInUnity(IComponent component);

        /// <summary>
        /// Metodo responsable de actualizar el mensaje de feedback mostrado en pantalla.
        /// </summary>
        /// <param name="feedback">Feedback que se vaya a actualizar.</param>
        /// <param name="text">Nuevo texto.</param>
        void UpdateFeedback(Feedback feedback, string text);

        /// <summary>
        /// Metodo responsable de actualizar el texto que aparece sobre un objeto.
        /// </summary>
        /// <param name="items">Item que se vaya actualizar.</param>
        /// <param name="text">Nuevo texto del item.</param>
        void UpdateText(Items items, string text);

        /// <summary>
        /// Metodo responsable de actualizar un item para que sea arrastrable o no.
        /// Si el item ya es arrastrable, no se ejecutara el metodo de unity para evitar errores.
        /// </summary>
        /// <param name="item">Item que se va a actualizar.</param>
        /// <param name="isDraggable">Bool que indica si va a ser arrastrable.</param>
        void SetItemDraggable(Items item, bool isDraggable);

        /// <summary>
        /// Metodo responsable actualizar si un item para que sea mostrado por pantalla u ocultado.
        /// </summary>
        /// <param name="item">item que se va a actualizar.</param>
        /// <param name="active">Bool que indica si se va a mostrar u ocultar.</param>
        void SetActive(Items item, bool active);
    }
}