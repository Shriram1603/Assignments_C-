

using InventoryManagement.InventoryManager;

InventoryManager Manager =new InventoryManager();
UserCommunicationConsole Communication = new UserCommunicationConsole(Manager);

while (true)
{
    Communication.AddProduct();
    Communication.Display();
    Communication.AddProduct();
    Communication.Display();
    Communication.AddProduct();
    Communication.Display();
    Communication.RemoveProduct();
    Communication.Display();
    Communication.RemoveProduct();
    Communication.Display();
}

