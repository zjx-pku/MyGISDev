using System;
using System.Drawing;
using System.Windows.Forms;

/*
 * 2006_1_9->2006_1_12
 */
namespace Team3
{
	public class Globals
	{
		private static readonly int countOfRow = 24;//总行数
		private static readonly int countOfTier = 10;//总列数
		private static readonly int distanceOfGird = 1;//网格之间的间隔
		private static readonly int widthOfGird = 10; //方块的边长
		private static readonly int widthOfScreen = countOfTier * (widthOfGird+distanceOfGird);//显示区域宽度
		private static readonly int heightOfScreen = countOfRow * (widthOfGird+distanceOfGird);//显示区域高度
		private static int indexOfCurrentShape = 0;//记录着当前形状的索引号
		private static GirdPoint basePoint = new GirdPoint(0,0);//基础点
		private static Color colorOfBackBlock = Color.LightCyan;//背景方块颜色
		private static Color colorOfDynamicBlock = Color.Black;//动态方块颜色
		private static Color colorOfFixedBlock = Color.Black;//固定方块颜色
		private static Color colorOfViewBlock = Color.LightCoral;//预览方块颜色
		private static int soundLevel = 100;

		/// <summary>
		/// 获取或设置一个值,其指示当前背景音乐音量
		/// </summary>
		public static int SoundLevel
		{
			get
			{
				return soundLevel;
			}
			set
			{
				soundLevel = value;
				Sound.SetVolume(value);
			}
		}

		/// <summary>
		/// 获取或设置一个bool值，其指示是否开启背景声音
		/// </summary>
		public static bool HasSound = true;
		
		/// <summary>
		/// 获取或设置一个bool值，其指示是否显示网格背景
		/// </summary>
		public static bool IsShowBackBlock = true;

		/// <summary>
		///  获取或设置一个bool值，其指示是否播放背景音乐
		/// </summary>
		public static bool IsPlayBackMusic = false;

		/// <summary>
		/// 获取或设置背景音乐路径
		/// </summary>
		public static string PathOfBackMusic = Application.StartupPath + @"\Sounds\Bg.mp3";

		/// <summary>
		/// 获取或设置背景方块颜色
		/// </summary>
		public static Color ColorOfBackBlock
		{
			get
			{
				return colorOfBackBlock;
			}
			set
			{
				colorOfBackBlock = value;

				for(int i=0; i<countOfRow; i++)
				{
					for(int j=0; j<countOfTier; j++)
					{
						if(GirdArray[i,j] == 0)//如果未被占据
						BackBlocks[i,j].BackColor = value;
					}
				}
			}

		}

		/// <summary>
		/// 获取或设置动态方块颜色
		/// </summary>
		public static Color ColorOfDynamicBlock
		{
			get
			{
				return colorOfDynamicBlock;
			}
			set
			{
				colorOfDynamicBlock = value;

				for(int i=0; i<4; i++)
				{
					DynamicBlocksArray[i].BackColor = value;
				}
			}
		}

		/// <summary>
		/// 获取或设置固定方块颜色
		/// </summary>
		public static Color ColorOfFixedBlock
		{
			get
			{
				return colorOfFixedBlock;
			}
			set
			{
				colorOfFixedBlock = value;
				
				for(int i=0; i<countOfRow; i++)
				{
					for(int j=0; j<countOfTier; j++)
					{
						if(GirdArray[i,j] == 1)//如果被占据
							BackBlocks[i,j].BackColor = value;
					}
				}
				
			}
		}

		/// <summary>
		/// 获取或设置预览方块颜色
		/// </summary>
		public static Color ColorOfViewBlock
		{
			get
			{
				return colorOfViewBlock;
			}
			set
			{
				colorOfViewBlock = value;

				for(int i=0; i<4; i++)
				{
					ViewDynamicBlocksArray[i].BackColor = value;
				}
			}
		}

		/// <summary>
		/// 获取或设置 下落计时器时间间隔
		/// </summary>
		public static int SpeedTime = 400 ;

		/// <summary>
		/// 获取或设置 下一个形状的索引号
		/// </summary>
		public static int NextIndexOfShape = 0;

