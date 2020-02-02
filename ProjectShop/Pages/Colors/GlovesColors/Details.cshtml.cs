using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Gloves;

namespace ProjectShop.Pages.Colors.GlovesColors
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public ColorsOfGloves ColorsOfGloves { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorsOfGloves = await _context.ColorsOfGloves
                .Include(c => c.Gloves).FirstOrDefaultAsync(m => m.Id == id);

            if (ColorsOfGloves == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
