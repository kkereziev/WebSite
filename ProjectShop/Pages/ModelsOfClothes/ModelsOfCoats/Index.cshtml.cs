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

namespace ProjectShop.Pages.ModelsOfClothes.ModelsOfCoats
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string CoatIdSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }
        public PaginatedList<CoatModel> CoatModel { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //CoatModel = await _context.CoatModel.Include(c => c.Coat).ToListAsync();
            this.CurrentFilter = searchString;
            this.NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
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
            IQueryable<CoatModel> modelIQ = from a in _context.CoatModel
                    .Include(s => s.Coat)
                    .Include(s => s.Size)
                    .Include(c => c.Colors)
                select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Length == 36)
                {
                    Guid number = Guid.Parse(searchString);
                    modelIQ = modelIQ.Where(a => a.CoatId.Equals(number));
                }
                else
                {
                    modelIQ = modelIQ.Where(a => a.Name.Contains(searchString));
                }
            }

            switch (sortOrder)
            {
                case "Name":
                    modelIQ = modelIQ.OrderBy(a => a.Name);
                    break;
                case "Name_desc":
                    modelIQ = modelIQ.OrderByDescending(a => a.Name);
                    break;
                case "CoatId":
                    modelIQ = modelIQ.OrderBy(a => a.CoatId);
                    break;
                case "CoatId_desc":
                    modelIQ = modelIQ.OrderByDescending(a => a.CoatId);
                    break;
            }

            int pageSize = 3;
            this.CoatModel =
                await PaginatedList<CoatModel>.CreateAsync(modelIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
