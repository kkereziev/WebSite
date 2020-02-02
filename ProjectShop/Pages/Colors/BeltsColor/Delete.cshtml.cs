using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Belts;

namespace ProjectShop.Pages.Colors.BeltsColor
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ColorsOfBelts ColorsOfBelts { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorsOfBelts = await _context.ColorsOfBelts
                .Include(c => c.Belt).FirstOrDefaultAsync(m => m.Id == id);

            if (ColorsOfBelts == null)
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

            ColorsOfBelts = await _context.ColorsOfBelts.FindAsync(id);

            if (ColorsOfBelts != null)
            {
                _context.ColorsOfBelts.Remove(ColorsOfBelts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
