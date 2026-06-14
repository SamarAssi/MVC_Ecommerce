namespace Ecommerce;

public class IndexProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double Rate { get; set; }
    public int Quantity { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
