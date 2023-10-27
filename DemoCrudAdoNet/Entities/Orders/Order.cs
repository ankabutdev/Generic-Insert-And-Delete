namespace DemoCrudAdoNet.Entities.Orders;

public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public int ItemId { get; set; }
}
