//--------------------------------------------------------------------------------
// <copyright file="IComponent.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Interfaz IComponent.
    /// En esta interfaz utilizamos el Principio de SEGREGACIÓN de INTERFACES, este nos dice que,
    /// ninguna clase debería depender de métodos que no usa. Por tanto, creamos interfaces
    /// que definen comportamientos, las clases que necesiten de estos comportamientos van a
    /// implementar esta interfaz.Ejemplo: Space, World
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Gets or sets del ID de un objeto asignado al crearlo en unity.
        /// </summary>
        /// <value></value>
        string ID { get; set; }
    }
}