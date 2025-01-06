using AspDotNetCoreEmpty.Models;
namespace AspDotNetCoreEmpty.Components;

public class CategoryMenu(ICategoryRepository categoryRepository) : ViewComponent
{
    readonly ICategoryRepository _categoryRepository = categoryRepository;

    public IViewComponentResult Invoke() => View(_categoryRepository.AllCategories.OrderBy(x => x.CategoryName));
}
