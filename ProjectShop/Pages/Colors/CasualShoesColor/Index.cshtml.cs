using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.CasualShoes;

namespace ProjectShop.Pages.Colors.CasualShoesColor
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<ColorOfCasualShoes> ColorOfCasualShoes { get;set; }

        public async Task OnGetAsync()
        {
            ColorOfCasualShoes = await _context.ColorOfCasualShoes
                .Include(c => c.CasualShoes).ToListAsync();
        }
    }
}
