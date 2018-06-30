namespace ORMCompare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCol : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeTitleId", "dbo.EmployeeTitles");
            DropIndex("dbo.Employees", new[] { "EmployeeTitleId" });
            AlterColumn("dbo.Employees", "EmployeeTitleId", c => c.Int());
            CreateIndex("dbo.Employees", "EmployeeTitleId");
            AddForeignKey("dbo.Employees", "EmployeeTitleId", "dbo.EmployeeTitles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeTitleId", "dbo.EmployeeTitles");
            DropIndex("dbo.Employees", new[] { "EmployeeTitleId" });
            AlterColumn("dbo.Employees", "EmployeeTitleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "EmployeeTitleId");
            AddForeignKey("dbo.Employees", "EmployeeTitleId", "dbo.EmployeeTitles", "Id", cascadeDelete: true);
        }
    }
}
