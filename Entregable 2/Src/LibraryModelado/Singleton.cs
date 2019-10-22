//--------------------------------------------------------------------------------
// <copyright file="Singleton.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Patron Singleton, permite crear solamente una instancia de una clase generica "T".
    /// </summary>
    /// <typeparam name="T">Clase Generica.</typeparam>
    public static class Singleton<T> where T : new()
    {
        /// <summary>
        /// Instancia del singleton.
        /// </summary>
        private static T instance;

        /// <summary>
        /// Gets de la instancia de la clase T.
        /// </summary>
        /// <value>Instance type T.</value>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}