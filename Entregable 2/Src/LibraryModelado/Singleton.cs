//--------------------------------------------------------------------------------
// <copyright file="Singleton.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// El patrón SINGLETON nos permite garantizar la existencia de una sola instancia de clase.
    /// Además el acceso a esa única instancia tiene que ser global. Esto es de mucha utilidad 
    /// debido a que, tomamos la decisión de que en nuestro juego haya un único World, por tanto, 
    /// Singleton es fundamental debido a que se ejecuta una única vez, así nos aseguramos que 
    /// sólo existe una instancia. En caso de querer llamarlo en cualquier parte del programa 
    /// se puede realizar.
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