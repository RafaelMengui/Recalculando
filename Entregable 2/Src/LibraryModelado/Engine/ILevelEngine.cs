//--------------------------------------------------------------------------------
// <copyright file="ILevelEngine.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Interfaz para los motores de los niveles.
    /// </summary>
    public interface ILevelEngine
    {
        /// <summary>
        /// Metodo que crea la etiqueta de texto que servira de feedback a las acciones realizadas.
        /// </summary>
        /// <returns>Etiqueta de texto.</returns>
        Label CreateFeedback();

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        void GoodFeedback();

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        void BadFeedback();
    }
}