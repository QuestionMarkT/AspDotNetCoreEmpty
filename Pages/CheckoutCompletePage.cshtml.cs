namespace AspDotNetCoreEmpty.Pages;

public class CheckoutCompletePageModel : PageModel
{
    public void OnGet()
    {
        ViewData["CheckoutCompleteMessage"] = """Thanks for your order. You'll soon enjoy our delicious pies!""";
    }
}
