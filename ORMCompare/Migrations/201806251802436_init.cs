namespace ORMCompare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        EmployeeTitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeTitles", t => t.EmployeeTitleId, cascadeDelete: true)
                .Index(t => t.EmployeeTitleId);
            
            CreateTable(
                "dbo.DepartmentManagers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.EmployeeTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            this.Sql(Properties.Resources.SP_DeleteAllEmployees);
            this.Sql(Properties.Resources.SP_DeleteAllDepartmentEmployees);
            this.Sql(Properties.Resources.SP_DeleteAllDepartmentManagers);
            this.Sql(Properties.Resources.SP_DeleteAllDepartments);
            this.Sql(Properties.Resources.SP_DeleteAllEmployees);

            this.Sql(Properties.Resources.SP_InsertDepartmentEmployees);
            this.Sql(Properties.Resources.SP_InsertDepartmentManagers);
            this.Sql(Properties.Resources.SP_InsertDepartments);
            this.Sql(Properties.Resources.SP_InsertEmployees);
            this.Sql(Properties.Resources.SP_InsertEmployeeTitles);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeTitleId", "dbo.EmployeeTitles");
            DropForeignKey("dbo.DepartmentManagers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DepartmentManagers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DepartmentEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DepartmentEmployees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.DepartmentManagers", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentManagers", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "EmployeeTitleId" });
            DropIndex("dbo.DepartmentEmployees", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentEmployees", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeTitles");
            DropTable("dbo.DepartmentManagers");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartmentEmployees");
        }
    }
}
