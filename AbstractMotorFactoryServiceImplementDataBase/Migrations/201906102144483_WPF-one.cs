namespace AbstractMotorFactoryServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WPFone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EngineId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Int(nullable: false),
                        TimeCreate = c.DateTime(nullable: false),
                        TimeImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Engines", t => t.EngineId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EngineId);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EngineName = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DetailName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EngineDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EngineId = c.Int(nullable: false),
                        DetailId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.DetailId, cascadeDelete: true)
                .ForeignKey("dbo.Engines", t => t.EngineId, cascadeDelete: true)
                .Index(t => t.EngineId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.StoreDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        DetailId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Engine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Engines", t => t.Engine_Id)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Details", t => t.DetailId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.DetailId)
                .Index(t => t.Engine_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreDetails", "DetailId", "dbo.Details");
            DropForeignKey("dbo.StoreDetails", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.StoreDetails", "Engine_Id", "dbo.Engines");
            DropForeignKey("dbo.EngineDetails", "EngineId", "dbo.Engines");
            DropForeignKey("dbo.EngineDetails", "DetailId", "dbo.Details");
            DropForeignKey("dbo.Productions", "EngineId", "dbo.Engines");
            DropForeignKey("dbo.Productions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.StoreDetails", new[] { "Engine_Id" });
            DropIndex("dbo.StoreDetails", new[] { "DetailId" });
            DropIndex("dbo.StoreDetails", new[] { "StoreId" });
            DropIndex("dbo.EngineDetails", new[] { "DetailId" });
            DropIndex("dbo.EngineDetails", new[] { "EngineId" });
            DropIndex("dbo.Productions", new[] { "EngineId" });
            DropIndex("dbo.Productions", new[] { "CustomerId" });
            DropTable("dbo.Stores");
            DropTable("dbo.StoreDetails");
            DropTable("dbo.EngineDetails");
            DropTable("dbo.Details");
            DropTable("dbo.Engines");
            DropTable("dbo.Productions");
            DropTable("dbo.Customers");
        }
    }
}
