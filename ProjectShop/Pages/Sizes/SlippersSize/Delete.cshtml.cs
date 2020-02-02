using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Slippers;

namespace ProjectShop.Pages.Sizes.SlippersSize
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SizeOfSlippers SizeOfSlippers { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SizeOfSlippers = await _context.SizeOfSlippers
                .Include(s => s.Slippers).FirstOrDefaultAsync(m => m.Id == id);

            if (SizeOfSlippers == null)
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

            SizeOfSlippers = await _context.SizeOfSlippers.FindAsync(id);

            if (SizeOfSlippers != null)
            {
                _context.SizeOfSlippers.Remove(SizeOfSlippers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
