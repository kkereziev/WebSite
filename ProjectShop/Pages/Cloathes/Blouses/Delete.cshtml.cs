using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;

namespace ProjectShop.Pages.Cloathes.Blouses
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Blouse Blouse { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blouse = await _context.Blouse.FirstOrDefaultAsync(m => m.Id == id);

            if (Blouse == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
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

            Blouse = await _context.Blouse.FindAsync(id);

            if (Blouse != null)
            {
                _context.Blouse.Remove(Blouse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
