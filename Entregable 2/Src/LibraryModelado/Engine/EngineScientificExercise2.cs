//--------------------------------------------------------------------------------
// <copyright file="EngineScientificExercise2.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Proyecto.Item;
using Proyecto.Item.ScientistLevel;

namespace Proyecto.LibraryModelado.Engine
{
    /// <summary>
    /// Clase EngineScientificExercise2, responsable de implementar la logica del nivel scientific ejercicio 2.
    /// </summary>
    public class EngineScientificExercise2 : IEngine, ILevelEngine
    {
        /// <summary>
        /// Variable Level utilizada para instanciar un nivel asignable.
        /// </summary>
        private Space level;

        /// <summary>
        /// Instancia unica del motor general.
        /// </summary>
        private EngineGame engineGame = Singleton<EngineGame>.Instance;

        private Feedback levelFeedback;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EngineScientificExercise2()
        {
            this.ResultsOfLevel = new bool[2];
            this.LevelCounter = 0;
            this.Operations = new Operation[2] { null, null };
            this.LevelFeedback = this.levelFeedback;
        }

        public Feedback LevelFeedback{get;set;}

        public Space Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Operation[] Operations { get; set; }

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
        /// Por predeterminado los dos parametros son False.
        /// true = Completo una operacion correctamente.
        /// false = No contesto bien la pregunta.
        /// </summary>
        /// <value>Array de Bools.</value>
        public bool[] ResultsOfLevel { get; private set; }

        /// <summary>
        /// Verifica que se hayan completado las dos preguntas del nivel.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool VerifyWinLevel()
        {
            return this.ResultsOfLevel[0] && this.ResultsOfLevel[1];
        }

        /// <summary>
        /// Metodo que se utiliza para verificar que se responda la pregunta de forma correcta.
        /// Si esta bien contestada, el bool de la pagina (this.ResultsOfLevel) pasa a ser true, y el
        /// level counter suma 1.
        /// </summary>
        /// <param name="button">Boton seleccionado.</param>
        /// <returns>Bool si el boton es correcto.</returns>
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
            this.ResultsOfLevel = new bool[2];
            this.LevelCounter = 0;
            this.Feedback = this.CreateFeedback();
        }

        /// <summary>
        /// Metodo responsable de crear la etiqueta de texto que servira de feedback a las acciones realizadas.
        /// </summary>
        /// <returns>Etiqueta <see cref="Label"/>.</returns>
        public Label CreateFeedback()
        {
            foreach (var space in this.engineGame.LevelEngines)
            {
                if (space.Value is EngineScientificExercise2)
                {
                    this.level = space.Key;
                }
            }

            Label feedback = new Label("Feedback", this.level, 600, 240, 100, 50, "Vacio.png", string.Empty);
            this.level.ItemList.Add(feedback);
            return feedback;
        }

        /// <summary>
        /// Metodo que asigna al texto un buen feedback. Utilizado cuando la accion realizada es correcta.
        /// </summary>
        public void GoodFeedback()
        {
            this.Feedback.Text = "Correcto! Sigue asi.";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
        }

        /// <summary>
        /// Metodo que asigna al texto un mal feedback. Utilizado cuando la accion realizada es incorrecta.
        /// </summary>
        public void BadFeedback()
        {
            this.Feedback.Text = "Intentalo de nuevo ¡Tu puedes!";
            this.engineGame.UpdateFeedback(this.LevelFeedback);
        }

        /// <summary>
        /// Sobrescribe el metodo abstracto de <see cref="IEngine"/>, en donde se recorre el diccionario
        /// de motores asociados a niveles (EngineGame.LevelEngines), para reconocer en que nivel
        /// se debe crear el boton que mostrara la pagina principal al ejecutarlo.
        /// </summary>
        public override IComponent ButtonGoToMain()
        {
            foreach (var space in this.engineGame.LevelEngines)
            {
                if (space.Value is EngineScientificExercise2)
                {
                    this.level = space.Key;
                }
            }

            Items goToMain = new ButtonGoToPage("Scientific2ToMain", this.level, -595, 228, 75, 75, "GoToMain.png", "#FCFCFC", "MainPage");
            this.level.ItemList.Add(goToMain);
            return goToMain;
        }

        public void ButtonGoToNextLevel()
        {
            foreach (var space in this.engineGame.LevelEngines)
            {
                if (space.Value is EngineScientificExercise2)
                {
                    this.level = space.Key;
                }
            }

            Items goToNext = new ButtonGoToPage("Scientific2ToScientific3", this.level, 0, 0, 200, 150, "huevo.png", "#FCFCFC", "ScientificExercise3");
            this.level.ItemList.Add(goToNext);
            this.engineGame.CreateInUnity(goToNext);
        }

        public override void SetOperations(IComponent component)
        {
            for (int i = 0; i < this.Operations.Length; i++)
            {
                if (this.Operations[i].Equals(null))
                {
                    this.Operations[i] = component as Operation;
                }
            }
        }
    }
}