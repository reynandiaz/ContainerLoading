using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace ContainerLoading.DataProcess
{
    public class BarcodesTable
    {
        public static List<ScannedBarcodeTableRow> RetrieveBarcodes()
        {
            string query = "Select * from ContainerDetails";

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
    }

    public class ScannedBarcodeTableRow
    {
        public ScannedBarcodeTableRow()
        {
        }

        public ScannedBarcodeTableRow(DataRow row)
        {
            this.Seq = row["Seq"].ToString();
            this.ContainerBarcode = row["ContainerBarcode"].ToString();
            this.PalletBarcode = row["PalletBarcode"].ToString();
            this.Status = Convert.ToInt32(row["Status"]);
            this.UpdatedBy = GlobalVariables.EmployeeID;

            this.Designation = GlobalVariables.Designation;

            this.Forklift = GlobalVariables.Forklift;
            this.Bracer = GlobalVariables.Bracer;
            this.MatChecker = GlobalVariables.MatChecker;
            this.LoadChecker = GlobalVariables.LoadChecker;
            this.CasualChecker = GlobalVariables.CasualChecker;
            this.DataChecker = GlobalVariables.DataChecker;
        }
        //creates the field
        public string Seq { get; set; }
        public string ContainerBarcode { get; set; }
        public string PalletBarcode { get; set; }
        public int Status { get; set; }
        public string UpdatedBy { get; set; }

        public int Designation { get; set; }

        public string Forklift { get; set; }
        public string Bracer { get; set; }
        public string MatChecker { get; set; }
        public string LoadChecker { get; set; }
        public string CasualChecker { get; set; }
        public string DataChecker { get; set; }

    }
}
