namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Patron Singleton, permite crear solamente una instancia de una clase generica "T".
    /// </summary>
    /// <typeparam name="T">Clase Generica.</typeparam>
    public class Singleton<T> where T : new()
    {
        private static T instance;

        /// <summary>
        /// Gets or sets de la instancia de la clase T.
        /// </summary>
        /// <value></value>
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