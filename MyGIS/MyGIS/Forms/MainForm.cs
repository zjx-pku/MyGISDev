using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyGIS.Forms
{
    public partial class MainForm : Form
    {
        private ILayer pGlobalFeatureLayer;
        private Operation oprFlag;
        private PolylineClass geoCollection;
        private PolylineClass ptCollection;
        private object missing;
        private IGeometry pGeometry;
        private ILayer relayer;//存储最终获取的图层


        public MainForm()
        {
            InitializeComponent();
        }

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


        //定义一个Operation枚举
        enum Operation
        {
            ConstructionPoint,//绘制点
            ConstructionPolyLine,//绘制线
            ConstructionPolygon,//绘制面
            Nothing
        }

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
            catch
            { }

        }

        private void 点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oprFlag = Operation.ConstructionPoint;
        }


        private void 折线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oprFlag = Operation.ConstructionPolyLine;
            geoCollection = new PolylineClass();
            ptCollection = new PolylineClass();
        }

        private void 面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oprFlag = Operation.ConstructionPolygon;
        }

        /// <summary>
        /// axMapContol控件的鼠标单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //表示 System.Type 信息中的缺少值。 此字段为只读。
            missing = Type.Missing;
            //若为添加点的事件
            if (oprFlag == Operation.ConstructionPoint)
            {
                //axMapControl1控件的当前地图工具为空
                axMapControl1.CurrentTool = null;
                //通过AddPointByStore函数, 获取绘制点的图层——Cities
                //从GetPoint函数获取点的坐标
                AddPointByStore("Cities", GetPoint(e.mapX, e.mapY) as IPoint);
                //点添加完之后结束编辑状态
                oprFlag = Operation.Nothing;
            }
            //若为添加折线的事件
            if (oprFlag == Operation.ConstructionPolyLine)
            {
                //axMapControl1控件的当前地图工具为空
                axMapControl1.CurrentTool = null;
                //获取鼠标单击的坐标
                //ref参数能够将一个变量带入一个方法中进行改变, 改变完成后, 再将改变后的值带出方法
                //ref参数要求在方法外必须为其赋值, 而方法内可以不赋值
                ptCollection.AddPoint(GetPoint(e.mapX, e.mapY), ref missing, ref missing);
                //定义集合类型绘制折线的方法
                pGeometry = axMapControl1.TrackLine();

                //通过addFeature函数的两个参数, Highways——绘制折线的图层; Geometry——绘制的几何折线
                AddFeature("Highways", pGeometry);

                //折线添加完之后结束编辑状态
                oprFlag = Operation.Nothing;
            }
            //若为添加面的事件
            if (oprFlag == Operation.ConstructionPolygon)
            {
                //axMapControl1控件的当前地图工具为空
                axMapControl1.CurrentTool = null;
                //
                CreateDrawPolygon(axMapControl1.ActiveView, "Counties");
                //面添加完之后结束编辑状态
                oprFlag = Operation.Nothing;
            }
        }

        /// <summary>
        /// 获取绘制点的图层——Cities, 保存点绘制的函数
        /// </summary>
        /// <param name="pointLayerName"></param>
        /// <param name="point"></param>
        private void AddPointByStore(string pointLayerName, IPoint pt)
        {
            //得到要添加地物的图层
            IFeatureLayer pFeatureLayer = GetLayerByName(pointLayerName) as IFeatureLayer;
            if (pFeatureLayer != null)
            {
                //定义一个地物类, 把要编辑的图层转化为定义的地物类
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                //先定义一个编辑的工作空间, 然后将其转化为数据集, 最后转化为编辑工作空间
                IWorkspaceEdit w = (pFeatureClass as IDataset).Workspace as IWorkspaceEdit;
                IFeature pFeature;
                //开始事务操作
                w.StartEditing(false);
                //开始编辑
                w.StartEditOperation();
                //创建一个(点)要素
                pFeature = pFeatureClass.CreateFeature();
                //赋值该要素的Shape属性
                pFeature.Shape = pt;

                //保存要素, 完成点要素生成
                //此时生成的点要素只要集合特征(shape/Geometry), 无普通属性
                pFeature.Store();

                //结束编辑
                w.StopEditOperation();
                //结束事务操作
                w.StopEditing(true);

            }
            //屏幕刷新
            this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, pFeatureLayer, null);

        }

        /// <summary>
        /// 获取鼠标单击时的坐标位置信息
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private IPoint GetPoint(double x, double y)
        {
            IPoint pt = new PointClass();
            pt.PutCoords(x, y);
            return pt;
        }

        /// <summary>
        /// 添加实体对象到地图图层(添加线、面要素)
        /// </summary>
        /// <param name="layerName">图层名称</param>
        /// <param name="pGeometry">绘制形状(线、面)</param>
        private void AddFeature(string layerName, IGeometry pGeometry)
        {
            ILayer pLayer = GetLayerByName(layerName);
            //得到要添加地物的图层
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            if (pFeatureLayer != null)
            {
                //定义一个地物类, 把要编辑的图层转化为定义的地物类
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                //先定义一个编辑的工作空间, 然后将其转化为数据集, 最后转化为编辑工作空间
                IWorkspaceEdit w = (pFeatureClass as IDataset).Workspace as IWorkspaceEdit;
                IFeature pFeature;

                //开始事务操作
                w.StartEditing(true);
                //开始编辑
                w.StartEditOperation();

                //在内存创建一个用于暂时存放编辑数据的要素(FeatureBuffer)
                IFeatureBuffer pFeatureBuffer = pFeatureClass.CreateFeatureBuffer();
                //定义游标
                IFeatureCursor pFtCursor;
                //查找到最后一条记录, 游标指向该记录后再进行插入操作
                pFtCursor = pFeatureClass.Search(null, true);
                pFeature = pFtCursor.NextFeature();
                //开始插入新的实体对象(插入对象要使用Insert游标)
                pFtCursor = pFeatureClass.Insert(true);
                try
                {
                    //向缓存游标的Shape属性赋值
                    pFeatureBuffer.Shape = pGeometry;
                }
                catch (COMException ex)
                {
                    MessageBox.Show("绘制的几何图形超出了边界！");
                    return;
                }
                //判断:几何图形是否为多边形
                if (pGeometry.GeometryType.ToString() == "esriGeometryPolygon")
                {
                    int index = pFeatureBuffer.Fields.FindField("STATE_NAME");
                    pFeatureBuffer.set_Value(index, "California");
                }
                object featureOID = pFtCursor.InsertFeature(pFeatureBuffer);
                //保存实体
                pFtCursor.Flush();

                //结束编辑
                w.StopEditOperation();
                //结束事务操作
                w.StopEditing(true);

                //释放游标
                Marshal.ReleaseComObject(pFtCursor);
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, pLayer, null);
            }
            else
            {
                MessageBox.Show("未发现" + layerName + "图层");
            }
        }

        /// <summary>
        /// 添加面事件
        /// </summary>
        /// <param name="activeView"></param>
        /// <param name="v"></param>
        private void CreateDrawPolygon(IActiveView activeView, string sLayer)
        {
            //绘制多边形事件
            pGeometry = axMapControl1.TrackPolygon();
            //通过AddFeature函数的两个参数, sLayer——绘制折线的图层; pGeometry——绘制几何的图层
            AddFeature(sLayer, pGeometry);
        }

        //根据图层名称获取图层
        private ILayer GetLayerByName(string LayerName)
        {
            relayer = null;
            ICompositeLayer pCompositeLayer;
            for (int i = 0; i < axMapControl1.LayerCount; i++)//遍历所有图层
            {
                if (axMapControl1.get_Layer(i) is ICompositeLayer)
                {
                    string test = axMapControl1.get_Layer(i).Name;
                    pCompositeLayer = axMapControl1.get_Layer(i) as ICompositeLayer;
                    Togetlayer(pCompositeLayer, LayerName);
                    if (relayer != null)
                    {
                        return relayer;
                    }
                }
                else if (axMapControl1.get_Layer(i).Name == LayerName)
                {
                    return axMapControl1.get_Layer(i);
                }
            }
            return null;
        }

        //遍历要素集下的所有图层
        private void Togetlayer(ICompositeLayer pCompositeLayer, string name)
        {
            ICompositeLayer icolayer;
            for (int i = 0; i < pCompositeLayer.Count; i++)
            {
                string test = pCompositeLayer.get_Layer(i).Name;
                if (pCompositeLayer.get_Layer(i) is ICompositeLayer)
                {
                    icolayer = pCompositeLayer.get_Layer(i) as ICompositeLayer;
                    Togetlayer(icolayer, name);
                }
                if (pCompositeLayer.get_Layer(i).Name == name)
                {
                    relayer = pCompositeLayer.get_Layer(i);
                }
            }
        }


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
                绘制标注ToolStripMenuItem.Enabled = true;
                绘制一般图形ToolStripMenuItem.Enabled = true;
                编辑状态ToolStripMenuItem.Text = "停止编辑";
            }
            else if (编辑状态ToolStripMenuItem.Text == "停止编辑")
            {
                绘制地层线ToolStripMenuItem.Enabled = false;
                绘制断层线ToolStripMenuItem.Enabled = false;
                绘制标注ToolStripMenuItem.Enabled = false;
                绘制一般图形ToolStripMenuItem.Enabled = false;
                编辑状态ToolStripMenuItem.Text = "开始编辑";
            }
        }


        private void 绘制地层线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 绘制断层线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 绘制标注ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 点ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 线ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 面ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
