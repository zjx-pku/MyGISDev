using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System.Data;
using System.Windows.Forms;

namespace MyGIS.Forms
{
    public partial class AttributeTable : Form
    {
        ILayer mLayer;

        public AttributeTable(ILayer pFeatureLayer)
        {
            InitializeComponent();
            mLayer = pFeatureLayer;
        }

        private void FormTable_Load(object sender, System.EventArgs e)
        {
            IFeatureLayer pFeatureLayer = mLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            DataTable dataTable = new DataTable();
            if (pFeatureClass != null)
            {
                DataColumn dataColumn;
                for (int i = 0; i < pFeatureClass.Fields.FieldCount; ++i)
                {
                    dataColumn = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                    dataTable.Columns.Add(dataColumn);
                }

                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                DataRow dataRow;

                while (pFeature != null)
                {
                    dataRow = dataTable.NewRow();
                    for (int j = 0; j < pFeatureClass.Fields.FieldCount; ++j)
                    {
                        if (pFeature.Fields.get_Field(j).Name == "Shape")
                        {
                            if (pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
                            {
                                dataRow[j] = '点';
                            }
                            if (pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPolyline)
                            {
                                dataRow[j] = '线';
                            }
                            if (pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon)
                            {
                                dataRow[j] = '面';
                            }
                        }
                        else
                        {
                            dataRow[j] = pFeature.get_Value(j).ToString();
                        }
                    }
                    dataTable.Rows.Add(dataRow);
                    pFeature = pFeatureCursor.NextFeature();
                }
                dataGridView1.DataSource = dataTable;
            }

        }


    }
}
