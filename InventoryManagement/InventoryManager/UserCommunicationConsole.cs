namespace InventoryManagement.InventoryManager;
using System;
public class UserCommunicationConsole
{

    private InventoryManagementFunctionality Manager { get; set; }

    public UserCommunicationConsole(InventoryManagementFunctionality obj)
    {

        Manager = obj;
    }

    public int Menu()
    {
        Console.WriteLine("\nEnter the Operation You want to perform: \n [1] - Add Product \n [2] - Products \n [3] - Delete Product \n [4] - Update Product \n [5] - exit \n [6] - Search \n [7] - Sorted View\n");
        var UserInput = Console.ReadLine();
        int userChoice;
        if (int.TryParse(UserInput, out userChoice))
        {
            return userChoice;
        }
        else
        {
            Console.WriteLine("Cannot Convert to Integer");
            return 0;
        }

    }

    public void AddProduct()
    {
        Console.WriteLine("Enter the [Name] of the Product : ");
        string productName = Console.ReadLine();
        if (Validator.IsValidProductName(productName))
        {
            Console.WriteLine("Product Name Cannot Be Empty");
            return;
        }

        Console.WriteLine("Enter the [Price] of the product :");
        var UserInput = Console.ReadLine();
        double Price;
        if (double.TryParse(UserInput, out Price))
        {

            if (Validator.IsValidPrice(Price))
            {

                Console.WriteLine("Valid Price");
            }
            else
            {
                Console.WriteLine("Price Cannot be 0 or less than that");
                return;
            }
        }
        else
        {
            Console.WriteLine("Enter a Double [numeric] Value");
            return;
        }

        Console.WriteLine("Enter the [Quantity] of the Product :");
        var Input = Console.ReadLine();
        int Quantity;
        if (int.TryParse(Input, out Quantity))
        {
            if (Validator.IsValidQuantity(Quantity))
            {

                Console.WriteLine("Valid Quantity");
            }
            else
            {
                Console.WriteLine("Quality cannot ");
            }
        }
        else
        {
            Console.WriteLine("Enter an integer value");
        }
        Manager.Add(productName, Price, Quantity);

    }

    public void RemoveProduct()
    {
        Console.WriteLine("Enter the name of the Product You want to remove :");
        string ProductName = Console.ReadLine();
        if (!Validator.IsValidProductName(ProductName))
        {
            Console.WriteLine("Product [Name] Cannot Be Empty");
            return;
        }
        else 
        {
            //InventoryManagerFunction
        }

    }

    public void Edit()
    {
        Console.WriteLine("Enter the [Name] of the contact you want to update .");
        string ProductName = Console.ReadLine();
        if (!Validator.IsValidProductName(ProductName))
        {
            Console.WriteLine("Product [Name] Cannot Be Empty");
            return;
        }
        else
        {
            //InventoryManagerFunction
        }

    }

    public void Search()
    {
        Console.WriteLine("Type to Search Contact :");
        var item = Console.ReadLine();
        //InventoryManagerFunction
    }

    public void Display()
    {

    }
    public void SortedSearch()
    {

    }

}
