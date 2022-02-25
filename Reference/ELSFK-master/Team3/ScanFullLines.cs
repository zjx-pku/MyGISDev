using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Team3
{
    class ScanFullLines
    {
		public static System.Timers.Timer timer = new System.Timers.Timer(Globals.SpeedTime);
		

		/// <summary>
		/// 固定当前形状在屏幕上
		/// </summary>
		public static void FixShape()
		{

			timer.Stop();//停止下落

			for (int i = 0; i < 4; i++)
			{
				//点亮对应的背景方块
				Globals.BackBlocks[Globals.DynamicBlocksArray[i].GLocation.Y
					, Globals.DynamicBlocksArray[i].GLocation.X].BackColor = Globals.ColorOfFixedBlock;
				//将对应的网格值设置为1，表示此网格已经被占据
				Globals.GirdArray[Globals.DynamicBlocksArray[i].GLocation.Y,
								  Globals.DynamicBlocksArray[i].GLocation.X] = 1;
			}

			int temp = Globals.BasePoint.Y;

			MoveAndRotate.MakeNewShape();

			//扫描当前形状所在的四行,但最多达到第22行
			DelLines(temp, temp + 3 > 22 ? 22 : temp + 3);


			if (IsGameOver())
			{
				Game.Over();
			}

			timer.Start();


		}





		/// <summary>
		/// 判断是否有行可以消除，如果有则消除并加分
		/// </summary>
		/// <param name="lineStart">从此行开始扫描并判断(包括此行)</param>
		/// <param name="lineEnd">从此行结束扫描和判断(包括此行)</param>
		private static void DelLines(int lineStart, int lineEnd)
		{
			int countOfFullLine = 0;//记录此次消除的行数,以便加分

			for (int i = lineStart; i <= lineEnd; i++)
			{
				bool isFull = true;//指示是否已被填满
				for (int j = 0; j < Globals.CountOfTier; j++)
				{
					if (Globals.GirdArray[i, j] == 0)
					{
						isFull = false;
					}
				}

				if (isFull)
				{
					countOfFullLine++;
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Del.wav", IntPtr.Zero, 1);
					DelLine(i);

				}
			}

			switch (countOfFullLine)
			{
				case 0:
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Down.wav", IntPtr.Zero, 1);
					break;
				case 1:
					Game.AddScore(100);
					break;
				case 2:
					Game.AddScore(300);
					break;
				case 3:
					Game.AddScore(600);
					break;
				case 4:
					Game.AddScore(1000);
					break;
				default:
					break;
			}

		}

		//删除指定行
		private static void DelLine(int indexOfLine)
		{
			MoveAndRotate.AutoDown(false);
			Game.CanOp = false;

			//熄灭该行上的背景块，表现为移出了该行上的块
			for (int i = 0; i < Globals.CountOfTier; i++)
			{
				if (indexOfLine % 2 == 0)//偶数行从左向由消失
				{
					Globals.BackBlocks[indexOfLine, i].BackColor = Globals.ColorOfBackBlock;
					//释放被占据的网格
					Globals.GirdArray[indexOfLine, i] = 0;
				}
				else//奇数行从右向左消失
				{
					Globals.BackBlocks[indexOfLine, Globals.CountOfTier - 1 - i].BackColor = Globals.ColorOfBackBlock;
					//释放被占据的网格
					Globals.GirdArray[indexOfLine, Globals.CountOfTier - 1 - i] = 0;
				}
				//表现为从左向右逐个消失(原来的问题是当一直按住向下键时，没有效果,解决方法是建立新线程)
				System.Threading.Thread.Sleep(30);
			}

			//该行以上的所有行整体下落
			for (int i = indexOfLine - 1; i >= 3; i--)
			{
				for (int j = 0; j < Globals.CountOfTier; j++)
				{
					if (Globals.GirdArray[i, j] == 1)
					{
						//此块熄灭,其正下方的块点亮,表现为下落了一格
						Globals.GirdArray[i, j] = 0;
						Globals.BackBlocks[i, j].BackColor = Globals.ColorOfBackBlock;
						Globals.GirdArray[i + 1, j] = 1;
						Globals.BackBlocks[i + 1, j].BackColor = Globals.ColorOfFixedBlock;
					}
				}
			}

			MoveAndRotate.AutoDown(false);
			Game.CanOp = true;
		}


		//判断是否游戏已经结束
		private static bool IsGameOver()
		{
			for (int i = 0; i < Globals.CountOfTier; i++)
			{
				if (Globals.GirdArray[3, i] == 1)//如果第三行(即可见的顶部的第一行)有被占据的网格,那么游戏结束
				{
					return true;
				}
			}

			return false;
		}

		private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			MoveAndRotate.ToDown(Globals.IndexOfCurrentShape);
		}
	}
}
