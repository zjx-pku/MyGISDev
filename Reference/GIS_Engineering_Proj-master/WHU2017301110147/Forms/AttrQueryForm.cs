using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace WHU2017301110147.Forms
{
    public partial class AttrQueryForm : Form
    {
        
        //地图数据 
        private AxMapControl mMapControl;
        //选中的图层 
        private IFeatureLayer mFeatureLayer;
        //根据所选择的图层查询得到的特征类
        private IFeatureClass pFeatureClass = null;
        public AttrQueryForm(AxMapControl mapControl)//传递参数mapControl
        {
            InitializeComponent();
            this.mMapControl = mapControl;
        }


        public AttrQueryForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "and ";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = " ";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AttrQueryForm_Load(object sender, EventArgs e)
        {
            //MapControl中没有图层时返回 
            if (this.mMapControl.LayerCount <= 0)
                return;
            //获取MapControl中的全部图层名称，并加入ComboBox 
            //图层 
            ILayer pLayer;
            //图层名称 
            string strLayerName;
            for (int i = 0; i < this.mMapControl.LayerCount; i++)
            {
                pLayer = this.mMapControl.get_Layer(i);
                strLayerName = pLayer.Name;
                //图层名称加入cboLayer 
                this.cboLayer.Items.Add(strLayerName);
            }
            //默认显示第一个选项 
            this.cboLayer.SelectedIndex = 0;
        }

        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxField.Items.Clear();
            //获取cboLayer中选中的图层 
            mFeatureLayer = mMapControl.get_Layer(cboLayer.SelectedIndex) as IFeatureLayer;
            pFeatureClass = mFeatureLayer.FeatureClass;
            string strFldName;
            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {
                strFldName = pFeatureClass.Fields.get_Field(i).Name;
                this.listBoxField.Items.Add(strFldName);
            }
            this.listBoxField.SelectedIndex = 0;

        }

        private void listBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sFieldName = listBoxField.Text;
            listBoxValue.Items.Clear();
            int iFieldIndex = 0;
            IField pField = null;
            IFeatureCursor pFeatCursor = pFeatureClass.Search(null, true);
            IFeature pFeat = pFeatCursor.NextFeature();
            iFieldIndex = pFeatureClass.FindField(sFieldName);
            pField = pFeatureClass.Fields.get_Field(iFieldIndex);
            while (pFeat != null)
            {
                if (!" ".Equals(pFeat.get_Value(iFieldIndex)))
                {
                    listBoxValue.Items.Add(pFeat.get_Value(iFieldIndex));
                    
                }
                pFeat = pFeatCursor.NextFeature();
            }

        }

        private void listBoxField_DoubleClick(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = listBoxField.SelectedItem.ToString() + " ";
        }

        private void listBoxValue_DoubleClick(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = listBoxValue.SelectedItem.ToString() + " ";
        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "= ";
        }

        private void btnunequal_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "!= ";

        }

        private void btnis_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "is ";

        }

        private void btnlike_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "like ";

        }

        private void btnmore_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "> ";

        }

        private void btnmoe_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = ">= ";

        }

        private void btnloe_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "<= ";

        }

        private void btnor_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "or ";

        }

        private void btnnull_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "null ";

        }

        private void btnless_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "< ";

        }

        private void btnnot_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "not ";

        }

        private void btnin_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "in ";

        }

        private void btnunderline_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "_ ";

        }

        private void btnpercent_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "% ";

        }

        private void btncharacter_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "''";

        }

        private void btnbetween_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "between ";

        }

        private void btnempty_Click(object sender, EventArgs e)
        {
            textBoxSql.Clear();

        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            try
            {
                mMapControl.Map.ClearSelection(); //清除上次查询结果
                IActiveView pActiveView = mMapControl.Map as IActiveView;
                //pQueryFilter的实例化 
                IQueryFilter pQueryFilter = new QueryFilterClass();
                //设置查询过滤条件 
                pQueryFilter.WhereClause = textBoxSql.Text;
                //search的参数第一个为过滤条件，第二个为是否重复执行
                IFeatureCursor pFeatureCursor = mFeatureLayer.Search(pQueryFilter, false);
                //获取查询到的要素 
                IFeature pFeature = pFeatureCursor.NextFeature();
                //判断是否获取到要素 
                while (pFeature != null)
                {
                    mMapControl.Map.SelectFeature(mFeatureLayer, pFeature); //选择要素 
                    //放大到要素
                    //IEnvelope pEnv = null;
                    //IGeometry geometry = pFeature.Shape;
                    //pEnv = geometry.Envelope;
                    //简化几何
                    //ITopologicalOperator mTopologicalOperator = (ITopologicalOperator2)((IPolygon)pFeature.ShapeCopy);
                    //if (mTopologicalOperator.IsSimple == false)
                    //{
                    //    mTopologicalOperator.Simplify();
                    //}
                    //缓冲
                    //IPolygon mPolygonBuffer = (IPolygon)mTopologicalOperator.Buffer(5.0) ;
                    /*
                    if (geometry.GeometryType != esriGeometryType.esriGeometryPoint)
                    {
                        mMapControl.Extent = ;
                        pEnv.Expand(1.5, 1.5, true);
                    }
                    else
                    {
                        pEnv.Expand(5, 5, false);
                    }
                    mMapControl.Extent = pEnv;
                    */
                    mMapControl.Extent = pFeature.Shape.Envelope;
                    pFeature = pFeatureCursor.NextFeature();
                }
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                pActiveView.Refresh();//刷新图层
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void listBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSql_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

