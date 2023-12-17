using SimpleInventoryManagementSystem.UI;

namespace SimpleInventoryManagementSystem.MenuCommand
{
    public class AddProductCommand : ICommand
    {
        private InventoryUI _inventoryUI;
        public AddProductCommand(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }
        public void Execute()
        {
            _inventoryUI.AddProduct();
        }
    }
}
