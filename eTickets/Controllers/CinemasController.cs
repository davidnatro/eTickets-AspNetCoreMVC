using System.Linq;
using System.Threading.Tasks;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CinemasController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.Cinemas.ToListAsync();
            return View(data);
        }
    }
}