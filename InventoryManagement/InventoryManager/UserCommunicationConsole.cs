namespace InventoryManagement.InventoryManager;
using System;
public class UserCommunicationConsole
{

    private InventoryManager _manager { get; set; }

    public UserCommunicationConsole(InventoryManager manager)
    {

        _manager = manager;
    }

    public int Menu()
    {
        Console.WriteLine("\nEnter the Operation You want to perform: " +
            "\n [1] - Add Product " +
            "\n [2] - Products " +
            "\n [3] - Delete Product " +
            "\n [4] - Update Product " +
            "\n [5] - Search " +
            "\n [6] - Sorted View" +
            "\n [7] - exit \n" );
        var UserInput = Console.ReadLine();
        int userChoice;
        if (!int.TryParse(UserInput, out userChoice))
        {
            Console.WriteLine("Cannot Convert to Integer");
            return 0;
        }
        return userChoice;
    }

    public void AddProduct()
    {
        bool isRunning = true;
        while (isRunning)
        {
        RepeatProductName:
            string productName = GetProductName();
            if (productName == "")
            {
                Console.WriteLine("Name Cannot be Empty");
                goto RepeatProductName;
            }
            else if (_manager.IsProductPresent(productName)) 
            {
                bool restocked = Restock(productName);
                if (!restocked)
                {
                    goto RepeatProductName;
                }
                else
                {
                    break;
                }
            }
            RepeatPrice:
                double price = GetProductPrice();
                if (price == 0)
                {
                    Console.WriteLine("Invalid Price ");
                    goto RepeatPrice;
                }
            RepeatQuantity:
                int Quantity = GetQuantity();
                if (Quantity == -1)
                {
                    Console.WriteLine("Invalid Quantity ");
                    goto RepeatQuantity;
                }
                _manager.Add(productName, price, Quantity);
                Console.WriteLine("[+] Product Added !!");
                isRunning = false;
            }

    } 

    public bool Restock(string productName)
    {
        Console.Write("[*] Product with the same Name was Found. " +
            "\nDo You want to Restock ? [Yes/No]");
        string Choice = Console.ReadLine();
        if (Choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            RepeatQuantity:

                int quantity = GetQuantity();
                if (quantity == -1)
                {
                    Console.WriteLine("Invalid Quantity ");
                    goto RepeatQuantity;
                }
                _manager.RestockProduct(productName, quantity);
                Console.WriteLine($"[+] Product {productName} Restocked");
                return true;
        }
        else
        {
            Console.WriteLine("[-] Then Provide a Unique Product Name or include Brand Name !!");
            return false;
        }
    }

    public void RemoveProduct()
    {
        Console.WriteLine("Enter the name of the Product You want to remove :");
        string ProductName = Console.ReadLine();
        if (ProductValidator.IsValidProductName(ProductName))
        {
            _manager.Remove(ProductName);
            
        }
        else 
        {
            Console.WriteLine("Product [Name] Cannot Be Empty");
            return;
        }

    }

    public void Edit()
    {
        Console.WriteLine("Enter the [Name] of the contact you want to update .");
        string ProductName = Console.ReadLine();
        if (ProductValidator.IsValidProductName(ProductName))
        {
            //InventoryManagerFunction
        }
        else
        {
            Console.WriteLine("Product [Name] Cannot Be Empty");
            return;
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
        _manager.DisplayProducts();
    }
    public void SortedSearch()
    {

    }

    private string GetProductName()
    {
        Console.Write("Enter the [Name] of the Product : ");
        string productName = Console.ReadLine();
        productName = ProductValidator.IsValidProductName(productName) ? productName : "";
        return productName;

    }
    private double GetProductPrice()
    {
        Console.Write("Enter the [Price] of the product :");
        var userInput = Console.ReadLine();
        double price;
        price = double.TryParse(userInput, out price) 
            && (ProductValidator.IsValidPrice(price))
            ? price : 0;
        return price;
    }
    private int GetQuantity()
    {
        Console.Write("Enter the [Quantity] of the Product :");
        var input = Console.ReadLine();
        int quantity = int.TryParse(input, out quantity) 
            && ProductValidator.IsValidQuantity(quantity) 
            ? quantity : -1;
        return quantity;
    }

}