		/// <summary>
	    /// 获取或设置网格数组
		/// </summary>
		public static int[,] GirdArray = new int[countOfRow,countOfTier];

		/// <summary>
		/// 获取或设置预览网格数组
		/// </summary>
		public static int[,] ViewGirdArray = new int[8,8];

		/// <summary>
		/// 获取或设置一个Block[,]，该数组维持了显示区域的背景方块
		/// </summary>
		public static Block[,] BackBlocks = new Block[countOfRow,countOfTier];

		/// <summary>
		/// 获取或设置一个数组，该数组保存了贯穿于游戏始终的四个方块，将由它们形成运动的形状
		/// </summary>
		public static Block[] DynamicBlocksArray = new Block[4]
			{
				new Block(),new Block(), new Block(), new Block()
			};

		/// <summary>
		/// 获取或设置一个数组，该数组保存了预览方块，将由它们形成预览形状
		/// </summary>
		public static Block[] ViewDynamicBlocksArray = new Block[4]
			{
				new Block(0,0,ColorOfViewBlock),new Block(0,0,ColorOfViewBlock), 
				new Block(0,0,ColorOfViewBlock), new Block(0,0,ColorOfViewBlock)
			};

		
		static Globals()
		{
			//初始化网格数组，0到22行为空，23行填满
			for(int i=0; i<countOfRow-1; i++)
			{
				for(int j=0; j<countOfTier; j++)
				{
					GirdArray[i,j]=0;
				}
			}
			for(int i=0; i<countOfTier; i++)
			{
				GirdArray[countOfRow-1,i] = 1;
			}
			//end_初始化网格数组

			//初始化背景方块数组
			for(int i=0; i<countOfRow; i++)
			{
				for(int j=0; j<countOfTier; j++)
				{
					BackBlocks[i,j] = new Block(j,i,ColorOfBackBlock);
				}
			}

			Random rand = new Random();
			NextIndexOfShape  = rand.Next(19);
		}

		/// <summary>
		/// 获取网格总行数
		/// </summary>
		public static int CountOfRow
		{
			get
			{
				return countOfRow;
			}
		}

		/// <summary>
		/// 获取网格总列数
		/// </summary>
		public static int CountOfTier
		{
			get
			{
				return countOfTier;
			}
		}


		/// <summary>
		/// 获取网格之间的间隔
		/// </summary>
		public static int DistanceOfGird
		{
			get
			{
				return distanceOfGird;
			}
		}

		/// <summary>
		/// 获取网格的边长
		/// </summary>
		public static int WidthOfGird
		{
			get
			{
				return widthOfGird;
			}
		}


		/// <summary>
		/// 获取显示区域宽度
		/// </summary>
		public static int WidthOfScreen
		{
			get
			{
				return widthOfScreen;
			}
		}


		/// <summary>
		/// 获取显示区域高度
		/// </summary>
		public static int HeightOfScreen
		{
			get
			{
				return heightOfScreen;
			}
		}

		/// <summary>
		/// 获取或设置一个值， 这个值记录着当前形状的索引号
		/// </summary>
		public static int IndexOfCurrentShape
		{
			get
			{
				return indexOfCurrentShape;
			}
			set
			{
				indexOfCurrentShape = value;
			}
		}


		/// <summary>
		/// 获取或设置一个GirdPoint对象，它将作为基础点参与指导形状的移动和旋转
		/// </summary>
		public static GirdPoint BasePoint
		{
			get
			{
				return basePoint;
			}
			set
			{
				basePoint = value;
			}
		}


		/// <summary>
		/// 由网格坐标值转成象素坐标
		/// </summary>
		/// <param name="gCoordinate">网格坐标值</param>
		/// <returns>象素坐标值</returns>
		public static int ToPCoordinate(int gCoordinate)
		{
			return gCoordinate*(widthOfGird+distanceOfGird);
		}

		/// <summary>
		/// 由象素坐标转成网格坐标，注意:可能有误差
		/// </summary>
		/// <param name="pCoordinate">象素坐标值</param>
		/// <returns>网格坐标值</returns>
		public static int ToGCoordinate(int pCoordinate)
		{
			return pCoordinate/(widthOfGird+distanceOfGird);
		}

	}
}
