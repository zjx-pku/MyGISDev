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
    /// 地质界线采集点信息表
    /// </summary>
    public partial class GeoBoundaryPoint : Form
    {
        #region 构造函数
        public GeoBoundaryPoint()
        {
            InitializeComponent();
            GetMapIDRouteID();
        }
        #endregion

        #region 函数
        private void GetMapIDRouteID()
        {
            // 获取MapID
            try
            {
                // 建立数据库连接
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                // 执行查询语句
                string commandText = "select MapID from map";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                // 读取结果并写入名为MapID的下拉框中
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; ++i)
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

            // 获取RouteID
            try
            {
                // 建立数据库连接
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                // 执行查询语句
                string commandText = "select RouteID from route";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                // 读取查询结果并写入名为RouteID的下拉框中
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; ++i)
                    {
                        RouteID.Items.Add(mySqlDataReader[i].ToString());
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
        /// “获取经纬度和高程”按钮触发的事件：（未实现）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 获取经纬度和高程_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// “确认提交”按钮触发的事件：读取用户填写的内容并更新到数据库中
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
            String pointId = null;
            String longitude = null;
            String latitude = null;
            String altitude = null;
            String contactRela = null;
            String leftBody = null;
            String rightBody = null;
            String strike = null;
            String dip = null;
            String dipAngle = null;
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

            // (4)地质点号
            try
            {
                pointId = PointID.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (5)经度
            try
            {
                longitude = Longitude.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (6)纬度
            try
            {
                latitude = Latitude.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (7)高程
            try
            {
                altitude = Altitude.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (8)接触关系
            try
            {
                contactRela = ContactRela.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (9)左地质体
            try
            {
                leftBody = LeftBody.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (10)右地质体
            try
            {
                rightBody = RightBody.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (11)走向
            try
            {
                strike = Strike.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (12)倾向
            try
            {
                dip = Dip.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (13)倾角
            try
            {
                dipAngle = DipAngle.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (14)备注
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

                string commandText = "insert into geoboundarypoint(MapID, MapName, RouteID, PointID, Longitude, Latitude, Altitude, ContactRela, LeftBody, RightBody, Strike, Dip, DipAngle, Remark) " +
                                     "values('" + mapId + "','" + mapName + "','" + routeId + "','" + pointId + "'," + longitude + "," + latitude + "," + altitude + ",'" + contactRela + "','" + 
                                     leftBody + "','" + rightBody + "'," + strike + "," + dip + "," + dipAngle + ",'" + remark + "')";
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
        /// “取消”按钮触发的事件：关闭当前界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// MapID复选框内容改变后触发的事件：根据MapID更新对应的MapName
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

                // 将查询结果写入MapName文本框中
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
