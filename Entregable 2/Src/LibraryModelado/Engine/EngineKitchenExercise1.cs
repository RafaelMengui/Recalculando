//--------------------------------------------------------------------------------
// <copyright file="EngineKitchenExercise1.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using Proyecto.Item;
using Proyecto.Item.KitchenLevel;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineKitchenExercise1, responsable de implementar la logica del ejercicio 1 del nivel Kitchen.
    /// Este motor presenta una ALTA COHESIÓN, debido a que, una clase con responsabilidades alta o fuertemente
    /// relacionadas tiene alta cohesión. Esto nos dice que, la información que almacena una clase debe ser coherente
    /// y debe estar (en la medida de lo posible) relacionada con la clase. Esto sucede claramente en EngineKitchenExercise1
    /// este motor tiene solamente lo que le interesa para funcionar, por esto decidimos realizar un motor para cada ejercicio.
    /// Hereda de las clases abstractas <see cref="IEngine"/> y <see cref="ILevelEngine"/>.
    /// </summary>
    public class EngineKitchenExercise1 : IEngine, ILevelEngine
    {
        /// <summary>
        /// Variable Recipe utilizada para guardar la recipe actual.
        /// </summary>
        private Recipe recipe;
        /// <summary>
        /// Lista con las recipes del nivel
        /// </summary>
        public List<Recipe> recipeList { get; set; }

        /// <summary>
        /// Variable Level utilizada para instanciar un nivel asignable.
        /// </summary>
        private Space level;

        /// <summary>
        /// Objeto de tipo <see cref="Feedback"/> que mostrara por pantalla textos para interactuar con el usuario.
        /// </summary>
        private Feedback levelFeedback;

        /// <summary>
        /// Button que aparecera al completarse el nivel, con la funcionalidad de empezar el proximo nivel.
        /// </summary>
        private ButtonStartLevel buttonNextLevel;

        /// <summary>
        /// Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        private ButtonGoToPage buttonGoToMain;


        /// <summary>
        /// Instancia unica del motor general.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        /// <summary>
        /// Constructor del motor.
        /// </summary>
        public EngineKitchenExercise1()
        {
            this.Level = this.level;
            this.ResultsOfLevel = new bool[3];
            this.LevelFeedback = this.levelFeedback;
            this.ButtonGoToMain = this.buttonGoToMain;
            this.Operations = new List<Operations>();
        }

        /// <summary>
        /// Gets or sets Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        public ButtonGoToPage ButtonGoToMain { get; set; }

        /// <summary>
        /// Gets de lista de operaciones del nivel.
        /// </summary>
        /// <value>Lista de operacions.</value>
        public List<Operations> Operations { get; }

        /// <summary>
        /// Gets or sets del Feedback asociado al motor.
        /// </summary>
        /// <value>Feedback.</value>
        public Feedback LevelFeedback { get; set; }

        /// <summary>
        /// Gets or sets del nivel asociado a este Motor.
        /// </summary>
        /// <value>Level.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Gets or sets de contador utilizado para saber en que operacion de la pagina nos encontramos.
        /// Existen dos operaciones dentro de la pagina.
        /// </summary>
        /// <value>Int.</value>
        public int OperationCounter { get; private set; }

        /// <summary>
        /// Gets or sets del contador de receta actual.
        /// </summary>
        /// <value>Int.</value>
        public int actualRecipe { get; set; }

        /// <summary>
        /// Gets or sets de los resultados del nivel.
        /// Por predeterminado los dos parametros son False.
        /// true = Completo una pagina correctamente (los dos parametros de this.ResultsOfPage son true).
        /// false = No completo las dos operaciones de la pagina.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del juego.
        /// </summary>
        public void StartLevel()
        {
            string text = "Hola! En este juego deberas completar la suma, arrastrando el dinero correcto.";

            if (this.ButtonGoToMain is null)
            {
                this.CreateButtonGoToMain();
            }
            if (this.LevelFeedback is null)
            {
                this.CreateFeedback();
            }

            this.ResultsOfLevel = new bool[3];
            this.OperationCounter = 0;
            this.actualRecipe = 0;
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
            this.RestartContainers();

        }



        /// <summary>
        /// Metodo responsable de verificar si el objeto tipo Food soltado dentro del Bowl,
        /// tiene el tipo que aceptado por la.
        /// </summary>
        /// <param name="bowl">Container tipo <see cref="Bowl"/>.</param>
        /// <param name="food">DraggableItem tipo <see cref="Food"/>.</param>
        /// <returns>Bool si el alimento está en la receta o no.</returns>
        public bool VerifyOperation(Bowl bowl, Food food)
        {
            bool result = false;

            this.recipe = this.recipeList[this.actualRecipe];  //acá podría regenerarse la lista (cuidado de error)

            foreach (Food _food in this.recipe.FoodList)
            {
                if (food.Type == _food.Type)
                {
                    this.recipe.FoodList.Remove(_food);
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Verifica que se hayan completado las tres operaciones de recetas.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel[0] && this.ResultsOfLevel[1] && this.ResultsOfLevel[2])
            {
                // Se Actualiza el Feedback.
                string text = "Excelente trabajo! Completaste todas las recetas.";
                this.engineGame.UpdateFeedback(this.LevelFeedback, text);

                // Se muestra el boton para volver al inicio.
                this.engineGame.SetActive(this.buttonGoToMain, true);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica que se haya completado la receta.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyRecipe()
        {
            if (this.recipe.FoodList.Count == 0)
            {
                this.actualRecipe += 1;
                this.ResultsOfLevel[this.OperationCounter] = true;
                this.OperationCounter += 1;
                this.VerifyWinLevel();
                this.RestartContainers();

                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Metodo que se utiliza para verificar que este correctamente realizada una de las operaciones.
        /// Si esta bien hecha la operacion, el bool (en this.ResultsOfPage) asociado a la parte del nivel pasa a ser true.
        /// Al contador se le suma 1, y el container del money, pasa a ser el container en donde es dropeado.
        /// </summary>
        /// <param name="bowl">Container de alimentos donde se encuentra la receta.</param>
        /// <param name="food">Alimento arrastrado.</param>
        /// <returns>Bool si el alimento soltado es correcto.</returns>
        public bool VerifyExercise(Bowl bowl, Food food)
        {
            if (this.VerifyOperation(bowl, food))
            {
                this.engineGame.SetItemDraggable(food, false);
                this.GoodFeedback();
                this.VerifyRecipe();
                return true;
            }
            else
            {
                this.BadFeedback();
                return false;
            }

        }

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        public void GoodFeedback()
        {
            string text = "Muy buen trabajo, ¡Continua asi!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public void BadFeedback()
        {
            string text = "Esa suma no es correcta, ¡Intentalo de nuevo!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, crea el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>

        /// <summary>
        /// Metodo responsable de Crear y asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        public void CreateFeedback()
        {
            Feedback feedback = new Feedback("Feedback1", this.Level, 710, 70, 320, 400, "Vacio.png", string.Empty, 30, true, false);
            this.engineGame.CreateInUnity(feedback);
            this.LevelFeedback = feedback;
        }

        /// <summary>
        /// Metodo para crear un boton que al ejecutarlo ira a la pantalla principal.
        /// </summary>
        public void CreateButtonGoToMain()
        {
            ButtonGoToPage goToMain = new ButtonGoToPage("Kitchen1ToMain", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MainPage");
            this.Level.ItemList.Add(goToMain);
            this.engineGame.CreateInUnity(goToMain);
            this.ButtonGoToMain = goToMain;
        }

        /// <summary>
        /// Método que devuelve cada objeto a su container originario.
        /// </summary>
        public void RestartContainers()
        {
            foreach (Operations operation in this.Operations)
            {
                Items item = operation.Components.Last();
                if (item is IContainer)
                {
                    IContainer resultContainer = item as IContainer;
                    foreach (Items savedItem in resultContainer.SavedItems)
                    {
                        if (savedItem is IDraggable)
                        {
                            IDraggable draggableItem = savedItem as IDraggable;
                            this.engineGame.SetItemDraggable(draggableItem, true);
                            this.engineGame.CenterInContainer(draggableItem);
                        }
                    }

                    resultContainer.SavedItems.Clear();
                }
            }
        }
    }
}