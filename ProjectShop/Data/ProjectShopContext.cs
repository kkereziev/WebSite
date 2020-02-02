using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Models.Clothes.Blouse;
using ProjectShop.Models.Clothes.Shirt;
using ProjectShop.Models.Clothes;
using ProjectShop.Models.Clothes.Coat;
using ProjectShop.Models.Clothes.Dress;
using ProjectShop.Models.Clothes.Panths;
using ProjectShop.Models.Shoes.Boots;
using ProjectShop.Models.Shoes.CasualShoes;
using ProjectShop.Models.Shoes.HighHeeledShoes;
using ProjectShop.Models.Shoes.Sandals;
using ProjectShop.Models.Shoes.Slippers;
using ProjectShop.Models.Shoes.SportShoes;
using ProjectShop.Models.Accessories.Bags;
using ProjectShop.Models.Accessories.Belts;
using ProjectShop.Models.Accessories.Gloves;
using ProjectShop.Models.Accessories.Jewelry;
using ProjectShop.Models.Accessories.Watches;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Data
{
    public class ProjectShopContext : IdentityDbContext
    {
        public ProjectShopContext (DbContextOptions<ProjectShopContext> options)
            : base(options)
        {
        }
        public DbSet<ProjectShop.Models.Clothes.Coat.Coat> Coat { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Dress.Dress> Dress { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Panths.Panths> Panths { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Shirt.Shirt> Shirt { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Blouse.BlouseSize> BlouseSize { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Boots.Boots> Boots { get; set; }
        public DbSet<ProjectShop.Models.Shoes.CasualShoes.CasualShoes> CasualShoes { get; set; }
        public DbSet<ProjectShop.Models.Shoes.HighHeeledShoes.HighHeeledShoes> HighHeeledShoes { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Sandals.Sandals> Sandals { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Slippers.Slippers> Slippers { get; set; }
        public DbSet<ProjectShop.Models.Shoes.SportShoes.Sport_Shoes> Sport_Shoes { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Bags.Bags> Bags { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Belts.Belts> Belts { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Gloves.Gloves> Gloves { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Jewelry.Jewelry> Jewelry { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Watches.Watches> Watches { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Coat.CoatSize> CoatSize { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Dress.DressSize> DressSize { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Panths.PanthsSize> PanthsSize { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Shirt.ShirtSize> ShirtSize { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Boots.SizeOfBoots> SizeOfBoots { get; set; }
        public DbSet<ProjectShop.Models.Shoes.CasualShoes.SizeOfCasualShoes> SizeOfCasualShoes { get; set; }
        public DbSet<ProjectShop.Models.Shoes.HighHeeledShoes.HighHeeledShoesSize> HighHeeledShoesSize { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Sandals.SizeOfSandals> SizeOfSandals { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Slippers.SizeOfSlippers> SizeOfSlippers { get; set; }
        public DbSet<ProjectShop.Models.Shoes.SportShoes.SizeOfShoes> SizeOfShoes { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Blouse.BlouseColor> BlouseColor { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Coat.CoatColor> CoatColor { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Dress.DressColor> DressColor { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Panths.PanthsColor> PanthsColor { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Shirt.ShirtColor> ShirtColor { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Boots.ColorOfBoots> ColorOfBoots { get; set; }
        public DbSet<ProjectShop.Models.Shoes.CasualShoes.ColorOfCasualShoes> ColorOfCasualShoes { get; set; }
        public DbSet<ProjectShop.Models.Shoes.HighHeeledShoes.HighHeeledShoesColors> HighHeeledShoesColors { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Sandals.ColorOfSandals> ColorOfSandals { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Slippers.ColorOfSlippers> ColorOfSlippers { get; set; }
        public DbSet<ProjectShop.Models.Shoes.SportShoes.ColorOfShoes> ColorOfShoes { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Bags.ColorsOfBags> ColorsOfBags { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Belts.ColorsOfBelts> ColorsOfBelts { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Gloves.ColorsOfGloves> ColorsOfGloves { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Bags.MaterialsOfBags> MaterialsOfBags { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Belts.MaterialOfBelts> MaterialOfBelts { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Gloves.MaterialOfGloves> MaterialOfGloves { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Jewelry.CategoryOfJewelry> CategoryOfJewelry { get; set; }
        public DbSet<ProjectShop.Models.Accessories.Watches.StylesOfWatches> StylesOfWatches { get; set; }
        public DbSet<ProjectShop.Models.Discounts.Discount> Discount { get; set; }
        public DbSet<ProjectShop.Models.New_Collection.NewCollection> NewCollection { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Blouse.Blouse> Blouse { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Blouse.BlouseModel> BlouseModel { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Coat.CoatModel> CoatModel { get; set; }
        public DbSet<ProjectShop.Models.Clothes.Dress.DressModel> DressModel { get; set; }
        public DbSet<ProjectShop.Models.Shoes.Boots.BootsModel> BootsModel { get; set; }

    }
}
