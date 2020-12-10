using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;


namespace ContainerLoading.DataProcess
{
    public class BarcodesProcess
    {
        public static void InsertToBarcodesTable(string strContainer, string strPallet)
        {
            var connection = new SqlCeConnection(Properties.Resources.SDFConnection);

            string CheckPallet = "Select count(ContainerBarcode) as cnt from ContainerDetails where " +
                "PalletBarcode= '"+ strPallet +"' ";

            string ContainerSeq = strContainer.Substring(strContainer.Length -2, 1).ToString();

            string InsertQuery = "Insert into ContainerDetails values (" +
                "'" + ContainerSeq + "',"+
                "'"+ strContainer +"'," +
                "'" + strPallet + "'," +
                "0)";

            var cmdCheck = new SqlCeCommand(CheckPallet, connection);
            var cmdInsert = new SqlCeCommand(InsertQuery, connection);

            try
            {
                connection.Open();
                var cnt = cmdCheck.ExecuteScalar();

                if (Convert.ToInt32(cnt) == 0)
                {
                    cmdInsert.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }
        public static void DeleteTransmittedData()
        {
            var connection = new SqlCeConnection(Properties.Resources.SDFConnection);

            string query = "Delete from ContainerDetails where Status <> 0";

            var command = new SqlCeCommand(query, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
