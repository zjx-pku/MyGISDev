using System;

namespace Tetris2
{
	/// <summary>
	/// ����������Ϊ����ĵ�ṹ
	/// </summary>
	public struct GirdPoint
	{
		public int X;
		public int Y;

		public GirdPoint(int x, int y)
		{
			if(x<-1 || x>=Globals.CountOfTier)
			{
				throw new Exception("��ʼ��GirdPointʱ�����˲������xֵ\n��Ӧ����(0,"+Globals.CountOfTier+")֮��,Ŀǰֵ"+x);
			}

			if(y<0 || y>=Globals.CountOfRow)
			{
				throw new Exception("��ʼ��GirdPointʱ�����˲������yֵ\n��Ӧ����(0,"+Globals.CountOfRow+")֮��Ŀǰֵ"+y);
			}

			this.X = x;
			this.Y = y;
		}


	}
	
}