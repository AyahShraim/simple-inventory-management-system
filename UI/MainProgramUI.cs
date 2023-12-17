using SimpleInventoryManagementSystem.MenuCommand;
using SimpleInventoryManagementSystem.Utilities;

namespace SimpleInventoryManagementSystem.UI
{
    public class MainProgramUI
    {
        public Dictionary<MenuChoice, ICommand> MenuCommands { get; private set; }
        private InventoryUI _inventoryUI;
        private IWriter _writer;
        public MainProgramUI(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
            _writer = new ConsoleWriter();
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            MenuCommands = new Dictionary<MenuChoice, ICommand>
            {
                {MenuChoice.AddProduct, new AddProductCommand(_inventoryUI)},
                {MenuChoice.ViewAllProducts, new ViewAllProductCommand(_inventoryUI)},
                {MenuChoice.EditProduct, new UpdateProductCommand(_inventoryUI)},
                {MenuChoice.DeleteProduct, new DeleteProductCommand(_inventoryUI)},
                {MenuChoice.SearchProduct, new SearchProductCommand(_inventoryUI)},
                {MenuChoice.Exit, new ExitCommand()}
            };
        }
        public void HandleUserInput(MenuChoice choice)
        {
            if (MenuCommands.TryGetValue(choice, out ICommand command))
            {
                command.Execute();
            }
            else
            {
                _writer.Write("invalid choice! Please select a valid option.");
            }
        }
    }
}
