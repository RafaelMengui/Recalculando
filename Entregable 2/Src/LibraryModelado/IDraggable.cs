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
        Items Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        bool Drop(IContainer container);
    }
}