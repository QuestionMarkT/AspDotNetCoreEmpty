namespace AspDotNetCoreEmpty.Models;

public class PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext) : IPieRepository
{
    readonly BethanysPieShopDbContext _bethanysPieShopDbContext = bethanysPieShopDbContext;

    public IEnumerable<Pie> AllPies
    {
        get => _bethanysPieShopDbContext.Pies.Include(x => x.Category);
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get => _bethanysPieShopDbContext.Pies.Include(x => x.Category).Where(x => x.IsPieOfTheWeek);
    }

    public Pie? GetPieById(int pieId) => _bethanysPieShopDbContext.Pies.FirstOrDefault(x => x.PieId == pieId);

    public IEnumerable<Pie> SearchPies(string searchQuery) => _bethanysPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
}
