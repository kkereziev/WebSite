using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Panths;

namespace ProjectShop.Pages.Cloathes.Panthies
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Panths Panths { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Panths = await _context.Panths.FirstOrDefaultAsync(m => m.Id == id);

            if (Panths == null)
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

            Panths = await _context.Panths.FindAsync(id);

            if (Panths != null)
            {
                _context.Panths.Remove(Panths);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
