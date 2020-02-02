using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Jewelry;

namespace ProjectShop.Pages.CategoriesAndStyles.JewelryCategory
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<CategoryOfJewelry> CategoryOfJewelry { get;set; }

        public async Task OnGetAsync()
        {
            CategoryOfJewelry = await _context.CategoryOfJewelry
                .Include(c => c.Jewelry).ToListAsync();
        }
    }
}
