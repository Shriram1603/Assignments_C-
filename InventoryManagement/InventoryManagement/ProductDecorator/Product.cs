namespace InventoryManagement.ProductDecorator;

/// <summary>
/// <see cref="Product"/> class holds the actual implementation of <see cref="IProduct"/> 
/// storing the informations [name,price,quantity] of a product.
/// </summary>
public class Product : IProduct 
{   
    private readonly Guid Id = Guid.NewGuid();

    /// <summary>
    /// Holds the name of a <see cref="Product"/> as type string.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Holds the price of a <see cref="Product"/> as type double.
    /// </summary>
    public double Price { get; set;}

    /// <summary>
    /// Holds the quantity of a <see cref="Product"/> as type integer.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Holds the expiry date of a product as type dateonly if it has one else none
    /// </summary>
    public DateOnly? ExpiryDate { get; set; } = null;

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
    /// Constructor of <see cref="Product"/> class to instantiate
    /// [name, price and quantity] properties
    /// </summary>
    /// <param name="productName">Name of the product as string</param>
    /// <param name="price">Price of the product as double</param>
    /// <param name="quantity">Quantity of the product as integer</param>
    /// <param name="expiryDate">Expiry date of the product as date only</param>
    public Product(string productName, double price, int quantity, DateOnly? expiryDate)
    {
        ProductName = productName;
        Price = price;
        Quantity = quantity;
        ExpiryDate = expiryDate;
    }

    /// <summary>
    /// Checks if a product is expired or not by
    /// comparing the expiry date agains the current date.
    /// </summary>
    /// <returns>true if expired and false if not expired</returns>
    public bool IsExpired()
    {
        var dateNow = DateOnly.FromDateTime(DateTime.Now);
        return dateNow >= ExpiryDate;
    }

    /// <summary>
    /// Generates a string containing the information of the <see cref="Product"/>.
    /// </summary>
    /// <returns>Details of the product as string</returns>
    public string GetDetails()
    {
        string expiryLabel = "";
        if (ExpiryDate != null)
        {
            string expiryStatus = IsExpired() ? "Expired" : "Not Expired";
            expiryLabel = $"Expiry Date : {ExpiryDate}, Status : {expiryStatus}.";
        }
        
        return $"ID: {Id}, Product : {ProductName}, Price: {Price}, Quantity: {Quantity}, {expiryLabel}";
    }
}
