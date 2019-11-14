using Proyecto.Item.ScientistLevel;
using Xunit;

namespace Proyecto.LibraryModelado.Engine.test
{
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
