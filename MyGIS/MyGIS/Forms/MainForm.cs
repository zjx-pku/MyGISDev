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
        private object missing;
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

        private void EditPolyline()
        {
            oprFlag = Operation.ConstructionPolyLine;
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
                oprFlag = Operation.Nothing;
            }
        }


        private void 绘制地层线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPolyline();
        }

        private void 绘制断层线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPolyline();
        }

        private void 绘制标注ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 点ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditPoint();
        }

        private void 线ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditPolyline();
        }

        private void 面ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EditPolygon();
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

        #region 界面左下角显示鼠标位置
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
        #endregion

        #region MapControl触发的事件函数
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
                    missing = Type.Missing;

                    //axMapControl1控件的当前地图工具为空
                    axMapControl1.CurrentTool = null;

                    //定义集合类型绘制折线的方法
                    pGeometry = axMapControl1.TrackLine();

                    AddFeatureOnLayer("polyline", pGeometry);
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
