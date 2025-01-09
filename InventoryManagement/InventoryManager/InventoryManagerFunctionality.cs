using System;
namespace InventoryManagement.InventoryManager;

public class InventoryManagementFunctionality
{
    private List<Product> products = new List<Product>();

    public void Add(string Name, double Price, int Quantity)
    {   Product item = products.FirstOrDefault(i => i.Product_Name.Equals(Name, StringComparison.OrdinalIgnoreCase));
        if(item == null)
        {
            products.Add(new Product(Name, Price, Quantity));
            Console.WriteLine("[+] Product Added !!");
        }
        else
        {
            Console.WriteLine("[*] Product with the same Name was Found. Do You want to Restock ? [Yes/No]");
            string Choice = Console.ReadLine();
            if (Choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                item.Quantity += Quantity;
                Console.WriteLine($"[+] Product {item.Product_Name} Restocked");
            }
            else
            {
                Console.WriteLine("[-] Then Provide a Unique Product Name or include Brand Name !!");
            }
        }
    }

    public void Remove(string Name)
    {
        if (products.Any(i => i.Product_Name.Equals(Name,StringComparison.OrdinalIgnoreCase)))
        {
            products.RemoveAll(i => i.Product_Name.Equals(Name, StringComparison.OrdinalIgnoreCase));
        }
        else
        {
            Console.WriteLine($"[-] Product [{Name}] does not Exist !!");
        }
    }

    public void DisplayProducts()
    {
        int Serial_no = 1;
        if (products.Count > 0)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{Serial_no}. {product}");
            }
        }
        else
        {
            Console.WriteLine("No items to Display");
        }
    }
}