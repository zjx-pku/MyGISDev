using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Team3
{
	/// <summary>
	/// 包含了关于形状的数据和操作
	/// </summary>
	public class AllShapes
	{
		/// <summary>
		/// 获取一个数组， 该数组保存了索引的形状
		/// </summary>
		public static readonly Shape[] Shapes = new Shape[19]
			{
				new Shape(0,new int[8]{0,2,1,2,2,2,3,2},1),
				new Shape(1,new int[8]{1,0,1,1,1,2,1,3},0),
				new Shape(2,new int[8]{0,0,0,1,0,2,1,2},3),
				new Shape(3,new int[8]{0,2,1,2,2,2,0,3},4),
				new Shape(4,new int[8]{0,1,1,1,1,2,1,3},5),
				new Shape(5,new int[8]{2,1,0,2,1,2,2,2},2),
				new Shape(6,new int[8]{0,2,1,2,0,3,1,3},6),
				new Shape(7,new int[8]{1,1,0,2,1,2,0,3},8),
				new Shape(8,new int[8]{0,1,1,1,1,2,2,2},7),
				new Shape(9,new int[8]{1,1,1,2,0,3,1,3},10),
				new Shape(10,new int[8]{0,1,0,2,1,2,2,2},11),
				new Shape(11,new int[8]{1,1,2,1,1,2,1,3},12),
				new Shape(12,new int[8]{0,2,1,2,2,2,2,3},9),
				new Shape(13,new int[8]{0,1,0,2,1,2,1,3},14),
				new Shape(14,new int[8]{1,1,2,1,0,2,1,2},13),
				new Shape(15,new int[8]{1,1,0,2,1,2,2,2},16),
				new Shape(16,new int[8]{1,1,1,2,2,2,1,3},17),
				new Shape(17,new int[8]{0,2,1,2,2,2,1,3},18),
				new Shape(18,new int[8]{1,1,0,2,1,2,1,3},15),
		};

		/// <summary>
		/// 用于控制形状自动下落的计时器
		/// </summary>
		public static System.Timers.Timer timer = new System.Timers.Timer(Globals.SpeedTime);

		static AllShapes()
		{
			timer.Stop();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
		}
		private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			MoveAndRotate.ToDown(Globals.IndexOfCurrentShape);
		}
	}

}
