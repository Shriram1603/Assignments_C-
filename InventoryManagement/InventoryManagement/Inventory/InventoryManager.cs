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
        IProduct product = _products.FirstOrDefault( i => i.ProductName == productName);
        product.Quantity += quantity;
    }

    /// <summary>
    /// Removes a specified product passed to it as product name from <see cref="_products"/>
    /// </summary>
    /// <param name="productName">Name of the product</param>
    public void RemoveProduct(string productName)
    {
        IProduct product = _products.FirstOrDefault( i => i.ProductName == productName);
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
    /// if not found throws an argumenterror by passing product name.
    /// </summary>
    /// <param name="productName">Name of the product as string</param>
    /// <returns>string <see cref="IProduct.GetDetails"/> if product is not found throws an argumenterror by passing product name.</returns>
    public string SearchProduct(string productName)
    {   
        IProduct product = _products.FirstOrDefault( i => i.ProductName == productName);
        if(product != null)
        {
            return product.GetDetails();
        }
        throw new ArgumentException(productName);
    }

    /// <summary>
    /// Updates the the details of a particualr product ,leaves the data as it is if the user just pressed enter.
    /// </summary>
    /// <param name="oldName">Name of the product to be updated</param>
    /// <param name="updatedName">New name of the product</param>
    /// <param name="updatedPrice">New price of the product</param>
    /// <param name="updatedQuantity">New quantity of the product</param>
    public void UpdateProduct(string oldName,string updatedName,double updatedPrice,int updatedQuantity)
    {
        IProduct product = _products.FirstOrDefault( i => i.ProductName == oldName);
        product.ProductName = String.IsNullOrWhiteSpace(updatedName) ? product.ProductName : updatedName;
        product.Price = updatedPrice == 0 ? product.Price : updatedPrice;
        product.Quantity = updatedQuantity == 0 ? product.Quantity : updatedQuantity;
    }


    /// <summary>
    /// Overloaded method of <see cref="UpdateProduct(string, string, double, int)"/> includes expiry date,
    /// updates the the details of a particualr product ,leaves the data as it is if the user just pressed enter.
    /// </summary>
    /// <param name="oldName">Name of the product to be updated</param>
    /// <param name="updatedName">New name of the product</param>
    /// <param name="updatedPrice">New price of the product</param>
    /// <param name="updatedQuantity">New quantity of the product</param>
    /// <param name="expiryDate"></param>
    public void UpdateProduct(string oldName,string updatedName,double updatedPrice,int updatedQuantity,DateOnly expiryDate)
    {
        DateOnly defaultDate = DateOnly.MinValue;
        ExpiryDecorator product = (ExpiryDecorator)_products.FirstOrDefault( i => i.ProductName == oldName);
        product.ProductName = String.IsNullOrWhiteSpace(updatedName) ? product.ProductName : updatedName;
        product.Price = updatedPrice == 0 ? product.Price : updatedPrice;
        product.Quantity = updatedQuantity == 0 ? product.Quantity : updatedQuantity;
        product.ExpiryDate = expiryDate == defaultDate ? product.ExpiryDate : expiryDate;
    }

    /// <summary>
    /// Sorts the products by name in both acending and decending order.
    /// </summary>
    /// <returns>List of string containing the products ordered in ascending and decending order</returns>
    public IList<string> SortProducts()
    {
        IList<string> products = new List<string>();
        var ascending = _products.OrderBy(i => i.ProductName).ToList();
        var decending = _products.OrderByDescending(i => i.ProductName).ToList();
        products.Add("\tAscending Order[name] :");
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

    /// <summary>
    /// Finds if a product is persent in ilist <see cref="_products"/>
    /// </summary>
    /// <param name="productName">Name of the product to check if present in <see cref="_products"/></param>
    /// <returns>true if present and false if not present</returns>
    public bool IsProductPresent(string productName)
    {
        IProduct product = _products.FirstOrDefault(i => i.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
        return product != null;
    }

    /// <summary>
    /// Finds if a product is of type <see cref="ExpiryDecorator"/>
    /// </summary>
    /// <param name="productName">Name of the product to check if it is of type <see cref="ExpiryDecorator"/></param>
    /// <returns>true if product is of type <see cref="ExpiryDecorator"/> else false</returns>
    public bool IsPerishable(string productName)
    {
        IProduct product = _products.FirstOrDefault( i => i.ProductName == productName);
        return product is ExpiryDecorator;
    }
}