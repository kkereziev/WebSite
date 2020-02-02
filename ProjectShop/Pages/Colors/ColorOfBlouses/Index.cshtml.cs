using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Colors.ColorOfBlouses
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public string ColorOfBlouseSort { get; set; }
        public string ModelIdSort { get; set; }
        public string BlouseIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<BlouseColor> BlouseColor { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //BlouseColor = await _context.BlouseColor.Include(b => b.Model).ToListAsync();
            this.CurrentFilter = searchString;
            this.ColorOfBlouseSort = sortOrder == "ColorOfBlouse" ? "ColorOfBlouse_desc" : "ColorOfBlouse";
            this.ModelIdSort= sortOrder == "ModelId" ? "ModelId_desc" : "ModelId";
            this.BlouseIdSort= sortOrder == "BlouseId" ? "BlouseId_desc" : "BlouseId";
            if (searchString!=null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.CurrentSort = sortOrder;
            this.CurrentFilter = searchString;
            IQueryable<BlouseColor> colorIQ = from a in _context.BlouseColor
                    .Include(b=>b.Model)
                    .Include(b=>b.Model.Blouse)
                select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                colorIQ = colorIQ.Where(s => s.ColorOfBlouse.Contains(searchString)
                                                    || s.Model.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ColorOfBlouse":
                    colorIQ = colorIQ.OrderBy(a => a.ColorOfBlouse);
                    break;
                case "ColorOfBlouse_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.ColorOfBlouse);
                    break;
                case "ModelId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.Name);
                    break;
                case "ModelId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.Name);
                    break;
                case "BlouseId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.BlouseId);
                    break;
                case "BlouseId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.BlouseId);
                    break;
            }

            int pageSize = 3;
            BlouseColor = await PaginatedList<BlouseColor>.CreateAsync(
                colorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
