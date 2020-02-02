using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.HighHeeledShoes;

namespace ProjectShop.Pages.Colors.ColorOfHighHeeledShoes
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<HighHeeledShoesColors> HighHeeledShoesColors { get;set; }

        public async Task OnGetAsync()
        {
            HighHeeledShoesColors = await _context.HighHeeledShoesColors.ToListAsync();
        }
    }
}
