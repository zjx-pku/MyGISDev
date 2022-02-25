using System;

namespace Team3
{
	public struct Shape
	{
		/// <summary>
		/// 获取或设置该形状的索引值
		/// </summary>
		public int Index;

	    /// <summary>
	    /// 获取或设置一个数组，其为该形状的相对于基础点的相对网格坐标组
	    /// </summary>
		public int[] DCoordinates;

		/// <summary>
		/// 获取或设置该形状旋转后的新形状的索引
		/// </summary>
		public int EddiedIndex;

		public Shape(int index, int[] dCoordinates, int eddiedIndex)
		{
			this.Index = index;
			this.DCoordinates = dCoordinates;
			this.EddiedIndex = eddiedIndex;
		}
	}
}