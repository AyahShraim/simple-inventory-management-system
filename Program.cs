using SimpleInventoryManagementSystem.ProductsManegements;

Inventory Inv=new Inventory();
PrintWelcome();
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

void ShowMainMenu()
{
    string? choice;
    while (true) { 
        Console.ForegroundColor = ConsoleColor.White;
        Console.ResetColor();
        Console.Clear();

        Console.WriteLine($"\nYou currently have {Inventory.products.Count} product");

        Console.WriteLine(@"
--------------------------
Select an action to statrt ->
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
        choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Inv.AddProduct();
                Console.ReadLine();
                break;

            case "2":
                Inv.ViewAllProducts();
                Console.ReadLine();
                break;

            case "3":
                Inv.UpdateProduct();
                Console.ReadLine();
                break;

            case "4":
                Inv.DeleteProduct();
                Console.ReadLine();
                break;
            case "5":
                Inv.SearchDisplayProduct();
                Console.ReadLine();
                break;

            case "0":
                Console.WriteLine("Good Bye!");
                return;

            default:
                Console.ReadLine();
                break;
        }
    } 
   
}