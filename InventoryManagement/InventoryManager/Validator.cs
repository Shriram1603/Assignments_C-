namespace InventoryManagement.InventoryManager;

public class Validator
{
    public static bool IsValidProductName(string productName) => String.IsNullOrWhiteSpace(productName) || String.IsNullOrEmpty(productName);

    public static bool IsValidPrice(double price) =>  price > 0;

    public static bool IsValidQuantity(int quantity) => quantity >= 0;


}