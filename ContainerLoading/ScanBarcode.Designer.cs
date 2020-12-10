namespace ContainerLoading
{
    partial class ScanBarcode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLegends = new System.Windows.Forms.Button();
            this.btnTransmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblContainer = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.chkDirect = new System.Windows.Forms.CheckBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 218);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(240, 218);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.MappingName = "Barcodes2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnLegends);
            this.panel2.Controls.Add(this.btnTransmit);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 33);
            // 
            // btnLegends
            // 
            this.btnLegends.Location = new System.Drawing.Point(81, 4);
            this.btnLegends.Name = "btnLegends";
            this.btnLegends.Size = new System.Drawing.Size(75, 22);
            this.btnLegends.TabIndex = 12;
            this.btnLegends.Text = "Legends&8";
            this.btnLegends.Click += new System.EventHandler(this.btnLegends_Click);
            // 
            // btnTransmit
            // 
            this.btnTransmit.Location = new System.Drawing.Point(162, 4);
            this.btnTransmit.Name = "btnTransmit";
            this.btnTransmit.Size = new System.Drawing.Size(75, 22);
            this.btnTransmit.TabIndex = 11;
            this.btnTransmit.Text = "Transmit&9";
            this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(5, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(24, 22);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "<&0";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblContainer);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.chkDirect);
            this.panel1.Controls.Add(this.lblEmployeeID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 69);
            // 
            // lblContainer
            // 
            this.lblContainer.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblContainer.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblContainer.Location = new System.Drawing.Point(5, 47);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(149, 19);
            this.lblContainer.Text = "CONTAINER CD";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(5, 20);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(232, 21);
            this.txtBarcode.TabIndex = 7;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // chkDirect
            // 
            this.chkDirect.Location = new System.Drawing.Point(177, 43);
            this.chkDirect.Name = "chkDirect";
            this.chkDirect.Size = new System.Drawing.Size(60, 18);
            this.chkDirect.TabIndex = 3;
            this.chkDirect.Text = "Direct";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblEmployeeID.Location = new System.Drawing.Point(136, 2);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(99, 15);
            this.lblEmployeeID.Text = "label1";
            this.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ScanBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ScanBarcode";
            this.Text = "ScanBarcode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanBarcode_Load);
            this.Closed += new System.EventHandler(this.ScanBarcode_Closed);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.CheckBox chkDirect;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnLegends;
        private System.Windows.Forms.Button btnTransmit;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Label lblContainer;
    }
}