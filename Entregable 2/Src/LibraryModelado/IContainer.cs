//--------------------------------------------------------------------------------
// <copyright file="IContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
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
    public interface IContainer
    {
        /// <summary>
        /// Gets de Lista de elementos guardados en el container.
        /// </summary>
        /// <value>Lista de items.</value>
        List<Items> SavedItems { get; }
    }
}