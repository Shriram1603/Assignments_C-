namespace InventoryManagement.ProductDecorator;

/// <summary>
/// Abstract class <see cref="ProductDecorator"/> can be inherited to add 
/// decorators to existing <see cref="Product"/> cless
/// </summary>
public abstract class ProductDecorator : IProduct
{
    protected readonly IProduct product;

    /// <summary>
    /// Dependecy injection of type <see cref="IProduct"/>
    /// through contructor <see cref="ProductDecorator"/> to access <see cref="Product"/>
    /// </summary>
    /// <param name="product">Object of type <see cref="IProduct"/> and it's child class <see cref="Product"/></param>
    public ProductDecorator(IProduct product)
    {
        this.product = product;
    }

    /// <summary>
    /// Virtual implementation of <see cref="ProductName"/> property
    /// </summary>
    public virtual string ProductName
    {
        get => product.ProductName;
        set => product.ProductName = value;
    }

    /// <summary>
    /// Virtual implementation of <see cref="Product.Price"/> property
    /// </summary>
    public virtual double Price
    {
        get => product.Price;
        set => product.Price = value;
    }

    /// <summary>
    /// Virtual implementation of <see cref="Product.Quantity"/> property
    /// </summary>
    public virtual int Quantity
    {
        get => product.Quantity;
        set => product.Quantity = value;
    }

    /// <summary>
    /// Virtual implementation of <see cref="Product.GetDetails"/> property
    /// </summary>
    public virtual string GetDetails() => product.GetDetails();
}
