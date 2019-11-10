//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise3.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using Proyecto.Item.ScientistLevel;
using Proyecto.Item;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineScientificExercise3, responsable de implementar la logica del nivel scientific ejercicio 3.
    /// Este motor presenta una ALTA COHESIÓN, debido a que, una clase con responsabilidades alta o fuertemente
    /// relacionadas tiene alta cohesión. Esto nos dice que, la información que almacena una clase debe ser coherente
    /// y debe estar (en la medida de lo posible) relacionada con la clase.Esto sucede claramente en EngineScientificExercise3
    /// este motor tiene solamente lo que le interesa para funcionar, por esto decidimos realizar un motor para cada ejercicio.
    /// </summary>
    public class EngineScientificExercise3 : IEngine, ILevelEngine
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
        /// Constructor.
        /// </summary>
        public EngineScientificExercise3()
        {
            this.ResultsOfLevel = new bool[2];
            this.LevelCounter = 0;
            this.LevelFeedback = this.levelFeedback;
            this.ButtonGoToMain = this.buttonGoToMain;
            this.ButtonNextLevel = this.buttonNextLevel;
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

        public List<Operations> Operations { get; }

        public Space Level { get; set; }


        /// <summary>
        /// Gets or sets de la etiqueta de texto utilizado para especificar si la accion fue correcta o incorrecta.
        /// </summary>
        /// <value>Etiqueta <see cref="Label"/>.</value>
        public Label Feedback { get; set; }

        /// <summary>
        /// Gets or sets de contador utilizado para saber en que pagina del nivel nos encontramos.
        /// Existen dos paginas en el nivel.
        /// </summary>
        /// <value>Int.</value>
        public int LevelCounter { get; private set; }

        /// <summary>
        /// Gets or sets de los resultados del nivel.
        /// Por predeterminado los cuatro parametros son False.
        /// true = Completo una pagina correctamente.
        /// false = No contesto bien la pregunta.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }
        public Feedback LevelFeedback { get ; set ; }

        /// <summary>
        /// Verifica que se hayan completado las cuatro paginas del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            return this.ResultsOfLevel[0] && this.ResultsOfLevel[1];
        }

        /// <summary>
        /// Metodo que se utiliza para verificar la opcion selccionada.
        /// Si esta bien contestada, el bool de la pagina (this.ResultsOfLevel) pasa a ser true, y el
        /// level counter suma 1.
        /// </summary>
        public bool VerifyQuestion(ButtonTrueFalse button)
        {
            if (button.Value)
            {
                this.ResultsOfLevel[this.LevelCounter] = true;
                this.LevelCounter += 1;
                this.GoodFeedback();
                return true;
            }
            else
            {
                this.BadFeedback();
                return false;
            }
        }

        /// <summary>
        /// Metodo utilizado para iniciar o reiniciar el motor del nivel.
        /// </summary>
        public void StartLevel()
        {
            string text = "Hola! En este juego deberas seleccionar la respuesta correcta.";
            if (this.buttonGoToMain is null)
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

            this.engineGame.SetActive(this.buttonNextLevel, false);
            this.engineGame.UpdateFeedback(this.LevelFeedback, text);
            this.ResultsOfLevel = new bool[2];
            this.LevelCounter = 0;
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
        /// Metodo responsable de asignarle al motor, su respectivo objeto feedback.
        /// </summary>
        public void CreateFeedback()
        {
            Feedback feedback = new Feedback("Feedback3", this.Level, 710, 70, 320, 400, "Vacio.png", string.Empty, 30, true, false);
            this.engineGame.CreateInUnity(feedback);
            this.LevelFeedback = feedback;
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, crea el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public void CreateButtonGoToMain()
        {
            ButtonGoToPage goToMain = new ButtonGoToPage("Scientific3ToMain", this.Level, -890, 470, 125, 125, "GoToMain.png", "#FCFCFC", "MainPage");
            this.Level.ItemList.Add(goToMain);
            this.engineGame.CreateInUnity(goToMain);
            this.ButtonGoToMain = goToMain;
        }

        /// <summary>
        /// Este boton aparecera en pantalla al terminar un nivel, al ejecutarlo ira a la proxima pantalla del nivel scientific.
        /// </summary>
        public void CreateButtonGoToNextLevel()
        {
            ButtonStartLevel goToNext = new ButtonStartLevel("Scientific3ToScientific4", this.Level, 0, 0, 500, 300, "siguienteNivel.png", "#FCFCFC", "ScientificExercise4");
            this.Level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
            this.ButtonNextLevel = goToNext;
        }
    }
}