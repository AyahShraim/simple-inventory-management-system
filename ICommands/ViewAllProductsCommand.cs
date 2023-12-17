using SimpleInventoryManagementSystem.UI;

namespace SimpleInventoryManagementSystem.MenuCommand
{
    public class ViewAllProductCommand : ICommand
    {
        private InventoryUI _inventoryUI;
        public ViewAllProductCommand(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }
        public void Execute()
        {
            _inventoryUI.ViewAllProducts();
        }
    }
}
