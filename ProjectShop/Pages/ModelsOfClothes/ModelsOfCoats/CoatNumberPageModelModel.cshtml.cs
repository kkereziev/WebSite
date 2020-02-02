using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;

namespace ProjectShop.Pages.ModelsOfClothes.ModelsOfCoats
{
    public class CoatNumberPageModelModelModel : PageModel
    {
        public SelectList BrandNumberSL { get; set; }
        public void PopulateStreamsDropDownList(ProjectShopContext _context,
            object selectedStream = null)
        {
            var streamsQuery = from s in _context.Coat
                orderby s.Brand
                select s;
            BrandNumberSL = new SelectList(streamsQuery.AsNoTracking(),
                "Id", "Brand", selectedStream);
        }
    }
}