using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Bags;

namespace ProjectShop.Pages.Materials.BagsMaterials
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public MaterialsOfBags MaterialsOfBags { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialsOfBags = await _context.MaterialsOfBags
                .Include(m => m.Bag).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialsOfBags == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
