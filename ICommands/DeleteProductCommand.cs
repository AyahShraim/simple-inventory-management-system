using SimpleInventoryManagementSystem.UI;

namespace SimpleInventoryManagementSystem.MenuCommand
{
    public class DeleteProductCommand : ICommand
    {
        private InventoryUI _inventoryUI;
        public DeleteProductCommand(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }
        public void Execute()
        {
            _inventoryUI.DeleteProduct();
        }
    }
}
