using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Boots;

namespace ProjectShop.Pages.Colors.BootsColor
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ColorOfBoots ColorOfBoots { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorOfBoots = await _context.ColorOfBoots
                .Include(c => c.Model).FirstOrDefaultAsync(m => m.Id == id);

            if (ColorOfBoots == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorOfBoots = await _context.ColorOfBoots.FindAsync(id);

            if (ColorOfBoots != null)
            {
                _context.ColorOfBoots.Remove(ColorOfBoots);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
