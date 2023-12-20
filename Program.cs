using SimpleInventoryManagementSystem.DataAccess;
using SimpleInventoryManagementSystem.MenuCommand;
using SimpleInventoryManagementSystem.ProductsManagement;
using SimpleInventoryManagementSystem.UI;
using SimpleInventoryManagementSystem.Utilities;

PrintWelcome();
string connectionString = ReadDbConnectionString();
IDbConnectionProvider connectionProvider = new DBConnectionProvider(connectionString);
InventoryRepository inventory = new InventoryRepository(connectionProvider);
IWriter writer = new ConsoleWriter();
InventoryUI inventoryUI =new InventoryUI(inventory, writer);
MainProgramUI mainProgramUI = new MainProgramUI(inventoryUI);
ShowMainMenu();
void PrintWelcome()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
*********************************************************
*                                                       *
*        Welcome to Inventory Management System         * 
*                                                       *
*********************************************************
    ");
    Console.ResetColor();
    Console.WriteLine("Press any key to start!");
    Console.ReadLine();
    Console.Clear();
}
string ReadDbConnectionString()
{
    return DBHelper.ConnectionString("InventoryDB");
}
void ShowMainMenu()
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.ResetColor();
        Console.WriteLine(@"
--------------------------
Select an action to start ->
--------------------------
");
        Console.WriteLine("1.Add product");
        Console.WriteLine("2.View all products ");
        Console.WriteLine("3.Edit product");
        Console.WriteLine("4.Delete product");
        Console.WriteLine("5.Search product");
        Console.WriteLine("0.Exit");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Your Choice is:");
        Console.ForegroundColor = ConsoleColor.White;
        HandleUserInput();
    }
}
void HandleUserInput()
{
    string userSelection = Console.ReadLine()?.Trim();
    if (Enum.TryParse(userSelection, out MenuChoice userChoice))
    {
        mainProgramUI.HandleUserInput(userChoice);
    }
    else
    {
        Console.WriteLine("Invalid choice! Please enter a valid option.");
    }
    Console.WriteLine("**********************************************");
}