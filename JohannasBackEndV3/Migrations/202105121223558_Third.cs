namespace JohannasBackEndV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.Purchases", new[] { "Budget_Id" });
            DropColumn("dbo.Purchases", "Budget_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Budget_Id", c => c.Int());
            CreateIndex("dbo.Purchases", "Budget_Id");
            AddForeignKey("dbo.Purchases", "Budget_Id", "dbo.Budgets", "Id");
        }
    }
}
