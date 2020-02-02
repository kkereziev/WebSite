using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Shirt;

namespace ProjectShop.Pages.Colors.ColorOfShirt
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShirtColor ShirtColor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShirtColor = await _context.ShirtColor
                .Include(s => s.Shirt).FirstOrDefaultAsync(m => m.Id == id);

            if (ShirtColor == null)
            {
                return NotFound();
            }
           ViewData["ShirtId"] = new SelectList(_context.Shirt, "Id", "Id");
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

            _context.Attach(ShirtColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShirtColorExists(ShirtColor.Id))
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

        private bool ShirtColorExists(Guid id)
        {
            return _context.ShirtColor.Any(e => e.Id == id);
        }
    }
}
