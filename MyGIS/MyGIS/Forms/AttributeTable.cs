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

        private void AttributeTable_Load(object sender, System.EventArgs e)
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

        private void EditButton_Click(object sender, System.EventArgs e)
        {
            // 进入编辑状态，允许进行表的修改
            if (EditButton.Text == "开始编辑")
            {
                // 1. 修改按钮内容
                EditButton.Text = "保存并停止编辑";
                // 2. 设置表格的可读属性
                dataGridView1.ReadOnly = false;
            }
            // 退出编辑状态，保存修改内容
            else if (EditButton.Text == "保存并停止编辑")
            {
                // 1. 修改按钮内容
                EditButton.Text = "开始编辑";
                // 2. 设置表格的可读属性
                dataGridView1.ReadOnly = true;
                // 3. 获取表格的行列数
                int columnCount = dataGridView1.Columns.Count;
                int rowCount = dataGridView1.Rows.Count;
                // 4. 遍历每一行（除去最后一个空行），对该行对应的要素进行属性更新
                for (int i = 0; i < rowCount - 1; ++i)
                {
                    // (1) FID是匹配表格行和特定要素的唯一标识
                    int fid = int.Parse((string)dataGridView1.Rows[i].Cells[0].Value);

                    IFeatureLayer pFeatureLayer = mLayer as IFeatureLayer;
                    IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                    IFeature pFeature = pFeatureClass.GetFeature(fid);

                    // (2) 遍历fid和Shape之后的每一列
                    for (int j = 2; j < columnCount; ++j)
                    {
                        // 获取该列的列名
                        string fieldName = dataGridView1.Columns[j].Name;
                        // 根据列名获取该字段的索引
                        int fieldIndex = pFeature.Fields.FindField(fieldName);
                        // 根据该字段的索引获取该字段对象，进而获得其类型
                        esriFieldType fieldType =  pFeature.Fields.get_Field(fieldIndex).Type;
                        // 新建一个object对象用来存储字段值，系统中涉及到的字段类型包括int和string
                        object fieldValue = new object();
                        // 如果字段类型为string，则将该单元格内的值转换为string
                        if (fieldType == esriFieldType.esriFieldTypeString)
                        {
                            fieldValue = (string)dataGridView1.Rows[i].Cells[j].Value;
                        }
                        // 如果字段类型为int，则将该单元格内的值转换为string并用int类型进行解析
                        else if (fieldType == esriFieldType.esriFieldTypeInteger)
                        {
                            fieldValue = int.Parse((string)dataGridView1.Rows[i].Cells[j].Value);
                        }
                        // 根据字段索引和单元格内的值类更新该要素的属性
                        pFeature.set_Value(fieldIndex, fieldValue);
                        // 保存
                        pFeature.Store();
                    }
                }
            }
        }



    }
}
