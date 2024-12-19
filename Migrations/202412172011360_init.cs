﻿namespace Yummy_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Item_1 = c.String(),
                        Item_2 = c.String(),
                        Item_3 = c.String(),
                        Description = c.String(),
                        VideoUrl = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        BookingDate = c.DateTime(nullable: false),
                        PersoneCount = c.Int(nullable: false),
                        MessageContent = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ImageUrl = c.String(),
                        Ingredients = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Chefs",
                c => new
                    {
                        ChefId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Description = c.String(),
                        Title = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ChefId);
            
            CreateTable(
                "dbo.ChefSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        ChefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chefs", t => t.ChefId, cascadeDelete: true)
                .Index(t => t.ChefId);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        MapUrl = c.String(),
                        OpenHours = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.FeatureId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        MessageBody = c.String(),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.PhotoGalleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestimonialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChefSocials", "ChefId", "dbo.Chefs");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ChefSocials", new[] { "ChefId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.Services");
            DropTable("dbo.PhotoGalleries");
            DropTable("dbo.Messages");
            DropTable("dbo.Features");
            DropTable("dbo.Events");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.ChefSocials");
            DropTable("dbo.Chefs");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Bookings");
            DropTable("dbo.Abouts");
        }
    }
}
