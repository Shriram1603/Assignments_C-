namespace InventoryManagement.InventoryManager;
using System;

public class Product
{
    public Guid Id = Guid.NewGuid();
    public string Product_Name { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public Product(string product_name, double price, int quantity)
    {

        Product_Name = product_name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $" Product Name = [{Product_Name}] ; Price = [{Price}] ; Quantity = [{Quantity}] ";
    }

}