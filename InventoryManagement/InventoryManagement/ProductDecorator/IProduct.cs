namespace InventoryManagement.ProductDecorator;

/// <summary>
/// Interface <see cref="IProduct"/> contains ProductName, Price, Quantity 
/// which classes that implement must contain. 
/// </summary>
public interface IProduct 
{
    
    string GetDetails();
}
