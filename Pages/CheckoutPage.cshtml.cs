using AspDotNetCoreEmpty.Models;
namespace AspDotNetCoreEmpty.Pages;

public class CheckoutPageModel(IOrderRepository orderRepository, IShoppingCart shoppingCart) : PageModel
{
    readonly IOrderRepository _orderRepository = orderRepository;
    readonly IShoppingCart _shoppingCart = shoppingCart;

    [BindProperty]
    public Order Order { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if(!ModelState.IsValid)
        {
            return Page();
        }

        List<ShoppingCartItem> items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        if(_shoppingCart.ShoppingCartItems.Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty, add some pies first");
        }

        if(ModelState.IsValid)
        {
            _orderRepository.CreateOrder(Order);
            _shoppingCart.ClearCart();
            return RedirectToPage("CheckoutCompletePage");
        }

        return Page();
    }
}