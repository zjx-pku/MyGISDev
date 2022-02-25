using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Tetris2
{
	/// <summary>
	/// �����˹�����״�����ݺͲ���
	/// </summary>
	public class AllShapes
	{
		/// <summary>
		/// ��ȡһ�����飬 �����鱣������������״
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
		/// ���ڿ�����״�Զ�����ļ�ʱ��
		/// </summary>
		public static System.Timers.Timer timer = new System.Timers.Timer(Globals.SpeedTime);

		static AllShapes()
		{
			timer.Stop();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
		}

		/// <summary>
		/// ����ָ�����������µ�Ԥ����״
		/// </summary>
		/// <param name="indexOfShape">ָ������״����</param>
		public static void MakeNewViewShape(int indexOfShape)
		{
			AssembleViewShape(indexOfShape);
		}

		/// <summary>
		/// ��ת��ǰ��״
		/// </summary>
		/// <param name="indexOfShape">��ǰ��״��������</param>
		public static void Eddy(int indexOfShape)
		{

			if(!canEddy(indexOfShape))
			{
				return;
			}

			int eddiedIndex = AllShapes.Shapes[indexOfShape].EddiedIndex;//��ת�������״������

			AssembleShape(eddiedIndex);//������ϳ�����״

			Globals.IndexOfCurrentShape = eddiedIndex;//����ת������״����������Ϊ��ǰ����
		}


		
		/// <summary>
		/// ����ǰ��״�����ƶ�һ������ܵĻ���
		/// </summary>
		/// <param name="indexOfShape">��ǰ��״��������</param>
		public static void ToLeft(int indexOfShape)
		{
			if(!CanMove(indexOfShape,'L'))
			{
				return;
			}

			//Globals.BasePoint.GOffset(-1,0);�˾�ʧ��
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X-1, Globals.BasePoint.Y);
			AssembleShape(indexOfShape);
			
		}

		/// <summary>
		/// ����ǰ��״�����ƶ�һ������ܵĻ���
		/// </summary>
		/// <param name="indexOfShape">��ǰ��״��������</param>
		public static void ToRight(int indexOfShape)
		{
			if(!CanMove(indexOfShape,'R'))
			{
				return;
			}

			//Globals.BasePoint.GOffset(1,0);�˾�ʧ��
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X+1, Globals.BasePoint.Y);
			AssembleShape(indexOfShape);
		}


		/// <summary>
		/// ����ǰ��״�����ƶ�һ������ܵĻ���
		/// </summary>
		/// <param name="indexOfShape">��ǰ��״��������</param>
		public static void ToDown(int indexOfShape)
		{
			if(!CanMove(indexOfShape,'D'))
			{
				ThreadStart tStart = new ThreadStart(FixShape);
				Thread thread = new Thread(tStart);
				thread.Start();
				return;
			}

			//Globals.BasePoint.GOffset(0,1);�˾�ʧ��
			Globals.BasePoint = new GirdPoint(Globals.BasePoint.X, Globals.BasePoint.Y+1);
			AssembleShape(indexOfShape);
		}


		/// <summary>
		/// �����Զ�����
		/// </summary>
		/// <param name="b">true������false�ر�</param>
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
		/// ��������״������
		/// </summary>
		public static void MakeNewShape()
		{
			if(Game.State == GameStates.Playing)
			{
				Globals.IndexOfCurrentShape  = Globals.NextIndexOfShape;
				Random rand = new Random();
				Globals.NextIndexOfShape = rand.Next(18);

				//MakeNewViewShape(Globals.NextIndexOfShape);//��ʾԤ����״
				//���ڲ�������״ʱ������AllShapes.Eddy(Globals.IndexOfCurrentShape);������������������һ�䣬����������ע�͵���
				//������ֵ�����״��Ԥ����״���90��
				MakeNewViewShape(AllShapes.Shapes[Globals.NextIndexOfShape].EddiedIndex);

				Globals.BasePoint = new GirdPoint(0,0);
				AllShapes.Eddy(Globals.IndexOfCurrentShape);			
			}
		}


		//̽���ܷ���ת
		private static bool canEddy(int indexOfShape)
		{
			int eddiedIndex = AllShapes.Shapes[indexOfShape].EddiedIndex;//��ת�������״������
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
					case 'E'://���ƶ��������ж��ܷ���ת�����ж��ƶ���ͬ���Ǵ����indexOfShape���ж���ת�õ�����ת�����״�����������ƶ��õ��ǵ�ǰ��
						tempBasePoint = Globals.BasePoint;
						break;
					default:
						MessageBox.Show("����Ĳ���"+arg+"\nӦ��Ϊ'L'��'R'��'D'");
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

				//i,j,m,nΪ�伴���������λ�õ�����ֵ����Ϊ1��˵���������ѱ�ռ��				
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

        //������״������������ϳ���״
		private static void AssembleShape(int indexOfShape)
		{

			//���°����ĸ���̬���λ�����γ�����״
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

		//������״������������ϳ�Ԥ����״
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
		/// �̶���ǰ��״����Ļ��
		/// </summary>
		private static void FixShape()
		{
			
			timer.Stop();//ֹͣ����

			for(int i=0; i<4; i++)
			{
				//������Ӧ�ı�������
				Globals.BackBlocks[Globals.DynamicBlocksArray[i].GLocation.Y
					,Globals.DynamicBlocksArray[i].GLocation.X].BackColor = Globals.ColorOfFixedBlock;
				//����Ӧ������ֵ����Ϊ1����ʾ�������Ѿ���ռ��
				Globals.GirdArray[Globals.DynamicBlocksArray[i].GLocation.Y,
					              Globals.DynamicBlocksArray[i].GLocation.X] = 1;
			}

			int temp = Globals.BasePoint.Y;

			MakeNewShape();

			//ɨ�赱ǰ��״���ڵ�����,�����ﵽ��22��
			DelLines(temp,temp+3>22?22:temp+3);

	
			if(IsGameOver())
			{
				Game.Over();
			}

			timer.Start();	

            
		}

		/// <summary>
		/// �ж��Ƿ����п�����������������������ӷ�
		/// </summary>
		/// <param name="lineStart">�Ӵ��п�ʼɨ�貢�ж�(��������)</param>
		/// <param name="lineEnd">�Ӵ��н���ɨ����ж�(��������)</param>
		private static void DelLines(int lineStart, int lineEnd)
		{
			int countOfFullLine = 0;//��¼�˴�����������,�Ա�ӷ�

			for(int i= lineStart; i<=lineEnd; i++)
			{
				bool isFull = true;//ָʾ�Ƿ��ѱ�����
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

        //ɾ��ָ����
		private static void DelLine(int indexOfLine)
		{ 
			AllShapes.AutoDown(false);
			Game.CanOp = false;

			//Ϩ������ϵı����飬����Ϊ�Ƴ��˸����ϵĿ�
			for(int i=0; i<Globals.CountOfTier; i++)
			{
				if(indexOfLine%2==0)//ż���д���������ʧ
				{
					Globals.BackBlocks[indexOfLine,i].BackColor = Globals.ColorOfBackBlock;
					//�ͷű�ռ�ݵ�����
					Globals.GirdArray[indexOfLine,i] = 0;
				}
				else//�����д���������ʧ
				{
					Globals.BackBlocks[indexOfLine,Globals.CountOfTier-1-i].BackColor = Globals.ColorOfBackBlock;
					//�ͷű�ռ�ݵ�����
					Globals.GirdArray[indexOfLine,Globals.CountOfTier-1-i] = 0;
				}
				//����Ϊ�������������ʧ(ԭ���������ǵ�һֱ��ס���¼�ʱ��û��Ч��,��������ǽ������߳�)
				System.Threading.Thread.Sleep(30);
			}

			//�������ϵ���������������
			for(int i=indexOfLine-1;i>=3; i--)
			{
				for(int j=0; j<Globals.CountOfTier; j++)
				{
					if(Globals.GirdArray[i,j] == 1)
					{
						//�˿�Ϩ��,�����·��Ŀ����,����Ϊ������һ��
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

		
		//�ж��Ƿ���Ϸ�Ѿ�����
		private static bool IsGameOver()
		{
			for(int i=0; i<Globals.CountOfTier; i++)
			{
				if(Globals.GirdArray[3,i] == 1)//���������(���ɼ��Ķ����ĵ�һ��)�б�ռ�ݵ�����,��ô��Ϸ����
				{
					return true;
				}
			}

			return false;
		}
	}

}
