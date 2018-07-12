namespace ORMCompare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSalaryColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            this.Sql(Properties.Resources.SP_DeleteAllEmployees);
            this.Sql(Properties.Resources.SP_DeleteAllDepartmentEmployees);
            this.Sql(Properties.Resources.SP_DeleteAllDepartmentManagers);
            this.Sql(Properties.Resources.SP_DeleteAllDepartments);
            this.Sql(Properties.Resources.SP_DeleteAllEmployeeTitles);

            this.Sql(Properties.Resources.SP_InsertDepartmentEmployees);
            this.Sql(Properties.Resources.SP_InsertDepartmentManagers);
            this.Sql(Properties.Resources.SP_InsertDepartments);
            this.Sql(Properties.Resources.SP_InsertEmployees);
            this.Sql(Properties.Resources.SP_InsertEmployeeTitles);

            this.Sql(Properties.Resources.SP_DeleteEmployees);
            this.Sql(Properties.Resources.SP_DeleteDepartmentEmployees);
            this.Sql(Properties.Resources.SP_DeleteDepartmentManagers);
            this.Sql(Properties.Resources.SP_DeleteDepartments);
            this.Sql(Properties.Resources.SP_DeleteEmployeeTitles);
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
