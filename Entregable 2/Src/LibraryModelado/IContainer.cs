//--------------------------------------------------------------------------------
// <copyright file="IContainer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// En esta interfaz utilizamos el Principio de SEGREGACIÓN de INTERFACES, este nos dice que,
    /// ninguna clase debería depender de métodos que no usa. Por tanto, creamos interfaces
    /// que definen comportamientos, las clases que necesiten de estos comportamientos van a
    /// implementar esta interfaz..
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