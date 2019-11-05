//--------------------------------------------------------------------------------
// <copyright file="IButton.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Interfaz de Botones.
    /// Esta interfaz es creada, debido a que, cuando en un futuro querramos
    /// tener difrentes tipos de botones lo podamos hacer. Por ejemplo, un botón
    /// que sea una imagen,un botón contador, botón audio, etc.
    /// En este caso, estamos pensando en la funcionalidad futura del código,
    /// para cuando debamos ampliar el juego.
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// Acciones y eventos realizados al hacer click en un boton.
        /// Esta operación es POLIMÓRFICA debido a que es implementada por dos
        /// o más objetos de diferentes tipos. El método Click, es implementado
        /// por todos los botones del juego, por esto, se puede llamar una operación
        /// Polymórfica. 
        /// </summary>
        /// <param name="text">String.</param>
        void Click(string text);
    }
}