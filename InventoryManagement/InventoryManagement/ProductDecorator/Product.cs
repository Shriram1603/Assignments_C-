namespace InventoryManagement.ProductDecorator;

/// <summary>
/// <see cref="Product"/> class holds the actual implementation of <see cref="IProduct"/> 
/// storing the informations [name,price,quantity] of a product.
/// </summary>
public class Product : IProduct 
{   
    Guid Id = Guid.NewGuid();
    public string ProductName {get; set; }
    public double Price {get; set;}
    public int Quantity {get; set; }

    /// <summary>
    /// Constructor of <see cref="Product"/> class to instantiate
    /// [name, price and quantity] properties
    /// </summary>
    /// <param name="productName">Name of the product as string</param>
    /// <param name="price">Price of the product as double</param>
    /// <param name="quantity">Quantity of the product as integer</param>
    public Product(string productName, double price, int quantity)
    {
        ProductName =productName;
        Price = price;
        Quantity = quantity;
    }

    /// <summary>
    /// Generates a string containing the information of the product.
    /// </summary>
    /// <returns>Details of the product as string</returns>
    public string GetDetails() => $"ID: {Id}, Product : {ProductName}, Price: {Price}, Quantity: {Quantity}";
}
