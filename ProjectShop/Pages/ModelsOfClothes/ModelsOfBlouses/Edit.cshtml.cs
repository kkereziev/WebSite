using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;

namespace ProjectShop.Pages.ModelsOfClothes.ModelsOfBlouses
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlouseModel BlouseModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            ViewData["BrandId"] = new SelectList(_context.Set<Blouse>(), "Id", "Brand");
            if (id == null)
            {
                return NotFound();
            }

            BlouseModel = await _context.BlouseModel.FindAsync(id);

            if (BlouseModel == null)
            {
                return NotFound();
            }
            return Page();

        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var modelToUpdate = await _context.BlouseModel.FindAsync(id);
            if (await TryUpdateModelAsync<BlouseModel>(
                modelToUpdate,
                "BlouseModel",
                n=>n.Name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool BlouseModelExists(Guid id)
        {
            return _context.BlouseModel.Any(e => e.Id == id);
        }
    }
}
