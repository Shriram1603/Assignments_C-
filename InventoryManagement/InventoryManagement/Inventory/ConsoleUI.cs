using System;
using InventoryManagement.ProductDecorator;
namespace InventoryManagement.Inventory;

/// <summary>
/// The <see cref="ConsoleUI"/> class interacts with the user to get and show information.
/// </summary>
public class ConsoleUI
{   
    private readonly InventoryManager _manager;

    /// <summary>
    /// Dependency injection of <see cref="InventoryManager"/> through constructor <see cref="ConsoleUI"/>
    /// </summary>
    /// <param name="manager">Object of type <see cref="InventoryManager"/></param>
    public ConsoleUI(InventoryManager manager)
    {
        _manager = manager;
    }

    /// <summary>
    /// Displays a menu of options and prompts the user to chose a option.
    /// </summary>
    /// <returns>Input of user as integer</returns>
     public int ShowMenu()
    {
        Console.WriteLine("\nEnter the Operation You want to perform: " +
            "\n [1] - Add Product " +
            "\n [2] - Display Products " +
            "\n [3] - Delete Product " +
            "\n [4] - Update Product " +
            "\n [5] - Search " +
            "\n [6] - Sorted View" +
            "\n [7] - exit \n" );
        var userInput = Console.ReadLine();
        int userChoice;
        if (!int.TryParse(userInput, out userChoice))
        {
            return 0;
        }
        return userChoice;
    }

    /// <summary>
    /// Prompts the user and gets the data of a product's name, price, quantity and expiry date and
    /// then creates the <see cref="IProduct"/> and passes it to <see cref="InventoryManager.Add(IProduct)"/>
    /// </summary>
    public void AddProduct()
    {
        string productName = GetName("Enter the Name of the Product : ");
        if(_manager.IsProductPresent(productName))
            {
                if(!Restock(productName))
                {
                    AddProduct();
                }
                return;
            }
        double price = GetPrice("Enter the price of the product : ");
        int quantity = GetQuantity("Enter the Quantity of the Product : ");
        IProduct nonPerishable = new Product(productName,price,quantity);
        if(IsPerishable())
        {
            DateOnly expiryDate = GetExpiryDate($"Enter the ExpiryDate (e.g., yyyy-mm-dd) : ");
            IProduct perishable = new ExpiryDecorator(nonPerishable,expiryDate);
            _manager.Add(perishable);
            Console.WriteLine($"Product Added Successfully !!");
            return;
        }
        _manager.Add(nonPerishable);
        Console.WriteLine($"Product Added Successfully !!");
        return;
    }

    /// <summary>
    /// Gets a list of all products from <see cref="InventoryManager.DisplayProducts"/> and displays all the products in the list.
    /// </summary>
    public void ShowProducts()
    {
        Console.WriteLine($"Your Inventory : \n");
        IList<string> products = _manager.DisplayProducts();
        if(products.Count > 0)
        {
             foreach(var product in products)
             {
                 Console.WriteLine(product);
             }
        }
        else
        {
             Console.WriteLine($"\tNo Products to Show !!");
        }
    }

    /// <summary>
    /// Propmts the user for a product's new name, quantity, price and expiry date and then passes it to 
    /// <see cref="InventoryManager.UpdateProduct(string, string, double, int)"/> or 
    /// <see cref="InventoryManager.UpdateProduct(string, string, double, int, DateOnly)"/>
    /// </summary>
    public void EditProduct()
    {
        string name = GetName("Enter the name of the product You want to update : ");
        if(_manager.IsProductPresent(name))
        {    
            string nameToUpdate = GetName($"Enter the new name for [{name}] : ");
            double priceToTpdate = GetPrice($"Enter the new price for [{name}] : ");
            int quantityToUpdate = GetQuantity($"Enter the new Quantity for [{name}] : ");
            if(_manager.IsPerishable(name))
            {
                DateOnly expiryDate = GetExpiryDate($"Enter the new expiry date for [{name}] (e.g., yyyy-mm-dd) : ");
                _manager.UpdateProduct(name,nameToUpdate,priceToTpdate,quantityToUpdate,expiryDate);
                return;
            }
            _manager.UpdateProduct(name,nameToUpdate,priceToTpdate,quantityToUpdate);
            Console.WriteLine($"Product [{name}] Updated Successfully !!");
        }
        Console.WriteLine($"No Product with name : {name} is found");
        return;
    }

