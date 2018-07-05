namespace ORMCompare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSalaryColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
