using System;

namespace Tetris2
{
	/// <summary>
	/// 以网格坐标为坐标的点结构
	/// </summary>
	public struct GirdPoint
	{
		public int X;
		public int Y;

		public GirdPoint(int x, int y)
		{
			if(x<-1 || x>=Globals.CountOfTier)
			{
				throw new Exception("初始化GirdPoint时采用了不合理的x值\n其应该在(0,"+Globals.CountOfTier+")之间,目前值"+x);
			}

			if(y<0 || y>=Globals.CountOfRow)
			{
				throw new Exception("初始化GirdPoint时采用了不合理的y值\n其应该在(0,"+Globals.CountOfRow+")之间目前值"+y);
			}

			this.X = x;
			this.Y = y;
		}


	}
	
}