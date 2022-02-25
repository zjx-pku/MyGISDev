using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;


namespace WHU2017301110147
{
    public partial class AttributeForm : Form
    {
        private ILayer pLayer;//打开属性表的图层
        private IFeatureLayer pFeatureLayer;
        private IFeatureClass pFeatureClass;
        private ILayerFields pLayerFields;
        public AttributeForm()
        {
            InitializeComponent();
        }
        public AttributeForm(ILayer pLyr)
        {
            InitializeComponent();
            pLayer = pLyr;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AttributeForm_Load(object sender, EventArgs e)
        {
            try
            {
                string tableName;
                tableName = getValidFeatureClassName(pLayer.Name);//从图层名中获取图层名
                this.Text = tableName + "属性表".ToString();//替换窗体名称
                pFeatureLayer = pLayer as IFeatureLayer;
                pFeatureClass = pFeatureLayer.FeatureClass;
                pLayerFields = pFeatureLayer as ILayerFields;
                DataTable dt = new DataTable(pFeatureLayer.Name);//实例化数据表
                DataColumn dc = null;
                for (int i = 0; i < pLayerFields.FieldCount; i++)
                {
                    //通过实例化获取数据表的字段名
                    dc = new DataColumn(pLayerFields.get_Field(i).Name);
                    dt.Columns.Add(dc);//在数据表得到列
                    dc = null;
                }
                //
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)//当要素不为空
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < pLayerFields.FieldCount; j++)
                    {// 在pLayerFields对象中找到pFeatureClass.ShapeFieldName的索引，并在数据表中显示该shape的类型。                      
                        if (pLayerFields.FindField(pFeatureClass.ShapeFieldName) == j)
                        {
                            dr[j] = pFeatureClass.ShapeType.ToString();// pFeatureClass.ShapeType得到类型值，然后转换为字符串。若没有该句就无法显示形状类型，效果见下页。
                        }
                        else
                        {
                            dr[j] = pFeature.get_Value(j);//直接返回这个值
                        }
                    }
                    dt.Rows.Add(dr);
                    pFeature = pFeatureCursor.NextFeature();//游标下移
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show("读取属性表失败：" + exc.Message);
                this.Dispose();
            }
        }
        private string getValidFeatureClassName(string FCname)
        {
            int dot = FCname.IndexOf(".");
            if (dot != -1)
            {
                return FCname.Replace(".", "_");
            }
            return FCname;
        }
    }

    

}
