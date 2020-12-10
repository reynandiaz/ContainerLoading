using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ContainerLoading.DataProcess;
using System.Net;


namespace ContainerLoading
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Check client app version.
                this.checkVersion();
                


                // Check client local database version.
                Initialization.Initialize();
            }
            catch (Exception exc) // catch (System.Net.WebException exc)
            {
                MessageBox.Show(exc.ToString());
                this.Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void checkVersion()
        {
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            this.lblVer.Text = "ver. " + assemblyName.Version.ToString(3);
            Version requiredVersion;

            using (var service = new ContainerService.Service1())
            {
                string ver = service.GetRequiredClientVersion();

                service.Url = Utilities.MyUtilities.ServicePath;
                if (String.IsNullOrEmpty(ver))
                    throw new SystemException("Failed to get the required client version.");
                else
                    requiredVersion = new Version(ver);
            }
            if (assemblyName.Version.CompareTo(requiredVersion) < 0)
            {
                MessageBox.Show(String.Format(
                    "Update your client app.\r\nYour version: {0}\r\nRequired version: {1}\r\n\r\n" +
                    "After update, start the app manually.",
                    assemblyName.Version.ToString(3), requiredVersion));
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(Utilities.MyUtilities.ServerCabPath, null);
                this.Close();
            }
        }

        private void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtEmployeeID.Text.Length == 10)
                {
                    try
                    {
                        LoginProcess.CheckLogin(txtEmployeeID.Text);
                        if (GlobalVariables.Designation == 0 || chkDesig.Checked)
                        {
                            Form desig = new Designation();
                            desig.ShowDialog();
                        }
                        if (GlobalVariables.Designation != 0)
                        {
                            Form checkers = new Checkers();
                            checkers.ShowDialog();

                            Form scanbarcode = new ScanBarcode();
                            scanbarcode.ShowDialog();
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                }
                txtEmployeeID.Text = "";
                txtEmployeeID.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LoginProcess.CheckLogin(txtEmployeeID.Text);
                if (GlobalVariables.Designation == 0 || chkDesig.Checked)
                {
                    Form desig = new Designation();
                    desig.ShowDialog();
                }
                if (GlobalVariables.Designation != 0)
                {
                    Form checkers = new Checkers();
                    checkers.ShowDialog();

                    Form scanbarcode = new ScanBarcode();
                    scanbarcode.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            txtEmployeeID.Text = "";
            txtEmployeeID.Focus();
        }

    }
}