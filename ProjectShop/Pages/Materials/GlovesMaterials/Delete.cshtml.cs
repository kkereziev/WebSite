using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Gloves;

namespace ProjectShop.Pages.Materials.GlovesMaterials
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialOfGloves MaterialOfGloves { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialOfGloves = await _context.MaterialOfGloves
                .Include(m => m.Gloves).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialOfGloves == null)
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

            MaterialOfGloves = await _context.MaterialOfGloves.FindAsync(id);

            if (MaterialOfGloves != null)
            {
                _context.MaterialOfGloves.Remove(MaterialOfGloves);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
