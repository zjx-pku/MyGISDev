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
    /// <summary>
    /// 地质路线信息采集表
    /// </summary>
    public partial class Route : Form
    {
        #region 构造函数
        public Route()
        {
            InitializeComponent();  // 初始化控件
            GetMapID();             // 获取MapID
        }
        #endregion

        #region 函数
        /// <summary>
        /// 获取MapID
        /// </summary>
        private void GetMapID()
        {
            try
            {
                // 建立数据库连接
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                // 执行查询语句
                string commandText = "select MapID from map";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                // 读取查询结果并写入名为MapID的下拉框中
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for(int i = 0; i < mySqlDataReader.FieldCount; ++i)
                    {
                        MapID.Items.Add(mySqlDataReader[i].ToString());                    
                    }
                }

                // 断开数据库连接
                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// “确认提交”按钮点击后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 确定提交_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// 1. 新建变量，用来接受调查人员填写的数据
            /// </summary>
            String mapId = null;
            String mapName = null;
            String routeId = null;
            String routeName = null;
            String routeDir = null;
            String routeDes = null;
            DateTime date = new DateTime();
            String weather = null;
            String longStar = null;
            String latiStar = null;
            String altitudeStar = null;
            String longEnd = null;
            String latiEnd = null;
            String altitudeEnd = null;
            String remark = null;

            /// <summary>
            /// 2. 获取调查人员填写的数据
            /// </summary>
            // (1)图幅编号
            try
            {
                mapId = MapID.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (2)图幅名称
            try
            {
                mapName = MapName.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (3)路线编号
            try
            {
                routeId = RouteID.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (4)路线名称
            try
            {
                routeName = RouteName.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (5)路线方向
            try
            {
                routeDir = RouteDir.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (6)路线描述
            try
            {
                routeDes = RouteDes.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (7)日期
            try
            {
                date = Date.Value;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (8)气候
            try
            {
                weather = Weather.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (9)起点经度
            try
            {
                longStar = LongStar.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (10)起点纬度
            try
            {
                latiStar = LatiStar.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (11)起点高程
            try
            {
                altitudeStar = AltitudeStar.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (12)终点经度
            try
            {
                longEnd = LongEnd.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (13)终点纬度
            try
            {
                latiEnd = LatiEnd.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (14)终点高程
            try
            {
                altitudeEnd = AltitudeEnd.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (15)备注
            try
            {
                remark = Remark.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            /// <summary>
            /// 3.连接数据库，将数据写入数据库
            /// </summary>
            try
            {
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                string commandText = "insert into route(MapID, MapName, RouteID, RouteName, RouteDir, RouteDes, Date, Weather, LongStar, LatiStar, AltitudeStar, LongEnd, LatiEnd, AltitudeEnd, Remark) " +
                                     "values('" + mapId + "','" + mapName + "','" + routeId + "','" + routeName + "','" + routeDir + "','" + routeDes + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + 
                                     weather + "'," + longStar + "," + latiStar + "," + altitudeStar + "," + longEnd + "," + latiEnd + "," + altitudeEnd + ",'" + Remark + "')";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            /// <summary>
            /// 4.提交成功
            /// </summary>
            MessageBox.Show("提交成功！");



        }

        /// <summary>
        /// “取消”按钮点击后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// MapID选中文本改变后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 建立数据库连接
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                // 执行查询语句
                string commandText = "select MapName from map where MapID = " + MapID.Text;
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                // 读取查询结果并写入MapName文本框中
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; ++i)
                    {
                        MapName.Text = mySqlDataReader[i].ToString();
                    }
                }

                // 断开数据库连接
                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion
    }
}
