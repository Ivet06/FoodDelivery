namespace FoodDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigranion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Info = c.String(),
                        Price = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Type = c.String(),
                        DishTypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DishTypes", t => t.DishTypesId, cascadeDelete: true)
                .Index(t => t.DishTypesId);
            
            CreateTable(
                "dbo.DishTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "DishTypesId", "dbo.DishTypes");
            DropIndex("dbo.Dishes", new[] { "DishTypesId" });
            DropTable("dbo.DishTypes");
            DropTable("dbo.Dishes");
        }
    }
}
