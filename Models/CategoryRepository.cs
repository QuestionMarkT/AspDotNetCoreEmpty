namespace AspDotNetCoreEmpty.Models;

public class CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext) : ICategoryRepository
{
    readonly BethanysPieShopDbContext _bethanysPieShopDbContext = bethanysPieShopDbContext;

    public IEnumerable<Category> AllCategories => _bethanysPieShopDbContext.Categories.OrderBy(x => x.CategoryName);
}
