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
    public partial class FaultPoint : Form
    {
        public FaultPoint()
        {
            InitializeComponent();
            GetMapIDRouteIDPointID();
        }

        private void GetMapIDRouteIDPointID()
        {
            try
            {
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                string commandText = "select MapID from map";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; ++i)
                    {
                        MapID.Items.Add(mySqlDataReader[i].ToString());
                    }
                }

                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                string commandText = "select RouteID from route";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; ++i)
                    {
                        RouteID.Items.Add(mySqlDataReader[i].ToString());
                    }
                }

                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                string commandText = "select PointID from geoboundarypoint";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; ++i)
                    {
                        PointID.Items.Add(mySqlDataReader[i].ToString());
                    }
                }

                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 获取经纬度和高程_Click(object sender, EventArgs e)
        {

        }

        private void 确定提交_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// 1. 新建变量，用来接受调查人员填写的数据
            /// </summary>
            String mapId = null;
            String mapName = null;
            String routeId = null;
            String pointId = null;
            String faultId = null;
            String longitude = null;
            String latitude = null;
            String altitude = null;
            String faultType = null;
            String faultName = null;
            String faultDist = null;
            String faultAge = null;
            String faultRock = null;
            String faultStrike = null;
            String faultDip = null;
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

            // (5)断层编号
            try
            {
                faultId = FaultID.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (6)经度
            try
            {
                longitude = Longitude.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (7)纬度
            try
            {
                latitude = Latitude.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (8)高程
            try
            {
                altitude = Altitude.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (9)断层类型
            try
            {
                faultType = FaultType.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (10)断层名称
            try
            {
                faultName = FaultName.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (11)估计断距
            try
            {
                faultDist = FaultDist.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (12)期次与年龄
            try
            {
                faultAge = FaultAge.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (13)断层岩
            try
            {
                faultRock = FaultRock.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (14)断层走向
            try
            {
                faultStrike = FaultStrike.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (15)断层面倾向
            try
            {
                faultDip = FaultDip.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (16)断层面倾角
            try
            {
                dipAngle = DipAngle.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (17)备注
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

                string commandText = "insert into faultpoint(MapID, MapName, RouteID, PointID, FaultID, Longitude, Latitude, Altitude, FaultType, FaultName, FaultDist, FaultAge, FaultRock, FaultStrike, FaultDip, DipAngle, Remark) " +
                                     "values('" + mapId + "','" + mapName + "','" + routeId + "','" + pointId + "','" + faultId + "'," + longitude + "," + latitude + "," + altitude + ",'" + faultType + "','" + faultName + "'," + 
                                     faultDist + ",'" + faultAge + "','" + faultRock + "'," + faultStrike + "," + faultDip + "," + dipAngle + ",'" + remark + "')";
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

        private void 取消_Click(object sender, EventArgs e)
        {

        }

        private void MapID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                string commandText = "select MapName from map where MapID = " + MapID.Text;
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; ++i)
                    {
                        MapName.Text = mySqlDataReader[i].ToString();
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
