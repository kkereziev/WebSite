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
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<MaterialsOfBags> MaterialsOfBags { get;set; }

        public async Task OnGetAsync()
        {
            MaterialsOfBags = await _context.MaterialsOfBags
                .Include(m => m.Bag).ToListAsync();
        }
    }
}
