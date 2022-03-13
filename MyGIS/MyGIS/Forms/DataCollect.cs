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
                //"placepoint",
                //"samplepoint",
                //"fossilpoint",
                "map",
                //"attitude",
                //"sketch",
                //"picture",
                //"wave",
                //"avi",
                //"geoboundary",
                //"fault",
                //"stra",
                //"text"
            };
        }

        private void InitTableColumnNameList()
        {
            tableColumnNames = new List<List<String>>();

            tableColumnNames.Add(new List<String>(){"人员编号","姓名","性别","出生年月","学历","起始点","结束点","备注"});
            tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","路线名称","路线方向","路线描述","日期","气候","起点经度","起点纬度","起点高程","终点经度","终点纬度","终点高程","备注"});
            tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","经度","纬度","高程","接触关系","左地质体","右地质体","走向","倾向","倾角","备注"});
            tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","断层编号","经度","纬度","高程","断层类型","断层名称","估计断距","期次与年龄","断层岩","断层走向","断层面倾向","断层面倾角","备注"});
            tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","褶皱编号","经度","纬度","高程","褶皱类型","褶皱名称","褶皱轴向","轴面倾向","轴面倾角","形成时代","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","矿点编号","经度","纬度","高程","矿产地名","矿产种类","矿体数","矿床规模","形成时代","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","样品编号","经度","纬度","高程","采样日期","地理位置","样品采集人","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","化石编号","经度","纬度","高程","化石采集人","采集日期","地理位置","野外定名","室内定名","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名","左下角X坐标","左下角Y坐标","右上角X坐标","右上角Y坐标","坐标系统","高程系统","填图单位","填图开始时间","填图结束时间","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","产状编号","产状类型","经度","纬度","高程","测量日期","测量人员","走向","倾向","倾角","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","素描编号","经度","纬度","高程","素描图名","素描人员","素描日期","素描描述","文件位置","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","图片编号","经度","纬度","高程","照片名称","拍摄人员","拍摄日期","照片描述","文件位置","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","录音编号","经度","纬度","高程","录音名称","录音人员","录音日期","录音描述","文件位置","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","图幅编号","图幅名称","路线编号","地质点号","视频编号","经度","纬度","高程","视频名称","拍摄人员","拍摄日期","视频描述","文件位置","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","接触关系","左地质体","右地质体","走向","倾向","倾角","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","断层编号","断层名称","断层类型","估计断距","断层年龄","断层岩","断层走向","断层倾向","断层倾角","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","地层名称","地层符号","备注"});
            //tableColumnNames.Add(new List<String>(){"系统字段","系统字段","文本内容","备注"});
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
                        dataGridView.Columns[j].HeaderText = tableColumnNames[i][j];
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
            //else if (tableName == "placepoint")
            //{
            //    return this.placepointDataGridView;
            //}
            //else if (tableName == "samplepoint")
            //{
            //    return this.samplepointDataGridView;
            //}
            //else if (tableName == "fossilpoint")
            //{
            //    return this.fossilpointDataGridView;
            //}
            else if (tableName == "map")
            {
                return this.mapDataGridView;
            }
            //else if (tableName == "attitude")
            //{
            //    return this.attitudeDataGridView;
            //}
            //else if (tableName == "sketch")
            //{
            //    return this.sketchDataGridView;
            //}
            //else if (tableName == "picture")
            //{
            //    return this.pictureDataGridView;
            //}
            //else if (tableName == "wave")
            //{
            //    return this.waveDataGridView;
            //}
            //else if (tableName == "avi")
            //{
            //    return this.aviDataGridView;
            //}
            //else if (tableName == "geoboundary")
            //{
            //    return this.geoboundaryDataGridView;
            //}
            //else if (tableName == "fault")
            //{
            //    return this.faultDataGridView;
            //}
            //else if (tableName == "stra")
            //{
            //    return this.straDataGridView;
            //}
            //else if (tableName == "text")
            //{
            //    return this.textDataGridView;
            //}
            else
            {
                return null;
            }
        }
    }

}
