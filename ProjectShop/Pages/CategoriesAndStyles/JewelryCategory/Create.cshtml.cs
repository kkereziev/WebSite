using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Jewelry;

namespace ProjectShop.Pages.CategoriesAndStyles.JewelryCategory
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
        ViewData["JewelryId"] = new SelectList(_context.Jewelry, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CategoryOfJewelry CategoryOfJewelry { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryOfJewelry.Add(CategoryOfJewelry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
