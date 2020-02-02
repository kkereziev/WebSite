using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;

namespace ProjectShop.Pages.Cloathes.Blouses
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public Blouse Blouse { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blouse = await _context.Blouse
                .Include(m=>m.Models)
                .ThenInclude(c=>c.Colors)
                .Include(s=>s.Models)
                .ThenInclude(s=>s.Size)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Blouse == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
