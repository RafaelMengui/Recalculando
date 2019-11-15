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
    /// Clase EngineScientificExercise2, responsable de implementar la logica del nivel scientific ejercicio 2.
    /// En este juego se debe seleccionar cual es la opción correcta para el problema matemático que se plantea.
    /// El motor se encarga de que esta lógica funcione.
    /// Este motor presenta una ALTA COHESIÓN, debido a que, una clase con responsabilidades alta o fuertemente
    /// relacionadas tiene alta cohesión. Esto nos dice que, la información que almacena una clase debe ser coherente
    /// y debe estar (en la medida de lo posible) relacionada con la clase.Esto sucede claramente en EngineScientificExercise2
    /// este motor tiene solamente lo que le interesa para funcionar, por esto decidimos realizar un motor para cada ejercicio.
    /// Además también cumple con el patrón EXPERT, este nos dice que, debemos asignar la responsabilidad al experto en
    /// información, es decir, a la clase que tiene la información necesaria para poder cumplir con la responsabilidad. En este
    /// caso, la clase que tiene toda la información lógica del ejercicio 1 es EngineScientificExcerise2, por esto, es la experta.
    /// Utilzamos este patrón porque se mantiene el encapsulamiento, los objetos utilizan su propia información para
    /// llevar a cabo sus tareas.
    /// Hereda de la interfaz <see cref="ILevelEngine"/>.
    /// </summary>
    public class EngineScientificExercise2 : ILevelEngine
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
        /// Button que aparecera al completarse el nivel, con la funcionalidad de empezar el proximo nivel.
        /// </summary>
        private ButtonStartLevel buttonNextLevel;

        /// <summary>
        /// Boton que al apretarlo aparecera la pantalla principal.
        /// </summary>
        private ButtonGoToPage buttonGoToMain;

        /// <summary>
        /// Constructor del motor.
        /// </summary>
        public EngineScientificExercise2()
        {
            this.Level = this.level;
            this.ResultsOfLevel = false;
            this.Operations = new List<Operations>();
            this.ButtonGoToMain = this.buttonGoToMain;
            this.ButtonNextLevel = this.buttonNextLevel;
            this.LevelFeedback = this.levelFeedback;
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
        /// Gets de lista de operaciones del nivel
        /// </summary>
        public List<Operations> Operations { get; }

        /// <summary>
        /// Gets or sets del nivel asociado a este Motor.
        /// </summary>
        /// <value>Level.</value>
        public Space Level { get; set; }

        /// <summary>
        /// Gets or sets de los resultados del nivel.
        /// true = Completo la pregunta correctamente.
        /// false = No contesto bien la pregunta.
        /// </summary>
        /// <value>Bool.</value>
        public bool ResultsOfLevel { get; private set; }

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
            string text = "¡Hola de nuevo!";

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

            this.ResultsOfLevel = false;
            this.engineGame.SetActive(this.ButtonNextLevel, false);
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);

            foreach (Operations operation in this.Operations)
            {
                foreach (Items item in operation.Components)
                {
                    (item as ButtonTrueFalse).Pushable = true;
                }
            }
        }

        /// <summary>
        /// Verifica que se hayan completado las dos preguntas del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            if (this.ResultsOfLevel)
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
                this.ResultsOfLevel = true;
                this.GoodFeedback();
                this.VerifyWinLevel();

                foreach (Operations operation in this.Operations)
                {
                    foreach (Items item in operation.Components)
                    {
                        (item as ButtonTrueFalse).Pushable = false;
                    }
                }
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
            string text = "Excelente trabajo! Puedes continuar al siguiente nivel.";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public void BadFeedback()
        {
            string text = "Intentalo de nuevo ¡Tu puedes!";
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
        }

        /// <summary>
        /// Metodo responsable de Crear y asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        public void CreateFeedback()
        {
            Feedback feedback = new Feedback("Feedback2", this.Level, 705, 82, 320, 400, "Vacio.png", string.Empty, 34, true, false);
            this.engineGame.CreateInUnity(feedback);
            this.LevelFeedback = feedback;
        }

        /// <summary>
        /// Metodo para crear un boton que al ejecutarlo ira a la pantalla principal.
        /// </summary>
        public void CreateButtonGoToMain()
        {
            ButtonGoToPage goToMain = new ButtonGoToPage("Scientific2ToMain", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MenuScientific");
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
            ButtonStartLevel goToNext = new ButtonStartLevel("Scientific2ToScientific3", this.Level, 0, 0, 500, 300, "siguienteNivel.png", "#FCFCFC", "ScientificExercise3");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
            this.ButtonNextLevel = goToNext;
        }
    }
}