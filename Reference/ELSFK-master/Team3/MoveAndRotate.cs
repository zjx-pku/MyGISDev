using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Threading;
namespace Team3
{
    class MoveAndRotate
    {
		//public static System.Timers.Timer timer = new System.Timers.Timer(Globals.SpeedTime);

		/// <summary>
		/// 按照指定索引生成新的预览形状
		/// </summary>
		/// <param name="indexOfShape">指定的形状索引</param>
		public static void MakeNewViewShape(int indexOfShape)
		{
			AssembleViewShape(indexOfShape);
		}

		/// <summary>
		/// 旋转当前形状
		/// </summary>
		/// <param name="indexOfShape">当前形状的索引号</param>
		public static void Eddy(int indexOfShape)
		{

			if (!canEddy(indexOfShape))
			{
				return;
			}

			int eddiedIndex = AllShapes.Shapes[indexOfShape].EddiedIndex;//旋转后的新形状的索引

			AssembleShape(eddiedIndex);//重新组合成新形状

			Globals.IndexOfCurrentShape = eddiedIndex;//将旋转后新形状的索引设置为当前索引
		}



		/// <summary>
		/// 将当前形状向左移动一格（如果能的话）
		/// </summary>
		/// <param name="indexOfShape">当前形状的索引号</param>
		public static void ToLeft(int indexOfShape)
		{
			if (!CanMove(indexOfShape, 'L'))
			{
				return;
			}

			//Globals.BasePoint.GOffset(-1,0);此句失败
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X - 1, Globals.BasePoint.Y);
			AssembleShape(indexOfShape);

		}

