using Proyecto.Item.ScientistLevel;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase abstracta de motores.
    /// </summary>
    public abstract class IEngine
    {
        /// <summary>
        /// Metodo abstracto de crear un boton prefabricado que muestra la pagina principal, en cada nivel.
        /// </summary>
        public abstract IComponent ButtonGoToMain();

        /// <summary>
        /// /// Metodo abstracto que asigna las operaciones de cada nivel.
        /// </summary>
        /// <param name="component"></param>
        public abstract void SetOperations(IComponent component);
    }
}