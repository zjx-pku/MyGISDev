using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHU2017301110147.Classes;
using WHU2017301110147.Forms;
using ESRI.ArcGIS.ADF;

namespace WHU2017301110147
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);
        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);
        [DllImport("user32.dll")]
        public static extern uint DestroyCursor(IntPtr cursorHandle);

        IEnvelope pEnvelope;
        private Pan pan = null;

        public MainForm()
        {
            InitializeComponent();
            SynchronizeEagleEye();
            
        }

        /***************非事件方法************/

        private void SynchronizeEagleEye()
        {
            if (axMapControl2.LayerCount > 0)
            {
                axMapControl2.ClearLayers();
            }
            //保持鸟瞰图和数据视图空间参考一致
            axMapControl2.SpatialReference = axMapControl1.SpatialReference;
            for (int i = axMapControl1.LayerCount - 1; i >= 0; i--)
            {
                axMapControl2.AddLayer(axMapControl1.get_Layer(i));
            }
            IEnvelope pEnv = axMapControl1.Extent;
            pEnv.Expand(4, 4, true);
            axMapControl2.Extent = pEnv;
            pEnvelope = axMapControl1.Extent;
            DrawRectangle(pEnvelope);//具体实现见下页
            axMapControl2.Refresh();//每次必须刷新
        }
        private void DrawRectangle(IEnvelope pEnvelope)
        {
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;
            IRgbColor pRgbColor = new RgbColorClass();
            pRgbColor.Red = 255;
            pRgbColor.Blue = 0;
            pRgbColor.Green = 0;
            pRgbColor.Transparency = 255;
            ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
            pLineSymbol.Width = 3;
            pLineSymbol.Color = pRgbColor;
            pRgbColor.Red = 255;
            pRgbColor.Blue = 0;
            pRgbColor.Green = 0;
            pRgbColor.Transparency = 0;
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Outline = pLineSymbol;
            pFillSymbol.Color = pRgbColor;
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }


        /***/
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMXD = new OpenFileDialog();
            openMXD.Title = "打开mxd";
            openMXD.InitialDirectory = "E:";
            openMXD.Filter = "Map Documents (*.mxd)|*.mxd";
            if (openMXD.ShowDialog() == DialogResult.OK)
            {
                string MxdPath = openMXD.FileName;
                axMapControl1.LoadMxFile(MxdPath);
            }
        }

        private void axMapControl1_OnMapReplaced(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();
            #region 坐标单位替换
            esriUnits mapUnits = axMapControl1.MapUnits;
            switch (mapUnits)
            {
                case esriUnits.esriCentimeters:
                    pMapUnits = "Centimeters";
                    break;
                case esriUnits.esriDecimalDegrees:
                    pMapUnits = "Decimal Degrees";
                    break;
                case esriUnits.esriDecimeters:
                    pMapUnits = "Decimeters";
                    break;
                case esriUnits.esriFeet:
                    pMapUnits = "Feet";
                    break;
                case esriUnits.esriInches:
                    pMapUnits = "Inches";
                    break;
                case esriUnits.esriKilometers:
                    pMapUnits = "Kilometers";
                    break;
                case esriUnits.esriMeters:
                    pMapUnits = "Meters";
                    break;
                case esriUnits.esriMiles:
                    pMapUnits = "Miles";
                    break;
                case esriUnits.esriMillimeters:
                    pMapUnits = "Millimeters";
                    break;
                case esriUnits.esriNauticalMiles:
                    pMapUnits = "NauticalMiles";
                    break;
                case esriUnits.esriPoints:
                    pMapUnits = "Points";
                    break;
                case esriUnits.esriUnknownUnits:
                    pMapUnits = "Unknown";
                    break;
                case esriUnits.esriYards:
                    pMapUnits = "Yards";
                    break;
            }
            #endregion

        }

        private void axMapControl1_OnExtentUpdated(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            pEnvelope = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnvelope);
        }
        private void axMapControl2_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                axMapControl1.CenterAt(pPoint);
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

            }
        }
        Cursor myCursor_axMap = null;
        private void axMapControl1_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {

            myCursor_axMap = getCursor();
            this.Cursor = myCursor_axMap;
            Console.WriteLine(movecount++);


            //漫游（BaseTool方法）
            if (pan != null)
                pan.OnMouseMove(e.button, e.shift, e.x, e.y); //调用前面定义的pan.cs的函数

            // 取得鼠标所在工具的索引号  
            int index = axToolbarControl1.HitTest(e.x, e.y, false);
            if (index != -1)
            {
                // 取得鼠标所在工具的 ToolbarItem  
                IToolbarItem toolbarItem = axToolbarControl1.GetItem(index);
                // 设置状态栏信息  
                StatusLabel.Text = toolbarItem.Command.Message;
            }
            else
            {
                StatusLabel.Text = " 就绪 ";
            }
            // 显示当前比例尺
            ScaleLabel.Text = " 比例尺 1:" + ((long)this.axMapControl1.MapScale).ToString();

            // 显示当前坐标
            CoordinateLabel.Text = " 当前坐标 X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + pMapUnits.ToString();

        }


        private void axMapControl2_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (axMapControl2.Map.LayerCount > 0)
            {
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    axMapControl1.CenterAt(pPoint); axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else if (e.button == 2)
                {
                    IEnvelope pEnv = axMapControl2.TrackRectangle();
                    axMapControl1.Extent = pEnv;
                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
        }


        private void axToolbarControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        private void 文件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private string pMapUnits;
        private int movecount = 0;
        private Cursor getCursor()
        {
            Cursor myCursor = new Cursor(Cursor.Current.Handle);
            IntPtr colorCursorHandle = LoadCursorFromFile("E:\\学习2\\GIS工程\\包图网_18046809樱花季春季樱花写实花瓣矢量手绘元素素材\\5c7a8a18e807f.cur");//鼠标图标路径
            myCursor.GetType().InvokeMember("handle", BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance |
                BindingFlags.SetField, null, myCursor,
                new object[] { colorCursorHandle });
            
            return myCursor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pMapUnits = "Unknown";
            Cursor myCursor = getCursor();
            this.Cursor = myCursor;
            //axMapControl1.
            pictureBox1.BackgroundImage = Image.FromFile("E:\\学习2\\GIS工程\\" + "1501895387883301.png");
        }

        private void 加载工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenMXD = new OpenFileDialog(); //可实例化类
                                                           // Gets or sets the file dialog box title. (Inherited from FileDialog.)
            OpenMXD.Title = "打开地图"; // OpenFileDialog类的属性Title
                                    // Gets or sets the initial directory displayed by the file dialog box. 
            OpenMXD.InitialDirectory = "C:";
            // Gets or sets the current file name filter string ,Save as file type
            OpenMXD.Filter = "Map Documents (*.mxd)|*.mxd";
            if (OpenMXD.ShowDialog() == DialogResult.OK) //ShowDialog是类的方法
            {
                //FileName:Gets or sets a string containing the file name selected in the file dialog box
                string MxdPath = OpenMXD.FileName;
                axMapControl1.LoadMxFile(MxdPath); //IMapControl的方法
                SynchronizeEagleEye();

            }
        }

        private void 加载图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenShpFile = new OpenFileDialog();
            OpenShpFile.Title = "打开图层文件";
            OpenShpFile.InitialDirectory = "C:";
            OpenShpFile.Filter = "Shape文件(*.shp)|*.shp";
            if (OpenShpFile.ShowDialog() == DialogResult.OK)
            {
                string ShapPath = OpenShpFile.FileName;
                int Position = ShapPath.LastIndexOf("\\"); //利用"\\"将文件路径分成两部分
                string FilePath = ShapPath.Substring(0, Position);
                string ShpName = ShapPath.Substring(Position + 1);
                axMapControl1.AddShapeFile(FilePath, ShpName);
                SynchronizeEagleEye();
            }

        }

        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //传入从axTOCControl1.HitTest方法中获取的图层，通过FrmAttribute类的构造函数实例化
            AttributeForm frm1 = new AttributeForm(pLayer as IFeatureLayer);
            frm1.Show();

        }

        private void 打开属性表ToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private ILayer pLayer;//定义全局变量pLayer
        private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {
            if (axMapControl1.LayerCount > 0)
            {
            
                esriTOCControlItem pItem = new esriTOCControlItem();//用类实例化         
                pLayer = new FeatureLayerClass();
                IBasicMap pBasicMap = new MapClass();
                object pOther = new object();
                object pIndex = new object();
                // Returns the item in the TOCControl at the specified coordinates.
                axTOCControl1.HitTest(e.x, e.y, ref pItem, ref pBasicMap, ref pLayer, ref pOther, ref pIndex);
            }//TOCControl类的ITOCControl接口的HitTest方法,获取坐标
            if (e.button == 2)//等待点击右键
            {
                contextMenuStrip1.Show(axTOCControl1, e.x, e.y);//显示菜单项

            }
        }

        private void 缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 中心放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //声明与初始化 
            FixedZoomIn fixedZoomin = new FixedZoomIn();
            //与MapControl关联 
            fixedZoomin.OnCreate(this.axMapControl1.Object); 
            fixedZoomin.OnClick();

        }

        private void 中心缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //基于arcgis封装的类
            ICommand command = new ControlsMapZoomOutFixedCommandClass();
            command.OnCreate(this.axMapControl1.Object);
            command.OnClick();

        }

        private void 漫游ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pan != null)
            {
                //解除漫游状态
                pan = null;
            }
            else
            {
                //声明并初始化
                pan = new Pan();
                //关联MapControl
                pan.OnCreate(this.axMapControl1.Object);
                this.axMapControl1.CurrentTool = pan;
                
            }

        }
        private SpatialQueryResaultTable spatialQueryResaultTable = null;
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (pan != null)
                pan.OnMouseDown(e.button, e.shift, e.x, e.y);//调用前面定义的pan.cs的函数
            if (IsRouteSearch)
            {
                if (routeForm != null)
                {
                    
                    routeForm.fillText(e.mapX, e.mapY);
                    
                }
                else
                {
                    MessageBox.Show("导航功能错误");
                }
            }

            //当空间查询的状态为真时
            if (IsSpatialSearch)
            {
                if(spatialQueryResaultTable!=null)
                    spatialQueryResaultTable.Hide();
                //获取精确图层
                //ILayer pLayer = axMapControl1.get_Layer(Get_Layer(pLayer.Name));

                //将图层强转成要素图层
                IFeatureLayer pFtLayer = pLayer as IFeatureLayer;
                //将要素图层的图层类强转成要素类
                try
                {
                    if (pFtLayer != null)
                    {
                        ESRI.ArcGIS.Geodatabase.IFeatureClass pFtClass = pFtLayer.FeatureClass; //as ESRI.ArcGIS.Geodatabase.IFeatureClass;
                                                                                                //随着鼠标拖动得到一个矩形框
                        IEnvelope pEnvelope = axMapControl1.TrackRectangle();
                        //调用核心空间查询函数（采用空间相交的方法esriSpatialRelIntersects）

                        DataTable dataTable = SpatialSearch(pFtClass, "",
                            pEnvelope, ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelIntersects);
                        spatialQueryResaultTable = new SpatialQueryResaultTable(dataTable);
                        spatialQueryResaultTable.Show();
                        axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                    }
                    else
                    {
                        MessageBox.Show("请先选择一个图层");
                    }
                   
                }
                catch(System.NullReferenceException nulle)
                {
                    MessageBox.Show(nulle.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            //漫游（BaseTool方法）
            if (pan != null)
            {
                pan.OnMouseUp(e.button, e.shift, e.x, e.y); //调用前面定义的pan.cs的函数
                pan = null;
            }

        }

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tool的定义和初始化 
            ITool tool = new ControlsMapZoomInToolClass();
            //查询接口获取ICommand 
            ICommand command = tool as ICommand;
            //Tool通过ICommand与MapControl的关联 
            command.OnCreate(this.axMapControl1.Object);
            command.OnClick();
            //MapControl的当前工具设定为tool 
            this.axMapControl1.CurrentTool = tool;

        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tool的定义和初始化 
            ITool tool = new ControlsMapZoomOutToolClass();
            //查询接口获取ICommand 
            ICommand command = tool as ICommand;
            //Tool通过ICommand与MapControl的关联 
            command.OnCreate(this.axMapControl1.Object);
            command.OnClick();
            //MapControl的当前工具设定为tool 
            this.axMapControl1.CurrentTool = tool;

        }

        private void axMapControl1_Enter(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void MainForm_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void axToolbarControl1_OnMouseMove(object sender, IToolbarControlEvents_OnMouseMoveEvent e)
        {
            Cursor myCursor = getCursor();
            this.Cursor = myCursor;

        }

        private void 属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttrQueryForm formqueryattr = new AttrQueryForm(this.axMapControl1);
            formqueryattr.Show();
        }
        //用于判断空间查询的状态
        bool IsSpatialSearch = false;

        private void 空间查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsSpatialSearch == false)
            {
                IsSpatialSearch = true;
            }
            else
            {
                IsSpatialSearch = false;
                axMapControl1.Map.ClearSelection(); //清除上次查询结果
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
        }
        private DataTable SpatialSearch(ESRI.ArcGIS.Geodatabase.IFeatureClass pFtClass, string pWhereClause, IGeometry pGeometry, ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum pSpRel)
        {
            //定义空间查询过滤器对象
            ESRI.ArcGIS.Geodatabase.ISpatialFilter pSpatialFilter = new ESRI.ArcGIS.Geodatabase.SpatialFilterClass();
            //设置sql查询语句
            pSpatialFilter.WhereClause = pWhereClause;
            //设置查询范围
            pSpatialFilter.Geometry = pGeometry;
            //给定范围与查询对象的空间关系
            pSpatialFilter.SpatialRel = pSpRel;

            axMapControl1.Map.ClearSelection(); //清除上次查询结果
            //查询结果以游标的形式返回(下面与属性查询一样)
            ESRI.ArcGIS.Geodatabase.IFeatureCursor pFtCursor = pFtClass.Search(pSpatialFilter, false);
            
            ESRI.ArcGIS.Geodatabase.IFeature pFt = pFtCursor.NextFeature();
            DataTable DT = new DataTable();
            for (int i = 0; i < pFtCursor.Fields.FieldCount; i++)
            {
                DataColumn dc = new DataColumn(pFtCursor.Fields.get_Field(i).Name,
                    System.Type.GetType(ParseFieldType((pFtCursor.Fields.get_Field(i).Type))));
                DT.Columns.Add(dc);
            }
            while (pFt != null)
            {
                axMapControl1.Map.SelectFeature(pLayer, pFt); //选择要素 
                DataRow dr = DT.NewRow();
                for (int i = 0; i < pFt.Fields.FieldCount; i++)
                {
                    dr[i] = pFt.get_Value(i);
                }
                DT.Rows.Add(dr);
                pFt = pFtCursor.NextFeature();
            }
            return DT;
        }
        private int Get_Layer(string LayerName)
        {
            //遍历主视图的图层
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                //如果图层索引对应的名字和用户输入的名字相同则返回索引
                if (axMapControl1.get_Layer(i).Name.Equals(LayerName))
                {
                    return i;
                }
            }
            return -1;//返回-1
        }
        private static string ParseFieldType(ESRI.ArcGIS.Geodatabase.esriFieldType FieldType)
        {
            switch (FieldType)
            {
                case ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";
                case ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeOID:
                    return "System.Int32";
                case ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeDouble:
                    return "System.Double";
                case ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";
                default:
                    return "System.String";
            }
        }
        //用于判断导航的状态
        bool IsRouteSearch = false;
        RouteForm routeForm = null;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (IsRouteSearch)
            {
                if (routeForm != null)
                {
                    routeForm.Hide();
                }
                IsRouteSearch = false;
            }
            else
            {
                routeForm = new RouteForm(axMapControl1);
                routeForm.Show();
                IsRouteSearch = true;
            }
        }
        
        private void 显示地点名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EnableFeatureLayerLabel(pLayer as IFeatureLayer, "name", null, 6, "name");
        }


        public void EnableFeatureLayerLabel(IFeatureLayer pFeaturelayer, string sLableField, IRgbColor pRGB, int size, string angleField)
        {
            //判断图层是否为空
            if (pFeaturelayer == null)
                return;
            IGeoFeatureLayer pGeoFeaturelayer = (IGeoFeatureLayer)pFeaturelayer;
            IAnnotateLayerPropertiesCollection pAnnoLayerPropsCollection;
            pAnnoLayerPropsCollection = pGeoFeaturelayer.AnnotationProperties;
            pAnnoLayerPropsCollection.Clear();

            stdole.IFontDisp pFont = new stdole.StdFont() as stdole.IFontDisp; ; //字体
            ITextSymbol pTextSymbol;

            pFont.Name = "黑体";
            pFont.Size = 4;
            //未指定字体颜色则默认为黑色
            if (pRGB == null)
            {
                pRGB = new RgbColorClass();
                pRGB.Red = 0;
                pRGB.Green = 0;
                pRGB.Blue = 0;
            }

            pTextSymbol = new TextSymbolClass();
            pTextSymbol.Color = (IColor)pRGB;
            pTextSymbol.Size = size; //标注大小

            IBasicOverposterLayerProperties4 pBasicOverposterlayerProps4 = new BasicOverposterLayerPropertiesClass();
            switch (pFeaturelayer.FeatureClass.ShapeType)//判断图层类型
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    pBasicOverposterlayerProps4.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolygon;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                    pBasicOverposterlayerProps4.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    pBasicOverposterlayerProps4.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                    break;
            }
            pBasicOverposterlayerProps4.PointPlacementMethod = esriOverposterPointPlacementMethod.esriRotationField;
            //pBasicOverposterlayerProps4.RotationField = angleField;

            ILabelEngineLayerProperties pLabelEnginelayerProps = new LabelEngineLayerPropertiesClass();
            pLabelEnginelayerProps.Expression = "[" + sLableField + "]";
            pLabelEnginelayerProps.Symbol = pTextSymbol;
            pLabelEnginelayerProps.BasicOverposterLayerProperties = pBasicOverposterlayerProps4 as IBasicOverposterLayerProperties;
            pAnnoLayerPropsCollection.Add((IAnnotateLayerProperties)pLabelEnginelayerProps);
            pGeoFeaturelayer.DisplayAnnotation = true;//很重要，必须设置 
            //刷新地图
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void 关闭地点名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer pFeaturelayer = pLayer as IFeatureLayer;
            if (pFeaturelayer == null)
                return;
            IGeoFeatureLayer pGeoFeaturelayer = (IGeoFeatureLayer)pFeaturelayer;
            pGeoFeaturelayer.DisplayAnnotation = false;//很重要，必须设置 
            //刷新地图
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.weather.com.cn/weather/101200101.shtml");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}

