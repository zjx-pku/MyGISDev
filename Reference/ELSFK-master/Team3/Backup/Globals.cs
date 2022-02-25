using System;
using System.Drawing;
using System.Windows.Forms;

/*
 * 2006_1_9->2006_1_12
 */
namespace Tetris2
{
	public class Globals
	{
		private static readonly int countOfRow = 24;//������
		private static readonly int countOfTier = 10;//������
		private static readonly int distanceOfGird = 1;//����֮��ļ��
		private static readonly int widthOfGird = 10; //����ı߳�
		private static readonly int widthOfScreen = countOfTier * (widthOfGird+distanceOfGird);//��ʾ������
		private static readonly int heightOfScreen = countOfRow * (widthOfGird+distanceOfGird);//��ʾ����߶�
		private static int indexOfCurrentShape = 0;//��¼�ŵ�ǰ��״��������
		private static GirdPoint basePoint = new GirdPoint(0,0);//������
		private static Color colorOfBackBlock = Color.LightCyan;//����������ɫ
		private static Color colorOfDynamicBlock = Color.Black;//��̬������ɫ
		private static Color colorOfFixedBlock = Color.Black;//�̶�������ɫ
		private static Color colorOfViewBlock = Color.LightCoral;//Ԥ��������ɫ
		private static int soundLevel = 100;

		/// <summary>
		/// ��ȡ������һ��ֵ,��ָʾ��ǰ������������
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
		/// ��ȡ������һ��boolֵ����ָʾ�Ƿ�����������
		/// </summary>
		public static bool HasSound = true;
		
		/// <summary>
		/// ��ȡ������һ��boolֵ����ָʾ�Ƿ���ʾ���񱳾�
		/// </summary>
		public static bool IsShowBackBlock = true;

		/// <summary>
		///  ��ȡ������һ��boolֵ����ָʾ�Ƿ񲥷ű�������
		/// </summary>
		public static bool IsPlayBackMusic = false;

		/// <summary>
		/// ��ȡ�����ñ�������·��
		/// </summary>
		public static string PathOfBackMusic = Application.StartupPath + @"\Sounds\Bg.mp3";

		/// <summary>
		/// ��ȡ�����ñ���������ɫ
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
						if(GirdArray[i,j] == 0)//���δ��ռ��
						BackBlocks[i,j].BackColor = value;
					}
				}
			}

		}

		/// <summary>
		/// ��ȡ�����ö�̬������ɫ
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
		/// ��ȡ�����ù̶�������ɫ
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
						if(GirdArray[i,j] == 1)//�����ռ��
							BackBlocks[i,j].BackColor = value;
					}
				}
				
			}
		}

		/// <summary>
		/// ��ȡ������Ԥ��������ɫ
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
		/// ��ȡ������ �����ʱ��ʱ����
		/// </summary>
		public static int SpeedTime = 400 ;

		/// <summary>
		/// ��ȡ������ ��һ����״��������
		/// </summary>
		public static int NextIndexOfShape = 0;

		/// <summary>
	    /// ��ȡ��������������
		/// </summary>
		public static int[,] GirdArray = new int[countOfRow,countOfTier];

		/// <summary>
		/// ��ȡ������Ԥ����������
		/// </summary>
		public static int[,] ViewGirdArray = new int[8,8];

		/// <summary>
		/// ��ȡ������һ��Block[,]��������ά������ʾ����ı�������
		/// </summary>
		public static Block[,] BackBlocks = new Block[countOfRow,countOfTier];

		/// <summary>
		/// ��ȡ������һ�����飬�����鱣���˹ᴩ����Ϸʼ�յ��ĸ����飬���������γ��˶�����״
		/// </summary>
		public static Block[] DynamicBlocksArray = new Block[4]
			{
				new Block(),new Block(), new Block(), new Block()
			};

		/// <summary>
		/// ��ȡ������һ�����飬�����鱣����Ԥ�����飬���������γ�Ԥ����״
		/// </summary>
		public static Block[] ViewDynamicBlocksArray = new Block[4]
			{
				new Block(0,0,ColorOfViewBlock),new Block(0,0,ColorOfViewBlock), 
				new Block(0,0,ColorOfViewBlock), new Block(0,0,ColorOfViewBlock)
			};

		
		static Globals()
		{
			//��ʼ���������飬0��22��Ϊ�գ�23������
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
			//end_��ʼ����������

			//��ʼ��������������
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
		/// ��ȡ����������
		/// </summary>
		public static int CountOfRow
		{
			get
			{
				return countOfRow;
			}
		}

		/// <summary>
		/// ��ȡ����������
		/// </summary>
		public static int CountOfTier
		{
			get
			{
				return countOfTier;
			}
		}


		/// <summary>
		/// ��ȡ����֮��ļ��
		/// </summary>
		public static int DistanceOfGird
		{
			get
			{
				return distanceOfGird;
			}
		}

		/// <summary>
		/// ��ȡ����ı߳�
		/// </summary>
		public static int WidthOfGird
		{
			get
			{
				return widthOfGird;
			}
		}


		/// <summary>
		/// ��ȡ��ʾ������
		/// </summary>
		public static int WidthOfScreen
		{
			get
			{
				return widthOfScreen;
			}
		}


		/// <summary>
		/// ��ȡ��ʾ����߶�
		/// </summary>
		public static int HeightOfScreen
		{
			get
			{
				return heightOfScreen;
			}
		}

		/// <summary>
		/// ��ȡ������һ��ֵ�� ���ֵ��¼�ŵ�ǰ��״��������
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
		/// ��ȡ������һ��GirdPoint����������Ϊ���������ָ����״���ƶ�����ת
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
		/// ����������ֵת����������
		/// </summary>
		/// <param name="gCoordinate">��������ֵ</param>
		/// <returns>��������ֵ</returns>
		public static int ToPCoordinate(int gCoordinate)
		{
			return gCoordinate*(widthOfGird+distanceOfGird);
		}

		/// <summary>
		/// ����������ת���������꣬ע��:���������
		/// </summary>
		/// <param name="pCoordinate">��������ֵ</param>
		/// <returns>��������ֵ</returns>
		public static int ToGCoordinate(int pCoordinate)
		{
			return pCoordinate/(widthOfGird+distanceOfGird);
		}

	}
}
