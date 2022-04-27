using System.Linq;
using System.Threading.Tasks;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProducersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.Producers.ToListAsync();
            return View(data);
        }
    }
}