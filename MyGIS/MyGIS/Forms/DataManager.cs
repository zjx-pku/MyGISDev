using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyGIS.Forms
{
    /// <summary>
    /// “数据管理”界面类，可以针对采集的数据进行编辑、删除和生成图层文件
    /// </summary>
    public partial class DataManager : Form
    {
        #region 字段
        private List<String> tableNames;                // 涉及到的采集数据表的名称
        private List<List<String>> tableColumnNames;    // 设计到的采集数据表中每个字段列的名称
        #endregion

        #region 构造函数
        public DataManager()
        {
            InitializeComponent();      // 初始化组件界面
            InitTableNameList();        // 初始化tableNames
            InitTableColumnNameList();  // 初始化tableColumnNames
            TableConnetcDB();           // 连接数据库，用数据库中的数据初始化数据表
        }
        #endregion

        #region 事件
        /// <summary>
        /// “删除所选”按钮被点击后触发的事件：删除当前数据表的所有选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除所选_Click(object sender, EventArgs e)
        {
            // (1) 获取当前被选中的选项卡编号
            int selectedIndex = tabControl.SelectedIndex;

            // (2) 如果选项卡编号为0，说明当前查看的数据表为“地质路线”
            if (selectedIndex == 0)
            {
                // 遍历“地质路线”数据表中被选中的每一行
                foreach (DataGridViewRow row in routeDataGridView.SelectedRows)
                {
                    try
                    {
                        // 建立数据库连接
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        // 执行删除语句
                        string commandText = "delete from route where RouteID = " + row.Cells[2].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        // 断开数据库连接
                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                // 重新连接数据库，刷新数据表的内容
                TableConnetcDB();
            }
            // (3) 如果选项卡编号为1，说明说明当前查看的数据表为“地层界限点”
            else if (selectedIndex == 1)
            {
                // 遍历“地层界限点”数据表中被选中的每一行
                foreach (DataGridViewRow row in geoboundarypointDataGridView.SelectedRows)
                {
                    try
                    {
                        // 建立数据库连接
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        // 执行删除语句
                        string commandText = "delete from geoboundarypoint where PointID = " + row.Cells[3].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        // 断开数据库连接
                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                // 重新连接数据库，刷新数据表的内容
                TableConnetcDB();
            }
            // (3) 如果选项卡编号为2，说明说明当前查看的数据表为“断层采集点”
            else if (selectedIndex == 2)
            {
                // 遍历“断层采集点”数据表中被选中的每一行
                foreach (DataGridViewRow row in faultpointDataGridView.SelectedRows)
                {
                    try
                    {
                        // 建立数据库连接
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        // 执行删除语句
                        string commandText = "delete from faultpoint where FaultID = " + row.Cells[4].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        // 断开数据库连接
                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                // 重新连接数据库，刷新数据表的内容
                TableConnetcDB();
            }
            // (4) 如果选项卡编号为3，说明说明当前查看的数据表为“褶皱采集点”
            else if (selectedIndex == 3)
            {
                // 遍历“褶皱采集点”数据表中被选中的每一行
                foreach (DataGridViewRow row in foldpointDataGridView.SelectedRows)
                {
                    try
                    {
                        // 建立数据库连接
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        // 执行删除语句
                        string commandText = "delete from foldpoint where FoldID = " + row.Cells[4].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        // 断开数据库连接
                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                // 重新连接数据库，刷新数据表的内容
                TableConnetcDB();
            }
            // (5) 如果选项卡编号为4，说明当前查看的数据表为“图幅信息数据”
            else if (selectedIndex == 4)
            {
                // 遍历“图幅信息数据”数据表中被选中的每一行
                foreach (DataGridViewRow row in mapDataGridView.SelectedRows)
                {
                    try
                    {
                        // 建立数据库连接
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        // 执行删除语句
                        string commandText = "delete from map where MapID = " + row.Cells[0].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        // 断开数据库连接
                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                // 重新连接数据库，刷新数据表的内容
                TableConnetcDB();
            }
        }

        /// <summary>
        /// “生成图层文件”按钮被点击后触发的事件：生成地层界线点、断层采集点和褶皱采集点图层文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 生成图层文件_Click(object sender, EventArgs e)
        {
            // (1) 获取当前被选中的选项卡编号
            int selectedIndex = tabControl.SelectedIndex;

            // (2) 创建存储生成图层文件的文件夹folderPath并将其访问属性设置为normal（可读可写）
            String folderPath = Application.StartupPath + "\\ShpFile\\" + DateTime.Now.ToString().Replace('/', '.').Replace(':', '.') + "\\";
            System.IO.Directory.CreateDirectory(folderPath);
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(folderPath);
            directoryInfo.Attributes = System.IO.FileAttributes.Normal;

            // (3) 如果选项卡编号为1，说明当前查看的数据表为“地层界线点”
            if (selectedIndex == 1)
            {
                // 在指定folderPath路径下创建一个名为"地层界线点"点状shp文件
                CreateShpFile(folderPath, "地层界线点");
                
                // 获取表格的行列数
                int columnCount = geoboundarypointDataGridView.Columns.Count;
                int rowCount = geoboundarypointDataGridView.Rows.Count;

                // 遍历每一行（除去最后一个空行）读取属性数据，创建点状要素
                for (int i = 0; i < rowCount - 1; ++i)
                {
                    // 创建点状要素，并将其位置(x,y)初始化为经度和纬度
                    IPoint point = new PointClass();
                    point.PutCoords(double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[4].Value)),
                        double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[5].Value)));

                    // 将上述点状要素添加到名为"地层界线点"的shp文件中（注意此时点状要素尚未写入其他属性数据）
                    AddPointByStore("地层界线点", point);

                    // 读取名为"地层界线点"的要素图层对象pFeatureLayer中的要素类pFeatureClass
                    IFeatureLayer pFeatureLayer = GetLayerByNameFromMap("地层界线点") as IFeatureLayer;
                    IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

                    // 根据fid获取刚刚添加的点状要素对象pFeature
                    IFeature pFeature = pFeatureClass.GetFeature(i);

                    // 遍历数据表当前行的每一列数据，写入到上述点状要素对象pFeature之中
                    for (int j = 0; j < columnCount; ++j)
                    {
                        // 获取该列的列名
                        string fieldName = geoboundarypointDataGridView.Columns[j].Name;

                        // 可能是因为AE的bug，导致名为"ContactRela"的列名被截断为"ContactRel"，所以这里需要特殊处理一下
                        if (fieldName == "ContactRela")
                        {
                            fieldName = "ContactRel";
                        }

                        // 根据列名获取该字段的索引
                        int fieldIndex = pFeature.Fields.FindField(fieldName);

                        // 根据该字段的索引获取该字段对象，进而获得其类型
                        esriFieldType fieldType = pFeature.Fields.get_Field(fieldIndex).Type;

                        // 新建一个object对象用来存储字段值，系统中涉及到的字段类型包括int,double和string
                        object fieldValue = new object();

                        // 如果字段类型为string，则将该单元格内的值转换为string
                        if (fieldType == esriFieldType.esriFieldTypeString)
                        {
                            fieldValue = (string)geoboundarypointDataGridView.Rows[i].Cells[j].Value;
                        }
                        // 如果字段类型为int，则将该单元格内的值转换为string并用int类型进行解析
                        else if (fieldType == esriFieldType.esriFieldTypeInteger)
                        {
                            fieldValue = int.Parse(Convert.ToString(geoboundarypointDataGridView.Rows[i].Cells[j].Value));
                        }
                        else if (fieldType == esriFieldType.esriFieldTypeDouble)
                        {
                            fieldValue = double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[j].Value));
                        }

                        // 根据字段索引和单元格内的值类更新该要素的属性
                        pFeature.set_Value(fieldIndex, fieldValue);

                        // 保存
                        pFeature.Store();
                    }
                }
            }
            // (4) 如果选项卡编号为2，说明当前查看的数据表为“断层采集点”
            else if (selectedIndex == 2)
            {
                // 在指定folderPath路径下创建一个名为"断层采集点"的点状shp文件
                CreateShpFile(folderPath, "断层采集点");

                // 获取表格的行列数
                int columnCount = faultpointDataGridView.Columns.Count;
                int rowCount = faultpointDataGridView.Rows.Count;

                // 遍历每一行（除去最后一个空行）读取属性数据，创建点状要素
                for (int i = 0; i < rowCount - 1; ++i)
                {
                    // 创建点状要素，并将其位置(x,y)初始化为经度和纬度
                    IPoint point = new PointClass();
                    point.PutCoords(double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[5].Value)),
                                double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[6].Value)));

                    // 将上述点状要素添加到名为"断层采集点"的shp文件中（注意此时点状要素尚未写入其他属性数据）
                    AddPointByStore("断层采集点", point);

                    // 读取名为"断层采集点"的要素图层对象pFeatureLayer中的要素类pFeatureClass
                    IFeatureLayer pFeatureLayer = GetLayerByNameFromMap("断层采集点") as IFeatureLayer;
                    IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

                    // 根据fid获取刚刚添加的点状要素对象pFeature
                    IFeature pFeature = pFeatureClass.GetFeature(i);

                    // 遍历数据表当前行的每一列数据，写入到上述点状要素对象pFeature之中
                    for (int j = 0; j < columnCount; ++j)
                    {
                        // 获取该列的列名
                        string fieldName = faultpointDataGridView.Columns[j].Name;

                        // 可能是因为AE的bug，导致名为"FaultStrike"的列名被截断为"FaultStrik"，所以这里需要特殊处理一下
                        if (fieldName == "FaultStrike")
                        {
                            fieldName = "FaultStrik";
                        }

                        // 根据列名获取该字段的索引
                        int fieldIndex = pFeature.Fields.FindField(fieldName);
                        
                        // 根据该字段的索引获取该字段对象，进而获得其类型
                        esriFieldType fieldType = pFeature.Fields.get_Field(fieldIndex).Type;
                        
                        // 新建一个object对象用来存储字段值，系统中涉及到的字段类型包括int和string
                        object fieldValue = new object();
                        
                        // 如果字段类型为string，则将该单元格内的值转换为string
                        if (fieldType == esriFieldType.esriFieldTypeString)
                        {
                            fieldValue = (string)faultpointDataGridView.Rows[i].Cells[j].Value;
                        }
                        // 如果字段类型为int，则将该单元格内的值转换为string并用int类型进行解析
                        else if (fieldType == esriFieldType.esriFieldTypeInteger)
                        {
                            fieldValue = int.Parse(Convert.ToString(faultpointDataGridView.Rows[i].Cells[j].Value));
                        }
                        // 如果字段类型为double，则将该单元格内的值转换为string并用double类型进行解析
                        else if (fieldType == esriFieldType.esriFieldTypeDouble)
                        {
                            fieldValue = double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[j].Value));
                        }

                        // 根据字段索引和单元格内的值类更新该要素的属性
                        pFeature.set_Value(fieldIndex, fieldValue);
                        
                        // 保存
                        pFeature.Store();
                    }
                }
            }
            // (4) 如果选项卡编号为3，说明当前查看的数据表为“褶皱采集点”
            else if (selectedIndex == 3)
            {
                // 在指定folderPath路径下创建一个名为"断层采集点"的点状shp文件
                CreateShpFile(folderPath, "褶皱采集点");

                // 获取表格的行列数
                int columnCount = foldpointDataGridView.Columns.Count;
                int rowCount = foldpointDataGridView.Rows.Count;

                // 遍历每一行（除去最后一个空行）读取属性数据，创建点状要素
                for (int i = 0; i < rowCount - 1; ++i)
                {
                    // 创建点状要素，并将其位置(x,y)初始化为经度和纬度
                    IPoint point = new PointClass();
                    point.PutCoords(double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[5].Value)),
                                double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[6].Value)));

                    // 将上述点状要素添加到名为"褶皱采集点"的shp文件中（注意此时点状要素尚未写入其他属性数据）
                    AddPointByStore("褶皱采集点", point);

                    // 读取名为"褶皱采集点"的要素图层对象pFeatureLayer中的要素类pFeatureClass
                    IFeatureLayer pFeatureLayer = GetLayerByNameFromMap("褶皱采集点") as IFeatureLayer;
                    IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

                    // 根据fid获取刚刚添加的点状要素对象pFeature
                    IFeature pFeature = pFeatureClass.GetFeature(i);

                    // 遍历数据表当前行的每一列数据，写入到上述点状要素对象pFeature之中
                    for (int j = 0; j < columnCount; ++j)
                    {
                        // 获取该列的列名
                        string fieldName = foldpointDataGridView.Columns[j].Name;

                        // 可能是因为AE的bug，导致名为"FoldAxTrend", "FoldAxRegDip", "FoldAxRegAng"的列名被截断，所以这里需要特殊处理一下
                        if (fieldName == "FoldAxTrend")
                        {
                            fieldName = "FoldAxTren";
                        }
                        else if (fieldName == "FoldAxRegDip")
                        {
                            fieldName = "FoldAxRegD";
                        }
                        else if (fieldName == "FoldAxRegAng")
                        {
                            fieldName = "FoldAxRegA";
                        }

                        // 根据列名获取该字段的索引
                        int fieldIndex = pFeature.Fields.FindField(fieldName);
                        
                        // 根据该字段的索引获取该字段对象，进而获得其类型
                        esriFieldType fieldType = pFeature.Fields.get_Field(fieldIndex).Type;
                        
                        // 新建一个object对象用来存储字段值，系统中涉及到的字段类型包括int和string
                        object fieldValue = new object();
                        
                        // 如果字段类型为string，则将该单元格内的值转换为string
                        if (fieldType == esriFieldType.esriFieldTypeString)
                        {
                            fieldValue = (string)foldpointDataGridView.Rows[i].Cells[j].Value;
                        }
                        // 如果字段类型为int，则将该单元格内的值转换为string并用int类型进行解析
                        else if (fieldType == esriFieldType.esriFieldTypeInteger)
                        {
                            fieldValue = int.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[j].Value));
                        }
                        // 如果字段类型为double，则将该单元格内的值转换为string并用double类型进行解析
                        else if (fieldType == esriFieldType.esriFieldTypeDouble)
                        {
                            fieldValue = double.Parse(Convert.ToString(foldpointDataGridView.Rows[i].Cells[j].Value));
                        }

                        // 根据字段索引和单元格内的值类更新该要素的属性
                        pFeature.set_Value(fieldIndex, fieldValue);
                        
                        // 保存
                        pFeature.Store();
                    }
                }
            }
        }

        /// <summary>
        /// “编辑”按钮被点击后触发的事件：编辑或停止编辑表格内的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑_Click(object sender, EventArgs e)
        {
            // (1) 获取当前被选中的选项卡编号
            int selectIndex = tabControl.SelectedIndex;

            // (2) 如果按钮的文字为"开始编辑"，说明点击后进入了编辑状态
            if (编辑.Text == "开始编辑")
            {
                // 修改按钮文字为"保存并停止编辑"
                编辑.Text = "保存并停止编辑";

                // 如果当前选项卡编号为0，说明查看的数据表为“地质路线”，修改其只读属性为false
                if (selectIndex == 0)
                {
                    routeDataGridView.ReadOnly = false;
                }
                // 如果当前选项卡编号为1，说明查看的数据表为“地层界线点”，修改其只读属性为false
                else if (selectIndex == 1)
                {
                    geoboundarypointDataGridView.ReadOnly = false;
                }
                // 如果当前选项卡编号为2，说明查看的数据表为“断层采集点”，修改其只读属性为false
                else if (selectIndex == 2)
                {
                    faultpointDataGridView.ReadOnly = false;
                }
                // 如果当前选项卡编号为3，说明查看的数据表为“褶皱采集点”，修改其只读属性为false
                else if (selectIndex == 3)
                {
                    foldpointDataGridView.ReadOnly = false;
                }
                // 如果当前选项卡编号为4，说明查看的数据表为“图幅信息数据”，修改其只读属性为false
                else if (selectIndex == 4)
                {
                    mapDataGridView.ReadOnly = false;
                }
            }
            // (3) 如果按钮的文字为"保存并停止编辑"，说明点击后停止了编辑
            else if (编辑.Text == "保存并停止编辑")
            {
                // 修改按钮文字为"开始编辑"
                编辑.Text = "开始编辑";

                // 如果当前选项卡编号为0，说明查看的数据表为“地质路线”，修改其只读属性为true并将修改后的内容同步到数据库中
                if (selectIndex == 0)
                {
                    // 修改只读属性为true
                    routeDataGridView.ReadOnly = true;

                    // 获取表格行数
                    int rowsCount = routeDataGridView.Rows.Count;

                    // 遍历表格所有行，将修改后的数据内容更新到数据库中
                    for (int i = 0; i < rowsCount - 1; ++i)
                    {
                        DataGridViewRow row = routeDataGridView.Rows[i];

                        try
                        {
                            // 建立数据库连接
                            string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                            mySqlConnection.Open();

                            // 执行更新语句
                            string commandText = "update route set " +
                                                 "MapID = '" + row.Cells[0].Value.ToString() +
                                                 "', MapName = '" + row.Cells[1].Value.ToString() +
                                                 "', RouteName = '" + row.Cells[3].Value.ToString() +
                                                 "', RouteDir = '" + row.Cells[4].Value.ToString() +
                                                 "', RouteDes = '" + row.Cells[5].Value.ToString() +
                                                 "', Date = '" + row.Cells[6].Value.ToString() +
                                                 "', Weather = '" + row.Cells[7].Value.ToString() +
                                                 "', LongStar = " + row.Cells[8].Value.ToString() +
                                                 ", LatiStar = " + row.Cells[9].Value.ToString() +
                                                 ", AltitudeStar = " + row.Cells[10].Value.ToString() +
                                                 ", LongEnd = " + row.Cells[11].Value.ToString() +
                                                 ", LatiEnd = " + row.Cells[12].Value.ToString() +
                                                 ", AltitudeEnd = " + row.Cells[13].Value.ToString() +
                                                 ", Remark = '" + row.Cells[14].Value.ToString() +
                                                 "' where RouteID = '" + row.Cells[2].Value.ToString() + "';";
                            MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                            mySqlCommand.ExecuteNonQuery();

                            // 断开数据库连接
                            mySqlConnection.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }

                    // 重新连接数据库，刷新表格数据
                    TableConnetcDB();
                }
                // 如果当前选项卡编号为1，说明查看的数据表为“地层界线点”，修改其只读属性为true并将修改后的内容同步到数据库中
                else if (selectIndex == 1)
                {
                    // 修改只读属性为true
                    geoboundarypointDataGridView.ReadOnly = true;

                    // 获取表格行数
                    int rowsCount = geoboundarypointDataGridView.Rows.Count;

                    // 遍历表格所有行，将修改后的数据内容更新到数据库中
                    for (int i = 0; i < rowsCount - 1; ++i)
                    {
                        DataGridViewRow row = geoboundarypointDataGridView.Rows[i];
                        
                        try
                        {
                            // 建立数据库连接
                            string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                            mySqlConnection.Open();

                            // 执行更新语句
                            string commandText = "update geoboundarypoint set " +
                                                 "MapID = '" + row.Cells[0].Value.ToString() +
                                                 "', MapName = '" + row.Cells[1].Value.ToString() +
                                                 "', RouteID = '" + row.Cells[2].Value.ToString() +
                                                 "', Longitude = " + row.Cells[4].Value.ToString() +
                                                 ", Latitude = " + row.Cells[5].Value.ToString() +
                                                 ", Altitude = " + row.Cells[6].Value.ToString() +
                                                 ", ContactRela = '" + row.Cells[7].Value.ToString() +
                                                 "', LeftBody = '" + row.Cells[8].Value.ToString() +
                                                 "', RightBody = '" + row.Cells[9].Value.ToString() +
                                                 "', Strike = " + row.Cells[10].Value.ToString() +
                                                 ", Dip = " + row.Cells[11].Value.ToString() +
                                                 ", DipAngle = " + row.Cells[12].Value.ToString() +
                                                 ", Remark = '" + row.Cells[13].Value.ToString() +
                                                 "' where PointID = '" + row.Cells[3].Value.ToString() + "';";
                            MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                            mySqlCommand.ExecuteNonQuery();

                            // 断开数据库连接
                            mySqlConnection.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }

                    // 重新连接数据库，刷新表格数据
                    TableConnetcDB();
                }
                // 如果当前选项卡编号为2，说明查看的数据表为“断层采集点”，修改其只读属性为true并将修改后的内容同步到数据库中
                else if (selectIndex == 2)
                {
                    // 修改其只读属性为true
                    faultpointDataGridView.ReadOnly = true;

                    // 获取表格行数
                    int rowsCount = faultpointDataGridView.Rows.Count;

                    // 遍历表格所有行，将修改后的数据内容更新到数据库中
                    for (int i = 0; i < rowsCount - 1; ++i)
                    {
                        DataGridViewRow row = faultpointDataGridView.Rows[i];

                        try
                        {
                            // 建立数据库连接
                            string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                            mySqlConnection.Open();

                            // 执行更新语句
                            string commandText = "update faultpoint set " +
                                                 "MapID = '" + row.Cells[0].Value.ToString() +
                                                 "', MapName = '" + row.Cells[1].Value.ToString() +
                                                 "', RouteID = '" + row.Cells[2].Value.ToString() +
                                                 "', PointID = '" + row.Cells[3].Value.ToString() +
                                                 "', Longitude = " + row.Cells[5].Value.ToString() +
                                                 ", Latitude = " + row.Cells[6].Value.ToString() +
                                                 ", Altitude = " + row.Cells[7].Value.ToString() +
                                                 ", FaultType = '" + row.Cells[8].Value.ToString() +
                                                 "', FaultName = '" + row.Cells[9].Value.ToString() +
                                                 "', FaultDist = " + row.Cells[10].Value.ToString() +
                                                 ", FaultAge = '" + row.Cells[11].Value.ToString() +
                                                 "', FaultRock = '" + row.Cells[12].Value.ToString() +
                                                 "', FaultStrike = " + row.Cells[13].Value.ToString() +
                                                 ", FaultDip = " + row.Cells[14].Value.ToString() +
                                                 ", DipAngle = " + row.Cells[15].Value.ToString() +
                                                 ", Remark = '" + row.Cells[16].Value.ToString() +
                                                 "' where FaultID = '" + row.Cells[4].Value.ToString() + "';";
                            MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                            mySqlCommand.ExecuteNonQuery();

                            // 断开数据库连接
                            mySqlConnection.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }

                    // 重新连接数据库，刷新表格数据
                    TableConnetcDB();
                }
                // 如果当前选项卡编号为3，说明查看的数据表为“褶皱采集点”，修改其只读属性为true并将修改后的内容同步到数据库中
                else if (selectIndex == 3)
                {
                    // 修改其只读属性为true
                    foldpointDataGridView.ReadOnly = true;

                    // 获取表格行数
                    int rowsCount = foldpointDataGridView.Rows.Count;

                    // 遍历表格所有行，将修改后的数据内容更新到数据库中
                    for (int i = 0; i < rowsCount - 1; ++i)
                    {
                        DataGridViewRow row = foldpointDataGridView.Rows[i];
                        
                        try
                        {
                            // 建立数据库连接
                            string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                            mySqlConnection.Open();

                            // 执行更新语句
                            string commandText = "update foldpoint set " +
                                                 "MapID = '" + row.Cells[0].Value.ToString() +
                                                 "', MapName = '" + row.Cells[1].Value.ToString() +
                                                 "', RouteID = '" + row.Cells[2].Value.ToString() +
                                                 "', PointID = '" + row.Cells[3].Value.ToString() +
                                                 "', Longitude = " + row.Cells[5].Value.ToString() +
                                                 ", Latitude = " + row.Cells[6].Value.ToString() +
                                                 ", Altitude = " + row.Cells[7].Value.ToString() +
                                                 ", FoldType = '" + row.Cells[8].Value.ToString() +
                                                 "', FoldName = '" + row.Cells[9].Value.ToString() +
                                                 "', FoldAxTrend = " + row.Cells[10].Value.ToString() +
                                                 ", FoldAxRegDip = " + row.Cells[11].Value.ToString() +
                                                 ", FoldAxRegAng = " + row.Cells[12].Value.ToString() +
                                                 ", FoldAge = " + row.Cells[13].Value.ToString() +
                                                 ", Remark = '" + row.Cells[14].Value.ToString() +
                                                 "' where FoldID = '" + row.Cells[4].Value.ToString() + "';";
                            MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                            mySqlCommand.ExecuteNonQuery();

                            // 断开数据库连接
                            mySqlConnection.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }

                    // 重新连接数据库，刷新表格数据
                    TableConnetcDB();
                }
                // 如果当前选项卡编号为4，说明查看的数据表为“图幅信息数据”，修改其只读属性为true并将修改后的内容同步到数据库中
                else if (selectIndex == 4)
                {
                    // 修改其只读属性为true
                    mapDataGridView.ReadOnly = true;

                    // 获取表格行数
                    int rowsCount = mapDataGridView.Rows.Count;

                    // 遍历表格所有行，将修改后的数据内容更新到数据库中
                    for (int i = 0; i < rowsCount - 1; ++i)
                    {
                        DataGridViewRow row = mapDataGridView.Rows[i];
                        
                        try
                        {
                            // 建立数据库连接
                            string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                            mySqlConnection.Open();

                            // 执行更新语句
                            string commandText = "update map set " +
                                                 "MapName = '" + row.Cells[1].Value.ToString() +
                                                 "', LeftLongX = " + row.Cells[2].Value.ToString() +
                                                 ", LeftLatiY = " + row.Cells[3].Value.ToString() +
                                                 ", RightLongX = " + row.Cells[4].Value.ToString() +
                                                 ", RightLatiY = " + row.Cells[5].Value.ToString() +
                                                 ", CoorSys = '" + row.Cells[6].Value.ToString() +
                                                 "', AltitudeSys = '" + row.Cells[7].Value.ToString() +
                                                 "', MappingUnit = '" + row.Cells[8].Value.ToString() +
                                                 "', MappingS = '" + row.Cells[9].Value.ToString() +
                                                 "', MappingE = '" + row.Cells[10].Value.ToString() +
                                                 "', Remark = '" + row.Cells[11].Value.ToString() +
                                                 "' where MapID = '" + row.Cells[0].Value.ToString() + "';";
                            MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                            mySqlCommand.ExecuteNonQuery();

                            // 断开数据库连接
                            mySqlConnection.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }

                    // 重新连接数据库，刷新表格数据
                    TableConnetcDB();
                }
            }
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 初始化tableNames
        /// </summary>
        private void InitTableNameList()
        {
            tableNames = new List<String>{
                "people",
                "route",
                "geoboundarypoint",
                "faultpoint",
                "foldpoint",
                "map",
            };
        }

        /// <summary>
        /// 初始化tableColumnNames
        /// </summary>
        private void InitTableColumnNameList()
        {
            tableColumnNames = new List<List<String>>();

            tableColumnNames.Add(new List<String>(){"人员编号","姓名","性别","出生年月","学历","起始点","结束点","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","路线名称","路线方向","路线描述","日期","气候","起点经度","起点纬度","起点高程","终点经度","终点纬度","终点高程","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","地质点号","经度","纬度","高程","接触关系","左地质体","右地质体","走向","倾向","倾角","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","地质点号","断层编号","经度","纬度","高程","断层类型","断层名称","估计断距","期次与年龄","断层岩","断层走向","断层面倾向","断层面倾角","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","地质点号","褶皱编号","经度","纬度","高程","褶皱类型","褶皱名称","褶皱轴向","轴面倾向","轴面倾角","形成时代","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名","左下角X坐标","左下角Y坐标","右上角X坐标","右上角Y坐标","坐标系统","高程系统","填图单位","填图开始时间","填图结束时间","备注"});
        }

        /// <summary>
        /// 连接数据库，刷新表格数据
        /// </summary>
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

        /// <summary>
        /// 根据表格名称获取dataGridView对象
        /// </summary>
        /// <param name="tableName">表格名称</param>
        /// <returns>该表格对应的dataGridView对象</returns>
        private DataGridView GetDataGridView(String tableName)
        {
            if (tableName == "route")
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
            else if (tableName == "map")
            {
                return this.mapDataGridView;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 向某要素图层对象中添加点对象
        /// </summary>
        /// <param name="pointLayerName">要素图层对象的名称</param>
        /// <param name="point">点对象</param>
        private void AddPointByStore(String pointLayerName, IPoint point)
        {
            // 根据名称得到要添加地物的图层并转换为要素层
            IFeatureLayer pFeatureLayer = GetLayerByNameFromMap(pointLayerName) as IFeatureLayer;

            if (pFeatureLayer != null)
            {
                // 定义一个地物类，把要编辑的图层转化为定义的地物类
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                // 先定义一个编辑的工作空间，然后将上述地物类转化为数据集，最后转化为编辑工作空间
                IWorkspaceEdit pWorkspaceEdit = (pFeatureClass as IDataset).Workspace as IWorkspaceEdit;

                // 开始事务操作
                pWorkspaceEdit.StartEditing(false);
                // 开始编辑操作
                pWorkspaceEdit.StartEditOperation();

                // 创建一个点要素
                IFeature pFeature = pFeatureClass.CreateFeature();
                pFeature.Shape = point;

                // 保存点要素，完成编辑。此时生成的点要素只有集合特征(shape/Geometry), 无普通属性
                pFeature.Store();

                // 结束编辑操作
                pWorkspaceEdit.StopEditOperation();

                // 结束事务操作
                pWorkspaceEdit.StopEditing(true);
            }

            // 刷新图层界面
            MainForm.form.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, pFeatureLayer, null);
        }

        /// <summary>
        /// 在指定的文件夹下创建特定名称的点类型的shp文件
        /// </summary>
        /// <param name="strShapeFolder">文件夹路径</param>
        /// <param name="strShapeName">点类型shp文件的名称</param>
        private void CreateShpFile(string strShapeFolder, string strShapeName)
        {
            // 打开工作空间
            const string strShapeFieldName = "shape";

            // 新建WorkSpaceFactory对象
            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactory();
            IFeatureWorkspace pWS = (IFeatureWorkspace)pWSF.OpenFromFile(strShapeFolder, 0);

            // 设置字段集
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;

            // 设置字段
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = (IFieldEdit)pField;

            IFeatureClassDescription fcDesc = new FeatureClassDescriptionClass();
            IObjectClassDescription ocDesc = (IObjectClassDescription)fcDesc;

            // Use IFieldChecker to create a validated fields collection.
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IEnumFieldError enumFieldError = null;
            IFields validatedFields = null;
            fieldChecker.ValidateWorkspace = pWS as IWorkspace;
            fieldChecker.Validate(pFields, out enumFieldError, out validatedFields);

            // 创建类型为几何类型的字段
            pFieldEdit.Name_2 = strShapeFieldName;
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;

            // 为esriFieldTypeGeometry类型的字段创建几何定义，包括类型和空间参照
            IGeometryDef pGeoDef = new GeometryDefClass(); //The geometry definition for the field if IsGeometry is TRUE.
            IGeometryDefEdit pGeoDefEdit = (IGeometryDefEdit)pGeoDef;
            pGeoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;

            // 创建地理坐标系
            ISpatialReferenceFactory pSpatialReferFac = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialRefer = pSpatialReferFac.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            pGeoDefEdit.SpatialReference_2 = pSpatialRefer;

            pFieldEdit.GeometryDef_2 = pGeoDef;
            pFieldsEdit.AddField(pField);

            // 如果是"地层界线点"，则添加如下的字段
            if (strShapeName == "地层界线点")
            {
                IField mapIdField = new FieldClass();
                IFieldEdit mapIdFieldEdit = mapIdField as IFieldEdit;
                mapIdFieldEdit.Name_2 = "MapID";
                mapIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(mapIdField);

                IField mapNameField = new FieldClass();
                IFieldEdit mapNameFieldEdit = mapNameField as IFieldEdit;
                mapNameFieldEdit.Name_2 = "MapName";
                mapNameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(mapNameField);

                IField routeIdField = new FieldClass();
                IFieldEdit routeIdFieldEdit = routeIdField as IFieldEdit;
                routeIdFieldEdit.Name_2 = "RouteID";
                routeIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(routeIdField);

                IField pointIdField = new FieldClass();
                IFieldEdit pointIdFieldEdit = pointIdField as IFieldEdit;
                pointIdFieldEdit.Name_2 = "PointID";
                pointIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(pointIdField);


                IField longitudeField = new FieldClass();
                IFieldEdit longitudeFieldEdit = longitudeField as IFieldEdit;
                longitudeFieldEdit.Name_2 = "Longitude";
                longitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(longitudeField);


                IField latitudeField = new FieldClass();
                IFieldEdit latitudeFieldEdit = latitudeField as IFieldEdit;
                latitudeFieldEdit.Name_2 = "Latitude";
                latitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(latitudeField);


                IField altitudeField = new FieldClass();
                IFieldEdit altitudeFieldEdit = altitudeField as IFieldEdit;
                altitudeFieldEdit.Name_2 = "Altitude";
                altitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(altitudeField);

                IField contactRelaField = new FieldClass();
                IFieldEdit contactRelaFieldEdit = contactRelaField as IFieldEdit;
                contactRelaFieldEdit.Name_2 = "ContactRela";
                contactRelaFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(contactRelaField);

                IField leftBodyField = new FieldClass();
                IFieldEdit leftBodyFieldEdit = leftBodyField as IFieldEdit;
                leftBodyFieldEdit.Name_2 = "LeftBody";
                leftBodyFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(leftBodyField);

                IField rightBodyField = new FieldClass();
                IFieldEdit rightBodyFieldEdit = rightBodyField as IFieldEdit;
                rightBodyFieldEdit.Name_2 = "RightBody";
                rightBodyFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(rightBodyField);

                IField strikeField = new FieldClass();
                IFieldEdit strikeFieldEdit = strikeField as IFieldEdit;
                strikeFieldEdit.Name_2 = "Strike";
                strikeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(strikeField);

                IField dipField = new FieldClass();
                IFieldEdit dipFieldEdit = dipField as IFieldEdit;
                dipFieldEdit.Name_2 = "Dip";
                dipFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(dipField);

                IField dipAngleField = new FieldClass();
                IFieldEdit dipAngleFieldEdit = dipAngleField as IFieldEdit;
                dipAngleFieldEdit.Name_2 = "DipAngle";
                dipAngleFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(dipAngleField);

                IField remarkField = new FieldClass();
                IFieldEdit remarkFieldEdit = remarkField as IFieldEdit;
                remarkFieldEdit.Name_2 = "Remark";
                remarkFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(remarkField);
            }
            // 如果是"断层采集点"，则添加如下的字段
            else if (strShapeName == "断层采集点")
            {
                IField mapIdField = new FieldClass();
                IFieldEdit mapIdFieldEdit = mapIdField as IFieldEdit;
                mapIdFieldEdit.Name_2 = "MapID";
                mapIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(mapIdField);

                IField mapNameField = new FieldClass();
                IFieldEdit mapNameFieldEdit = mapNameField as IFieldEdit;
                mapNameFieldEdit.Name_2 = "MapName";
                mapNameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(mapNameField);

                IField routeIdField = new FieldClass();
                IFieldEdit routeIdFieldEdit = routeIdField as IFieldEdit;
                routeIdFieldEdit.Name_2 = "RouteID";
                routeIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(routeIdField);

                IField pointIdField = new FieldClass();
                IFieldEdit pointIdFieldEdit = pointIdField as IFieldEdit;
                pointIdFieldEdit.Name_2 = "PointID";
                pointIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(pointIdField);

                IField faultIdField = new FieldClass();
                IFieldEdit faultIdFieldEdit = faultIdField as IFieldEdit;
                faultIdFieldEdit.Name_2 = "FaultID";
                faultIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(faultIdField);

                IField longitudeField = new FieldClass();
                IFieldEdit longitudeFieldEdit = longitudeField as IFieldEdit;
                longitudeFieldEdit.Name_2 = "Longitude";
                longitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(longitudeField);


                IField latitudeField = new FieldClass();
                IFieldEdit latitudeFieldEdit = latitudeField as IFieldEdit;
                latitudeFieldEdit.Name_2 = "Latitude";
                latitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(latitudeField);


                IField altitudeField = new FieldClass();
                IFieldEdit altitudeFieldEdit = altitudeField as IFieldEdit;
                altitudeFieldEdit.Name_2 = "Altitude";
                altitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(altitudeField);

                IField faultTypeField = new FieldClass();
                IFieldEdit faultTypeFieldEdit = faultTypeField as IFieldEdit;
                faultTypeFieldEdit.Name_2 = "FaultType";
                faultTypeFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(faultTypeField);

                IField faultNameField = new FieldClass();
                IFieldEdit faultNameFieldEdit = faultNameField as IFieldEdit;
                faultNameFieldEdit.Name_2 = "FaultName";
                faultNameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(faultNameField);

                IField faultDistField = new FieldClass();
                IFieldEdit faultDistFieldEdit = faultDistField as IFieldEdit;
                faultDistFieldEdit.Name_2 = "FaultDist";
                faultDistFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(faultDistField);

                IField faultAgeField = new FieldClass();
                IFieldEdit faultAgeFieldEdit = faultAgeField as IFieldEdit;
                faultAgeFieldEdit.Name_2 = "FaultAge";
                faultAgeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(faultAgeField);

                IField faultRockField = new FieldClass();
                IFieldEdit faultRockFieldEdit = faultRockField as IFieldEdit;
                faultRockFieldEdit.Name_2 = "FaultRock";
                faultRockFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(faultRockField);

                IField strikeField = new FieldClass();
                IFieldEdit strikeFieldEdit = strikeField as IFieldEdit;
                strikeFieldEdit.Name_2 = "FaultStrike";
                strikeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(strikeField);

                IField dipField = new FieldClass();
                IFieldEdit dipFieldEdit = dipField as IFieldEdit;
                dipFieldEdit.Name_2 = "FaultDip";
                dipFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(dipField);

                IField dipAngleField = new FieldClass();
                IFieldEdit dipAngleFieldEdit = dipAngleField as IFieldEdit;
                dipAngleFieldEdit.Name_2 = "DipAngle";
                dipAngleFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(dipAngleField);

                IField remarkField = new FieldClass();
                IFieldEdit remarkFieldEdit = remarkField as IFieldEdit;
                remarkFieldEdit.Name_2 = "Remark";
                remarkFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(remarkField);
            }
            // 如果是"褶皱采集点"，则添加如下的字段
            else if (strShapeName == "褶皱采集点")
            {
                IField mapIdField = new FieldClass();
                IFieldEdit mapIdFieldEdit = mapIdField as IFieldEdit;
                mapIdFieldEdit.Name_2 = "MapID";
                mapIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(mapIdField);

                IField mapNameField = new FieldClass();
                IFieldEdit mapNameFieldEdit = mapNameField as IFieldEdit;
                mapNameFieldEdit.Name_2 = "MapName";
                mapNameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(mapNameField);

                IField routeIdField = new FieldClass();
                IFieldEdit routeIdFieldEdit = routeIdField as IFieldEdit;
                routeIdFieldEdit.Name_2 = "RouteID";
                routeIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(routeIdField);

                IField pointIdField = new FieldClass();
                IFieldEdit pointIdFieldEdit = pointIdField as IFieldEdit;
                pointIdFieldEdit.Name_2 = "PointID";
                pointIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(pointIdField);

                IField foldIdField = new FieldClass();
                IFieldEdit foldIdFieldEdit = foldIdField as IFieldEdit;
                foldIdFieldEdit.Name_2 = "FoldID";
                foldIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(foldIdField);

                IField longitudeField = new FieldClass();
                IFieldEdit longitudeFieldEdit = longitudeField as IFieldEdit;
                longitudeFieldEdit.Name_2 = "Longitude";
                longitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(longitudeField);


                IField latitudeField = new FieldClass();
                IFieldEdit latitudeFieldEdit = latitudeField as IFieldEdit;
                latitudeFieldEdit.Name_2 = "Latitude";
                latitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(latitudeField);


                IField altitudeField = new FieldClass();
                IFieldEdit altitudeFieldEdit = altitudeField as IFieldEdit;
                altitudeFieldEdit.Name_2 = "Altitude";
                altitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                pFieldsEdit.AddField(altitudeField);


                IField foldNameField = new FieldClass();
                IFieldEdit foldNameFieldEdit = foldNameField as IFieldEdit;
                foldNameFieldEdit.Name_2 = "FoldName";
                foldNameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(foldNameField);

                IField foldTypeField = new FieldClass();
                IFieldEdit foldTypeFieldEdit = foldTypeField as IFieldEdit;
                foldTypeFieldEdit.Name_2 = "FoldType";
                foldTypeFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(foldTypeField);

                IField foldAxTrend = new FieldClass();
                IFieldEdit foldAxTrendEdit = foldAxTrend as IFieldEdit;
                foldAxTrendEdit.Name_2 = "FoldAxTrend";
                foldAxTrendEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(foldAxTrend);

                IField foldAxRegDip = new FieldClass();
                IFieldEdit foldAxRegDipEdit = foldAxRegDip as IFieldEdit;
                foldAxRegDipEdit.Name_2 = "FoldAxRegDip";
                foldAxRegDipEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(foldAxRegDip);

                IField foldAxRegAng = new FieldClass();
                IFieldEdit foldAxRegAngEdit = foldAxRegAng as IFieldEdit;
                foldAxRegAngEdit.Name_2 = "FoldAxRegAng";
                foldAxRegAngEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(foldAxRegAng);

                IField foldAge = new FieldClass();
                IFieldEdit foldAgeEdit = foldAge as IFieldEdit;
                foldAgeEdit.Name_2 = "FoldAge";
                foldAgeEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(foldAge);

                IField remarkField = new FieldClass();
                IFieldEdit remarkFieldEdit = remarkField as IFieldEdit;
                remarkFieldEdit.Name_2 = "Remark";
                remarkFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(remarkField);
            }

            //创建shapefile
            IFeatureClass featureClass = pWS.CreateFeatureClass(strShapeName, pFields, ocDesc.InstanceCLSID, ocDesc.ClassExtensionCLSID, esriFeatureType.esriFTSimple, strShapeFieldName, "");
            
            // 设置相关属性
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = featureClass.AliasName;
            featureLayer.Visible = true;

            // 刷新界面
            IActiveView activeView = MainForm.form.axMapControl1.ActiveView;
            activeView.FocusMap.AddLayer(featureLayer);
            activeView.Extent = activeView.FullExtent;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        /// <summary>
        /// 根据图层名称从当前项目中获取要素类图层对象
        /// </summary>
        /// <param name="layerName">图层名称</param>
        /// <returns>名为layerName的要素类图层对象</returns>
        public ILayer GetLayerByNameFromMap(String layerName)
        {
            // 遍历mapControl中的所有layer进行查找
            for (int i = 0; i < MainForm.form.axMapControl1.LayerCount; ++i)
            {
                if (MainForm.form.axMapControl1.get_Layer(i) is ICompositeLayer)
                {
                    return GetLayerByNameFromCom(MainForm.form.axMapControl1.get_Layer(i) as ICompositeLayer, layerName);
                }
                else
                {
                    if (MainForm.form.axMapControl1.get_Layer(i).Name == layerName)
                    {
                        return MainForm.form.axMapControl1.get_Layer(i);
                    }
                }
            }

            return null;
        }

        private ILayer GetLayerByNameFromCom(ICompositeLayer pCompositeLayer, String layerName)
        {
            for (int i = 0; i < pCompositeLayer.Count; ++i)
            {
                if (pCompositeLayer.get_Layer(i) is ICompositeLayer)
                {
                    return GetLayerByNameFromCom(pCompositeLayer.get_Layer(i) as ICompositeLayer, layerName);
                }
                else
                {
                    if (pCompositeLayer.get_Layer(i).Name == layerName)
                    {
                        return pCompositeLayer.get_Layer(i);
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
