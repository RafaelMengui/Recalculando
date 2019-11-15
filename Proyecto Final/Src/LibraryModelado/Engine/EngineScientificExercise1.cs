//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise1.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using Proyecto.Item;
using Proyecto.Item.ScientistLevel;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineScientificExercise1, responsable de implementar la logica del ejercicio 1 del nivel scientific.
    /// Este motor presenta una ALTA COHESIÓN, debido a que, una clase con responsabilidades alta o fuertemente
    /// relacionadas tiene alta cohesión. Esto nos dice que, la información que almacena una clase debe ser coherente
    /// y debe estar (en la medida de lo posible) relacionada con la clase.Esto sucede claramente en EngineScientificExercise1
    /// este motor tiene solamente lo que le interesa para funcionar, por esto decidimos realizar un motor para cada ejercicio.
    /// Además también cumple con el patrón EXPERT, este nos dice que, debemos asignar la responsabilidad al experto en
    /// información, es decir, a la clase que tiene la información necesaria para poder cumplir con la responsabilidad. En este
    /// caso, la clase que tiene toda la información lógica del ejercicio 1 es EngineScientificExcerise1, por esto, es la experta.
    /// Utilzamos este patrón porque se mantiene el encapsulamiento, los objetos utilizan su propia información para
    /// llevar a cabo sus tareas.
    /// Hereda de la interfaz <see cref="ILevelEngine"/>.
    /// </summary>
    public class EngineScientificExercise1 : ILevelEngine
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
        public EngineScientificExercise1()
        {
            this.Level = this.level;
            this.ResultsOfLevel = new bool[3];
            this.LevelFeedback = this.levelFeedback;
            this.ButtonGoToMain = this.buttonGoToMain;
            this.ButtonNextLevel = this.buttonNextLevel;
            this.LevelCounter = 0;
            this.Operations = new List<Operations>();
        }

        /// <summary>
        /// Gets or sets Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        public ButtonGoToPage ButtonGoToMain { get; set; }

        /// <summary>
        /// Gets or sets del boton que aparecera al completarse el nivel, con la funcionalidad de empezar el proximo nivel.
        /// </summary>
        public ButtonStartLevel ButtonNextLevel { get; set; }

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
        public int LevelCounter { get; private set; }

        /// <summary>
        /// Gets de los resultados del nivel.
        /// Por predeterminado los dos parametros son False.
        /// true = Completo una pagina correctamente (los dos parametros de this.ResultsOfPage son true).
        /// false = No completo las dos operaciones de la pagina.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del juego.
        /// Reinicia el feedback, el array de resultados, y el contador.
        /// Ademas recorre las operaciones, toma el ultimo container de la lista, debido a que
        /// este siempre sera el container del resultado. Toma el item guardado en este container,
        /// y lo retorna a su container inicial. Solamente si el Draggable item no es draggble
        /// (draggableItem.Draggable = false) lo convierte en true, para evitars errores.
        /// </summary>
        public void StartLevel()
        {
            string text = "Hola! Soy la Científica, en este juego deberas completar la suma, arrastrando el dinero correcto.";

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
            this.LevelCounter = 0;
            this.engineGame.SetActive(this.ButtonNextLevel, false);
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);

            this.RestartContainers();

        }

        /// <summary>
        /// Metodo responsable de verificar si el objeto tipo Money soltado dentro del MoneyContainer,
        /// tiene el valor que acepta el container.
        /// </summary>
        /// <param name="moneyContainer">Container tipo <see cref="MoneyContainer"/>.</param>
        /// <param name="money">DraggableItem tipo <see cref="Money"/>.</param>
        /// <returns>Bool si el valor es correcto o no.</returns>
        public bool VerifyOperation(MoneyContainer moneyContainer, Money money)
        {
            return moneyContainer.AcceptableValue == money.Value;
        }

        /// <summary>
        /// Verifica que se hayan completado las tres operaciones del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel[0] && this.ResultsOfLevel[1] && this.ResultsOfLevel[2])
            {
                // Se Actualiza el Feedback.
                string text = "Excelente trabajo! Puedes continuar al siguiente nivel.";
                this.engineGame.UpdateFeedback(this.LevelFeedback, text);

                // Se muestra el boton para el proximo nivel.
                this.engineGame.SetActive(this.ButtonNextLevel, true);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Metodo que se utiliza para verificar que este correctamente realizada una de las operaciones.
        /// Si esta bien hecha la operacion, el bool (en this.ResultsOfPage) asociado a la parte del nivel pasa a ser true.
        /// Al contador se le suma 1, y el container del money, pasa a ser el container en donde es dropeado.
        /// </summary>
        /// <param name="moneyContainer">Container de dinero en donde es soltado el dinero.</param>
        /// <param name="money">Dinero arrastrado.</param>
        /// <returns>Bool si el dinero soltado es correcto.</returns>
        public bool VerifyExercise(MoneyContainer moneyContainer, Money money)
        {
            if (this.VerifyOperation(moneyContainer, money))
            {
                this.ResultsOfLevel[this.LevelCounter] = true;
                this.LevelCounter += 1;
                this.GoodFeedback();
                this.engineGame.SetItemDraggable(money, false);
                this.VerifyWinLevel();
                return true;
            }
            else
            {
                if (moneyContainer.AcceptableValue != -1)
                {
                    this.BadFeedback();
                }

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
            ButtonGoToPage goToMain = new ButtonGoToPage("Scientific1ToMain", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MenuScientific");
            this.Level.ItemList.Add(goToMain);
            this.engineGame.CreateInUnity(goToMain);
            this.ButtonGoToMain = goToMain;
        }

        /// <summary>
        /// Metodo para crear un boton que al ejecutarlo ira al proximo nivel del nivel cientifico.
        /// Este boton aparecera en pantalla al terminar un nivel.
        /// </summary>
        public void CreateButtonGoToNextLevel()
        {
            ButtonStartLevel goToNext = new ButtonStartLevel("Scientific1ToScientific2", this.Level, 0, 0, 500, 300, "siguienteNivel.png", "#FCFCFC", "ScientificExercise2");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
            this.ButtonNextLevel = goToNext;
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
                        this.engineGame.SetItemDraggable(savedItem, true);
                        this.engineGame.CenterInContainer(savedItem);
                    }

                    resultContainer.SavedItems.Clear();
                }
            }
        }
    }
}