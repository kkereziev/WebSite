using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;

namespace ProjectShop.Pages.ModelsOfClothes.ModelsOfBlouses
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlouseModel BlouseModel { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlouseModel = await _context.BlouseModel.FirstOrDefaultAsync(m => m.Id == id);

            if (BlouseModel == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again.";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlouseModel = await _context.BlouseModel
                .AsNoTracking()
                .FirstOrDefaultAsync(m=>m.Id==id);
            if (BlouseModel == null)
            {
                return NotFound();
            }

            try
            {
                _context.BlouseModel.Remove(BlouseModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToPage("./Delete",
                    new {id, saveChangesError = true});
            }
        }
    }
}
