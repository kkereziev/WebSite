using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Gloves;

namespace ProjectShop.Pages.Accesories.Glovs
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gloves Gloves { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gloves = await _context.Gloves.FirstOrDefaultAsync(m => m.Id == id);

            if (Gloves == null)
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

            Gloves = await _context.Gloves.FindAsync(id);

            if (Gloves != null)
            {
                _context.Gloves.Remove(Gloves);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
