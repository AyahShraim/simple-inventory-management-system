using SimpleInventoryManagementSystem.UI;

namespace SimpleInventoryManagementSystem.MenuCommand
{
    public class UpdateProductCommand : ICommand
    {
        private InventoryUI _inventoryUI;
        public UpdateProductCommand(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }
        public void Execute()
        {
            _inventoryUI.UpdateProduct();
        }
    }
}
