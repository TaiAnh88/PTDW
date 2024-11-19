using Microsoft.AspNetCore.Mvc;
using PTDW.Models;
using Microsoft.EntityFrameworkCore;

namespace PTDW.Controllers
{
    public class ProductController : Controller
    {
        private readonly HarmicContext _context;

        public ProductController(HarmicContext context) 
        { 
        _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/product/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }
            var product = await _context.TblProducts.Include(i => i.CategoryProduct)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productReView = _context.TblProductReviews
                .Where(i => i.ProductId == id).ToList();
            ViewBag.productRelated = _context.TblProducts.
                Where(i => i.ProductId != id && i.CategoryProductId == product.CategoryProductId).Take(5).
                OrderByDescending(i => i.ProductId).ToList();
            return View(product);
        }
    }
}
