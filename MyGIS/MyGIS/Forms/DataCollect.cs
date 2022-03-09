using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGIS.Forms
{
    public partial class DataCollect : Form
    {

        List<String> tableNames;
        List<List<String>> tableColumnNames;

        public DataCollect()
        {
            InitializeComponent();
            InitTableNameList();
            InitTableColumnNameList();
            TableConnetcDB();
        }


        private void InitTableNameList()
        {
            tableNames = new List<String>{
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

        private void InitTableColumnNameList()
        {
            tableColumnNames = new List<List<String>>();
            {
                tableColumnNames.Add(new List<String>({"人员编号","姓名","性别","出生年月","学历","起始点","结束点","备注"}))
                {"系统字段","系统字段","图幅编号","图幅名称","路线编号","路线名称","路线方向","路线描述","日期","气候","起点经度","起点纬度","起点高程","终点经度","终点纬度","终点高程","备注"},
                {"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","经度","纬度","高程","接触关系","左地质体","右地质体","走向","倾向","倾角","备注"},
                {"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","断层编号","经度","纬度","高程","断层类型","断层名称","估计断距","期次与年龄","断层岩","断层走向","断层面倾向","断层面倾角","备注"},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
                {"","","","","","","","","","","","","","","","","","","","",},
            }
        }

        private void TableConnetcDB()
        {
            for (int i = 0; i < tableNames.Count; ++i)
            {
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                string sqlStr = string.Format("SELECT * FROM " + tableNames[i]);
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlStr, connectionStr);
                DataTable dataBase = new DataTable();
                adapter.Fill(dataBase);
                DataGridView dataGridView = GetDataGridView(tableNames[i]);
                if (dataGridView != null)
                {
                    dataGridView.DataSource = dataBase;
                    for (int j = 0; j < dataGridView.ColumnCount; ++j)
                    {
                        dataGridView.Columns[j].HeaderText = "哈哈哈";
                    }
                }
            }
        }

        private DataGridView GetDataGridView(String tableName)
        {
            if (tableName == "people")
            {
                return this.peopleDataGridView;
            }
            else if (tableName == "route")
            {
                return this.routeDataGridView;
            }
            else if (tableName == "geoboundarypoint")
            {
                return this.geoboundarypointDataGridView;
            }
            else if (tableName == "faultpoint")
            {
                return this.faultpointDataGridView;
            }
            else if (tableName == "foldpoint")
            {
                return this.foldpointDataGridView;
            }
            else if (tableName == "placepoint")
            {
                return this.placepointDataGridView;
            }
            else if (tableName == "samplepoint")
            {
                return this.samplepointDataGridView;
            }
            else if (tableName == "fossilpoint")
            {
                return this.samplepointDataGridView;
            }
            else if (tableName == "map")
            {
                return this.mapDataGridView;
            }
            else if (tableName == "attitude")
            {
                return this.attitudeDataGridView;
            }
            else if (tableName == "sketch")
            {
                return this.sketchDataGridView;
            }
            else if (tableName == "picture")
            {
                return this.pictureDataGridView;
            }
            else if (tableName == "wave")
            {
                return this.waveDataGridView;
            }
            else if (tableName == "avi")
            {
                return this.aviDataGridView;
            }
            else if (tableName == "geoboundary")
            {
                return this.geoboundaryDataGridView;
            }
            else if (tableName == "fault")
            {
                return this.faultDataGridView;
            }
            else if (tableName == "stra")
            {
                return this.straDataGridView;
            }
            else if (tableName == "text")
            {
                return this.textDataGridView;
            }
            else
            {
                return null;
            }
        }
    }

}
