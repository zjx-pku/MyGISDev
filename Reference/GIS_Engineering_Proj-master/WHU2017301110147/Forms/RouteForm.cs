using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHU2017301110147.Classes;

namespace WHU2017301110147.Forms
{
    public partial class RouteForm : Form
    {
        //地图数据 
        private AxMapControl mMapControl;
        public RouteForm()
        {
            InitializeComponent();
        }
        public RouteForm(AxMapControl mMapControl)
        {
            InitializeComponent();
            this.mMapControl = mMapControl;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private IElement pElement = null;
        //路径起止点
        public double startX = 0, startY = 0;
        public double endX = 0, endY = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //当确定按钮被点击时
            //连接数据库，路径规划
            //string sqlstr = "select ST_asbinary(ST_Union(geom)) as route from pgr_fromAtoB('whu_road_feature2line'::text,114.353,30.539,114.367,30.544) ;";
            string sqlstr = null;
            if ((startX * startY * endX * endY) != 0)
                sqlstr = "select ST_asbinary(ST_Union(geom)) as route from pgr_fromAtoB('whu_road_feature2line'::text," + startX + "," + startY + "," + endX + "," + endY + ") ;";
            else
            {
                MessageBox.Show("起始点或终止点不能为空");
                return;
            }
            Byte[] routeWKB = DAO.executeRouteQuery(sqlstr);
            IGeometry geom;
            int countin = routeWKB.GetLength(0);
            //地图容器，创建临时元素
            IMap pMap = mMapControl.Map;
            IActiveView pActiveView = pMap as IActiveView;
            IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
            if (pElement != null)
            {
                pGraphicsContainer.DeleteElement(pElement);
            }
            //转换wkb为IGeometry
            IGeometryFactory3 factory = new GeometryEnvironment() as IGeometryFactory3;
            factory.CreateGeometryFromWkbVariant(routeWKB, out geom, out countin);
            IPolyline pLine = (IPolyline)geom;
            
            //定义要素symbol
            ISimpleLineSymbol pLineSym = new SimpleLineSymbol();
            IRgbColor pColor = new RgbColor();
            pColor.Red = 11;
            pColor.Green = 120;
            pColor.Blue = 233;
            pLineSym.Color = pColor;
            pLineSym.Style = esriSimpleLineStyle.esriSLSSolid;
            pLineSym.Width = 2;
            //线元素symbol绑定
            ILineElement pLineElement = new LineElementClass();
            pLineElement.Symbol = pLineSym;
            //添加geom
            pElement = pLineElement as IElement;
            pElement.Geometry = pLine;
            //加入地图并刷新
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.Refresh();
            //object symbol = pLineSym as object;
            //mMapControl.DrawShape(pLine, ref symbol);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public bool IsStartTextBoxSelected = true;
        private void button4_Click(object sender, EventArgs e)
        {
            if (!IsStartTextBoxSelected) IsStartTextBoxSelected = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (IsStartTextBoxSelected) IsStartTextBoxSelected = false;
        }
        public void fillText(double X,double Y)
        {
            if (IsStartTextBoxSelected)
            {
                textBox1.Text = X + "," + Y;
                startX = X;
                startY = Y;
            }
            else
            {
                textBox2.Text = X + "," + Y;
                endX = X;
                endY = Y;
            }
            
        }
    }
}
