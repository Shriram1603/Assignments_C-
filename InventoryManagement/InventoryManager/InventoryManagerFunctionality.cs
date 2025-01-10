using System;
using System.Xml.Linq;
namespace InventoryManagement.InventoryManager;

public class InventoryManager
{
    private IList<Product> _products = new List<Product>();

    public void Add(string Name, double Price, int Quantity)
    {   Product item = _products.FirstOrDefault(i => i.Product_Name.Equals(Name, StringComparison.OrdinalIgnoreCase));
        if(item == null)
        {
            _products.Add(new Product(Name, Price, Quantity));
            
        }
        else
        {
            
            
        }
    }

    public void RestockProduct(string productName,int quantity)
    {
        Product item = _products.FirstOrDefault(i => i.Product_Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        item.Quantity += quantity;
    }

    public void Remove(string Name)
    {
        if (_products.Any(i => i.Product_Name.Equals(Name,StringComparison.OrdinalIgnoreCase)))
        {
            Product item = _products.FirstOrDefault( i => i.Product_Name.Equals(Name,StringComparison.OrdinalIgnoreCase) );
            _products.Remove(item);
        }
        else
        {
            Console.WriteLine($"[-] Product [{Name}] does not Exist !!");
        }
    }

    public void DisplayProducts()
    {
        int Serial_no = 1;
        if (_products.Count > 0)
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"{Serial_no}. {product}");
            }
        }
        else
        {
            Console.WriteLine("No items to Display");
        }
    }

    public void SortProducts()
    {

    }

    public bool IsProductPresent(string productName)
    {
        Product item = _products.FirstOrDefault(i => i.Product_Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        return item != null;
    }
}