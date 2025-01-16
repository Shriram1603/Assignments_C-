namespace InventoryManagement.ProductDecorator;

/// <summary>
/// Interface <see cref="IProduct"/> acts as the parent type for the <see cref="Product"/> class 
/// and the other decorators such as <see cref="ExpiryDecorator"/> and <see cref="ProductDecorator"/>
/// </summary>
public interface IProduct 
{
    string ProductName {get;set;}
    double Price {get;set;}
    int Quantity {get; set; }
    string GetDetails();
}
