namespace AspDotNetCoreEmpty.Models;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}