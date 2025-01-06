using AspDotNetCoreEmpty.Models;

namespace AspDotNetCoreEmpty.Controllers;

public class ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart) : Controller
{
    readonly IPieRepository _pieRepository = pieRepository;
    readonly IShoppingCart _shoppingCart = shoppingCart;

    public ViewResult Index()
    {
        List<ShoppingCartItem> items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        ShoppingCartViewModel shoppingCartViewModel = new(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

        return View(shoppingCartViewModel);
    }

    /// <summary>
    /// <see langword="true"/> to add to cart, <see langword="false"/> to remove
    /// </summary>
    /// <param name="pieId">pie ID</param>
    /// <param name="addOrRemove"><see langword="true"/> to add to cart, <see langword="false"/> to remove</param>
    /// <returns></returns>
    public RedirectToActionResult AddOrRemoveFromShoppingCart(int pieId, int amount, bool addOrRemove)
    {
        Pie? selectedPie = _pieRepository.AllPies.FirstOrDefault(x => x.PieId == pieId);

        if(selectedPie is not null)
        {
            for(int x = 0 ; x < amount && x <= 20_000; x++)
                if(addOrRemove)
                    _shoppingCart.AddToCart(selectedPie);
                else
                    _shoppingCart.RemoveFromCart(selectedPie);
        }
        return RedirectToAction(nameof(Index));
    }
}