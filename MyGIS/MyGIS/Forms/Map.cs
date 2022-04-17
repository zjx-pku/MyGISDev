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
    /// 图幅信息数据
    /// </summary>
    public partial class Map : Form
    {
        #region 构造函数
        public Map()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件
        /// <summary>
        /// 点击“确定提交”按钮后触发的事件
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
            String leftLongX = null;
            String leftLatiY = null;
            String rightLongX = null;
            String rightLatiY = null;
            String coorSys = null;
            String altitudeSys = null;
            String mappingUnit = null;
            String remark = null;
            DateTime mappingS = new DateTime();
            DateTime mappingE = new DateTime();

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

            // (2)图幅名
            try
            {
                mapName = MapName.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (3)左下角X坐标
            try
            {
                leftLongX = LeftLongX.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (4)左下角Y坐标
            try
            {
                leftLatiY = LeftLatiY.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (5)右上角X坐标
            try
            {
                rightLongX = RightLongX.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (6)右上角X坐标
            try
            {
                rightLatiY = RightLatiY.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (7)坐标系统
            try
            {
                coorSys = CoorSys.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (8)高程系统
            try
            {
                altitudeSys = AltitudeSys.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (9)填图单位
            try
            {
                mappingUnit = MappingUnit.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (10)填图开始时间
            try
            {
                mappingS = MappingS.Value;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (11)填图结束时间
            try
            {
                mappingE = MappingE.Value;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // (12)备注
            try
            {
                remark = Remark.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            /// <summary>
            /// 连接数据库，将数据写入数据库
            /// </summary>
            try
            {
                string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                mySqlConnection.Open();

                string commandText = "insert into map(MapID, MapName, LeftLongX, LeftLatiY, RightLongX, RightLatiY, CoorSys, AltitudeSys, MappingUnit, MappingS, MappingE, Remark) " +
                                     "values(" + mapId + ",'" + mapName + "'," + leftLongX + "," + leftLatiY + "," + rightLongX + "," + rightLatiY + ",'" + coorSys + "','" + altitudeSys +
                                     "','" + mappingUnit + "','" + mappingS.ToString("yyyy-MM-dd HH:mm:ss") + "','" + mappingE.ToString("yyyy-MM-dd HH:mm:ss") + "','" + remark + "')";
                MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            /// <summary>
            /// 提交成功
            /// </summary>
            MessageBox.Show("提交成功！");

        }

        /// <summary>
        /// 点击“取消”按钮后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
