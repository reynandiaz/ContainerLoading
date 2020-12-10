using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;

namespace ContainerLoading.DataProcess
{
    public class Initialization
    {
        public static void Initialize()
        {
            if (!File.Exists(Properties.Resources.DatabaseFileName))
            {
            //    File.Delete(Properties.Resources.DatabaseFileName); // TODO 開発用
            //    CreateDatabase();

            //}
            //else
            //{
                CreateDatabase();
            }
        
        }
        private static void CreateDatabase()
        {
            var engine = new SqlCeEngine(Properties.Resources.SDFConnection);
            engine.CreateDatabase();

            using (var connection = new SqlCeConnection(Properties.Resources.SDFConnection))
            {
                try
                {
                    connection.Open();
                    CreateLoginTable(connection);
                    CreateContainerDetails(connection);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private static void CreateLoginTable(SqlCeConnection connection)
        {
            string query = "Create table LoginTable(" +
                "EmployeeID nvarchar(20) not null," +
                "Designation int," +
                "Primary key (EmployeeID)" +
                ")";
            var command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery();
        }
        private static void CreateContainerDetails(SqlCeConnection connection)
        {
            string query = "Create table ContainerDetails(" +
                 "Seq nvarchar(10) not null," +
                 "ContainerBarcode nvarchar(50) not null," +
                 "PalletBarcode nvarchar(50) not null," +
                 "Status int,"+
                 "Primary key (ContainerBarcode,PalletBarcode)" +
                 ")";
            var command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery(); 
        }
    }
}
