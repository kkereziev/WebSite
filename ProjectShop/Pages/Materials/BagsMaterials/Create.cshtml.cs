using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Bags;

namespace ProjectShop.Pages.Materials.BagsMaterials
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
        ViewData["BagId"] = new SelectList(_context.Bags, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MaterialsOfBags MaterialsOfBags { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaterialsOfBags.Add(MaterialsOfBags);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
