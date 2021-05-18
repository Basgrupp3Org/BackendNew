namespace JohannasBackEndV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        BalanceLabel = c.String(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        UserName = c.String(maxLength: 20),
                        BalanceUser = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BudgetName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Budget_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Budget_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Purchases", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Purchases", "Budget_Id", "dbo.Budgets");
            DropForeignKey("dbo.Categories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Budgets", "User_Id", "dbo.Users");
            DropIndex("dbo.Purchases", new[] { "User_Id" });
            DropIndex("dbo.Purchases", new[] { "Budget_Id" });
            DropIndex("dbo.Categories", new[] { "User_Id" });
            DropIndex("dbo.Budgets", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Balances", new[] { "User_Id" });
            DropTable("dbo.Purchases");
            DropTable("dbo.Categories");
            DropTable("dbo.Budgets");
            DropTable("dbo.Users");
            DropTable("dbo.Balances");
        }
    }
}
