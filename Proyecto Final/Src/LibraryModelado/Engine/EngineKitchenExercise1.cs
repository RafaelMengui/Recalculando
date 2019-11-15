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
    /// En este juego se debe arrastrar los ingredientes que se piden por pantalla.La lógica se encarga de chequear
    /// que los ingredientes sean los correctos
    /// Este motor presenta una ALTA COHESIÓN, debido a que, una clase con responsabilidades alta o fuertemente
    /// relacionadas tiene alta cohesión. Esto nos dice que, la información que almacena una clase debe ser coherente
    /// y debe estar (en la medida de lo posible) relacionada con la clase. Esto sucede claramente en EngineKitchenExercise1
    /// este motor tiene solamente lo que le interesa para funcionar, por esto decidimos realizar un motor para cada ejercicio.
    /// Además también cumple con el patrón EXPERT, este nos dice que, debemos asignar la responsabilidad al experto en
    /// información, es decir, a la clase que tiene la información necesaria para poder cumplir con la responsabilidad. En este
    /// caso, la clase que tiene toda la información lógica del ejercicio 1 es EngineKitchenExcerise1, por esto, es la experta.
    /// Utilzamos este patrón porque se mantiene el encapsulamiento, los objetos utilizan su propia información para
    /// llevar a cabo sus tareas.
    /// Hereda de la interfaz <see cref="ILevelEngine"/>.
    /// </summary>
    public class EngineKitchenExercise1 : ILevelEngine
    {
        /// <summary>
        /// Variable Level utilizada para instanciar un nivel asignable.
        /// </summary>
        private Space level;

        /// <summary>
        /// Objeto de tipo <see cref="Feedback"/> que mostrara por pantalla textos para interactuar con el usuario.
        /// </summary>
        private Feedback levelFeedback;

        /// <summary>
        /// Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        private ButtonGoToPage buttonGoToMain;

        /// <summary>
        /// Contador de receta actual.
        /// </summary>
        /// <value>Int.</value>
        private int recipeCounter;

        /// <summary>
        /// Instancia unica del motor general.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        /// <summary>
        /// Button que aparecera al completarse el nivel, con la funcionalidad de empezar el proximo nivel.
        /// </summary>
        private ButtonGoToPage buttonNextLevel;

        /// <summary>
        /// Diccionario en donde se guardara la informacion de la receta.
        /// Clave = Tipo de alimento.
        /// Valor = Cantidad de alimentos.
        /// </summary>
        private Dictionary<string, int> currentRecipe;

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
            this.RecipeList = new List<Recipe>();
            this.ButtonNextLevel = this.buttonNextLevel;
            this.recipeCounter = 0;
            this.CurrentRecipe = this.currentRecipe;
        }

        /// <summary>
        /// Gets or sets Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        public ButtonGoToPage ButtonGoToMain { get; set; }

        /// <summary>
        /// Gets or sets del diccionario en donde se guardara la informacion de la receta.
        /// Clave = Tipo de alimento.
        /// Valor = Cantidad de alimentos.
        /// </summary>
        /// <value>Diccionario.</value>
        public Dictionary<string, int> CurrentRecipe { get; set; }

        /// <summary>
        /// Gets y Sets de la lista de recetas.
        /// </summary>
        /// <value>Recipe</value>
        public List<Recipe> RecipeList { get; set; }

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
        /// Gets or sets del boton que aparecera al completarse el nivel, con la funcionalidad de empezar el proximo nivel.
        /// </summary>
        public ButtonGoToPage ButtonNextLevel { get; set; }

        /// <summary>
        /// Gets or sets de contador utilizado para saber en que operacion de la pagina nos encontramos.
        /// Existen dos operaciones dentro de la pagina.
        /// </summary>
        /// <value>Int.</value>
        public int OperationCounter { get; private set; }

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
            string text = "¡Hola! Necesito ayuda para completar mi receta. ¿Puedes ayudarme? Arrastra el ingrediente que necesito al bowl";

            if (this.ButtonGoToMain is null)
            {
                this.CreateButtonGoToMain();
            }
            if (this.ButtonNextLevel is null)
            {
                this.CreateButtonGoToNextLevel();
            }
            if (this.LevelFeedback is null)
            {
                this.CreateFeedback();
            }

            this.ResultsOfLevel = new bool[3];
            this.OperationCounter = 0;
            this.recipeCounter = 0;
            this.CurrentRecipe = new Dictionary<string, int>(this.RecipeList[this.recipeCounter].FoodList);
            this.UpdateRecipe();

            this.engineGame.SetActive(this.ButtonNextLevel, false);
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);

            foreach (Operations operation in this.Operations)
            {
                foreach (Items item in operation.Components)
                {
                    this.engineGame.SetItemDraggable(item, true);
                }
            }
            this.RestartContainers();
        }

        /// <summary>
        /// Metodo responsable de verificar si el objeto tipo Food soltado dentro del Bowl,
        /// tiene el tipo que aceptado por la.
        /// </summary>
        /// <param name="bowl">Container tipo <see cref="FoodContainer"/>.</param>
        /// <param name="droppedFood">DraggableItem tipo <see cref="Food"/>.</param>
        /// <returns>Bool si el alimento está en la receta o no.</returns>
        public bool VerifyOperation(FoodContainer bowl, Food droppedFood)
        {
            foreach (var foodType in this.CurrentRecipe)
            {
                if (droppedFood.Type.Equals(foodType.Key))
                {
                    this.CurrentRecipe[foodType.Key] -= 1;

                    if (this.CurrentRecipe[foodType.Key] == 0)
                    {
                        this.CurrentRecipe.Remove(foodType.Key);
                    }
                    return true;
                }
            }

            return false;
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

                foreach (Operations operation in this.Operations)
                {
                    foreach (Items item in operation.Components)
                    {
                        this.engineGame.SetItemDraggable(item, false);
                    }
                }

                // Se muestra el boton para volver al inicio.
                this.engineGame.SetActive(this.ButtonNextLevel, true);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica que se haya completado la receta.
        /// Si fue completada, se actualiza la receta.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyRecipe()
        {
            if (this.CurrentRecipe.Count == 0)
            {
                this.ResultsOfLevel[this.OperationCounter] = true;
                this.OperationCounter += 1;
                this.recipeCounter += 1;

                if (this.recipeCounter < this.RecipeList.Count)
                {
                    string text = "Receta Completada! Continuemos con la proxima.";
                    this.engineGame.UpdateFeedback(this.LevelFeedback, text);
                    this.CurrentRecipe = new Dictionary<string, int>(this.RecipeList[this.recipeCounter].FoodList);
                    this.UpdateRecipe();
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que se utiliza para verificar que se haya soltado el item correcto dentro del bowl.
        /// Solamente se podra soltar un item dentro de un FoodContainer que se encuentre dentro de algun operation.
        /// </summary>
        /// <param name="bowl">Container de alimentos donde se encuentra la receta.</param>
        /// <param name="food">Alimento arrastrado.</param>
        /// <returns>Bool si el alimento soltado es correcto.</returns>
        public bool VerifyExercise(FoodContainer bowl, Food food)
        {
            foreach (Operations operation in this.Operations)
            {
                if (operation.Components.Contains(bowl))
                {
                    if (this.VerifyOperation(bowl, food))
                    {
                        this.VerifyRecipe();
                        this.GoodFeedback();
                        this.UpdateRecipe();
                        this.VerifyWinLevel();
                        return true;
                    }
                    else
                    {
                        this.BadFeedback();
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        public void GoodFeedback()
        {
            string text = "¡Muy bien, sigue asi!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public void BadFeedback()
        {
            string text = "Este ingrediente no lo necesito ahora, ¡vuelve a intentarlo!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo responsable de Crear y asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        public void CreateFeedback()
        {
            Feedback feedback = new Feedback("Feedback1", this.Level, -580, 165, 325, 400, "Vacio.png", string.Empty, 35, true, false);
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
        /// Este boton aparecera en pantalla al terminar un nivel.
        /// </summary>
        public void CreateButtonGoToNextLevel()
        {
            ButtonGoToPage goToNext = new ButtonGoToPage("kitchenToMain", this.Level, 0, 0, 500, 300, "botonToMain.png", "#FCFCFC", "MainPage");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
            this.ButtonNextLevel = goToNext;
        }

        /// <summary>
        /// Metodo utilizado para vaciar el Food Container de los resultados.
        /// Es utilizado para evitar errores.
        /// </summary>
        public void RestartContainers()
        {
            foreach (Operations operation in this.Operations)
            {
                foreach (Items item in operation.Components)
                {
                    if (item is FoodContainer)
                    {
                        FoodContainer bowl = item as FoodContainer;
                        bowl.SavedItems.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Metodo utilizado para obtener informacion de un objeto <see cref="Recipe"/>,
        /// y devuelve un texto con el formato necesario para mostrarlo por pantalla.
        /// </summary>
        /// <returns>String</returns>
        public string GetOrder()
        {
            string order = string.Empty;
            if (this.CurrentRecipe.Count > 0)
            {
                foreach (var foods in this.CurrentRecipe)
                {
                    order += $"{foods.Value} {foods.Key}";

                    if (foods.Value > 1)
                    {
                        order += "s";
                    }
                    order += ",";
                }
            }
            return order;
        }

        /// <summary>
        /// Metod que actualiza la receta mostrada por pantalla, obtiene la informacion necesaria del metodo
        /// GetOrder().
        /// </summary>
        public void UpdateRecipe()
        {
            string[] orders = this.GetOrder().Split(',');
            int counter = 0;
            foreach (Operations operation in this.Operations)
            {
                foreach (Items item in operation.Components)
                {
                    if (item is Label && counter < orders.Length)
                    {
                        string text = orders[counter];
                        this.engineGame.UpdateText(item, text);
                        counter += 1;
                    }
                }
            }
        }
    }
}