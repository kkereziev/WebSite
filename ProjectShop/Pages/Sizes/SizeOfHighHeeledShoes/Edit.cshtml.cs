using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.HighHeeledShoes;

namespace ProjectShop.Pages.Sizes.SizeOfHighHeeledShoes
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HighHeeledShoesSize HighHeeledShoesSize { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HighHeeledShoesSize = await _context.HighHeeledShoesSize
                .Include(h => h.Shoes).FirstOrDefaultAsync(m => m.Id == id);

            if (HighHeeledShoesSize == null)
            {
                return NotFound();
            }
           ViewData["ShoesId"] = new SelectList(_context.HighHeeledShoes, "Id", "Id");
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

            _context.Attach(HighHeeledShoesSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighHeeledShoesSizeExists(HighHeeledShoesSize.Id))
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

        private bool HighHeeledShoesSizeExists(Guid id)
        {
            return _context.HighHeeledShoesSize.Any(e => e.Id == id);
        }
    }
}
