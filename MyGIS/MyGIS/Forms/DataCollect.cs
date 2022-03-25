using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.SystemUI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","路线名称","路线方向","路线描述","日期","气候","起点经度","起点纬度","起点高程","终点经度","终点纬度","终点高程","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","地质点号","经度","纬度","高程","接触关系","左地质体","右地质体","走向","倾向","倾角","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","地质点号","断层编号","经度","纬度","高程","断层类型","断层名称","估计断距","期次与年龄","断层岩","断层走向","断层面倾向","断层面倾角","备注"});
            tableColumnNames.Add(new List<String>(){"图幅编号","图幅名称","路线编号","地质点号","褶皱编号","经度","纬度","高程","褶皱类型","褶皱名称","褶皱轴向","轴面倾向","轴面倾角","形成时代","备注"});
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
            //if (tableName == "people")
            //{
            //    return this.peopleDataGridView;
            //}
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

        private void 删除所选_Click(object sender, EventArgs e)
        {
            int selectedIndex = tabControl.SelectedIndex;

            if (selectedIndex == 0)
            {
                foreach(DataGridViewRow row in routeDataGridView.SelectedRows)
                {
                    try
                    {
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        string commandText = "delete from route where RouteID = " + row.Cells[2].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                TableConnetcDB();
            }
            else if (selectedIndex == 1)
            {
                foreach (DataGridViewRow row in geoboundarypointDataGridView.SelectedRows)
                {
                    try
                    {
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        string commandText = "delete from geoboundarypoint where PointID = " + row.Cells[3].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                TableConnetcDB();
            }
            else if (selectedIndex == 2)
            {
                foreach (DataGridViewRow row in faultpointDataGridView.SelectedRows)
                {
                    try
                    {
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        string commandText = "delete from faultpoint where FaultID = " + row.Cells[4].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                TableConnetcDB();
            }
            else if (selectedIndex == 3)
            {
                foreach (DataGridViewRow row in foldpointDataGridView.SelectedRows)
                {
                    try
                    {
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        string commandText = "delete from foldpoint where FoldID = " + row.Cells[4].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                TableConnetcDB();
            }
            else if (selectedIndex == 4)
            {
                foreach (DataGridViewRow row in mapDataGridView.SelectedRows)
                {
                    try
                    {
                        string connectionStr = string.Format("server={0};user id = {1};port = {2};password={3};database=mygis;pooling = false;", "localhost", "root", 3306, "123456");
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                        mySqlConnection.Open();

                        string commandText = "delete from map where MapID = " + row.Cells[0].Value.ToString();
                        MySqlCommand mySqlCommand = new MySqlCommand(commandText, mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                TableConnetcDB();
            }
        }

        private void 编辑所选_Click(object sender, EventArgs e)
        {

        }

        private void 生成图层文件_Click(object sender, EventArgs e)
        {
            int selectedIndex = tabControl.SelectedIndex;

            String folderPath = Application.StartupPath + "\\ShpFile\\" + DateTime.Now.ToString().Replace('/', '.').Replace(':', '.') + "\\";
            System.IO.Directory.CreateDirectory(folderPath);
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(folderPath);
            directoryInfo.Attributes = System.IO.FileAttributes.Normal;

            // 地层界线点
            if (selectedIndex == 1)
            {
                CreateShpFile(folderPath, "地层界线点");
                IPoint point = new PointClass();
                AddPointByStore("地层界线点",)
            }
            // 断层采集点
            else if (selectedIndex == 2)
            {
                CreateShpFile(folderPath, "断层采集点");
            }
            // 褶皱采集点
            else if (selectedIndex == 3)
            {
                CreateShpFile(folderPath, "褶皱采集点");
            }
        }

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

            MainForm.form.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, pFeatureLayer, null);
        }

        private void CreateShpFile(string strShapeFolder, string strShapeName)
        {
            //打开工作空间
            const string strShapeFieldName = "shape";

            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactory();
            IFeatureWorkspace pWS = (IFeatureWorkspace)pWSF.OpenFromFile(strShapeFolder, 0);

            //设置字段集
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;

            //设置字段
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

            //创建类型为几何类型的字段
            pFieldEdit.Name_2 = strShapeFieldName;
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;

            //为esriFieldTypeGeometry类型的字段创建几何定义，包括类型和空间参照
            IGeometryDef pGeoDef = new GeometryDefClass(); //The geometry definition for the field if IsGeometry is TRUE.
            IGeometryDefEdit pGeoDefEdit = (IGeometryDefEdit)pGeoDef;
            pGeoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            pGeoDefEdit.SpatialReference_2 = new UnknownCoordinateSystemClass();

            pFieldEdit.GeometryDef_2 = pGeoDef;
            pFieldsEdit.AddField(pField);

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
                longitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(longitudeField);


                IField latitudeField = new FieldClass();
                IFieldEdit latitudeFieldEdit = latitudeField as IFieldEdit;
                latitudeFieldEdit.Name_2 = "Latitude";
                latitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(latitudeField);


                IField altitudeField = new FieldClass();
                IFieldEdit altitudeFieldEdit = altitudeField as IFieldEdit;
                altitudeFieldEdit.Name_2 = "Altitude";
                altitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
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
                longitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(longitudeField);


                IField latitudeField = new FieldClass();
                IFieldEdit latitudeFieldEdit = latitudeField as IFieldEdit;
                latitudeFieldEdit.Name_2 = "Latitude";
                latitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(latitudeField);


                IField altitudeField = new FieldClass();
                IFieldEdit altitudeFieldEdit = altitudeField as IFieldEdit;
                altitudeFieldEdit.Name_2 = "Altitude";
                altitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
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
                longitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(longitudeField);


                IField latitudeField = new FieldClass();
                IFieldEdit latitudeFieldEdit = latitudeField as IFieldEdit;
                latitudeFieldEdit.Name_2 = "Latitude";
                latitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(latitudeField);


                IField altitudeField = new FieldClass();
                IFieldEdit altitudeFieldEdit = altitudeField as IFieldEdit;
                altitudeFieldEdit.Name_2 = "Altitude";
                altitudeFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
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
                foldAxRegAngEdit.Name_2 = "FoldAxRegDip";
                foldAxRegAngEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(foldAxRegAng);

                IField remarkField = new FieldClass();
                IFieldEdit remarkFieldEdit = remarkField as IFieldEdit;
                remarkFieldEdit.Name_2 = "Remark";
                remarkFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(remarkField);
            }

            //创建shapefile
            IFeatureClass featureClass = pWS.CreateFeatureClass(strShapeName, pFields, ocDesc.InstanceCLSID, ocDesc.ClassExtensionCLSID, esriFeatureType.esriFTSimple, strShapeFieldName, "");
            
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = featureClass.AliasName;
            featureLayer.Visible = true;

            IActiveView activeView = MainForm.form.axMapControl1.ActiveView;
            activeView.FocusMap.AddLayer(featureLayer);
            activeView.Extent = activeView.FullExtent;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        public ILayer GetLayerByNameFromMap(String layerName)
        {
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
    }
}
