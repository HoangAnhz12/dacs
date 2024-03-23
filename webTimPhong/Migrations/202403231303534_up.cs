namespace webTimPhong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CITY",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DISTRICT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false, maxLength: 100),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CITY", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.ROOM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 300),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Acreage = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        WardId = c.Int(nullable: false),
                        DistrictId = c.Int(),
                        CityId = c.Int(nullable: false),
                        ExprireTime = c.DateTime(nullable: false),
                        Image = c.String(),
                        RoomCategoryId = c.Int(nullable: false),
                        Latitude = c.Decimal(precision: 18, scale: 2),
                        Longtitude = c.Decimal(precision: 18, scale: 2),
                        ViewCount = c.Int(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        Createddate = c.DateTime(nullable: false),
                        Modifierdate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CITY", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.DISTRICT", t => t.DistrictId)
                .ForeignKey("dbo.RoomCategory", t => t.RoomCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.WARD", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId)
                .Index(t => t.DistrictId)
                .Index(t => t.CityId)
                .Index(t => t.RoomCategoryId);
            
            CreateTable(
                "dbo.PICTURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROOM", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.RoomCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Icon = c.String(maxLength: 250),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeywords = c.String(maxLength: 250),
                        CreatedBy = c.String(),
                        Createddate = c.DateTime(nullable: false),
                        Modifierdate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WARD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WardName = c.String(nullable: false, maxLength: 100),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DISTRICT", t => t.DistrictId, cascadeDelete: false)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.FAQ",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Role = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ROOM", "WardId", "dbo.WARD");
            DropForeignKey("dbo.WARD", "DistrictId", "dbo.DISTRICT");
            DropForeignKey("dbo.ROOM", "RoomCategoryId", "dbo.RoomCategory");
            DropForeignKey("dbo.PICTURE", "RoomId", "dbo.ROOM");
            DropForeignKey("dbo.ROOM", "DistrictId", "dbo.DISTRICT");
            DropForeignKey("dbo.ROOM", "CityId", "dbo.CITY");
            DropForeignKey("dbo.DISTRICT", "CityId", "dbo.CITY");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.WARD", new[] { "DistrictId" });
            DropIndex("dbo.PICTURE", new[] { "RoomId" });
            DropIndex("dbo.ROOM", new[] { "RoomCategoryId" });
            DropIndex("dbo.ROOM", new[] { "CityId" });
            DropIndex("dbo.ROOM", new[] { "DistrictId" });
            DropIndex("dbo.ROOM", new[] { "WardId" });
            DropIndex("dbo.DISTRICT", new[] { "CityId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FAQ");
            DropTable("dbo.WARD");
            DropTable("dbo.RoomCategory");
            DropTable("dbo.PICTURE");
            DropTable("dbo.ROOM");
            DropTable("dbo.DISTRICT");
            DropTable("dbo.CITY");
        }
    }
}
