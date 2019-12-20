namespace CompileError.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchasedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "PurchasedProduct_Id", "dbo.PurchasedProducts");
            DropForeignKey("dbo.PurchasedProducts", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.SalesDetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "PurchasedProduct_Id" });
            DropIndex("dbo.PurchasedProducts", new[] { "PurchaseId" });
            DropIndex("dbo.PurchasedProducts", new[] { "ProductId" });
            DropIndex("dbo.Purchases", new[] { "Supplier_Id" });
            DropIndex("dbo.SalesDetails", new[] { "SaleId" });
            DropColumn("dbo.Purchases", "SupplierId");
            RenameColumn(table: "dbo.Purchases", name: "Supplier_Id", newName: "SupplierId");
            CreateTable(
                "dbo.PurchaseProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductCode = c.String(),
                        MfgDate = c.DateTime(nullable: false, storeType: "date"),
                        ExpDate = c.DateTime(nullable: false, storeType: "date"),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        MRPPrice = c.Double(nullable: false),
                        Remarks = c.String(),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.SaleProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        MRP = c.Double(nullable: false),
                        TotalMRP = c.Double(nullable: false),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.Sale_Id);
            
            AddColumn("dbo.Customers", "LoyaltyPoint", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "Code", c => c.String());
            AlterColumn("dbo.Purchases", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "Date", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Purchases", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false, storeType: "date"));
            CreateIndex("dbo.Purchases", "SupplierId");
            CreateIndex("dbo.Sales", "CustomerId");
            AddForeignKey("dbo.Sales", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "PurchasedProduct_Id");
            DropColumn("dbo.Customers", "LoyalityPoint");
            DropTable("dbo.PurchasedProducts");
            DropTable("dbo.SalesDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Quantity = c.Int(nullable: false),
                        MRP = c.Double(nullable: false),
                        TotalMRP = c.Double(nullable: false),
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchasedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ManufactureDate = c.String(),
                        ExpireDate = c.String(),
                        Quantity = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Mrp = c.Double(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "LoyalityPoint", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "PurchasedProduct_Id", c => c.Int());
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SaleProducts", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseProducts", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.SaleProducts", new[] { "Sale_Id" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseProducts", new[] { "Purchase_Id" });
            AlterColumn("dbo.Sales", "Date", c => c.String());
            AlterColumn("dbo.Purchases", "SupplierId", c => c.Int());
            AlterColumn("dbo.Purchases", "Date", c => c.String());
            AlterColumn("dbo.Purchases", "SupplierId", c => c.String());
            DropColumn("dbo.Purchases", "Code");
            DropColumn("dbo.Customers", "LoyaltyPoint");
            DropTable("dbo.SaleProducts");
            DropTable("dbo.PurchaseProducts");
            RenameColumn(table: "dbo.Purchases", name: "SupplierId", newName: "Supplier_Id");
            AddColumn("dbo.Purchases", "SupplierId", c => c.String());
            CreateIndex("dbo.SalesDetails", "SaleId");
            CreateIndex("dbo.Purchases", "Supplier_Id");
            CreateIndex("dbo.PurchasedProducts", "ProductId");
            CreateIndex("dbo.PurchasedProducts", "PurchaseId");
            CreateIndex("dbo.Products", "PurchasedProduct_Id");
            AddForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.SalesDetails", "SaleId", "dbo.Sales", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchasedProducts", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "PurchasedProduct_Id", "dbo.PurchasedProducts", "Id");
            AddForeignKey("dbo.PurchasedProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
