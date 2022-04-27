using System.Linq;
using System.Threading.Tasks;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Route("/")]
    public class MoviesController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MoviesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.Movies.Include(n => n.Cinema).
                OrderBy(n => n.Name).ToListAsync();
            return View(data);
        }
    }
}