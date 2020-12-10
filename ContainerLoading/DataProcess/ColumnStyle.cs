using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace ContainerLoading.DataProcess
{
    public delegate void CheckCellEventHandler(object sender, DataGridEnableEventArgs e);

    public class DataGridEnableEventArgs : EventArgs
    {
        private int _column;
        private int _row;
        private int _meetsCriteria;

       public DataGridEnableEventArgs(int row, int col, int val)
        {
            _row = row;
            _column = col;
            _meetsCriteria = val;
        }

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        public int  MeetsCriteria
        {
            get { return _meetsCriteria; }
            set { _meetsCriteria = value; }
        }
    }

    public class ColumnStyle : DataGridTextBoxColumn
    {
        public event CheckCellEventHandler CheckCellEven;

        private int _col;


        public ColumnStyle(int column)
        {
            _col = column;
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
     
            int enabled =0;
            

            if (CheckCellEven != null)
            {

                DataGridEnableEventArgs e = new DataGridEnableEventArgs(rowNum, _col, enabled);
                CheckCellEven(this,e);

                if (e.MeetsCriteria == 0)
                {
                    backBrush = new SolidBrush(Color.White);
                }
                else if (e.MeetsCriteria == 1)
                {
                    backBrush = new SolidBrush(Color.Lime);
                }
                else if (e.MeetsCriteria == 2)
                {
                    backBrush = new SolidBrush(Color.Yellow);
                }
                else 
                {
                    backBrush = new SolidBrush(Color.Red); 
                }
            }
         
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
          
        }

    }

}
