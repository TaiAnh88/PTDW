using PTDW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PTDW.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly HarmicContext _Context;
        public BlogViewComponent(HarmicContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = _Context.TblBlogs.Include(m => m.Category).Where(m => (bool)m.IsActive);
            return await Task.FromResult<IViewComponentResult>(View(item.OrderByDescending(m => m.BlogId).ToList()));
        }
    }
}
