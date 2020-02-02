using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Dress;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Colors.ColorOfDress
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string ColorOfDressSort { get; set; }
        public string ModelIdSort { get; set; }
        public string DressIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<DressColor> DressColor { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //DressColor = await _context.DressColor.Include(d => d.Model).ToListAsync();
            this.CurrentFilter = searchString;
            this.ColorOfDressSort = sortOrder == "ColorOfDress" ? "ColorOfDress_desc" : "ColorOfDress";
            this.ModelIdSort = sortOrder == "ModelId" ? "ModelId_desc" : "ModelId";
            this.DressIdSort = sortOrder == "DressId" ? "DressId_desc" : "DressId";
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
            IQueryable<DressColor> colorIQ = from a in _context.DressColor
                    .Include(b => b.Model)
                    .Include(b => b.Model.Dress)
                                              select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                colorIQ = colorIQ.Where(s => s.ColorOfDress.Contains(searchString)
                                                    || s.Model.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ColorOfBlouse":
                    colorIQ = colorIQ.OrderBy(a => a.ColorOfDress);
                    break;
                case "ColorOfBlouse_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.ColorOfDress);
                    break;
                case "ModelId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.Name);
                    break;
                case "ModelId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.Name);
                    break;
                case "BlouseId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.DressId);
                    break;
                case "BlouseId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.DressId);
                    break;
            }

            int pageSize = 3;
            DressColor = await PaginatedList<DressColor>.CreateAsync(
                colorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
