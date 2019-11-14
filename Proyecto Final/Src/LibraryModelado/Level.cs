//--------------------------------------------------------------------------------
// <copyright file="Level.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase responsable de crear Niveles en el modelado.
    /// Hereda de la clase abstracta <see cref="Space"/>.
    /// </summary>
    public class Level : Space
    {
        /// <summary>
        /// Initializes a new instance of level.
        /// </summary>
        /// <param name="name">Nombre del nivel.</param>
        /// <param name="image">Nombre de la imagen de fondo del nivel.</param>
        public Level(string name, string image)
        : base(name, image)
        {
        }
    }
}