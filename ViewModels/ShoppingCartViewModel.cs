using AspDotNetCoreEmpty.Models;
namespace AspDotNetCoreEmpty.ViewModels;

public class ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
{
    public IShoppingCart ShoppingCart { get; } = shoppingCart;
    public decimal ShoppingCartTotal { get; } = shoppingCartTotal;
}