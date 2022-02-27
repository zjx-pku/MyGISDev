using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using System;
using System.Windows.Forms;

namespace MyGIS.Forms
{
    public partial class MainForm : Form
    {
        private ILayer pGlobalFeatureLayer;

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

        private void 地层界线点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCollect dataCollect = new DataCollect();
            dataCollect.Show();
        }

    }
}
