using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Bags;

namespace ProjectShop.Pages.Colors.BagsColor
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public ColorsOfBags ColorsOfBags { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorsOfBags = await _context.ColorsOfBags
                .Include(c => c.Bag).FirstOrDefaultAsync(m => m.Id == id);

            if (ColorsOfBags == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
