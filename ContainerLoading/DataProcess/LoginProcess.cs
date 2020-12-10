using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace ContainerLoading.DataProcess
{
    public class LoginProcess
    {
        public static void CheckLogin(string prEmployeeID)
        {
            var connection = new SqlCeConnection(Properties.Resources.SDFConnection);

            string EmployeeID = prEmployeeID.Length == 10 ? EvaluateEmployeeID(prEmployeeID) : prEmployeeID;

            string checkid = "Select count(EmployeeID) from LoginTable where EmployeeID = @EmployeeID";

            string InsertID = "Insert into LoginTable values (@EmployeeID,0)";

            string selectid = "Select * from LoginTable where EmployeeID = @EmployeeID";

            var cmdCheck = new SqlCeCommand(checkid, connection);
            var cmdInsert = new SqlCeCommand(InsertID, connection);
            var cmdSelect = new SqlCeCommand(selectid, connection);

            try
            {
                connection.Open();
                cmdCheck.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = EmployeeID;
                var cnt = cmdCheck.ExecuteScalar();
                if (Convert.ToInt32(cnt) == 0)
                {
                    cmdInsert.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = EmployeeID;
                    cmdInsert.ExecuteNonQuery();

                    GlobalVariables.EmployeeID = EmployeeID;
                    GlobalVariables.Designation = 0;
                }
                else
                {
                    cmdSelect.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = EmployeeID;
                    var reader = cmdSelect.ExecuteReader();
                    while (reader.Read())
                    {
                        GlobalVariables.EmployeeID = reader["EmployeeID"].ToString();
                        GlobalVariables.Designation = Convert.ToInt32(reader["Designation"]);
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }


        public static string EvaluateEmployeeID(string EmployeeID)
        {
            string GetCompanyEmployeeID = "";
            string ValidatedID;
            char validateEmployeeID;

            EmployeeID = EmployeeID.Substring(0, EmployeeID.Length - 1);

            validateEmployeeID = Convert.ToChar(EmployeeID.Substring(2, 1));
            try
            {
                //HR
                if (validateEmployeeID == 'R' || validateEmployeeID == '3')
                {
                    GetCompanyEmployeeID = EmployeeID.Substring(4, 5);
                }
                //PV
                else if (validateEmployeeID == 'P' || validateEmployeeID == '0')
                {
                    GetCompanyEmployeeID = '0' + EmployeeID.Substring(4, 6);
                }
                //SCAD
                else if (validateEmployeeID == 'S' || validateEmployeeID == '1')
                {
                    GetCompanyEmployeeID = '1' + EmployeeID.Substring(4, 6);
                }
                //HTI
                else if (validateEmployeeID == 'H' || validateEmployeeID == '2')
                {
                    GetCompanyEmployeeID = '2' + EmployeeID.Substring(3, 6);
                }
                //WKN
                else if (validateEmployeeID == 'W' || validateEmployeeID == '4')
                {
                    GetCompanyEmployeeID = '4' + EmployeeID.Substring(4, 6);
                }
            }
            finally
            {
                ValidatedID = GetCompanyEmployeeID.ToString();
            }
            return ValidatedID;
        }

    }

}
