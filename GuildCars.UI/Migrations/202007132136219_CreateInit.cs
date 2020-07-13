namespace GuildCars.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyle",
                c => new
                    {
                        BodyStyleID = c.Int(nullable: false, identity: true),
                        BodyStyleName = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.BodyStyleID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        OnSale = c.Boolean(nullable: false),
                        IsInStock = c.Boolean(nullable: false),
                        MakeID = c.Int(),
                        ModelID = c.Int(),
                        ConditionID = c.Int(),
                        Year = c.Int(nullable: false),
                        BodyStyleID = c.Int(),
                        TransmissionID = c.Int(),
                        ExteriorColorID = c.Int(),
                        InteriorColorID = c.Int(),
                        Mileage = c.String(),
                        VIN = c.String(),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        DateAdded = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.BodyStyle", t => t.BodyStyleID)
                .ForeignKey("dbo.Condition", t => t.ConditionID)
                .ForeignKey("dbo.ExteriorColor", t => t.ExteriorColorID)
                .ForeignKey("dbo.InteriorColor", t => t.InteriorColorID)
                .ForeignKey("dbo.Make", t => t.MakeID)
                .ForeignKey("dbo.Model", t => t.ModelID)
                .ForeignKey("dbo.Transmission", t => t.TransmissionID)
                .Index(t => t.MakeID)
                .Index(t => t.ModelID)
                .Index(t => t.ConditionID)
                .Index(t => t.BodyStyleID)
                .Index(t => t.TransmissionID)
                .Index(t => t.ExteriorColorID)
                .Index(t => t.InteriorColorID);
            
            CreateTable(
                "dbo.Condition",
                c => new
                    {
                        ConditionID = c.Int(nullable: false, identity: true),
                        ConditionType = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.ConditionID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.ExteriorColor",
                c => new
                    {
                        ExteriorColorID = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.ExteriorColorID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.InteriorColor",
                c => new
                    {
                        InteriorColorID = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.InteriorColorID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.Make",
                c => new
                    {
                        MakeID = c.Int(nullable: false, identity: true),
                        MakeName = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.MakeID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        MakeID = c.Int(),
                        ModelName = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.ModelID)
                .ForeignKey("dbo.Make", t => t.MakeID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.MakeID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.Transmission",
                c => new
                    {
                        TransmissionID = c.Int(nullable: false, identity: true),
                        TransmissionType = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.TransmissionID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsID);
            
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
                "dbo.Specials",
                c => new
                    {
                        SpecialsID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageFileName = c.String(),
                    })
                .PrimaryKey(t => t.SpecialsID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Role = c.String(),
                        Email = c.String(),
                        AddressStreet1 = c.String(),
                        AddressStreet2 = c.String(),
                        City = c.String(),
                        StateID = c.Int(),
                        ZipCode = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Car", t => t.CarID)
                .ForeignKey("dbo.PurchaseType", t => t.PurchaseTypeID)
                .ForeignKey("dbo.State", t => t.StateID)
                .Index(t => t.CarID)
                .Index(t => t.StateID)
                .Index(t => t.PurchaseTypeID);
            
            CreateTable(
                "dbo.PurchaseType",
                c => new
                    {
                        PurchaseTypeID = c.Int(nullable: false, identity: true),
                        PurchaseTypeName = c.String(),
                        Transaction_TransactionID = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseTypeID)
                .ForeignKey("dbo.Transaction", t => t.Transaction_TransactionID)
                .Index(t => t.Transaction_TransactionID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateAbbr = c.String(),
                        StateName = c.String(),
                        Transaction_TransactionID = c.Int(),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Transaction", t => t.Transaction_TransactionID)
                .Index(t => t.Transaction_TransactionID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RoleID = c.Int(nullable: false),
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
            DropForeignKey("dbo.State", "Transaction_TransactionID", "dbo.Transaction");
            DropForeignKey("dbo.Transaction", "StateID", "dbo.State");
            DropForeignKey("dbo.PurchaseType", "Transaction_TransactionID", "dbo.Transaction");
            DropForeignKey("dbo.Transaction", "PurchaseTypeID", "dbo.PurchaseType");
            DropForeignKey("dbo.Transaction", "CarID", "dbo.Car");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Transmission", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Car", "TransmissionID", "dbo.Transmission");
            DropForeignKey("dbo.Model", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Car", "ModelID", "dbo.Model");
            DropForeignKey("dbo.Model", "MakeID", "dbo.Make");
            DropForeignKey("dbo.Make", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Car", "MakeID", "dbo.Make");
            DropForeignKey("dbo.InteriorColor", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Car", "InteriorColorID", "dbo.InteriorColor");
            DropForeignKey("dbo.ExteriorColor", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Car", "ExteriorColorID", "dbo.ExteriorColor");
            DropForeignKey("dbo.Condition", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Car", "ConditionID", "dbo.Condition");
            DropForeignKey("dbo.BodyStyle", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Car", "BodyStyleID", "dbo.BodyStyle");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.State", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.PurchaseType", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.Transaction", new[] { "PurchaseTypeID" });
            DropIndex("dbo.Transaction", new[] { "StateID" });
            DropIndex("dbo.Transaction", new[] { "CarID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Transmission", new[] { "Car_CarID" });
            DropIndex("dbo.Model", new[] { "Car_CarID" });
            DropIndex("dbo.Model", new[] { "MakeID" });
            DropIndex("dbo.Make", new[] { "Car_CarID" });
            DropIndex("dbo.InteriorColor", new[] { "Car_CarID" });
            DropIndex("dbo.ExteriorColor", new[] { "Car_CarID" });
            DropIndex("dbo.Condition", new[] { "Car_CarID" });
            DropIndex("dbo.Car", new[] { "InteriorColorID" });
            DropIndex("dbo.Car", new[] { "ExteriorColorID" });
            DropIndex("dbo.Car", new[] { "TransmissionID" });
            DropIndex("dbo.Car", new[] { "BodyStyleID" });
            DropIndex("dbo.Car", new[] { "ConditionID" });
            DropIndex("dbo.Car", new[] { "ModelID" });
            DropIndex("dbo.Car", new[] { "MakeID" });
            DropIndex("dbo.BodyStyle", new[] { "Car_CarID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.State");
            DropTable("dbo.PurchaseType");
            DropTable("dbo.Transaction");
            DropTable("dbo.Specials");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Transmission");
            DropTable("dbo.Model");
            DropTable("dbo.Make");
            DropTable("dbo.InteriorColor");
            DropTable("dbo.ExteriorColor");
            DropTable("dbo.Condition");
            DropTable("dbo.Car");
            DropTable("dbo.BodyStyle");
        }
    }
}