		/// <summary>
		/// 将当前形状向右移动一格（如果能的话）
		/// </summary>
		/// <param name="indexOfShape">当前形状的索引号</param>
		public static void ToRight(int indexOfShape)
		{
			if (!CanMove(indexOfShape, 'R'))
			{
				return;
			}

			//Globals.BasePoint.GOffset(1,0);此句失败
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X + 1, Globals.BasePoint.Y);
			AssembleShape(indexOfShape);
		}


		/// <summary>
		/// 将当前形状向下移动一格（如果能的话）
		/// </summary>
		/// <param name="indexOfShape">当前形状的索引号</param>
		public static void ToDown(int indexOfShape)
		{
			if (!CanMove(indexOfShape, 'D'))
			{
				ThreadStart tStart = new ThreadStart(ScanFullLines.FixShape);
				Thread thread = new Thread(tStart);
				thread.Start();
				return;
			}

			//Globals.BasePoint.GOffset(0,1);此句失败
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X, Globals.BasePoint.Y + 1);
			AssembleShape(indexOfShape);
		}


		/// <summary>
		/// 启动自动下落
		/// </summary>
		/// <param name="b">true启动，false关闭</param>
		public static void AutoDown(bool b)
		{
			if (b)
			{
				AllShapes.timer.Start();
			}
			else
			{
				AllShapes.timer.Stop();
			}
		}


		/// <summary>
		/// 产生新形状并下落
		/// </summary>
		public static void MakeNewShape()
		{
			if (Game.State == GameStates.Playing)
			{
				Globals.IndexOfCurrentShape = Globals.NextIndexOfShape;
				Random rand = new Random();
				Globals.NextIndexOfShape = rand.Next(18);

				//MakeNewViewShape(Globals.NextIndexOfShape);//显示预览形状
				//由于产生新形状时采用了AllShapes.Eddy(Globals.IndexOfCurrentShape);所以这里采用了下面的一句，而不是上面注释掉的
				//否则出现的新形状与预览形状相差90度
				MakeNewViewShape(AllShapes.Shapes[Globals.NextIndexOfShape].EddiedIndex);

				Globals.BasePoint = new GirdPoint(0, 0);
				MoveAndRotate.Eddy(Globals.IndexOfCurrentShape);
			}
		}


		//探测能否旋转
		private static bool canEddy(int indexOfShape)
		{
			int eddiedIndex = AllShapes.Shapes[indexOfShape].EddiedIndex;//旋转后的新形状的索引
			return CanMove(eddiedIndex, 'E');
		}


		private static bool CanMove(int indexOfShape, char arg)
		{
			try
			{
				GirdPoint tempBasePoint;

				switch (arg)
				{
					case 'L':
						tempBasePoint = new GirdPoint(Globals.BasePoint.X - 1, Globals.BasePoint.Y);
						break;
					case 'R':
						tempBasePoint = new GirdPoint(Globals.BasePoint.X + 1, Globals.BasePoint.Y);
						break;
					case 'D':
						tempBasePoint = new GirdPoint(Globals.BasePoint.X, Globals.BasePoint.Y + 1);
						break;
					case 'E'://不移动，用于判断能否旋转，与判断移动不同的是传入的indexOfShape，判断旋转用的是旋转后的形状的索引，而移动用的是当前的
						tempBasePoint = Globals.BasePoint;
						break;
					default:
						MessageBox.Show("错误的参数" + arg + "\n应该为'L'或'R'或'D'");
						return false;

				}

				int gX0 = AllShapes.Shapes[indexOfShape].DCoordinates[0] + tempBasePoint.X;
				int gY0 = AllShapes.Shapes[indexOfShape].DCoordinates[1] + tempBasePoint.Y;
				int i = Globals.GirdArray[gY0, gX0];

				int gX1 = AllShapes.Shapes[indexOfShape].DCoordinates[2] + tempBasePoint.X;
				int gY1 = AllShapes.Shapes[indexOfShape].DCoordinates[3] + tempBasePoint.Y;
				int j = Globals.GirdArray[gY1, gX1];

				int gX2 = AllShapes.Shapes[indexOfShape].DCoordinates[4] + tempBasePoint.X;
				int gY2 = AllShapes.Shapes[indexOfShape].DCoordinates[5] + tempBasePoint.Y;
				int m = Globals.GirdArray[gY2, gX2];

				int gX3 = AllShapes.Shapes[indexOfShape].DCoordinates[6] + tempBasePoint.X;
				int gY3 = AllShapes.Shapes[indexOfShape].DCoordinates[7] + tempBasePoint.Y;
				int n = Globals.GirdArray[gY3, gX3];

				//i,j,m,n为其即将到达的新位置的网格值，若为1，说明该网格已被占据				
				if (gX0 < 0 || gX0 >= Globals.CountOfTier || i == 1 ||
					gX1 < 0 || gX1 >= Globals.CountOfTier || j == 1 ||
					gX2 < 0 || gX2 >= Globals.CountOfTier || m == 1 ||
					gX3 < 0 || gX3 >= Globals.CountOfTier || n == 1)
				{
					return false;
				}

			}
			catch
			{
				return false;
			}

			return true;
		}

		//按照形状索引将方块组合成形状
		private static void AssembleShape(int indexOfShape)
		{

			//重新安排四个动态块的位置以形成新形状
			Globals.DynamicBlocksArray[0].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[0] + Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[1] + Globals.BasePoint.Y);

			Globals.DynamicBlocksArray[1].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[2] + Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[3] + Globals.BasePoint.Y);

			Globals.DynamicBlocksArray[2].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[4] + Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[5] + Globals.BasePoint.Y);

			Globals.DynamicBlocksArray[3].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[6] + Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[7] + Globals.BasePoint.Y);

		}

		//按照形状索引将方块组合成预览形状
		private static void AssembleViewShape(int indexOfShape)
		{
			Globals.ViewDynamicBlocksArray[0].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[0],
				AllShapes.Shapes[indexOfShape].DCoordinates[1]);

			Globals.ViewDynamicBlocksArray[1].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[2],
				AllShapes.Shapes[indexOfShape].DCoordinates[3]);

			Globals.ViewDynamicBlocksArray[2].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[4],
				AllShapes.Shapes[indexOfShape].DCoordinates[5]);

			Globals.ViewDynamicBlocksArray[3].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[6],
				AllShapes.Shapes[indexOfShape].DCoordinates[7]);
		}



	}
}
