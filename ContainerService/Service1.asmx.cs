using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using ContainerService.DataService;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace ContainerService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        

        [WebMethod]
        public string HelloWorld()
        {
            
            return "Hello World";
        }

        [WebMethod]
        public string GetRequiredClientVersion()
        {
            return Properties.Settings.Default.ClientVersion;
        }

        [WebMethod]
        public UploadScannedResult UploadScannedBarcode(List<UploadScannedBarcodeTableRow> scannedBarcodes)
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                var result = new UploadScannedResult();
                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();

                    foreach (UploadScannedBarcodeTableRow row in scannedBarcodes)
                    {
                        result.ServerStatus = 1;

                        TransmitScannedBarcodes.TransmitScannedData(connection, row, transaction);
                        result.UploadedData.Add(row);
                    }

                    transaction.Commit();
                    result.ServerStatus = 0;

                    return result;
                }
                catch (Exception exc)
                {
                    result.ServerMessage = exc.Message;
                    result.UploadedData.Clear();
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


    }
    public class UploadScannedResult
    {
        public UploadScannedResult()
        {
            this.UploadedData = new List<UploadScannedBarcodeTableRow>();
        }
        public int ServerStatus { get; set; } // [0]: Success, [1 or later]: Failure
        public string ServerMessage { get; set; }
        public List<UploadScannedBarcodeTableRow> UploadedData { get; set; }
    }
}
