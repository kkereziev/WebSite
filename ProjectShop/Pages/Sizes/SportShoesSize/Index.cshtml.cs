using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.SportShoes;

namespace ProjectShop.Pages.Sizes.SportShoesSize
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<SizeOfShoes> SizeOfShoes { get;set; }

        public async Task OnGetAsync()
        {
            SizeOfShoes = await _context.SizeOfShoes
                .Include(s => s.Shoes).ToListAsync();
        }
    }
}
