using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Tetris2
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

			if(!canEddy(indexOfShape))
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
			if(!CanMove(indexOfShape,'L'))
			{
				return;
			}

			//Globals.BasePoint.GOffset(-1,0);此句失败
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X-1, Globals.BasePoint.Y);
			AssembleShape(indexOfShape);
			
		}

		/// <summary>
		/// 将当前形状向右移动一格（如果能的话）
		/// </summary>
		/// <param name="indexOfShape">当前形状的索引号</param>
		public static void ToRight(int indexOfShape)
		{
			if(!CanMove(indexOfShape,'R'))
			{
				return;
			}

			//Globals.BasePoint.GOffset(1,0);此句失败
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X+1, Globals.BasePoint.Y);
			AssembleShape(indexOfShape);
		}


		/// <summary>
		/// 将当前形状向下移动一格（如果能的话）
		/// </summary>
		/// <param name="indexOfShape">当前形状的索引号</param>
		public static void ToDown(int indexOfShape)
		{
			if(!CanMove(indexOfShape,'D'))
			{
				ThreadStart tStart = new ThreadStart(FixShape);
				Thread thread = new Thread(tStart);
				thread.Start();
				return;
			}

			//Globals.BasePoint.GOffset(0,1);此句失败
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X, Globals.BasePoint.Y+1);
			AssembleShape(indexOfShape);
		}


		/// <summary>
		/// 启动自动下落
		/// </summary>
		/// <param name="b">true启动，false关闭</param>
		public static void AutoDown(bool b)
		{
			if(b)
			{
				timer.Start();
			}
			else
			{
				timer.Stop();
			}
		}


		/// <summary>
		/// 产生新形状并下落
		/// </summary>
		public static void MakeNewShape()
		{
			if(Game.State == GameStates.Playing)
			{
				Globals.IndexOfCurrentShape  = Globals.NextIndexOfShape;
				Random rand = new Random();
				Globals.NextIndexOfShape = rand.Next(18);

				//MakeNewViewShape(Globals.NextIndexOfShape);//显示预览形状
				//由于产生新形状时采用了AllShapes.Eddy(Globals.IndexOfCurrentShape);所以这里采用了下面的一句，而不是上面注释掉的
				//否则出现的新形状与预览形状相差90度
				MakeNewViewShape(AllShapes.Shapes[Globals.NextIndexOfShape].EddiedIndex);

				Globals.BasePoint = new GirdPoint(0,0);
				AllShapes.Eddy(Globals.IndexOfCurrentShape);			
			}
		}


		//探测能否旋转
		private static bool canEddy(int indexOfShape)
		{
			int eddiedIndex = AllShapes.Shapes[indexOfShape].EddiedIndex;//旋转后的新形状的索引
			return CanMove(eddiedIndex,'E');
		}


		private static bool CanMove(int indexOfShape, char arg)
		{
			try
			{
				GirdPoint tempBasePoint;

				switch(arg)
				{
					case 'L':
						tempBasePoint = new GirdPoint(Globals.BasePoint.X-1,Globals.BasePoint.Y);
						break;
					case 'R':
						tempBasePoint = new GirdPoint(Globals.BasePoint.X+1,Globals.BasePoint.Y);
						break;
					case 'D':
						tempBasePoint = new GirdPoint(Globals.BasePoint.X,Globals.BasePoint.Y+1);
						break;
					case 'E'://不移动，用于判断能否旋转，与判断移动不同的是传入的indexOfShape，判断旋转用的是旋转后的形状的索引，而移动用的是当前的
						tempBasePoint = Globals.BasePoint;
						break;
					default:
						MessageBox.Show("错误的参数"+arg+"\n应该为'L'或'R'或'D'");
						return false;

				}
				
				int gX0 = AllShapes.Shapes[indexOfShape].DCoordinates[0]+tempBasePoint.X;
				int gY0 = AllShapes.Shapes[indexOfShape].DCoordinates[1]+tempBasePoint.Y;
				int i = Globals.GirdArray[gY0,gX0];
             
				int gX1 = AllShapes.Shapes[indexOfShape].DCoordinates[2]+tempBasePoint.X;
				int gY1 = AllShapes.Shapes[indexOfShape].DCoordinates[3]+tempBasePoint.Y;
				int j = Globals.GirdArray[gY1,gX1];

				int gX2 = AllShapes.Shapes[indexOfShape].DCoordinates[4]+tempBasePoint.X;
				int gY2 = AllShapes.Shapes[indexOfShape].DCoordinates[5]+tempBasePoint.Y;
				int m = Globals.GirdArray[gY2,gX2];

				int gX3 = AllShapes.Shapes[indexOfShape].DCoordinates[6]+tempBasePoint.X;
				int gY3 = AllShapes.Shapes[indexOfShape].DCoordinates[7]+tempBasePoint.Y;
				int n = Globals.GirdArray[gY3,gX3];

				//i,j,m,n为其即将到达的新位置的网格值，若为1，说明该网格已被占据				
				if(gX0<0 || gX0>=Globals.CountOfTier ||  i == 1 ||
					gX1<0 || gX1>=Globals.CountOfTier || j == 1 ||
					gX2<0 || gX2>=Globals.CountOfTier || m == 1 ||
					gX3<0 || gX3>=Globals.CountOfTier || n == 1)
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
				AllShapes.Shapes[indexOfShape].DCoordinates[0]+Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[1]+Globals.BasePoint.Y);

			Globals.DynamicBlocksArray[1].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[2]+Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[3]+Globals.BasePoint.Y);

			Globals.DynamicBlocksArray[2].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[4]+Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[5]+Globals.BasePoint.Y);

			Globals.DynamicBlocksArray[3].GLocation = new GirdPoint(
				AllShapes.Shapes[indexOfShape].DCoordinates[6]+Globals.BasePoint.X,
				AllShapes.Shapes[indexOfShape].DCoordinates[7]+Globals.BasePoint.Y);

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

		private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			ToDown(Globals.IndexOfCurrentShape);
		}


		/// <summary>
		/// 固定当前形状在屏幕上
		/// </summary>
		private static void FixShape()
		{
			
			timer.Stop();//停止下落

			for(int i=0; i<4; i++)
			{
				//点亮对应的背景方块
				Globals.BackBlocks[Globals.DynamicBlocksArray[i].GLocation.Y
					,Globals.DynamicBlocksArray[i].GLocation.X].BackColor = Globals.ColorOfFixedBlock;
				//将对应的网格值设置为1，表示此网格已经被占据
				Globals.GirdArray[Globals.DynamicBlocksArray[i].GLocation.Y,
					              Globals.DynamicBlocksArray[i].GLocation.X] = 1;
			}

			int temp = Globals.BasePoint.Y;

			MakeNewShape();

			//扫描当前形状所在的四行,但最多达到第22行
			DelLines(temp,temp+3>22?22:temp+3);

	
			if(IsGameOver())
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

			for(int i= lineStart; i<=lineEnd; i++)
			{
				bool isFull = true;//指示是否已被填满
				for(int j=0; j<Globals.CountOfTier; j++)
				{
					if(Globals.GirdArray[i,j]==0)
					{
						isFull = false;
					}
				}

				if(isFull)
				{
					countOfFullLine++;
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Del.wav",IntPtr.Zero,1);
					DelLine(i);
					
				}
			}

			switch(countOfFullLine)
			{
				case 0:
					Sound.PlaySound(Application.StartupPath + @"\Sounds\Down.wav",IntPtr.Zero,1);
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
			AllShapes.AutoDown(false);
			Game.CanOp = false;

			//熄灭该行上的背景块，表现为移出了该行上的块
			for(int i=0; i<Globals.CountOfTier; i++)
			{
				if(indexOfLine%2==0)//偶数行从左向由消失
				{
					Globals.BackBlocks[indexOfLine,i].BackColor = Globals.ColorOfBackBlock;
					//释放被占据的网格
					Globals.GirdArray[indexOfLine,i] = 0;
				}
				else//奇数行从右向左消失
				{
					Globals.BackBlocks[indexOfLine,Globals.CountOfTier-1-i].BackColor = Globals.ColorOfBackBlock;
					//释放被占据的网格
					Globals.GirdArray[indexOfLine,Globals.CountOfTier-1-i] = 0;
				}
				//表现为从左向右逐个消失(原来的问题是当一直按住向下键时，没有效果,解决方法是建立新线程)
				System.Threading.Thread.Sleep(30);
			}

			//该行以上的所有行整体下落
			for(int i=indexOfLine-1;i>=3; i--)
			{
				for(int j=0; j<Globals.CountOfTier; j++)
				{
					if(Globals.GirdArray[i,j] == 1)
					{
						//此块熄灭,其正下方的块点亮,表现为下落了一格
						Globals.GirdArray[i,j] = 0;
						Globals.BackBlocks[i,j].BackColor = Globals.ColorOfBackBlock;
						Globals.GirdArray[i+1,j] = 1;
						Globals.BackBlocks[i+1,j].BackColor = Globals.ColorOfFixedBlock;
					}
				}
			}
	        
			AllShapes.AutoDown(false);
			Game.CanOp = true;
		}

		
		//判断是否游戏已经结束
		private static bool IsGameOver()
		{
			for(int i=0; i<Globals.CountOfTier; i++)
			{
				if(Globals.GirdArray[3,i] == 1)//如果第三行(即可见的顶部的第一行)有被占据的网格,那么游戏结束
				{
					return true;
				}
			}

			return false;
		}
	}

}
