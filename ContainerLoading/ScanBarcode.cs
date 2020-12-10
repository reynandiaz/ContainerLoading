using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ContainerLoading.DataProcess;

namespace ContainerLoading
{
    public partial class ScanBarcode : Form
    {

        private ScannedBarcodeFormRow bindingEntity = new ScannedBarcodeFormRow();


        public ScanBarcode()
        {
            InitializeComponent();
            try
            {
                addGridStyle(dataGrid1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem!!" + ex.ToString());
            }
        }

        private void addGridStyle(DataGrid dg)
        {

            DataGridTableStyle dtStyle = new DataGridTableStyle();
            dtStyle.MappingName = "ScannedBarcode";

            DataTable dt = this.bindingEntity.ScannedBarcode;
            for (int i = 0; i < this.bindingEntity.ScannedBarcode.Columns.Count; i++)
            {

                DataProcess.ColumnStyle myStyle = new DataProcess.ColumnStyle(i);

                myStyle.MappingName = this.bindingEntity.ScannedBarcode.Columns[i].ColumnName;

                if (this.bindingEntity.ScannedBarcode.Columns[i].ColumnName == "Seq")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Seq";
                    myStyle.MappingName = "Seq";
                    myStyle.Width = 30;
                }
                else if (this.bindingEntity.ScannedBarcode.Columns[i].ColumnName == "Container")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Container";
                    myStyle.MappingName = "Container";
                    myStyle.Width = 90;
                }
                else if (this.bindingEntity.ScannedBarcode.Columns[i].ColumnName == "Pallet")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Pallet";
                    myStyle.MappingName = "Pallet";
                    myStyle.Width = 90;
                }
                else if (this.bindingEntity.ScannedBarcode.Columns[i].ColumnName == "Status")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Status";
                    myStyle.MappingName = "Status";
                    myStyle.Width = 0;
                }
                dtStyle.GridColumnStyles.Add(myStyle);

            }
            dg.TableStyles.Add(dtStyle);
        }

        public void myStyle_isEven(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                if ((int)dataGrid1[e.Row, 3] == 0)
                {
                    e.MeetsCriteria = 0;
                }
                else if ((int)dataGrid1[e.Row, 3] == 1)
                {
                    e.MeetsCriteria = 1;

                }
                else if ((int)dataGrid1[e.Row, 3] == 2)
                {
                    e.MeetsCriteria = 2;
                }
                else
                {
                    e.MeetsCriteria = 3;
                }

            }
            catch (Exception ex)
            {
                e.MeetsCriteria = 4;
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScanBarcode_Load(object sender, EventArgs e)
        {
            lblEmployeeID.Text = GlobalVariables.EmployeeID + " - " + (GlobalVariables.Designation == 1 ? "Panel" : "I-Cube");
            chkDirect.Checked = true;
            txtBarcode.Focus();
            dataGrid1.DataSource = this.bindingEntity.ScannedBarcode;
            RefreshTable();
        }

        private void RefreshTable()
        {
            try
            {
                List<ScannedBarcodeTableRow> rows = BarcodesTable.RetrieveBarcodes();
                this.bindingEntity.ScannedBarcode.Clear();
                this.bindingEntity.SetBarcodes(rows);
                dataGrid1.DataSource = this.bindingEntity.ScannedBarcode;
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                //container barcode = 10
                //pallet barcode =13
                if (txtBarcode.Text.Length == 10)
                {
                    lblContainer.Text = txtBarcode.Text;
                }
                else if (txtBarcode.Text.Length == 13)
                {
                    BarcodesProcess.InsertToBarcodesTable(lblContainer.Text, txtBarcode.Text);
                    if (chkDirect.Checked == true)
                    {
                        List<ScannedBarcodeTableRow> row = BarcodeTransmit.RetrieveSingBarcodeForTransmit(txtBarcode.Text);
                        this.bindingEntity.ScannedBarcode.Clear();
                        this.bindingEntity.SetBarcodes(row);

                        TransmitData(row,"singledata");
                    }
                    RefreshTable();
                }
                txtBarcode.Text = "";
                txtBarcode.Focus();
            }
        }

        private void TransmitData(List<ScannedBarcodeTableRow> row,string TransmitType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                

                List<ContainerService.UploadScannedBarcodeTableRow> scannedBarcodes;
                scannedBarcodes = BarcodeTransmit.RetrieveForService(row);

                List<ContainerService.UploadScannedBarcodeTableRow> batchBarcodes = new List<ContainerService.UploadScannedBarcodeTableRow>();

                ContainerService.UploadScannedResult serviceResult;

                using (var service = new ContainerService.Service1())
                {
                    if (TransmitType == "singledata")
                    {

                        service.Url = Utilities.MyUtilities.ServicePath;

                        serviceResult = service.UploadScannedBarcode(scannedBarcodes.ToArray());
                        //STATUS
                        //1=success
                        //2=already scanned
                        //3=failed
                        BarcodeTransmit.UpdateLocalWithTransmittedData(serviceResult.UploadedData);

                        if (serviceResult.ServerStatus > 0)
                        {
                            MessageBox.Show(String.Format("Status: {0}\r\n{1}", serviceResult.ServerStatus, serviceResult.ServerMessage));
                        }
                    }
                    else if(TransmitType=="alldata")
                    {
                        int maxRows = Convert.ToInt32(Properties.Resources.MaxRows_InOneBatch);
                        service.Url = Utilities.MyUtilities.ServicePath;
                        int j = 1;
                        int maxBatches = (int)Math.Ceiling((double)scannedBarcodes.Count / maxRows);
                        while (scannedBarcodes.Count > 0 && j <= maxBatches)
                        {
                            int i = 0;
                            batchBarcodes.Clear();
                            while (scannedBarcodes.Count > 0 && i < maxRows)
                            {
                                var scannedrow = scannedBarcodes.First();
                                batchBarcodes.Add(scannedrow);

                                scannedBarcodes.Remove(scannedrow);
                                i++;
                            }

                            serviceResult = service.UploadScannedBarcode(batchBarcodes.ToArray());

                            BarcodeTransmit.UpdateLocalWithTransmittedData(serviceResult.UploadedData);

                            if (serviceResult.ServerStatus > 0)
                            {
                                MessageBox.Show(String.Format("Status: {0}\r\n{1}", serviceResult.ServerStatus, serviceResult.ServerMessage));
                            }
                            j++;
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ScanBarcode_Closed(object sender, EventArgs e)
        {
            BarcodesProcess.DeleteTransmittedData();
        }

        private void btnTransmit_Click(object sender, EventArgs e)
        {
            List<ScannedBarcodeTableRow> row = BarcodeTransmit.RetrieveAllBarcodeForTransmit();
            this.bindingEntity.ScannedBarcode.Clear();
            this.bindingEntity.SetBarcodes(row);

            TransmitData(row, "alldata");
            RefreshTable();
        }

        private void btnLegends_Click(object sender, EventArgs e)
        {
            Form legends = new Legends();
            legends.ShowDialog();
        }
    }



    public class ScannedBarcodeFormRow
    {
        public DataTable ScannedBarcode { get; set; }

        public ScannedBarcodeFormRow()
        {
            this.ScannedBarcode = new DataTable("ScannedBarcode");

            this.ScannedBarcode.Columns.Add("Seq", typeof(string));
            this.ScannedBarcode.Columns.Add("Container", typeof(string));
            this.ScannedBarcode.Columns.Add("Pallet", typeof(string));
            this.ScannedBarcode.Columns.Add("Status", typeof(int));

        }

        public void SetBarcodes(List<ScannedBarcodeTableRow> barcodes)
        {
            this.ScannedBarcode.Clear();
            foreach (var barcode in barcodes)
            {
                this.ScannedBarcode.Rows.Add(
                    barcode.Seq,
                    barcode.ContainerBarcode,
                    barcode.PalletBarcode,
                    barcode.Status
                );
            }
        }
    }
}