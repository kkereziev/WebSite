using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Gloves;

namespace ProjectShop.Pages.Materials.GlovesMaterials
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<MaterialOfGloves> MaterialOfGloves { get;set; }

        public async Task OnGetAsync()
        {
            MaterialOfGloves = await _context.MaterialOfGloves
                .Include(m => m.Gloves).ToListAsync();
        }
    }
}
