using AspDotNetCoreEmpty.Models;
using Microsoft.AspNetCore.Authorization;
namespace AspDotNetCoreEmpty.Controllers;

[Authorize]
public class OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart) : Controller
{
	readonly IOrderRepository _orderRepository = orderRepository;
	readonly IShoppingCart _shoppingCart = shoppingCart;
	
	public IActionResult Checkout() => View();

	[HttpPost] public IActionResult Checkout(Order order)
	{
		List<ShoppingCartItem> items = _shoppingCart.GetShoppingCartItems();
		_shoppingCart.ShoppingCartItems = items;

		if(_shoppingCart.ShoppingCartItems.Count == 0)
		{
			ModelState.AddModelError("", "Your cart is empty, add some pies first");
		}
		//var a = ModelState.GetValidationState(""); ::: is it supposed to be here?
		
		if(ModelState.IsValid)
		{
			_orderRepository.CreateOrder(order);
			_shoppingCart.ClearCart();
			return RedirectToAction(nameof(CheckoutComplete));
		}
		return View(order);
	}

	public IActionResult CheckoutComplete()
	{
		ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
		return View();
	}
}