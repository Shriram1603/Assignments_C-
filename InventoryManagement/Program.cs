

using InventoryManagement.InventoryManager;

InventoryManagementFunctionality Manager =new InventoryManagementFunctionality();
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

