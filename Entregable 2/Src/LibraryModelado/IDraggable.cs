//--------------------------------------------------------------------------------
// <copyright file="IDraggable.cs" company="Universidad Católica del Uruguay">
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