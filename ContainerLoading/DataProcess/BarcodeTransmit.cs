using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace ContainerLoading.DataProcess
{
    public class BarcodeTransmit
    {
        public static List<ScannedBarcodeTableRow> RetrieveSingBarcodeForTransmit(string strPallet)
        {
            string query = "Select * from ContainerDetails where PalletBarcode = '"+ strPallet +"'";

            var table = new DataTable();
            using (var adapter = new SqlCeDataAdapter(query.ToString(), Properties.Resources.SDFConnection))
            {
                adapter.Fill(table);
            }
            var result = new List<ScannedBarcodeTableRow>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new ScannedBarcodeTableRow(row));
            }
            return result;
        }

        public static List<ScannedBarcodeTableRow> RetrieveAllBarcodeForTransmit()
        {
            string query = "Select * from ContainerDetails where status =0";

            var table = new DataTable();
            using (var adapter = new SqlCeDataAdapter(query.ToString(), Properties.Resources.SDFConnection))
            {
                adapter.Fill(table);
            }
            var result = new List<ScannedBarcodeTableRow>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new ScannedBarcodeTableRow(row));
            }
            return result;
        }

        public static List<ContainerService.UploadScannedBarcodeTableRow> RetrieveForService(List<ScannedBarcodeTableRow> rows)
        {
            List<ScannedBarcodeTableRow> localRows;

            localRows = rows;

            var allServiceRow = new List<ContainerService.UploadScannedBarcodeTableRow>();

            foreach (ScannedBarcodeTableRow localRow in localRows)
            {
                var serviceRow = new ContainerService.UploadScannedBarcodeTableRow();

                serviceRow.ContainerBarcode = localRow.ContainerBarcode;
                serviceRow.PalletBarcode = localRow.PalletBarcode;
                serviceRow.Status = localRow.Status;
                serviceRow.UpdatedBy = localRow.UpdatedBy;

                serviceRow.Designation = localRow.Designation;

                serviceRow.Forklift = localRow.Forklift;
                serviceRow.Bracer = localRow.Bracer;
                serviceRow.MatChecker = localRow.MatChecker;
                serviceRow.LoadChecker = localRow.LoadChecker;
                serviceRow.CasualChecker = localRow.CasualChecker;
                serviceRow.DataChecker = localRow.DataChecker;

                allServiceRow.Add(serviceRow);
            }
            return allServiceRow;
        }

        public static void UpdateLocalWithTransmittedData(ContainerService.UploadScannedBarcodeTableRow[] servicerows)
        {
            var connection = new SqlCeConnection(Properties.Resources.SDFConnection);
            foreach (ContainerService.UploadScannedBarcodeTableRow row in servicerows)
            {
                string strUpdate = "Update ContainerDetails set Status=" + Convert.ToInt32(row.Status)
                    + " where PalletBarcode = '" +row.PalletBarcode + "'";

                var cmdUpdate = new SqlCeCommand(strUpdate, connection);
                try
                {
                    connection.Open();
                    cmdUpdate.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
