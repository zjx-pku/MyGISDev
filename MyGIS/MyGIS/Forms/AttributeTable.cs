using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Data;
using System.Windows.Forms;

namespace MyGIS.Forms
{
    /// <summary>
    /// 图层的“属性列表”类
    /// </summary>
    public partial class AttributeTable : Form
    {
        #region 成员变量
        private ILayer mLayer;      // 要素类图层
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pFeatureLayer">待查看属性的要素类图层对象</param>
        public AttributeTable(ILayer pFeatureLayer)
        {
            InitializeComponent();  // 初始化组件
            mLayer = pFeatureLayer; // 将待查看属性的要素类图层对象保存到mLayer中，便于后续操作
        }
        #endregion

        #region 事件
        /// <summary>
        /// 当加载该“属性列表”界面时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributeTable_Load(object sender, System.EventArgs e)
        {
            // (1) 获取待查看属性的要素类图层对象mLayer的要素类对象pFeatureClass
            IFeatureLayer pFeatureLayer = mLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            // (2) 新建一个数据表对象dataTable
            DataTable dataTable = new DataTable();

            // (3) 读取上述要素类对象pFeatureClass中的数据，写入数据表dataTable中
            if (pFeatureClass != null)
            {
                // 新建数据表列对象dataColumn
                DataColumn dataColumn;

                // 遍历要素类对象pFeatureClass的所有字段，根据当前字段名初始化数据表列对象dataColumn并添加到dataTable中
                for (int i = 0; i < pFeatureClass.Fields.FieldCount; ++i)
                {
                    dataColumn = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                    dataTable.Columns.Add(dataColumn);
                }

                // 新建IFeatureCursor对象，使用它来读取一系列要素对象
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);

                // 新建要素对象pFeature，赋值为pFeatureCursor读取得到的第一个要素对象
                IFeature pFeature = pFeatureCursor.NextFeature();

                // 新建数据表行对象dataRow
                DataRow dataRow;

                // 循环读取要素类对象pFeatureClass中的所有要素对象pFeature的属性，写入dataRow中并放在dataTable里面
                while (pFeature != null)
                {
                    // 新建一行
                    dataRow = dataTable.NewRow();

                    // 遍历当前要素对象pFeature的所有属性字段
                    for (int j = 0; j < pFeatureClass.Fields.FieldCount; ++j)
                    {
                        // 如果属性字段名为Shape，则根据该要素对象的类型（点、线、面）赋予不同值
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
                        // 否则，只需直接读取该要素对象位于当前字段的值并转为String写入dataRow之中
                        else
                        {
                            dataRow[j] = pFeature.get_Value(j).ToString();
                        }
                    }

                    // 将写好数据的dataRow加到dataTable中
                    dataTable.Rows.Add(dataRow);

                    // 读取下一个要素赋值给pFeature
                    pFeature = pFeatureCursor.NextFeature();
                }

                // 将dataGridView1的数据源设置为上述表格dataTable，实现数据的显示
                dataGridView1.DataSource = dataTable;
            }
        }

        /// <summary>
        /// “开始编辑”按钮被点击后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    // (2) 遍历fid和Shape之后的每一列（因此从j=2开始）
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
                            fieldValue = int.Parse(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value));
                        }
                        // 如果字段类型为double，则将该单元格内的值转换为string并用double类型进行解析
                        else if (fieldType == esriFieldType.esriFieldTypeDouble)
                        {
                            fieldValue = double.Parse(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value));
                        }

                        // 根据字段索引和单元格内的值类更新该要素的属性
                        pFeature.set_Value(fieldIndex, fieldValue);
                        
                        // 保存
                        pFeature.Store();
                    }
                }
            }
        }
        #endregion
    }
}
