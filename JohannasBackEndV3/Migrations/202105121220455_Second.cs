namespace JohannasBackEndV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxSpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Budget_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Budget_Id)
                .Index(t => t.Category_Id);
            
            AddColumn("dbo.Purchases", "BudgetCategory_Id", c => c.Int());
            CreateIndex("dbo.Purchases", "BudgetCategory_Id");
            AddForeignKey("dbo.Purchases", "BudgetCategory_Id", "dbo.BudgetCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "BudgetCategory_Id", "dbo.BudgetCategories");
            DropForeignKey("dbo.BudgetCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.BudgetCategories", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.BudgetCategories", new[] { "Category_Id" });
            DropIndex("dbo.BudgetCategories", new[] { "Budget_Id" });
            DropIndex("dbo.Purchases", new[] { "BudgetCategory_Id" });
            DropColumn("dbo.Purchases", "BudgetCategory_Id");
            DropTable("dbo.BudgetCategories");
        }
    }
}
