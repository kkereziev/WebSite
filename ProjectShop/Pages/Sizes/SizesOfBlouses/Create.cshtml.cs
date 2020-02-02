using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;


namespace ProjectShop.Pages.Sizes.SizesOfBlouses
{
    public class CreateModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public CreateModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ModelName"] = new SelectList(_context.Set<BlouseModel>(), "Id", "Name");
        return Page();
        }

        [BindProperty]
        public BlouseSize BlouseSize { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BlouseSize.Add(BlouseSize);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
