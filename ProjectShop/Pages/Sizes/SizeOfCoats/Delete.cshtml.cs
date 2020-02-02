using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Coat;

namespace ProjectShop.Pages.Sizes.SizeOfCoats
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoatSize CoatSize { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoatSize = await _context.CoatSize.FirstOrDefaultAsync(m => m.Id == id);

            if (CoatSize == null)
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

            CoatSize = await _context.CoatSize.FindAsync(id);

            if (CoatSize != null)
            {
                _context.CoatSize.Remove(CoatSize);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
