//--------------------------------------------------------------------------------
// <copyright file="UFactoryOperations.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Operation al juego.
    /// Implementa la interfaz <see cref="IFactoryUnity"/>.
    /// </summary>
    public class UFactoryOperations : IFactoryUnity
    {
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        private Operations operations;

        /// <summary>
        /// Sobrescribe el metodo abstracto de IFactoryUnity.
        /// Tiene la responsabilidad de asignarle la operacion a su respectivo motor de su nivel.
        /// No se creara el objeto en unity, debido a que las operaciones no son objetos, sino que una herramienta.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como Operations.
                this.operations = component as Operations;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as Operations");
            }

            this.engineGame.LevelEngines[this.operations.Level].Operations.Add(this.operations);
        }
    }
}