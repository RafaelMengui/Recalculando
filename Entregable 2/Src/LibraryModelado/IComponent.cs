//--------------------------------------------------------------------------------
// <copyright file="IComponent.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Interfaz IComponent.
    /// Todos los objetos creados en el modelado(World, Space, Items) seran de tipo IComponent.
    /// </summary>
    public interface IComponent
    {
        string ID { get; set; }
    }
}