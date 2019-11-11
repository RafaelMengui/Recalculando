//--------------------------------------------------------------------------------
// <copyright file="IButton.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Interfaz de Botones.
    /// En esta interfaz utilizamos el Principio de SEGREGACIÓN de INTERFACES, este nos dice que,
    /// ninguna clase debería depender de métodos que no usa. Por tanto, creamos interfaces
    /// que definen comportamientos, las clases que necesiten de estos comportamientos van a
    /// implementar esta interfaz.Ejemplo: Botón 
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// Gets or sets indicating whether el boton es presionable.
        /// Por defecto es true.
        /// </summary>
        /// <value>Bool.</value>
        bool Pushable { get; set; }

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