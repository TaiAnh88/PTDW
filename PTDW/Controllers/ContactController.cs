using Microsoft.AspNetCore.Mvc;
using PTDW.Models;

namespace PTDW.Controllers
{
    public class ContactController: Controller
    {
        private readonly HarmicContext _context;
        public ContactController(HarmicContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(string name,  string phone, string email, string message, string CreatedDate)
        {
            try {
                TblContact contact = new TblContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                _context.SaveChangesAsync();
                return Json(new { startus = true });
                    }
            catch
            {
                return Json(new { startus = false });
            }
        }
    }
}
