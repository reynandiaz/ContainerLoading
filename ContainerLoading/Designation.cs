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
    public partial class Designation : Form
    {
        public Designation()
        {
            InitializeComponent();
        }
        private void btnPanel_Click(object sender, EventArgs e)
        {
            DesignationProcess.UpdateDesignation(1);
            this.Close();
        }

        private void btnIcube_Click(object sender, EventArgs e)
        {
            DesignationProcess.UpdateDesignation(2);
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}