using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Boots;

namespace ProjectShop.Pages.Sizes.SizeOfBots
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SizeOfBoots SizeOfBoots { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SizeOfBoots = await _context.SizeOfBoots
                .Include(s => s.Model).FirstOrDefaultAsync(m => m.Id == id);

            if (SizeOfBoots == null)
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

            SizeOfBoots = await _context.SizeOfBoots.FindAsync(id);

            if (SizeOfBoots != null)
            {
                _context.SizeOfBoots.Remove(SizeOfBoots);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
