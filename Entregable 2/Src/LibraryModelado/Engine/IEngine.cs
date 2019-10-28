//--------------------------------------------------------------------------------
// <copyright file="IEngine.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase abstracta de motores.
    /// </summary>
    public abstract class IEngine
    {
        /// <summary>
        /// Metodo abstracto de crear un boton que muestra la pagina principal, en cada nivel.
        /// </summary>
        public abstract void ButtonGoToMain();
    }
}