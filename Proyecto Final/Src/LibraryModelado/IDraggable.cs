//--------------------------------------------------------------------------------
// <copyright file="IDraggable.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Interfaz de Objetos Arrastrables.
    /// En esta interfaz utilizamos el Principio de SEGREGACIÓN de INTERFACES, este nos dice que,
    /// ninguna clase debería depender de métodos que no usa. Por tanto, creamos interfaces
    /// que definen comportamientos, las clases que necesiten de estos comportamientos van a
    /// implementar esta interfaz.
    /// </summary>
    public interface IDraggable : IComponent
    {
        /// <summary>
        /// Container en donde se encuentra el draggable item.
        /// </summary>
        /// <value>IContainer.</value>
        IContainer Container { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether el item es arrastrable.
        /// </summary>
        /// <value>Bool arrastrable.</value>
        bool Draggable { get; set; }

        /// <summary>
        /// Metodo que se ejecutara al soltar el item.
        /// </summary>
        /// <param name="container">Container en donde se soltara el item.</param>
        bool Drop(IContainer container);
    }
}