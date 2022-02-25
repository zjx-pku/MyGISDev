using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHU2017301110147.Forms
{
    public partial class SpatialQueryResaultTable : Form
    {
        public SpatialQueryResaultTable()
        {
            InitializeComponent();
        }
        private DataTable dt = null;
        public SpatialQueryResaultTable(DataTable dataTable)
        {
            InitializeComponent();
            dt = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SpatialQueryResaultTable_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
        }
    }
}
