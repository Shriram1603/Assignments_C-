namespace InventoryManagement.Inventory;
using System.ComponentModel;
using InventoryManagement.ProductDecorator;

/// <summary>
/// This class <see cref="InventoryManager"/> performs the actual CRUD, restock, sorted display,
/// check if product is perishable and present in list funtionalities.
/// </summary>
public class InventoryManager
{
    private IList<IProduct> _products = new List<IProduct>();

    /// <summary>
    /// Add's the <see cref="IProduct"/> to <see cref="_products"/> ilist.
    /// </summary>
    /// <param name="product">Type of <see cref="IProduct"/></param>
    public void Add(IProduct product)
    {   
        _products.Add(product);
    }

    /// <summary>
    /// Increment's the quantity of a specified product name in the <see cref="_products"/> based on the passed the quantity amount.
    /// </summary>
    /// <param name="productName">Name of the product</param>
    /// <param name="quantity">Quantity to be added to the current quantity.</param>
    public void RestockProduct(string productName,int quantity)
    {
        IProduct product = _products.FirstOrDefault( i => i.Name == productName);
        product.Quantity += quantity;
    }

    /// <summary>
    /// Removes a specified product passed to it as product name from <see cref="_products"/>
    /// </summary>
    /// <param name="productName">Name of the product</param>
    public void RemoveProduct(string productName)
    {
        IProduct product = _products.FirstOrDefault( i => i.Name == productName);
        _products.Remove(product);
    }

    /// <summary>
    /// Returns a list of all the available products and their details as string.
    /// </summary>
    /// <returns>List of strings</returns>
    public IList<string> DisplayProducts()
    {
        int serialNumber = 1;
        IList<string> products = new List<string>();
        foreach (var product in _products)
        {
            products.Add($"\t{serialNumber++}. {product.GetDetails()}");
        }
        return products;
    }

    /// <summary>
    /// Returns the <see cref="IProduct.GetDetails"/> of a specified product name
    /// if not found returns a string stating "product not present".
    /// </summary>
    /// <param name="productName">Name of the product as string</param>
    /// <returns>string <see cref="IProduct.GetDetails"/> if product is not found returns "product is not present"</returns>
    public string SearchProduct(string productName)
    {   
        IProduct product = _products.FirstOrDefault( i => i.Name == productName);
        if(product != null)
        {
            return product.GetDetails();
        }
        return $"Product {productName} is not present in the inventory !!";
    }

    /// <summary>
    /// Updates the the details
    /// </summary>
    /// <param name="oldName"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    public void UpdateProduct(string oldName,string name,double price,int quantity)
    {
        IProduct product = _products.FirstOrDefault( i => i.Name == oldName);
        product.Name = String.IsNullOrWhiteSpace(name) ? product.Name : name;
        product.Price = price == 0 ? product.Price : price;
        product.Quantity = quantity == 0 ? product.Quantity : quantity;
    }
    public void UpdateProduct(string oldName,string name,double price,int quantity,DateOnly expiryDate)
    {
        DateOnly defaultDate = DateOnly.MinValue;
        ExpiryDecorator product = (ExpiryDecorator)_products.FirstOrDefault( i => i.Name == oldName);
        product.Name = String.IsNullOrWhiteSpace(name) ? product.Name : name;
        product.Price = price == 0 ? product.Price : price;
        product.Quantity = quantity == 0 ? product.Quantity : quantity;
        product.ExpiryDate = expiryDate == defaultDate ? product.ExpiryDate : expiryDate;
    }

    public IList<string> SortProducts()
    {
        IList<string> products = new List<string>();
        var ascending = _products.OrderBy(i => i.Name).ToList();
        var decending = _products.OrderByDescending(i => i.Name).ToList();
        products.Add("\tAscending Order [name] :");
        for(int i =0 ; i < _products.Count; i++)
        {
            products.Add($"\t\t{i+1}. {ascending[i].GetDetails()}");
        }
        products.Add("\n\tDecending Order[name] :");
        for(int i =0 ; i < _products.Count; i++)
        {
            products.Add($"\t\t{i+1}. {decending[i].GetDetails()}");
        }
        return products;
    }

    public bool IsProductPresent(string productName)
    {
        IProduct item = _products.FirstOrDefault(i => i.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        return item != null;
    }

    public bool IsPerishable(string name)
    {
        IProduct item = _products.FirstOrDefault( i => i.Name == name);
        return item is ExpiryDecorator;
    }
}