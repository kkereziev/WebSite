using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShop.Migrations
{
    public partial class AddingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewCollection",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bags_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bags_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Belts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Belts_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Belts_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blouse_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blouse_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boots_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boots_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CasualShoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasualShoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasualShoes_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasualShoes_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coat_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coat_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dress_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dress_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gloves",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gloves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gloves_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gloves_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HighHeeledShoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighHeeledShoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HighHeeledShoes_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HighHeeledShoes_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jewelry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewelry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jewelry_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jewelry_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Panths",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Panths_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Panths_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sandals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sandals_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sandals_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shirt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shirt_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shirt_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slippers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slippers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slippers_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slippers_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sport_Shoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport_Shoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sport_Shoes_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sport_Shoes_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    NewCollectionId = table.Column<Guid>(nullable: false),
                    DiscountsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watches_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_NewCollection_NewCollectionId",
                        column: x => x.NewCollectionId,
                        principalTable: "NewCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorsOfBags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfBag = table.Column<string>(nullable: true),
                    BagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsOfBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorsOfBags_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsOfBags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaterialOfBag = table.Column<string>(nullable: true),
                    BagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsOfBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialsOfBags_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorsOfBelts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfBelt = table.Column<string>(nullable: true),
                    BeltId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsOfBelts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorsOfBelts_Belts_BeltId",
                        column: x => x.BeltId,
                        principalTable: "Belts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialOfBelts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaterialOfBelt = table.Column<string>(nullable: true),
                    BeltId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialOfBelts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialOfBelts_Belts_BeltId",
                        column: x => x.BeltId,
                        principalTable: "Belts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlouseModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BlouseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlouseModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlouseModel_Blouse_BlouseId",
                        column: x => x.BlouseId,
                        principalTable: "Blouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BootsModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BootsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BootsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BootsModel_Boots_BootsId",
                        column: x => x.BootsId,
                        principalTable: "Boots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorOfCasualShoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfShoe = table.Column<string>(nullable: true),
                    CasualShoesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorOfCasualShoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorOfCasualShoes_CasualShoes_CasualShoesId",
                        column: x => x.CasualShoesId,
                        principalTable: "CasualShoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeOfCasualShoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfShoe = table.Column<int>(nullable: false),
                    ShoesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOfCasualShoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOfCasualShoes_CasualShoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "CasualShoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoatModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CoatId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoatModel_Coat_CoatId",
                        column: x => x.CoatId,
                        principalTable: "Coat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DressModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DressModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DressModel_Dress_DressId",
                        column: x => x.DressId,
                        principalTable: "Dress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorsOfGloves",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfGloves = table.Column<string>(nullable: true),
                    GlovesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsOfGloves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorsOfGloves_Gloves_GlovesId",
                        column: x => x.GlovesId,
                        principalTable: "Gloves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialOfGloves",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaterialsOfGloves = table.Column<string>(nullable: true),
                    GlovesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialOfGloves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialOfGloves_Gloves_GlovesId",
                        column: x => x.GlovesId,
                        principalTable: "Gloves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HighHeeledShoesColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfShoe = table.Column<string>(nullable: true),
                    HighHeeledShoeId = table.Column<Guid>(nullable: false),
                    HighHeeledShoesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighHeeledShoesColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HighHeeledShoesColors_HighHeeledShoes_HighHeeledShoesId",
                        column: x => x.HighHeeledShoesId,
                        principalTable: "HighHeeledShoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HighHeeledShoesSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfShoe = table.Column<int>(nullable: false),
                    ShoesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighHeeledShoesSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HighHeeledShoesSize_HighHeeledShoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "HighHeeledShoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryOfJewelry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryOfJewel = table.Column<string>(nullable: true),
                    JewelryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOfJewelry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryOfJewelry_Jewelry_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PanthsColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfPanths = table.Column<string>(nullable: true),
                    DressId = table.Column<Guid>(nullable: false),
                    PanthsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanthsColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PanthsColor_Panths_PanthsId",
                        column: x => x.PanthsId,
                        principalTable: "Panths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PanthsSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfPanths = table.Column<int>(nullable: false),
                    PanthsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanthsSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PanthsSize_Panths_PanthsId",
                        column: x => x.PanthsId,
                        principalTable: "Panths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorOfSandals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfSandal = table.Column<string>(nullable: true),
                    SandalsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorOfSandals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorOfSandals_Sandals_SandalsId",
                        column: x => x.SandalsId,
                        principalTable: "Sandals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeOfSandals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfSandal = table.Column<int>(nullable: false),
                    SandalsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOfSandals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOfSandals_Sandals_SandalsId",
                        column: x => x.SandalsId,
                        principalTable: "Sandals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShirtColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfShirt = table.Column<string>(nullable: true),
                    ShirtId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShirtColor_Shirt_ShirtId",
                        column: x => x.ShirtId,
                        principalTable: "Shirt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShirtSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfShirt = table.Column<int>(nullable: false),
                    ShirtId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShirtSize_Shirt_ShirtId",
                        column: x => x.ShirtId,
                        principalTable: "Shirt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorOfSlippers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfSlipper = table.Column<string>(nullable: true),
                    SlippersId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorOfSlippers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorOfSlippers_Slippers_SlippersId",
                        column: x => x.SlippersId,
                        principalTable: "Slippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeOfSlippers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfSlipper = table.Column<int>(nullable: false),
                    SlippersId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOfSlippers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOfSlippers_Slippers_SlippersId",
                        column: x => x.SlippersId,
                        principalTable: "Slippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorOfShoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfShoe = table.Column<string>(nullable: true),
                    ShoesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorOfShoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorOfShoes_Sport_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Sport_Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeOfShoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfShoe = table.Column<int>(nullable: false),
                    ShoesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOfShoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOfShoes_Sport_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Sport_Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StylesOfWatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StyleOfWatch = table.Column<string>(nullable: true),
                    WatchId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StylesOfWatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StylesOfWatches_Watches_WatchId",
                        column: x => x.WatchId,
                        principalTable: "Watches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlouseColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfBlouse = table.Column<string>(nullable: true),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlouseColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlouseColor_BlouseModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "BlouseModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlouseSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfBlouse = table.Column<int>(nullable: false),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlouseSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlouseSize_BlouseModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "BlouseModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorOfBoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    _ColorOfBoots = table.Column<string>(nullable: true),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorOfBoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorOfBoots_BootsModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "BootsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeOfBoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfBoot = table.Column<int>(nullable: false),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOfBoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOfBoots_BootsModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "BootsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoatColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfCoat = table.Column<string>(nullable: true),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoatColor_CoatModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CoatModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoatSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfCoat = table.Column<int>(nullable: false),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoatSize_CoatModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CoatModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DressColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColorOfDress = table.Column<string>(nullable: true),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DressColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DressColor_DressModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "DressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DressSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SizeOfDress = table.Column<int>(nullable: false),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DressSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DressSize_DressModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "DressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bags_DiscountsId",
                table: "Bags",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bags_NewCollectionId",
                table: "Bags",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Belts_DiscountsId",
                table: "Belts",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Belts_NewCollectionId",
                table: "Belts",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Blouse_DiscountId",
                table: "Blouse",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Blouse_NewCollectionId",
                table: "Blouse",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BlouseColor_ModelId",
                table: "BlouseColor",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BlouseModel_BlouseId",
                table: "BlouseModel",
                column: "BlouseId");

            migrationBuilder.CreateIndex(
                name: "IX_BlouseSize_ModelId",
                table: "BlouseSize",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Boots_DiscountId",
                table: "Boots",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Boots_NewCollectionId",
                table: "Boots",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BootsModel_BootsId",
                table: "BootsModel",
                column: "BootsId");

            migrationBuilder.CreateIndex(
                name: "IX_CasualShoes_DiscountsId",
                table: "CasualShoes",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_CasualShoes_NewCollectionId",
                table: "CasualShoes",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfJewelry_JewelryId",
                table: "CategoryOfJewelry",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coat_DiscountId",
                table: "Coat",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Coat_NewCollectionId",
                table: "Coat",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CoatColor_ModelId",
                table: "CoatColor",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CoatModel_CoatId",
                table: "CoatModel",
                column: "CoatId");

            migrationBuilder.CreateIndex(
                name: "IX_CoatSize_ModelId",
                table: "CoatSize",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorOfBoots_ModelId",
                table: "ColorOfBoots",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorOfCasualShoes_CasualShoesId",
                table: "ColorOfCasualShoes",
                column: "CasualShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorOfSandals_SandalsId",
                table: "ColorOfSandals",
                column: "SandalsId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorOfShoes_ShoesId",
                table: "ColorOfShoes",
                column: "ShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorOfSlippers_SlippersId",
                table: "ColorOfSlippers",
                column: "SlippersId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorsOfBags_BagId",
                table: "ColorsOfBags",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorsOfBelts_BeltId",
                table: "ColorsOfBelts",
                column: "BeltId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorsOfGloves_GlovesId",
                table: "ColorsOfGloves",
                column: "GlovesId");

            migrationBuilder.CreateIndex(
                name: "IX_Dress_DiscountId",
                table: "Dress",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Dress_NewCollectionId",
                table: "Dress",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DressColor_ModelId",
                table: "DressColor",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DressModel_DressId",
                table: "DressModel",
                column: "DressId");

            migrationBuilder.CreateIndex(
                name: "IX_DressSize_ModelId",
                table: "DressSize",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Gloves_DiscountsId",
                table: "Gloves",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gloves_NewCollectionId",
                table: "Gloves",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HighHeeledShoes_DiscountsId",
                table: "HighHeeledShoes",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_HighHeeledShoes_NewCollectionId",
                table: "HighHeeledShoes",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HighHeeledShoesColors_HighHeeledShoesId",
                table: "HighHeeledShoesColors",
                column: "HighHeeledShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_HighHeeledShoesSize_ShoesId",
                table: "HighHeeledShoesSize",
                column: "ShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_DiscountsId",
                table: "Jewelry",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_NewCollectionId",
                table: "Jewelry",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOfBelts_BeltId",
                table: "MaterialOfBelts",
                column: "BeltId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOfGloves_GlovesId",
                table: "MaterialOfGloves",
                column: "GlovesId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsOfBags_BagId",
                table: "MaterialsOfBags",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_Panths_DiscountsId",
                table: "Panths",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Panths_NewCollectionId",
                table: "Panths",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PanthsColor_PanthsId",
                table: "PanthsColor",
                column: "PanthsId");

            migrationBuilder.CreateIndex(
                name: "IX_PanthsSize_PanthsId",
                table: "PanthsSize",
                column: "PanthsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sandals_DiscountsId",
                table: "Sandals",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sandals_NewCollectionId",
                table: "Sandals",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirt_DiscountsId",
                table: "Shirt",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirt_NewCollectionId",
                table: "Shirt",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShirtColor_ShirtId",
                table: "ShirtColor",
                column: "ShirtId");

            migrationBuilder.CreateIndex(
                name: "IX_ShirtSize_ShirtId",
                table: "ShirtSize",
                column: "ShirtId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOfBoots_ModelId",
                table: "SizeOfBoots",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOfCasualShoes_ShoesId",
                table: "SizeOfCasualShoes",
                column: "ShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOfSandals_SandalsId",
                table: "SizeOfSandals",
                column: "SandalsId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOfShoes_ShoesId",
                table: "SizeOfShoes",
                column: "ShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOfSlippers_SlippersId",
                table: "SizeOfSlippers",
                column: "SlippersId");

            migrationBuilder.CreateIndex(
                name: "IX_Slippers_DiscountsId",
                table: "Slippers",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Slippers_NewCollectionId",
                table: "Slippers",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Shoes_DiscountsId",
                table: "Sport_Shoes",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Shoes_NewCollectionId",
                table: "Sport_Shoes",
                column: "NewCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StylesOfWatches_WatchId",
                table: "StylesOfWatches",
                column: "WatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_DiscountsId",
                table: "Watches",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_NewCollectionId",
                table: "Watches",
                column: "NewCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlouseColor");

            migrationBuilder.DropTable(
                name: "BlouseSize");

            migrationBuilder.DropTable(
                name: "CategoryOfJewelry");

            migrationBuilder.DropTable(
                name: "CoatColor");

            migrationBuilder.DropTable(
                name: "CoatSize");

            migrationBuilder.DropTable(
                name: "ColorOfBoots");

            migrationBuilder.DropTable(
                name: "ColorOfCasualShoes");

            migrationBuilder.DropTable(
                name: "ColorOfSandals");

            migrationBuilder.DropTable(
                name: "ColorOfShoes");

            migrationBuilder.DropTable(
                name: "ColorOfSlippers");

            migrationBuilder.DropTable(
                name: "ColorsOfBags");

            migrationBuilder.DropTable(
                name: "ColorsOfBelts");

            migrationBuilder.DropTable(
                name: "ColorsOfGloves");

            migrationBuilder.DropTable(
                name: "DressColor");

            migrationBuilder.DropTable(
                name: "DressSize");

            migrationBuilder.DropTable(
                name: "HighHeeledShoesColors");

            migrationBuilder.DropTable(
                name: "HighHeeledShoesSize");

            migrationBuilder.DropTable(
                name: "MaterialOfBelts");

            migrationBuilder.DropTable(
                name: "MaterialOfGloves");

            migrationBuilder.DropTable(
                name: "MaterialsOfBags");

            migrationBuilder.DropTable(
                name: "PanthsColor");

            migrationBuilder.DropTable(
                name: "PanthsSize");

            migrationBuilder.DropTable(
                name: "ShirtColor");

            migrationBuilder.DropTable(
                name: "ShirtSize");

            migrationBuilder.DropTable(
                name: "SizeOfBoots");

            migrationBuilder.DropTable(
                name: "SizeOfCasualShoes");

            migrationBuilder.DropTable(
                name: "SizeOfSandals");

            migrationBuilder.DropTable(
                name: "SizeOfShoes");

            migrationBuilder.DropTable(
                name: "SizeOfSlippers");

            migrationBuilder.DropTable(
                name: "StylesOfWatches");

            migrationBuilder.DropTable(
                name: "BlouseModel");

            migrationBuilder.DropTable(
                name: "Jewelry");

            migrationBuilder.DropTable(
                name: "CoatModel");

            migrationBuilder.DropTable(
                name: "DressModel");

            migrationBuilder.DropTable(
                name: "HighHeeledShoes");

            migrationBuilder.DropTable(
                name: "Belts");

            migrationBuilder.DropTable(
                name: "Gloves");

            migrationBuilder.DropTable(
                name: "Bags");

            migrationBuilder.DropTable(
                name: "Panths");

            migrationBuilder.DropTable(
                name: "Shirt");

            migrationBuilder.DropTable(
                name: "BootsModel");

            migrationBuilder.DropTable(
                name: "CasualShoes");

            migrationBuilder.DropTable(
                name: "Sandals");

            migrationBuilder.DropTable(
                name: "Sport_Shoes");

            migrationBuilder.DropTable(
                name: "Slippers");

            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "Blouse");

            migrationBuilder.DropTable(
                name: "Coat");

            migrationBuilder.DropTable(
                name: "Dress");

            migrationBuilder.DropTable(
                name: "Boots");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "NewCollection");
        }
    }
}
