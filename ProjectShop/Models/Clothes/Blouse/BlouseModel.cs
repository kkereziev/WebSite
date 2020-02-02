using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;

namespace ProjectShop.Models.Clothes.Blouse
{
    public class BlouseModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<BlouseColor> Colors { get; set; }
        public ICollection<BlouseSize> Size { get; set; }
        public Guid BlouseId { get; set; }
        public Blouse Blouse { get; set; }
    }
}
