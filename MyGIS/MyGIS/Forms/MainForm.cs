using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyGIS.Forms
{
    public partial class MainForm : Form
    {
        private ILayer pGlobalFeatureLayer;
        private Operation oprFlag;
        private String oprLayerName;
        private IGeometry pGeometry;


        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 定义一个操作的枚举，分别是新建点、线、面
        /// </summary>
        enum Operation
        {
            ConstructionPoint,      // 新建点
            ConstructionPolyLine,   // 新建折线
            ConstructionPolygon,    // 新建面
            Nothing
        }

        #region 调整操作状态（编辑点、线、面）
        private void EditPoint()
        {
            oprFlag = Operation.ConstructionPoint;
        }

        private void EditPolyline(String layerName)
        {
            oprFlag = Operation.ConstructionPolyLine;
            oprLayerName = layerName;
        }

        private void EditPolygon()
        {
            oprFlag = Operation.ConstructionPolygon;
        }
        #endregion

        #region 用于绘制点、线、面的主要函数
        private IPoint CreatePoint(double x, double y)
        {
            IPoint point = new PointClass();
            point.PutCoords(x, y);
            return point;
        }

        private void AddFeatureOnLayer(String layerName, IGeometry pGrometry)
        {
            // 根据图层名称，从当前地图中获取该图层并转换为要素层
            ILayer pLayer = GetLayerByNameFromMap(layerName);
            
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;

            // 如果成功获取，则进行如下编辑，将几何对象添加到地图图层之上
            if (pFeatureLayer != null)
            {
                // 定义一个地物类，将要编辑的图层转化为定义的地物类
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

                // 将上述地物类转化为数据集，然后转化为可编辑的工作空间
                IWorkspaceEdit pWorkspaceEdit = (pFeatureClass as IDataset).Workspace as IWorkspaceEdit;

                // 开始事务操作
                pWorkspaceEdit.StartEditing(true);

                // 开始编辑操作
                pWorkspaceEdit.StartEditOperation();

                // 在内存中创建一个用于暂时存放编辑数据的要素
                IFeatureBuffer pFeatureBuffer = pFeatureClass.CreateFeatureBuffer();
                // 定义游标并指向最后一条记录
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, true);
                IFeature pFeature = pFeatureCursor.NextFeature();

                // 使用insert游标插入新的实体对象
                pFeatureCursor = pFeatureClass.Insert(true);

                try
                {
                    // 向缓存游标的shp属性赋值
                    pFeatureBuffer.Shape = pGeometry;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

                object featureOid = pFeatureCursor.InsertFeature(pFeatureBuffer);

                // 保存实体
                pFeatureCursor.Flush();

                // 结束操作
                pWorkspaceEdit.StopEditOperation();
                pWorkspaceEdit.StopEditing(true);

                // 释放游标
                Marshal.ReleaseComObject(pFeatureCursor);
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, pLayer, null);
            }
            else
            {
                MessageBox.Show("未找到名为" + layerName + "的图层");
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

            this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, pFeatureLayer, null);
        }

        #endregion

        #region 从图层列表中根据图层名称获取相应图层
        private ILayer GetLayerByNameFromMap(String layerName)
        {
            for (int i = 0; i < axMapControl1.LayerCount; ++i)
            {
                if (axMapControl1.get_Layer(i) is ICompositeLayer)
                {
                    return GetLayerByNameFromCom(axMapControl1.get_Layer(i) as ICompositeLayer, layerName);
                }
                else
                {
                    if (axMapControl1.get_Layer(i).Name == layerName)
                    {
                        return axMapControl1.get_Layer(i);
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

        public static void CreateShpFile(string strShapeFolder, string strShapeName)
        {
            //打开工作空间
            const string strShapeFieldName = "shape";

            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace pWS = (IFeatureWorkspace)pWSF.OpenFromFile(strShapeFolder, 0);

            //设置字段集
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;

            //设置字段
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = (IFieldEdit)pField;


            //创建类型为几何类型的字段
            pFieldEdit.Name_2 = strShapeFieldName;
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;

            //为esriFieldTypeGeometry类型的字段创建几何定义，包括类型和空间参照
            IGeometryDef pGeoDef = new GeometryDefClass(); //The geometry definition for the field if IsGeometry is TRUE.
            IGeometryDefEdit pGeoDefEdit = (IGeometryDefEdit)pGeoDef;
            pGeoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            pGeoDefEdit.SpatialReference_2 = new UnknownCoordinateSystemClass();

            pFieldEdit.GeometryDef_2 = pGeoDef;
            pFieldsEdit.AddField(pField);


            if (strShapeName == "地层线")
            {
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
            else if (strShapeName == "断层线")
            {
                IField faultIdField = new FieldClass();
                IFieldEdit faultIdFieldEdit = faultIdField as IFieldEdit;
                faultIdFieldEdit.Name_2 = "FaultID";
                faultIdFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                pFieldsEdit.AddField(faultIdField);

                IField faultNameField = new FieldClass();
                IFieldEdit faultNameFieldEdit = faultNameField as IFieldEdit;
                faultNameFieldEdit.Name_2 = "FaultName";
                faultNameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(faultNameField);

                IField faultTypeField = new FieldClass();
                IFieldEdit faultTypeFieldEdit = faultTypeField as IFieldEdit;
                faultTypeFieldEdit.Name_2 = "FaultType";
                faultTypeFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                pFieldsEdit.AddField(faultTypeField);

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

            //创建shapefile
            pWS.CreateFeatureClass(strShapeName, pFields, null, null, esriFeatureType.esriFTSimple, strShapeFieldName, "");

        }

        private void AddShpToMxd(String shapefileLocation)
        {
            if (shapefileLocation != "")
            {
                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0);
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));
                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.FeatureClass = featureClass;
                featureLayer.Name = featureClass.AliasName;
                featureLayer.Visible = true;
                IActiveView activeView = axMapControl1.ActiveView;
                activeView.FocusMap.AddLayer(featureLayer);
                activeView.Extent = activeView.FullExtent;
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No shapefile chosen", "No Choice #1",
                                                    System.Windows.Forms.MessageBoxButtons.OK,
                                                    System.Windows.Forms.MessageBoxIcon.Exclamation);
            }            
        }
        #endregion

        #region 给要素添加字段
        private void AddField(IFeatureClass pFeatureClass, String fieldName, esriFieldType fieldType)
        {
            IFields pFields = pFeatureClass.Fields;
            IClass pClass = pFeatureClass as IClass;
            IFieldsEdit pFieldsEdit = pFields as IFieldsEdit;
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = fieldName;
            pFieldEdit.Type_2 = fieldType;
            pClass.AddField(pField);
        }

        private void GeoBoundaryAddFields(IFeatureClass pFeatureClass)
        {
            AddField(pFeatureClass, "ContactRela", esriFieldType.esriFieldTypeString);
            AddField(pFeatureClass, "LeftBody", esriFieldType.esriFieldTypeString);
            AddField(pFeatureClass, "RightBody", esriFieldType.esriFieldTypeString);
            AddField(pFeatureClass, "Strike", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "Dip", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "DipAngle", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "Remark", esriFieldType.esriFieldTypeString);
        }

        private void FaultAddFields(IFeatureClass pFeatureClass)
        {
            AddField(pFeatureClass, "FaultID", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "FaultName", esriFieldType.esriFieldTypeString);
            AddField(pFeatureClass, "FaultType", esriFieldType.esriFieldTypeString);
            AddField(pFeatureClass, "FaultDist", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "FaultAge", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "FaultRock", esriFieldType.esriFieldTypeString);
            AddField(pFeatureClass, "Strike", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "Dip", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "DipAngle", esriFieldType.esriFieldTypeInteger);
            AddField(pFeatureClass, "Remark", esriFieldType.esriFieldTypeString);
        }
        #endregion

        #region 文件菜单选项
        private void 新建图层文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String folderPath = Application.StartupPath + "\\ShpFile\\" + DateTime.Now.ToString().Replace('/','.').Replace(':','.') + "\\";
            System.IO.Directory.CreateDirectory(folderPath);
            CreateShpFile(folderPath, "地层线");
            CreateShpFile(folderPath, "断层线");
            AddShpToMxd(folderPath + "地层线.shp");
            AddShpToMxd(folderPath + "断层线.shp");
            //String prjFilePath = "E:\\2022GIS\\MyGISDev\\Data\\等高线.prj";
            //ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            //ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateESRISpatialReferenceFromPRJFile(prjFilePath); 
        }
        #endregion

        #region 数据采集菜单选项
        private void 图幅数据录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.Show();
        }

        private void 地质路线录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Route route = new Route();
            route.Show();
        }

        private void 地层界线点数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GeoBoundaryPoint geoBoundaryPoint = new GeoBoundaryPoint();
            geoBoundaryPoint.Show();
        }

        private void 断层采集点数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaultPoint faultPoint = new FaultPoint();
            faultPoint.Show();
        }

        private void 褶皱采集点数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoldPoint foldPoint = new FoldPoint();
            foldPoint.Show();
        }

        #endregion

        #region 数据管理菜单选项
        private void 数据管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCollect dataCollect = new DataCollect();
            dataCollect.Show();
        }
        #endregion

        #region 帮助菜单选项
        private void 帮助主题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        #endregion

        #region 目录右键菜单选项
        private void 属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable formTable = new AttributeTable(pGlobalFeatureLayer);
            formTable.Text = "属性表：" + pGlobalFeatureLayer.Name;
            formTable.ShowDialog();
        }

        private void 移除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < axMapControl1.LayerCount; ++i)
            {
                if (axMapControl1.get_Layer(i) == pGlobalFeatureLayer)
                {
                    axMapControl1.DeleteLayer(i);
                    break;
                }
            }
            axMapControl1.ActiveView.Refresh();
        }
        #endregion

        #region 编辑成图菜单选项
        private void 编辑状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (编辑状态ToolStripMenuItem.Text == "开始编辑")
            {
                绘制地层线ToolStripMenuItem.Enabled = true;
                绘制断层线ToolStripMenuItem.Enabled = true;
                编辑状态ToolStripMenuItem.Text = "停止编辑";
            }
            else if (编辑状态ToolStripMenuItem.Text == "停止编辑")
            {
                绘制地层线ToolStripMenuItem.Enabled = false;
                绘制断层线ToolStripMenuItem.Enabled = false;
                编辑状态ToolStripMenuItem.Text = "开始编辑";
                oprFlag = Operation.Nothing;
            }
        }

        private void 绘制地层线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPolyline("地层线");
        }

        private void 绘制断层线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPolyline("断层线");
        }
        #endregion

        #region 控制窗口的最小尺寸
        /// <summary>
        /// 窗口尺寸变化后触发的事件：若长宽小于最小值后就自动调整到该最小值
        /// </summary>
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width <= 828)
            {
                this.Width = 828;
            }

            if (this.Height <= 506)
            {
                this.Height = 506;
            }
        }
        #endregion

        #region 缩略图功能（有bug，需要后续完善）
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            // 得到新范围
            IEnvelope pEnvelope = (IEnvelope)e.newEnvelope;

            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;

            IActiveView pActiveView = pGraphicsContainer as IActiveView;

            //在绘制前,清除axMapControl2中的任何图形元素 
            pGraphicsContainer.DeleteAllElements();

            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pElement = pRectangleEle as IElement;
            pElement.Geometry = pEnvelope;

            //设置鹰眼图中的红线框

            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;

            //产生一个线符号对象

            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 3;
            pOutline.Color = pColor;

            //设置颜色属性

            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 0;

            //设置填充符号的属性

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pElement as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeEle, 0);

            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            if (axMapControl1.LayerCount > 0)
            {
                axMapControl2.Map = new MapClass();
                for (int i = 0; i <= axMapControl1.Map.LayerCount - 1; i++)
                {
                    axMapControl2.AddLayer(axMapControl1.get_Layer(i));
                }
                axMapControl2.Extent = axMapControl1.Extent;
                axMapControl2.Refresh();
            }
        }
        #endregion

        #region 缩略图与主窗口的互动（有bug，需要后续完善）
        private void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                axMapControl1.CenterAt(pPoint);
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (axMapControl2.Map.LayerCount > 0)
            {
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    axMapControl1.CenterAt(pPoint);
                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else if (e.button == 2)
                {
                    IEnvelope pEnv = axMapControl2.TrackRectangle();
                    axMapControl1.Extent = pEnv;
                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
        }
        #endregion

        #region 目录处右键查看要素属性表（代码copy，后续需要理解）
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                esriTOCControlItem pTOCControlItem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pBasicMap = new MapClass();
                pGlobalFeatureLayer = new FeatureLayerClass();
                object pOther = new object();
                object pIndex = new object();
                axTOCControl1.HitTest(e.x, e.y, ref pTOCControlItem, ref pBasicMap, ref pGlobalFeatureLayer, ref pOther, ref pIndex);

                if (pTOCControlItem == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    contextMenuStrip1.Show(axTOCControl1, new System.Drawing.Point(e.x, e.y));
                }
            }
        }
        #endregion

        #region MapControl1事件函数
        /// <summary>
        /// 鼠标移动的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            try
            {
                toolStripStatusLabel1.Text = string.Format("{0},{1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (oprFlag == Operation.ConstructionPoint)
            {
                // 设置axMapControl控件的当前地图工具为空
                axMapControl1.CurrentTool = null;
                // 指定图层名称，将点要素绘制其上
                AddPointByStore("point", CreatePoint(e.mapX, e.mapY) as IPoint);
            }
            else if (oprFlag == Operation.ConstructionPolyLine)
            {
                try
                {
                    //axMapControl1控件的当前地图工具为空
                    axMapControl1.CurrentTool = null;

                    //定义集合类型绘制折线的方法
                    pGeometry = axMapControl1.TrackLine();

                    AddFeatureOnLayer(oprLayerName, pGeometry);

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else if (oprFlag == Operation.ConstructionPolygon)
            {
                try
                {
                    //axMapControl1控件的当前地图工具为空
                    axMapControl1.CurrentTool = null;
                    pGeometry = axMapControl1.TrackPolygon();
                    AddFeatureOnLayer("polygon", pGeometry);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        #endregion
    }
}