    /// <summary>
    /// Displays the list of items returned by <see cref="InventoryManager.SortProducts"/> in ascending and decending order.
    /// </summary>
    public void SortedView()
    {   
        Console.WriteLine($"Sorted Display :");
        IList<string> products = _manager.SortProducts();
        foreach(var product in products)
        {
            Console.WriteLine(product);
        }
    }

    /// <summary>
    /// Prompts the user to enter the name of the product.
    /// passes that to <see cref="InventoryManager.SearchProduct"/>,
    /// displays the product if it is found.
    /// </summary>
    public void SearchProduct()
    {   
        string name = GetName("Enter the name of the Product to search : ");
        Console.WriteLine($"\nSearched Product :");
        var product = _manager.SearchProduct(name);
        Console.WriteLine($"\t\t{product}");
    }

    /// <summary>
    /// Prompts the user to enter quantity if he wants to restock 
    /// else asks him to provide a unique product name ,
    /// passes the name to <see cref="InventoryManager.RestockProduct(string, int)"/> in case of restock.
    /// </summary>
    /// <param name="name">Product name as string</param>
    /// <returns>true if restocked and false if user doesn't want to restock.</returns>
    public bool Restock(string name)
    {
        Console.Write("[*] Product with the same Name was Found. " +
            "\nDo You want to Restock ? [Yes/No] : ");
        var userChoice = Console.ReadLine();
        if(userChoice.Equals("yes",StringComparison.OrdinalIgnoreCase))
        {
            int quantity = GetQuantity("Enter the Quantity to be Restocked :");
            _manager.RestockProduct(name,quantity);
            Console.WriteLine($"{name} : Restocked for {quantity}");
            return true;
        }
        else
        {
            Console.WriteLine("[-] Then Provide a Unique Product Name or include Brand Name !!");
            return false;
        }
    }

    /// <summary>
    /// Prompts the user to enter a products's name to be deleted
    /// and passes it to <see cref="InventoryManager.RemoveProduct(string)"/>
    /// </summary>
    public void DeleteProduct()
    {
        string name = GetName("Enter the name of the product you Want to Delete : ");
        if(_manager.IsProductPresent(name))
        {
            _manager.RemoveProduct(name);
            Console.WriteLine($"Product [{name}] Deleted Successfully !!");
            return;
        }
        Console.WriteLine($"No Product with name : {name} is found");  
    }

    private bool IsPerishable()
    {
        Console.Write($"Is this product Perishable ? [yes / no] : ");
        bool isPersishable = Console.ReadLine()?.Trim().ToLower() == "yes";
        return isPersishable;
    }
    
    private string GetName(string message)
    {   while(true)
        {   
            Console.Write(message);
            string name = Console.ReadLine();
            if(!String.IsNullOrWhiteSpace(name))
            {
                return name; 
            }    
            Console.WriteLine("Product name cannot be null or Empty");;
        }
    }

    private double GetPrice(string message)
    {   double price;
        while(true)
        {
            Console.Write($"{message}");
            var userInput = Console.ReadLine();
            if(double.TryParse(userInput,out price) && price > 0)
            {
                return price;
            }
            Console.WriteLine("Invalid Price !!");
        }       
    }

    private int GetQuantity(string message)
    {   int quantity;
        while(true)
        {
            Console.Write(message);
            var userInput = Console.ReadLine();
            if( int.TryParse(userInput, out quantity) && quantity > 0 )
            {
                return quantity;
            }
            Console.WriteLine("Invalid Quantity!!");
        } 
    }

    private DateOnly GetExpiryDate(string message)
    {
        DateOnly expiryDate;
        while(true)
        {
            Console.Write(message);
            var userInput =Console.ReadLine();
            if(DateOnly.TryParse(userInput,out expiryDate) && expiryDate > DateOnly.FromDateTime(DateTime.Now))
            {
                return expiryDate;
            }
            Console.WriteLine($"Invalid Date - Date cannot be in Past !!");
        }
    }
}
