using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Slippers;

namespace ProjectShop.Pages.Colors.SlippersColor
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ColorOfSlippers ColorOfSlippers { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorOfSlippers = await _context.ColorOfSlippers
                .Include(c => c.Slippers).FirstOrDefaultAsync(m => m.Id == id);

            if (ColorOfSlippers == null)
            {
                return NotFound();
            }
           ViewData["SlippersId"] = new SelectList(_context.Slippers, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ColorOfSlippers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorOfSlippersExists(ColorOfSlippers.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ColorOfSlippersExists(Guid id)
        {
            return _context.ColorOfSlippers.Any(e => e.Id == id);
        }
    }
}
