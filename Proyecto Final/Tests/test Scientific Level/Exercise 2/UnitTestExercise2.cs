using Proyecto.Item.ScientistLevel;
using Xunit;

namespace Proyecto.LibraryModelado.Engine.test
{
    // Éste motor no puede ser testeado ya que para realizar el Verify y el WinLevel, utiliza el adapter de Unity el cual no podemos invocar de manera simple.
    // Probamos usar una clase que implemente MainViewAdapter para usarla como dummy pero se tornó demasiado complejo. Éstos son los tests que se usaban antes.
    public class UnitTextScientificExercise2
    {
        private Level level = new Level("level", null);
        private EngineScientificExercise2 engineScientific2 = Singleton<EngineScientificExercise2>.Instance;


        [Fact]
        public void VerifyWin()
        {
            this.engineScientific2.StartLevel();
            ButtonTrueFalse correctButtonPage1 = new ButtonTrueFalse("correcto", this.level, 20, 202, 202, 20, null, "#FCFCFC", true);
            ButtonTrueFalse incorrectButton1Page1 = new ButtonTrueFalse("incorrecto1", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
            ButtonTrueFalse incorrectButton2Page1 = new ButtonTrueFalse("incorrecto2", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
            if (engineScientific2.VerifyExercise(correctButtonPage1))
            {
                ButtonTrueFalse correctButtonPage2 = new ButtonTrueFalse("correcto", this.level, 20, 202, 202, 20, null, "#FCFCFC", true);
                ButtonTrueFalse incorrectButton1Page2 = new ButtonTrueFalse("incorrecto1", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                ButtonTrueFalse incorrectButton2Page2 = new ButtonTrueFalse("incorrecto2", this.level, 20, 202, 202, 20, null, "#FCFCFC", false);
                engineScientific2.VerifyExercise(correctButtonPage2);
            }
            Assert.Equal(true, engineScientific2.VerifyWinLevel());
        }
    }
}
