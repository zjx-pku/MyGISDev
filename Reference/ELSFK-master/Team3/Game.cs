using System;
using System.Windows.Forms;
using System.Drawing;

namespace Team3
{
	public enum GameStates
	{
		Stoped, Playing, Paused
	}

	/// <summary>
	///��Ϸ�Ŀ���
	/// </summary>
	public class Game
	{
		public static GameStates State = GameStates.Stoped;
 
		/// <summary>
		/// ��ȡ������һ��ֵ����ֵΪfalseʱ�û�������Ч
		/// </summary>
        public static bool CanOp = true;

		public static int Score = 0;
        public static int SpeedLevel = 1;

		/// <summary>
		/// ��ʼ����Ϸ
		/// </summary>
		public static void StartNewGame()
		{
			MoveAndRotate.AutoDown(false);
			if( State != GameStates.Stoped  && 
				MessageBox.Show("\n       ȷʵҪ���¿�ʼ��Ϸ��?                \n ",
				"���¿�ʼ",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.Yes)
			{
				if(State!=GameStates.Paused)
				{
					MoveAndRotate.AutoDown(true);
				}
				return;
			}
			
		    Ini();
			

			CanOp = true;
			State = GameStates.Playing;
			MoveAndRotate.MakeNewShape();
			MoveAndRotate.AutoDown(true);
			ClassMain.formMain.labelInfo.Text = "Playing....";
			
			if(Globals.IsPlayBackMusic)
			{
				Sound.PlayMusic(Globals.PathOfBackMusic,true);
			}
		}

		/// <summary>
		/// ��ʼ��Ϸ,������ԭ����(Ҫ��ԭ���ݲ���ʼ����Ϸ,��ʹ��StartNewGame())
		/// </summary>
		public static void Start()
		{
			Globals.BasePoint = new GirdPoint(0,0);
			CanOp = true;
			State = GameStates.Playing;
			MoveAndRotate.MakeNewShape();
			MoveAndRotate.AutoDown(true);
			ClassMain.formMain.labelInfo.Text = "Playing....";
			
			if(Globals.IsPlayBackMusic)
			{
				Sound.PlayMusic(Globals.PathOfBackMusic,true);
			}
		}

		//��ʼ����Ϸǰ�����ݻ�ԭ
		private static void Ini()
		{
			//��ԭ��������,��ԭ�������飬��ԭ������
			for(int i=0; i<Globals.CountOfRow-1; i++)
			{
				for(int j=0; j<Globals.CountOfTier; j++)
				{
					Globals.GirdArray[i,j]=0;
					Globals.BackBlocks[i,j].BackColor = Globals.ColorOfBackBlock;
				}
			}
			Globals.BasePoint = new GirdPoint(0,0);
			ClassMain.formMain.labelScore.Text = "0";
			Score = 0;
			SpeedLevel = 1;
			//MakeNewViewShape(Globals.NextIndexOfShape);//��ʾԤ����״
			//���ڲ�������״ʱ������AllShapes.Eddy(Globals.IndexOfCurrentShape);������������������һ�䣬����������ע�͵���
			MoveAndRotate.MakeNewViewShape(AllShapes.Shapes[Globals.NextIndexOfShape].EddiedIndex);

		}

		/// <summary>
		/// ��ͣ��Ϸ
		/// </summary>
		public static void Pause()
		{
			if(State == GameStates.Playing)
			{
				AllShapes.timer.Stop();
				CanOp = false;
				State = GameStates.Paused;
				ClassMain.formMain.labelInfo.Text = "Pause....";

				if(Globals.IsPlayBackMusic)
				{
					Sound.PauseMusic();
				}
			}
		}

		/// <summary>
		/// �ָ�����ͣ����Ϸ
		/// </summary>
		public static void Resume()
		{
			if(State == GameStates.Paused)
			{
				AllShapes.timer.Start();
				CanOp = true;
				State = GameStates.Playing;
				ClassMain.formMain.labelInfo.Text = "Playing....";

				if(Globals.IsPlayBackMusic)
				{
					Sound.ResumeMusic();
				}
			}
		}

		/// <summary>
		/// ������Ϸ
		/// </summary>
		public static void Over()
		{
			//Sound.StopMusic();//ֹͣ����,��Ϊ����over���߳������ֲ���ͬһ���߳���
			AllShapes.timer.Stop();
			State = GameStates.Stoped;
			CanOp = false;
			ClassMain.formMain.labelInfo.Text = "Game Over";
		}

		/// <summary>
		/// �ӷ�
		/// </summary>
		/// <param name="i">����ӵķ���ֵ,��ʹ��100����������</param>
		public static void AddScore(int i)
		{
			Score += i;
			ClassMain.formMain.labelScore.Text = Score.ToString();
			ClassMain.formMain.labelTempInfo.Text = "Goooooooood !!!";

			//ÿ5000����һ��
			if(Score%5000 == 0 && Score != 0)
			{
				ClassMain.formMain.labelTempInfo.Text = "!!!   ������   !!!";

				ChangeLevel(SpeedLevel +1);

				System.Threading.ThreadStart ts = new System.Threading.ThreadStart(LevelSound);
				System.Threading.Thread  th = new System.Threading.Thread(ts);
				th.Start();
			
			}

		}

		//����ʱ��������
		private static void LevelSound()
		{
			
			Sound.PlaySound(Application.StartupPath + @"\Sounds\Level.wav",IntPtr.Zero,1);//��������
			MoveAndRotate.AutoDown(false);
			CanOp = false;
			System.Threading.Thread.Sleep(7000);
			MoveAndRotate.AutoDown(true);
			CanOp = true;
		}

		/// <summary>
		/// �ı���Ϸ�ٶȼ���
		/// </summary>
		/// <param name="i">���� ,[1,9]֮�������</param>
		public static void ChangeLevel(int i)
		{
			switch(i)
			{
				case 1:
					 Globals.SpeedTime = 400;
					break;
				case 2:
					Globals.SpeedTime = 300;
					break;
				case 3:
					Globals.SpeedTime = 250;
					break;
				case 4:
					Globals.SpeedTime = 200;
					break;
				case 5:
					Globals.SpeedTime = 150;
					break;
				case 6:
					Globals.SpeedTime = 120;
					break;
				case 7:
					Globals.SpeedTime = 90;					
					break;
				case 8:
					Globals.SpeedTime = 50;
					break;
				case 9:
					Globals.SpeedTime = 30;
						break;
				default:
					break;
			}
			AllShapes.timer.Interval = Globals.SpeedTime;
			ClassMain.formMain.labelLever.Text = i.ToString();
			SpeedLevel = i;
		}

	}

	
}
