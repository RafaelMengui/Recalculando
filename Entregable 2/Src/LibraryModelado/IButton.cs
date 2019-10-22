//--------------------------------------------------------------------------------
// <copyright file="IButton.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Interfaz de Botones.
    /// Permite crear varios botones con diferentes funcionalidades.
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// Acciones y eventos realizados al hacer click en un boton.
        /// </summary>
        /// <param name="text">String.</param>
        void Click(string text);
    }
}