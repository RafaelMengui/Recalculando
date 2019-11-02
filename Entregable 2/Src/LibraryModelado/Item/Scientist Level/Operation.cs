using Proyecto.LibraryModelado;

namespace Proyecto.Item.ScientistLevel
{
    public class Operation
    {
        private World world = Singleton<World>.Instance;
        public Operation(Money money1, string operationType, Money money2, MoneyContainer resultContainer)
        {
            this.Money1 = money1;
            this.OperationType = this.OperationIcon(operationType);
            this.Money2 = money2;
            this.ResultContainer = resultContainer;
        }

        public Money Money1 { get; set; }
        public Money Money2 { get; set; }
        public MoneyContainer ResultContainer { get; set; }
        public Image OperationType { get; set; }

        private Image OperationIcon(string operationType)
        {
            Image icon;
            Space level;
            try
            {
                level = this.world.SpaceList.Find(delegate(Space space) { return space.Name == "ScientificExercise1"; });
            }
            catch (System.Exception)
            {
                
                throw;
            }
            if (operationType == "Add")
            {
            }
        }
    }
}