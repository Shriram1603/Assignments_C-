

using InventoryManagement.InventoryManager;

InventoryManagementFunctionality Manager =new InventoryManagementFunctionality();
UserCommunicationConsole Communication = new UserCommunicationConsole(Manager);

while (true)
{
    Communication.AddProduct();
}

