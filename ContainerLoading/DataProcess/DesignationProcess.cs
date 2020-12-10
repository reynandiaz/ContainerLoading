using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;



namespace ContainerLoading.DataProcess
{
    public class DesignationProcess
    {
        public static void UpdateDesignation(int intDesig)
        {
            var connection = new SqlCeConnection(Properties.Resources.SDFConnection);

            string query = "Update LoginTable set Designation = @Designation where EmployeeID = @EmployeeID";

            var command = new SqlCeCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.Add("@Designation", SqlDbType.Int).Value = intDesig;
                command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = GlobalVariables.EmployeeID;
                command.ExecuteNonQuery();

                GlobalVariables.Designation = intDesig;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
