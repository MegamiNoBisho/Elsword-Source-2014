﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBManager
{
    public partial class History : Form
    {

        DataTable m_dtHistory;

        public History()
        {
            InitializeComponent();
        }

        public void SetHistoryTable(DataTable dtHistory)
        {
            m_dtHistory = dtHistory;
        }

        private void History_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = m_dtHistory;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            DataGridViewColumn Column_1 = dataGridView1.Columns["Regdate"];//dataGridView1.Columns["ID"];
            ListSortDirection direction_1 = ListSortDirection.Ascending;
            dataGridView1.Sort(Column_1, direction_1);

            dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];
            this.Width = 1000;
            this.Height = 600;
            History_Resize(null, null);

        }

        private void History_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Escape == e.KeyChar)
                this.Hide();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Escape == e.KeyChar)
                this.Hide();
        }

        private void History_Resize(object sender, EventArgs e)
        {
            /*dataGridView1.Columns["ID"].Width = 100;
            dataGridView1.Columns["ENum"].Width = 150;
            dataGridView1.Columns["PreProcessor"].Width = 100;
            dataGridView1.Columns["UserID"].Width = 100;
            dataGridView1.Columns["UserIP"].Width = 150;            
            dataGridView1.Columns["Regdate"].Width = 150;

            dataGridView1.Columns["String"].Width = dataGridView1.Width - 850;*/

            dataGridView1.Columns["TextureIDX"].Width = 100;
            dataGridView1.Columns["FilePath"].Width = 150;
            dataGridView1.Columns["IsChange"].Width = 100;
            dataGridView1.Columns["Regdate"].Width = 150;

            dataGridView1.Columns["String"].Width = dataGridView1.Width - 700;

            dataGridView1.Width = this.Width - 30;
            dataGridView1.Height = this.Height - 60;
        }
    }
}