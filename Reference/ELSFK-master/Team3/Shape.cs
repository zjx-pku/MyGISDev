using System;

namespace Team3
{
	public struct Shape
	{
		/// <summary>
		/// ��ȡ�����ø���״������ֵ
		/// </summary>
		public int Index;

	    /// <summary>
	    /// ��ȡ������һ�����飬��Ϊ����״������ڻ�������������������
	    /// </summary>
		public int[] DCoordinates;

		/// <summary>
		/// ��ȡ�����ø���״��ת�������״������
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