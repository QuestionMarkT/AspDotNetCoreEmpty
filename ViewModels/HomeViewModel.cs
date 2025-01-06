using AspDotNetCoreEmpty.Models;
namespace AspDotNetCoreEmpty.ViewModels;

public class HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
{
    public IEnumerable<Pie> PiesOfTheWeek { get; } = piesOfTheWeek;
}
