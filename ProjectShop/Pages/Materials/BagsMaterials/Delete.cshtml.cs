using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Bags;

namespace ProjectShop.Pages.Materials.BagsMaterials
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialsOfBags MaterialsOfBags { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialsOfBags = await _context.MaterialsOfBags
                .Include(m => m.Bag).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialsOfBags == null)
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

            MaterialsOfBags = await _context.MaterialsOfBags.FindAsync(id);

            if (MaterialsOfBags != null)
            {
                _context.MaterialsOfBags.Remove(MaterialsOfBags);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
