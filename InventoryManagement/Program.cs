

using InventoryManagement.InventoryManager;

public class MainClass
{
    static void Main()
    {
        InventoryManager Manager = new InventoryManager();
        UserCommunicationConsole Inventory = new UserCommunicationConsole(Manager);

        bool IsRunning = true;
        while (IsRunning)
        {
            Inventory.AddProduct();
            Inventory.Display();
            Inventory.AddProduct();
            Inventory.Display();
            Inventory.AddProduct();
            Inventory.Display();
            Inventory.RemoveProduct();
            Inventory.Display();
            Inventory.RemoveProduct();
            Inventory.Display();
        }

    }
}


