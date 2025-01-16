namespace InventoryManagement.ProductDecorator;

/// <summary>
/// <see cref="ExpiryDecorator"/> class is used when an product is perishable.
/// </summary>
public class ExpiryDecorator : ProductDecorator
{
    public DateOnly ExpiryDate {get; set; }

    /// <summary>
    /// <see cref="ExpiryDecorator"/> constructor gets the expiry date of a product along 
    /// with the plain object <see cref="Product"/> , passes the <see cref="Product"/> to <see cref="ProductDecorator"/>
    /// and then add's the expiry date to it and make's it an <see cref="ExpiryDecorator"/> type. 
    /// </summary>
    /// <param name="product">Object of type <see cref="IProduct"/></param>
    /// <param name="expiryDate">Expiry date of a product as DateOnly</param>
    public ExpiryDecorator(IProduct product, DateOnly expiryDate) : base(product)
    {
        ExpiryDate = expiryDate;
    }
    
    /// <summary>
    /// Checks if a product is expired or not by
    /// comparing the expiry date agains the current date.
    /// </summary>
    /// <returns>true if expired and false if not expired</returns>
    public bool IsExpired(){
        var dateNow = DateOnly.FromDateTime(DateTime.Now);
        return dateNow >= ExpiryDate;
    }

    /// <summary>
    /// Overrides the <see cref="Product.GetDetails"/> to provide additional
    /// information such as expiry date and expiry status.
    /// </summary>
    /// <returns>Information about the product as string</returns>
    public override string GetDetails()
    {
        string baseDetails = base.GetDetails();
        string expiryStatus = IsExpired() ? "Expired" : "Not Expired";
        return $"{baseDetails}, Expiry Date : {ExpiryDate}, Status: {expiryStatus}";
    }
}