using System;
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
    /// <returns>Input of user as integer or 0 if input is invalid</returns>
     public int ShowMenu()
    {
        Console.WriteLine("\nEnter the Operation You want to perform: " +
            "\n [1] - Add Product " +
            "\n [2] - Display Products " +
            "\n [3] - Delete Product " +
            "\n [4] - Update Product " +
            "\n [5] - Search " +
            "\n [6] - Sorted View" +
            "\n [7] - Exit \n" );
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
        Console.WriteLine("Adding Product :\n");
        string productName = GetName("\tEnter the Name of the Product : ",true);
        if(_manager.IsProductPresent(productName))
            {
                if(!Restock(productName))
                {
                    AddProduct();
                }
                return;
            }
        double price = GetPrice("\tEnter the price of the product : ", true);
        int quantity = GetQuantity("\tEnter the Quantity of the Product : ", true);
        Product nonPerishable = new Product(productName, price, quantity);
        if(IsPerishable())
        {
            DateOnly expiryDate = GetExpiryDate($"\tEnter the ExpiryDate (e.g., yyyy-mm-dd) : ");
            Product perishable = new Product(productName, price, quantity, expiryDate);
            _manager.Add(perishable);
            DisplaySuccess($"\t[+] Product Added Successfully !!");
            return;
        }
        _manager.Add(nonPerishable);
        DisplaySuccess($"\t[+] Product Added Successfully !!");
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
             DisplayFailure($"\t[-] No Products to Show !!");
        }
    }

    /// <summary>
    /// Propmts the user for a product's new name, quantity, price and expiry date and then passes it to 
    /// <see cref="InventoryManager.UpdateProduct(string, string, double, int)"/> or 
    /// <see cref="InventoryManager.UpdateProduct(string, string, double, int, DateOnly)"/>
    /// </summary>
    public void EditProduct()
    {
        string productName = GetName("Enter the name of the product You want to update : ", true);
        if(_manager.IsProductPresent(productName))
        {   
            var product = _manager.SearchProduct(productName);
            Console.WriteLine($"Updating {productName} - Leave the field blank if you don't want to change it !!\n");
            string productNameToUpdate = GetName($"\tEnter the new name for [{product.ProductName}] : ",false);
            double priceToTpdate = GetPrice($"\tEnter the new price to update from [{product.Price}] : ", false);
            int quantityToUpdate = GetQuantity($"\tEnter the new Quantity update from [{product.Quantity}] : ", false);
            if(_manager.IsPerishable(productName))
            {
                DateOnly expiryDate = GetExpiryDateToUpdate($"\tEnter the new expiry date for [{product.ExpiryDate}] (e.g., yyyy-mm-dd) : ");
                _manager.UpdateProduct(productName,productNameToUpdate,priceToTpdate,quantityToUpdate,expiryDate);
                DisplaySuccess($"\t[+] Product [{productName}] Updated Successfully !!");
                return;
            }
            _manager.UpdateProduct(productName,productNameToUpdate,priceToTpdate,quantityToUpdate);
            DisplaySuccess($"\t[+] Product [{productName}] Updated Successfully !!");
            return;
        }
        DisplayFailure($"\t[-] No Product with name : {productName} is found");
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
        try
        {
            string productName = GetName("\n\tEnter the name of the Product to search : ", true);
            Console.WriteLine($"\n\tSearched Product :");
            var product = _manager.SearchProduct(productName);
            DisplaySuccess($"\t\t{product.GetDetails()}");
        }
        catch (Exception ex)
        {
            DisplayFailure($"\t[-] Product [{ex.Message}] is not present in the inventory !!");
        }
    }

    /// <summary>
    /// Prompts the user to enter quantity if he wants to restock 
    /// else asks him to provide a unique product name ,
    /// passes the name to <see cref="InventoryManager.RestockProduct(string, int)"/> in case of restock.
    /// </summary>
    /// <param name="productName">Product name as string</param>
    /// <returns>true if restocked and false if user doesn't want to restock.</returns>
    public bool Restock(string productName)
    {
        Console.Write("\t[*] Product with the same Name was Found. " +
            "\n\tDo You want to Restock ? [Yes/No] : ");
        var userChoice = Console.ReadLine();
        if(userChoice.Equals("yes",StringComparison.OrdinalIgnoreCase))
        {
            int quantity = GetQuantity("\tEnter the Quantity to be Restocked :", true);
            _manager.RestockProduct(productName,quantity);
            DisplaySuccess($"\n\t[+] {productName} : Restocked for {quantity}");
            return true;
        }
        else
        {
            DisplayFailure("\n\t[-] Then Provide a Unique Product Name or include Brand Name !!");
            return false;
        }
    }

    /// <summary>
    /// Prompts the user to enter a products's name to be deleted
    /// and passes it to <see cref="InventoryManager.RemoveProduct(string)"/>
    /// </summary>
    public void DeleteProduct()
    {
        string productName = GetName("\n\tEnter the name of the product you Want to Delete : ",true);
        if(_manager.IsProductPresent(productName))
        {
            _manager.RemoveProduct(productName);
            DisplaySuccess($"\n\t[+] Product [{productName}] Deleted Successfully !!");
            return;
        }
        DisplayFailure($"\n\t[-] No Product with name : {productName} is found");  
    }

    private bool IsPerishable()
    {
        Console.Write($"\n\tIs this product Perishable ? [yes / no] : ");
        bool isPersishable = Console.ReadLine()?.Trim().ToLower() == "yes";
        return isPersishable;
    }
    
    private string GetName(string message,bool validate)
    {   while(true)
        {   
            Console.Write(message);
            string name = Console.ReadLine();
            if(validate)
            {
                if (!String.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                DisplayFailure("\t[-]Product name cannot be null or Empty"); ;
            }
            else if(!validate) 
                return name;
        }
    }

    private double GetPrice(string message, bool validate)
    {   double price;
        while(true)
        {
            Console.Write($"{message}");
            var userInput = Console.ReadLine();
            if(double.TryParse(userInput,out price) && price > 0)
            {
                return price;
            }
            if(!validate)
            {
                return price;
            }
            DisplayFailure("\t[-] Invalid Price !! - Price should be in numeric value");
        }       
    }

    private int GetQuantity(string message, bool validate)
    {   int quantity;
        while(true)
        {
            Console.Write(message);
            var userInput = Console.ReadLine();
            if( int.TryParse(userInput, out quantity) && quantity >= 0)
            {
                return quantity;
            }
            if( !validate)
            {
                return quantity;
            }
            DisplayFailure("\t[-] Invalid Quantity!! - Quantity should be in numeric value");
        } 
    }

    private void DisplaySuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor= ConsoleColor.White;
    }

    private void DisplayFailure(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor= ConsoleColor.White;
    }

    private DateOnly GetExpiryDate(string message)
    {
        DateOnly expiryDate;
        while(true)
        {
            Console.Write(message);
            var userInput =Console.ReadLine();
            if (DateOnly.TryParse(userInput, out expiryDate))
            {
                if(expiryDate > DateOnly.FromDateTime(DateTime.Now))
                {
                    return expiryDate;
                }
                else
                {
                    DisplayFailure($"\t[-] Date cannot be in Past !!");
                }
            }
            else
            {
                DisplayFailure("\t[-] Invalid Date Format. Provide in yyyy-mm-dd format!!");
            }
        }
    }

    private DateOnly GetExpiryDateToUpdate(string message)
    {
        DateOnly expiryDate;
        while (true)
        {
            Console.Write(message);
            var userInput = Console.ReadLine();
            if (DateOnly.TryParse(userInput, out expiryDate))
            {   
                if (expiryDate > DateOnly.FromDateTime(DateTime.Now))
                {
                    return expiryDate;
                }
                else
                {
                    DisplayFailure($"\t[-] Date cannot be in Past !!");
                }
            }
            else
            {   
                if(userInput == "")
                {
                    return expiryDate;
                }
                DisplayFailure("\t[-] Invalid Date Format. Provide in yyyy-mm-dd format!!");
            }
        }
    }
}
