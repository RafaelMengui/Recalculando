//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise1.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
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
            this.Operations = new List<Operations>();
        }

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
            this.ResultsOfLevel = new bool[3];
            this.OperationCounter = 0;
            this.actualRecipe = 0;
        }

        /// <summary>
        /// Metodo responsable de asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        /// <param name="feedback">Feedback.</param>
        public void SetFeedback(Feedback feedback)
        {
            this.LevelFeedback = feedback;
            this.LevelFeedback.Text = "Hola! En este juego deberas completar la receta, arrastra los ingredientes que correspondan con la receta.";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
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
        /// Verifica que se hayan completado las tres operaciones del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel[0] && this.ResultsOfLevel[1] && this.ResultsOfLevel[2])
            {
                this.LevelFeedback.Text = "Bien Hecho! has completado la receta. Puedes continuar al siguiente nivel.";
                this.engineGame.UpdateFeedback(this.LevelFeedback);
                this.ButtonGoToNextLevel();
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
                food.Draggable = false;     //puede pasar que cuando se haga el clear() el food siga siendo draggable = flase
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
        public bool GoodFeedback()
        {
            this.LevelFeedback.Text = "Muy buen trabajo, ¡Continua asi!";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public bool BadFeedback()
        {
            this.LevelFeedback.Text = "Ese alimento no es correcta, ¡Intentalo de nuevo!";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
            return true;
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, crea el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public IComponent ButtonGoToMain()
        {
            Items goToMain = new ButtonGoToPage("Kitchen1ToMain", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MainPage");
            this.Level.ItemList.Add(goToMain);
            return goToMain;
        }

        /// <summary>
        /// Este boton aparecera en pantalla al terminar un nivel, al ejecutarlo ira a la proxima pantalla del nivel kitchen.
        /// </summary>
        public void ButtonGoToNextLevel()
        {
            Items goToNext = new ButtonStartLevel("Kitchen1ToKitchen2", this.Level, 0, 0, 500, 300, "siguienteNivel.png", "#FCFCFC", "KitchenExercise2");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
        }
    }
}