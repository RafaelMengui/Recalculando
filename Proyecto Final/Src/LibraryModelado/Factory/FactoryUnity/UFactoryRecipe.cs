//--------------------------------------------------------------------------------
// <copyright file="UFactoryRecipe.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Common;
using Proyecto.Item.KitchenLevel;
using Proyecto.LibraryModelado;
using Proyecto.LibraryModelado.Engine;

namespace Proyecto.Factory.Unity
{
    /// <summary>
    /// Esta clase es la resposable de agregar los componentes Recipe al juego.
    /// Hereda de la Clase abstracta <see cref="FactoryUnity"/>.
    /// </summary>
    public class UFactoryRecipe : FactoryUnity
    {
        /// <summary>
        /// Instancia del motor general del juego.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        /// <summary>
        /// Receta.
        /// </summary>
        private Recipe recipe;

        /// <summary>
        /// Sobrescribe el metodo abstracto de FactoryUnity.
        /// Debido a que no crearemos un objeto Recipe en unity, esta clase no tiene ninguna responsabilidad,
        /// mas que asignarle al motor de unity el adaptador de tipo <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="adapter">Adapter <see cref="IMainViewAdapter"/>.</param>
        /// <param name="component">Componente que se agregara a Unity <see cref="IComponent"/>.</param>
        public override void MakeUnityItem(IMainViewAdapter adapter, IComponent component)
        {
            try
            {
                // Castear como Recipe.
                this.recipe = component as Recipe;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Fail to cast component as Recipe");
            }

            if (this.engineGame.LevelEngines[this.recipe.Level] is EngineKitchenExercise1)
            {
                EngineKitchenExercise1 engineKitchen = this.engineGame.LevelEngines[this.recipe.Level] as EngineKitchenExercise1;
                engineKitchen.RecipeList.Add(this.recipe);
            }
        }
    }
}