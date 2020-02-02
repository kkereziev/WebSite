using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Coat;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Colors.ColorOfCoat
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string ColorOfCoatSort { get; set; }
        public string ModelIdSort { get; set; }
        public string CoatIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<CoatColor> CoatColor { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //CoatColor = await _context.CoatColor.ToListAsync();
            this.CurrentFilter = searchString;
            this.ColorOfCoatSort = sortOrder == "ColorOfCoat" ? "ColorOfCoat_desc" : "ColorOfCoat";
            this.ModelIdSort = sortOrder == "ModelId" ? "ModelId_desc" : "ModelId";
            this.CoatIdSort = sortOrder == "CoatId" ? "CoatId_desc" : "CoatId";
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
            IQueryable<CoatColor> colorIQ = from a in _context.CoatColor
                    .Include(b => b.Model)
                    .Include(b => b.Model.Coat)
                                              select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                colorIQ = colorIQ.Where(s => s.ColorOfCoat.Contains(searchString)
                                                    || s.Model.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ColorOfCoat":
                    colorIQ = colorIQ.OrderBy(a => a.ColorOfCoat);
                    break;
                case "ColorOfCoat_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.ColorOfCoat);
                    break;
                case "ModelId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.Name);
                    break;
                case "ModelId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.Name);
                    break;
                case "CoatId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.CoatId);
                    break;
                case "CoatId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.CoatId);
                    break;
            }

            int pageSize = 3;
            CoatColor = await PaginatedList<CoatColor>.CreateAsync(
                colorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
