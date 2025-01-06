using AspDotNetCoreEmpty.Models;
namespace AspDotNetCoreEmpty.Controllers.Api;

[Route("api/[controller]"), ApiController]
public class SearchController(IPieRepository pieRepository) : ControllerBase
{
    readonly IPieRepository _pieRepository = pieRepository;

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_pieRepository.AllPies);
    }

    [HttpGet("{id}")]
    public IActionResult GetAll(int id)
    {
        if(!_pieRepository.AllPies.Any(p => p.PieId == id))
            return NotFound();

        return Ok(_pieRepository.GetPieById(id));
    }

    [HttpPost]
    public IActionResult SearchPies([FromBody] string searchQuery)
    {
        IEnumerable<Pie> pies = [];

        if(!string.IsNullOrWhiteSpace(searchQuery))
        {
            pies = _pieRepository.SearchPies(searchQuery);
        }

        return new JsonResult(pies);
    }
}