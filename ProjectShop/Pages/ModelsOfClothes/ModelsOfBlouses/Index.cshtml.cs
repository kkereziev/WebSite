using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.ModelsOfClothes.ModelsOfBlouses
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string BlouseIdSort { get; set; }
        
        public string CurrentFilter { get; set; }
        
        public string CurrentSort { get; set; }
        
        public PaginatedList<BlouseModel> BlouseModel { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //BlouseModel = await _context.BlouseModel.ToListAsync();
            this.CurrentFilter = searchString;
            this.NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
            this.BlouseIdSort = sortOrder == "BlouseId" ? "BlouseId_desc" : "BlouseId";
            if (searchString !=null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.CurrentSort = sortOrder;
            this.CurrentFilter = searchString;
            IQueryable<BlouseModel> modelIQ = from a in _context.BlouseModel
                    .Include(s=>s.Blouse)   
                    .Include(s=>s.Size)
                    .Include(c=>c.Colors)
                select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Length== 36)
                {
                    Guid number = Guid.Parse(searchString);
                    modelIQ = modelIQ.Where(a => a.BlouseId.Equals(number));
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
                case "BlouseId":
                    modelIQ = modelIQ.OrderBy(a => a.BlouseId);
                    break;
                case "BlouseId_desc":
                    modelIQ = modelIQ.OrderByDescending(a => a.BlouseId);
                    break;
            }

            int pageSize = 3;
            this.BlouseModel =
                await PaginatedList<BlouseModel>.CreateAsync(modelIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
