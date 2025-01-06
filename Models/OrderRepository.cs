namespace AspDotNetCoreEmpty.Models;

public class OrderRepository(BethanysPieShopDbContext bethanysPieShopDbContext, IShoppingCart shoppingCart) : IOrderRepository
{
    readonly BethanysPieShopDbContext _bethanysPieShopDbContext = bethanysPieShopDbContext;
    readonly IShoppingCart _shoppingCart = shoppingCart;

    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;

        List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

        order.OrderDetails = [];

        //adding the order with its details
        foreach(ShoppingCartItem? shoppingCartItem in shoppingCartItems)
        {
            OrderDetail orderDetail = new()
            {
                Amount = shoppingCartItem.Amount,
                PieId = shoppingCartItem.Pie.PieId,
                Price = shoppingCartItem.Pie.Price,
            };

            order.OrderDetails.Add(orderDetail);
        }

        _bethanysPieShopDbContext.Orders.Add(order);
        _bethanysPieShopDbContext.SaveChanges();
    }
}