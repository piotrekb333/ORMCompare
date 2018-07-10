using ORMCompare.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare
{
    public class Helpers
    {
        public static string SPDeleteAllEmployeeTitle = "SP_DeleteAllEmployeeTitles";
        public static string SPDeleteAllDepartmentEmployees = "SP_DeleteAllDepartmentEmployees";
        public static string SPDeleteAllDepartmentManagers = "SP_DeleteAllDepartmentManagers";
        public static string SPDeleteAllDepartments = "SP_DeleteAllDepartments";
        public static string SPDeleteAllEmployees = "SP_DeleteAllEmployees";

        public static string SPDeleteEmployeeTitle = "SP_DeleteEmployeeTitles";
        public static string SPDeleteDepartmentEmployees = "SP_DeleteDepartmentEmployees";
        public static string SPDeleteDepartmentManagers = "SP_DeleteDepartmentManagers";
        public static string SPDeleteDepartments = "SP_DeleteDepartments";
        public static string SPDeleteEmployees = "SP_DeleteEmployees";


        public static string SPInsertEmployeeTitle = "SP_InsertEmployeeTitles";
        public static string SPInsertDepartmentEmployees = "SP_InsertDepartmentEmployees";
        public static string SPInsertDepartmentManagers = "SP_InsertDepartmentManagers";
        public static string SPInsertDepartments = "SP_InsertDepartments";
        public static string SPInsertEmployees = "SP_InsertEmployees";

        public static string GetConnectionString()
        {
            string source = ORMCompare.Properties.Settings.Default.IP;
            string user = "";
            string security = "True";
            if (!string.IsNullOrEmpty(ORMCompare.Properties.Settings.Default.Port))
            {
                source += "," + ORMCompare.Properties.Settings.Default.Port;
            }
            if (!string.IsNullOrEmpty(ORMCompare.Properties.Settings.Default.Login))
            {
                user = $"User Id={ORMCompare.Properties.Settings.Default.Login};Password={ORMCompare.Properties.Settings.Default.Password};";
                security = "False";
            }
            return $"Data Source={source};Initial Catalog={ORMCompare.Properties.Settings.Default.DatabaseName};Integrated Security={security};{user}TrustServerCertificate=False;MultipleActiveResultSets=True;";
            
        }

        public static DataSet ToDataSet<T>(IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }
    }
}
