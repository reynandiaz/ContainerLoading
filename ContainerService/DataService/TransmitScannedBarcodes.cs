using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace ContainerService.DataService
{
    public class TransmitScannedBarcodes
    {
        public static void TransmitScannedData(SqlConnection connection, UploadScannedBarcodeTableRow row, SqlTransaction transaction)
        {
            try
            {
                string strCheck = "Select count(Pallet_CD) from ContainerBarcodePallet where Pallet_CD='" + row.PalletBarcode.ToString() + "'";

                string strInsert = "INSERT INTO dbo.ContainerBarcodePallet " +
                                "	( " +
                                "	Container_CD, " +
                                "	Pallet_CD, " +
                                "	ForkliftOperator, " +
                                "	Bracer, " +
                                "	MaterialChecker, " +
                                "	LoadingChecker, " +
                                "	CasualBracer, " +
                                "	DataChecker, " +
                                "	ScannerDept, " +
                                "	CreatedDate, " +
                                "	DeletedDate, " +
                                "	UpdatedDate, " +
                                "	UpdateBy " +
                                "	) " +
                                "VALUES  " +
                                "	( " +
                                "	'"+row.ContainerBarcode +"', " +
                                "	'"+ row.PalletBarcode +"', " +
                                "	'"+ row.Forklift +"', " +
                                "	'" + row.Bracer + "', " +
                                "	'" + row.MatChecker + "', " +
                                "	'" + row.LoadChecker + "', " +
                                "	'" + row.CasualChecker + "', " +
                                "	'" + row.DataChecker + "', " +
                                "	" + row.Designation + ", " +
                                "	getdate(), " +
                                "	null, " +
                                "	getdate(), " +
                                "	'"+ row.UpdatedBy +"' " +
                                "	) ";

                var cmdCheck = new SqlCommand(strCheck, connection, transaction);
                var cmdInsert = new SqlCommand(strInsert, connection, transaction);

                var cnt = cmdCheck.ExecuteScalar();
                if (Convert.ToInt32(cnt) == 0)
                {
                    cmdInsert.ExecuteNonQuery();
                    row.Status = 1;
                }
                else
                {
                    row.Status = 2;
                }

            }
            catch(Exception exc)
            {
                row.Status = 3;
                row.ErrMsg = exc.ToString();
            }

        }
    }

    public class UploadScannedBarcodeTableRow
    {
        public UploadScannedBarcodeTableRow()
        {
        }
        public UploadScannedBarcodeTableRow(DataRow row)
        {
            this.ContainerBarcode = row["ContainerBarcode"].ToString();
            this.PalletBarcode = row["PalletBarcode"].ToString();
            this.Status = Convert.ToInt32(row["Status"]);
            this.UpdatedBy = row["UpdatedBy"].ToString();

            this.Designation = Convert.ToInt32(row["Designation"]);

            this.Forklift = row["Forklift"].ToString();
            this.Bracer = row["Bracer"].ToString();
            this.MatChecker = row["MatChecker"].ToString();
            this.LoadChecker = row["LoadChecker"].ToString();
            this.CasualChecker = row["CasualChecker"].ToString() ;
            this.DataChecker = row["DataChecker"].ToString();
            
        }
        //creates the field
        public string ContainerBarcode { get; set; }
        public string PalletBarcode { get; set; }
        public int Status { get; set; }
        public string ErrMsg { get; set; }
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
