//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise2.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Item;
using System.Collections.Generic;
using Proyecto.Item.ScientistLevel;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineScientificExercise4, responsable de implementar la logica del nivel scientific ejercicio 4.
    /// Este motor presenta una ALTA COHESIÓN, debido a que, una clase con responsabilidades alta o fuertemente
    /// relacionadas tiene alta cohesión. Esto nos dice que, la información que almacena una clase debe ser coherente
    /// y debe estar (en la medida de lo posible) relacionada con la clase.Esto sucede claramente en EngineScientificExercise4
    /// este motor tiene solamente lo que le interesa para funcionar, por esto decidimos realizar un motor para cada ejercicio.
    /// Además también cumple con el patrón EXPERT, este nos dice que, debemos asignar la responsabilidad al experto en
    /// información, es decir, a la clase que tiene la información necesaria para poder cumplir con la responsabilidad. En este
    /// caso, la clase que tiene toda la información lógica del ejercicio 1 es EngineScientificExcerise4, por esto, es la experta.
    /// Utilzamos este patrón porque se mantiene el encapsulamiento, los objetos utilizan su propia información para
    /// llevar a cabo sus tareas.
    /// Hereda de la interfaz <see cref="ILevelEngine"/>.
    /// </summary>
    public class EngineScientificExercise4 : ILevelEngine
    {
        /// <summary>
        /// Variable Level utilizada para instanciar un nivel asignable.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia unica del motor general.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        /// <summary>
        /// Objeto de tipo <see cref="Feedback"/> que mostrara por pantalla textos para interactuar con el usuario.
        /// </summary>
        private Feedback levelFeedback;

        /// <summary>
        /// Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        private ButtonGoToPage buttonGoToMain;

        /// <summary>
        /// Button que aparecera al completarse el nivel, con la funcionalidad de empezar el proximo nivel.
        /// Como este es el ultimo nivel, solamente ira al menu.
        /// </summary>
        private ButtonGoToPage buttonNextLevel;

        /// <summary>
        /// Operacion que se este ejecutando acutalmente.
        /// </summary>
        private Operations currentOperation;

        /// <summary>
        /// Constructor del motor.
        /// </summary>
        public EngineScientificExercise4()
        {
            this.Level = this.level;
            this.ResultsOfLevel = new bool[2];
            this.LevelCounter = 0;
            this.LevelFeedback = this.levelFeedback;
            this.ButtonGoToMain = this.buttonGoToMain;
            this.ButtonNextLevel = this.buttonNextLevel;
            this.Operations = new List<Operations>();
            this.CurrentOperation = this.currentOperation;
        }

        /// <summary>
        /// Gets or sets Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        public ButtonGoToPage ButtonGoToMain { get; set; }

        /// <summary>
        /// Gets or sets del boton que aparecera al completarse el nivel.
        /// </summary>
        public ButtonGoToPage ButtonNextLevel { get; set; }

        /// <summary>
        /// Gets or sets del operacion que se este ejecutando acutalmente.
        /// </summary>
        /// <value>Operation.</value>
        public Operations CurrentOperation { get; set; }

        /// <summary>
        /// Gets de lista de operaciones del nivel.
        /// </summary>
        public List<Operations> Operations { get; }

        /// <summary>
        /// Gets or sets del nivel asociado a este Motor.
        /// </summary>
        /// <value>Level.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Gets or sets de contador utilizado para saber en que pagina del nivel nos encontramos.
        /// Existen dos paginas en el nivel.
        /// </summary>
        /// <value>Int.</value>
        public int LevelCounter { get; private set; }

        /// <summary>
        /// Gets or sets de los resultados del nivel.
        /// Por predeterminado los dos parametros son False.
        /// true = Completo una operacion correctamente.
        /// false = No contesto bien la pregunta.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }

        /// <summary>
        /// Gets or sets del Feedback asociado al motor.
        /// </summary>
        /// <value>Feedback.</value>
        public Feedback LevelFeedback { get; set; }

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del nivel.
        /// </summary>
        public void StartLevel()
        {
            string text = "Hola! En este juego deberas seleccionar la operacion correcta.";
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

            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
            this.engineGame.SetActive(this.ButtonNextLevel, false);
            this.ResultsOfLevel = new bool[2];
            this.CurrentOperation = this.Operations[0];
            this.LevelCounter = 0;

            foreach (Operations operation in this.Operations)
            {
                foreach (Items item in operation.Components)
                {
                    this.engineGame.SetActive(item, false);
                }
            }

            foreach (Items item in this.CurrentOperation.Components)
            {
                this.engineGame.SetActive(item, true);
            }
        }

        /// <summary>
        /// Verifica que se hayan completado las dos preguntas del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel[0] && this.ResultsOfLevel[1])
            {
                string text = "Excelente! Has contestado correctamente las dos preguntas.";
                this.engineGame.UpdateFeedback(this.LevelFeedback, text);
                this.engineGame.SetActive(this.ButtonNextLevel, true);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que se utiliza para verificar que se responda la pregunta de forma correcta.
        /// Si esta bien contestada, el bool de la pagina (this.ResultsOfLevel) pasa a ser true, y el
        /// level counter suma 1.
        /// </summary>
        /// <param name="button">Boton seleccionado.</param>
        /// <returns>Bool si el boton es correcto.</returns>
        public bool VerifyExercise(ButtonTrueFalse button)
        {
            if (button.Value)
            {
                this.ResultsOfLevel[this.LevelCounter] = true;
                this.LevelCounter += 1;
                this.ChangeOperation();
                this.GoodFeedback();
                this.VerifyWinLevel();
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
            string text = "Excelente!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public void BadFeedback()
        {
            string text = "Eso no esta bien, ¡Intentalo denuevo!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo responsable de asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        public void CreateFeedback()
        {
            Feedback feedback = new Feedback("Feedback4", this.Level, 720, 86, 320, 400, "Vacio.png", string.Empty, 33, true, false);
            this.engineGame.CreateInUnity(feedback);
            this.LevelFeedback = feedback;
        }

        /// <summary>
        /// Este boton aparecera en pantalla al terminar un nivel, al ejecutarlo ira a la proxima pantalla del nivel scientific.
        /// Como este es el ultimo nivel, ira al menu.
        /// </summary>
        public void CreateButtonGoToNextLevel()
        {
            ButtonGoToPage goToNext = new ButtonGoToPage("Scientific4Tomain", this.Level, 0, 0, 500, 300, "botonToMain.png", "#FCFCFC", "MenuScientific");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
            this.ButtonNextLevel = goToNext;
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, crea el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public void CreateButtonGoToMain()
        {
            ButtonGoToPage goToMain = new ButtonGoToPage("Scientific4ToMenu", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MenuScientific");
            this.Level.ItemList.Add(goToMain);
            this.engineGame.CreateInUnity(goToMain);
            this.ButtonGoToMain = goToMain;
        }

        /// <summary>
        /// Metodo utilizado para actualizar la operacion que se encuentre en pantalla,
        /// Para su uso, el contador del nivel (this.LevelCounter) ya debe estar actualizado.
        /// </summary>
        public void ChangeOperation()
        {
            foreach (Items item in this.CurrentOperation.Components)
            {
                this.engineGame.SetActive(item, false);
            }

            if (this.LevelCounter < this.Operations.Count)
            {
                this.CurrentOperation = this.Operations[this.LevelCounter];
                foreach (Items newItem in this.CurrentOperation.Components)
                {
                    this.engineGame.SetActive(newItem, true);
                }
            }
        }
    }
}