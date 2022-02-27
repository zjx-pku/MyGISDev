using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGIS.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CollectData_Click(object sender, EventArgs e)
        {
            CollectData collectData = new CollectData();
            collectData.Show();
        }

        private void EditData_Click(object sender, EventArgs e)
        {
            EditData editData = new EditData();
            editData.Show();
        }

        private void SpatialAnalyze_Click(object sender, EventArgs e)
        {
            SpatialAnalyze spatialAnalyze = new SpatialAnalyze();
            spatialAnalyze.Show();
        }

        private void PrintOutput_Click(object sender, EventArgs e)
        {
            PrintOutput printOutput = new PrintOutput();
            printOutput.Show();
        }


    }
}
