using AspDotNetCoreEmpty.Models;
namespace AspDotNetCoreEmpty.Components;

public class ShoppingCartSummary(IShoppingCart shoppingCart) : ViewComponent
{
    readonly IShoppingCart _shoppingCart = shoppingCart;

    public IViewComponentResult Invoke()
    {
        List<ShoppingCartItem> items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        ShoppingCartViewModel shoppingCartViewModel = new(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

        return View(shoppingCartViewModel);
    }
}