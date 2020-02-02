using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;

namespace ProjectShop.Pages.ModelsOfClothes.ModelsOfBlouses
{
    public class CreateModel : BlouseNumberPageModelModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public CreateModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandId"] = new SelectList(_context.Set<Blouse>(), "Id", "Brand");
            return Page();
        }

        [BindProperty]
        public BlouseModel BlouseModel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BlouseModel.Add(BlouseModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
