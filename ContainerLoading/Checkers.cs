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
    public partial class Checkers : Form
    {
        public Checkers()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtForklift_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtForklift.Text.Length == 10)
                {
                    txtForklift.Text = LoginProcess.EvaluateEmployeeID(txtForklift.Text);
                    txtBracer.Focus();
                }
                else
                {
                    txtForklift.Text = "";
                    txtForklift.Focus();
                }
            }
        }

        private void txtBracer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtBracer.Text.Length == 10)
                {
                    txtBracer.Text = LoginProcess.EvaluateEmployeeID(txtBracer.Text);
                    txtMatChecker.Focus();
                }
                else
                {
                    txtBracer.Text = "";
                    txtBracer.Focus();
                }
            }
        }

        private void txtMatChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtMatChecker.Text.Length == 10)
                {
                    txtMatChecker.Text = LoginProcess.EvaluateEmployeeID(txtMatChecker.Text);
                    txtLoadChecker.Focus();
                }
                else
                {
                    txtMatChecker.Text = "";
                    txtMatChecker.Focus();
                }
            }
        }

        private void txtLoadChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtLoadChecker.Text.Length == 10)
                {
                    txtLoadChecker.Text = LoginProcess.EvaluateEmployeeID(txtLoadChecker.Text);
                    txtCasualBracer.Focus();
                }
                else
                {
                    txtLoadChecker.Text = "";
                    txtLoadChecker.Focus();
                }
            }
        }

        private void txtCasualBracer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtCasualBracer.Text.Length == 10)
                {
                    txtCasualBracer.Text = LoginProcess.EvaluateEmployeeID(txtCasualBracer.Text);
                    txtDataChecker.Focus();
                }
                else
                {
                    txtCasualBracer.Text = "";
                    txtCasualBracer.Focus();
                }
            }
        }

        private void txtDataChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtDataChecker.Text.Length == 10)
                {
                    txtDataChecker.Text = LoginProcess.EvaluateEmployeeID(txtDataChecker.Text);
                    btnNext.Focus();
                }
                else
                {
                    txtDataChecker.Text = "";
                    txtDataChecker.Focus();
                }
            }
        }

        private void Checkers_Closing(object sender, CancelEventArgs e)
        {
            GlobalVariables.Forklift = txtForklift.Text;
            GlobalVariables.Bracer = txtBracer.Text;
            GlobalVariables.MatChecker = txtMatChecker.Text;
            GlobalVariables.LoadChecker = txtLoadChecker.Text;
            GlobalVariables.CasualChecker = txtCasualBracer.Text;
            GlobalVariables.DataChecker = txtDataChecker.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}