using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MyGIS.Forms
{
    public partial class DataCollect : Form
    {

        String[] tableNames;

        public DataCollect()
        {
            InitializeComponent();
            InitList();
            LoadData();
        }

        private void InitList()
        {
            tableNames = new String[]{
                "people",
                "route",
                "geoboundarypoint",
                "faultpoint",
                "foldpoint",
                "placepoint",
                "samplepoint",
                "fossilpoint",
                "map",
                "attitude",
                "sketch",
                "picture",
                "wave",
                "avi",
                "geoboundary",
                "fault",
                "stra",
                "text"
            };
        }

        private void LoadData()
        {
            String connectStr = "server=127.0.0.1;port=3306;user=root;password=zjxpku123;database=mygis;";
            MySqlConnection mySqlConnection = new MySqlConnection(connectStr);

            try
            {
                mySqlConnection.Open();

                for (int i = 0; i < tableNames.GetLength(0); ++i)
                {
                    string sqlGetHeaders = "select * from people";
                    //string sqlGetHeaders = String.Format("select column_name from information_schema.columns where table_name='" + tableNames[i] + "' and table_schema='mygis'");
                    MySqlCommand cmdGetHeaders = new MySqlCommand(sqlGetHeaders, mySqlConnection);
                    MySqlDataReader readHeaders = cmdGetHeaders.ExecuteReader();

                    List<String> tableHeaders = new List<string>();

                    int index = 0;
                    while (readHeaders.Read())
                    {
                        tableHeaders.Add(readHeaders.GetString(index));
                        ++index;
                    }
                    foreach (string header in readHeaders)
                    {
                        Console.WriteLine(header);
                    }
                }

                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

    }
}
