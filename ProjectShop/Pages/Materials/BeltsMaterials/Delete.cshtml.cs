using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Belts;

namespace ProjectShop.Pages.Materials.BeltsMaterials
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialOfBelts MaterialOfBelts { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialOfBelts = await _context.MaterialOfBelts
                .Include(m => m.Belt).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialOfBelts == null)
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

            MaterialOfBelts = await _context.MaterialOfBelts.FindAsync(id);

            if (MaterialOfBelts != null)
            {
                _context.MaterialOfBelts.Remove(MaterialOfBelts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
