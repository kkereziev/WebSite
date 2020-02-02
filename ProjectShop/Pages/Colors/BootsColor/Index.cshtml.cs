using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Boots;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Colors.BootsColor
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string ColorOfBootsSort { get; set; }
        public string ModelIdSort { get; set; }
        public string BootsIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<ColorOfBoots> ColorOfBoots { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //ColorOfBoots = await _context.ColorOfBoots.Include(c => c.Model).ToListAsync();
            this.CurrentFilter = searchString;
            this.ColorOfBootsSort = sortOrder == "_ColorOfBoots" ? "_ColorOfBoots_desc" : "_ColorOfBoots";
            this.ModelIdSort = sortOrder == "ModelId" ? "ModelId_desc" : "ModelId";
            this.BootsIdSort = sortOrder == "BootsId" ? "BootsId_desc" : "BootsId";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.CurrentSort = sortOrder;
            this.CurrentFilter = searchString;
            IQueryable<ColorOfBoots> colorIQ = from a in _context.ColorOfBoots
                    .Include(b => b.Model)
                    .Include(b => b.Model.Boots)
                                             select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                colorIQ = colorIQ.Where(s => s._ColorOfBoots.Contains(searchString)
                                                    || s.Model.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "_ColorOfBoots":
                    colorIQ = colorIQ.OrderBy(a => a._ColorOfBoots);
                    break;
                case "_ColorOfBoots_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a._ColorOfBoots);
                    break;
                case "ModelId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.Name);
                    break;
                case "ModelId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.Name);
                    break;
                case "BootsId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.BootsId);
                    break;
                case "BootsId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.BootsId);
                    break;
            }

            int pageSize = 3;
            ColorOfBoots = await PaginatedList<ColorOfBoots>.CreateAsync(
                colorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
