namespace webTimPhong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
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
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CITY", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.MAP",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 300),
                        Latitude = c.Decimal(precision: 18, scale: 2),
                        Longtitude = c.Decimal(precision: 18, scale: 2),
                        WardId = c.Int(),
                        DistrictId = c.Int(),
                        CityId = c.Int(),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CITY", t => t.CityId)
                .ForeignKey("dbo.DISTRICT", t => t.DistrictId)
                .ForeignKey("dbo.ROOM", t => t.RoomId)
                .ForeignKey("dbo.WARD", t => t.WardId)
                .Index(t => t.WardId)
                .Index(t => t.DistrictId)
                .Index(t => t.CityId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.ROOM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(),
                        ExprireTime = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        ContactNumber = c.String(),
                        IsConfirm = c.Boolean(nullable: false),
                        BeginTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ConfirmStatus = c.Int(nullable: false),
                        IsAvaiable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PICTURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureName = c.String(maxLength: 100),
                        RoomId = c.Int(),
                        URL = c.String(nullable: false, maxLength: 300),
                        IsActive = c.Boolean(nullable: false),
                        NativeHeight = c.Int(nullable: false),
                        NativeWidth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROOM", t => t.RoomId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.ROOMDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(),
                        Title = c.String(maxLength: 300),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Acreage = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Description = c.String(storeType: "ntext"),
                        HasPrivateWC = c.Boolean(nullable: false),
                        HasMezzanine = c.Boolean(nullable: false),
                        AllowCook = c.Boolean(nullable: false),
                        FreeTime = c.Boolean(nullable: false),
                        WaterPrice = c.Int(),
                        ElectronicPrice = c.Int(),
                        WifiPrice = c.Decimal(precision: 18, scale: 2),
                        SecurityCamera = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROOM", t => t.RoomId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.WARD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WardName = c.String(nullable: false, maxLength: 100),
                        DistrictId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DISTRICT", t => t.DistrictId)
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
                "dbo.SystemSetting",
                c => new
                    {
                        settingkey = c.String(nullable: false, maxLength: 100),
                        settingvalue = c.String(maxLength: 1000),
                        settingdescription = c.String(),
                    })
                .PrimaryKey(t => t.settingkey);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
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
            DropForeignKey("dbo.MAP", "WardId", "dbo.WARD");
            DropForeignKey("dbo.WARD", "DistrictId", "dbo.DISTRICT");
            DropForeignKey("dbo.ROOMDetail", "RoomId", "dbo.ROOM");
            DropForeignKey("dbo.PICTURE", "RoomId", "dbo.ROOM");
            DropForeignKey("dbo.MAP", "RoomId", "dbo.ROOM");
            DropForeignKey("dbo.MAP", "DistrictId", "dbo.DISTRICT");
            DropForeignKey("dbo.MAP", "CityId", "dbo.CITY");
            DropForeignKey("dbo.DISTRICT", "CityId", "dbo.CITY");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.WARD", new[] { "DistrictId" });
            DropIndex("dbo.ROOMDetail", new[] { "RoomId" });
            DropIndex("dbo.PICTURE", new[] { "RoomId" });
            DropIndex("dbo.MAP", new[] { "RoomId" });
            DropIndex("dbo.MAP", new[] { "CityId" });
            DropIndex("dbo.MAP", new[] { "DistrictId" });
            DropIndex("dbo.MAP", new[] { "WardId" });
            DropIndex("dbo.DISTRICT", new[] { "CityId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SystemSetting");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FAQ");
            DropTable("dbo.WARD");
            DropTable("dbo.ROOMDetail");
            DropTable("dbo.PICTURE");
            DropTable("dbo.ROOM");
            DropTable("dbo.MAP");
            DropTable("dbo.DISTRICT");
            DropTable("dbo.CITY");
        }
    }
}
