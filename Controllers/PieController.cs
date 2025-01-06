using AspDotNetCoreEmpty.Models;
namespace AspDotNetCoreEmpty.Controllers;

public class PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository) : Controller
{
    readonly IPieRepository _pieRepository = pieRepository;
    readonly ICategoryRepository _categoryRepository = categoryRepository;

    /*public IActionResult List()
    {
        PieListViewModel pieListViewModel = new(_pieRepository.AllPies, "All pies");
        return View(pieListViewModel);
    }*/

    public ViewResult List(string category)
    {
        IEnumerable<Pie> pies;
        string? currentCategory;

        if(string.IsNullOrWhiteSpace(category))
        {
            pies = _pieRepository.AllPies.OrderBy(x => x.PieId);
            currentCategory = "All pies";
        }
        else
        {
            pies = _pieRepository.AllPies
                .Where(x => x.Category.CategoryName == category)
                .OrderBy(x => x.PieId);
            currentCategory = _categoryRepository.AllCategories
                .FirstOrDefault(x => x.CategoryName == category)?
                .CategoryName;
        }
        
        return View(new PieListViewModel(pies, currentCategory));
    }

    public IActionResult Details(int id)
    {
        Pie? pie = _pieRepository.GetPieById(id);
        return pie is not null ? View(pie) : NotFound();
    }

    public ActionResult Search() => View();
}