using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Dress;

namespace ProjectShop.Pages.Colors.ColorOfDress
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public DressColor DressColor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DressColor = await _context.DressColor
                .Include(d => d.Model).FirstOrDefaultAsync(m => m.Id == id);

            if (DressColor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
