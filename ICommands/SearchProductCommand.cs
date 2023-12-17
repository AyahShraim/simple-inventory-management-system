using SimpleInventoryManagementSystem.UI;

namespace SimpleInventoryManagementSystem.MenuCommand
{
    public class SearchProductCommand : ICommand
    {
        private InventoryUI _inventoryUI;
        public SearchProductCommand(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }
        public void Execute()
        {
            _inventoryUI.ViewProduct();
        }
    }
}
