﻿using Microsoft.AspNetCore.Mvc;
using PTDW.Models;

namespace PTDW.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly DatabaseContext _context;

        public MenuTopViewComponent(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblMenus.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
