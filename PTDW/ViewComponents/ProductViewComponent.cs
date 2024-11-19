using PTDW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PTDW.ViewComponents
{
    public class ProductViewComponent: ViewComponent
    {
        private readonly HarmicContext _Context;
        public ProductViewComponent(HarmicContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _Context.TblProducts.Include(m => m.CategoryProduct)
                .Where(m => m.IsActive == true && m.IsNew == true);
            return await Task.FromResult<IViewComponentResult>(View(items.OrderByDescending(m => m.ProductId).ToList()));
        }
    }
}
