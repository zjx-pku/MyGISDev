using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tetris2
{
	public enum GameStates
	{
		Stoped, Playing, Paused
	}

	/// <summary>
	///游戏的控制
	/// </summary>
	public class Game
	{
		public static GameStates State = GameStates.Stoped;
 
		/// <summary>
		/// 获取或设置一个值，该值为false时用户按键无效
		/// </summary>
        public static bool CanOp = true;

		public static int Score = 0;
        public static int SpeedLevel = 1;

		/// <summary>
		/// 开始新游戏
		/// </summary>
		public static void StartNewGame()
		{
			AllShapes.AutoDown(false);
			if( State != GameStates.Stoped  && 
				MessageBox.Show("\n       确实要重新开始游戏吗?                \n ",
				"重新开始",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.Yes)
			{
				if(State!=GameStates.Paused)
				{
					AllShapes.AutoDown(true);
				}
				return;
			}
			
		    Ini();
			

			CanOp = true;
			State = GameStates.Playing;
			AllShapes.MakeNewShape();
			AllShapes.AutoDown(true);
			ClassMain.formMain.labelInfo.Text = "Playing....";
			
			if(Globals.IsPlayBackMusic)
			{
				Sound.PlayMusic(Globals.PathOfBackMusic,true);
			}
		}

		/// <summary>
		/// 开始游戏,但不还原数据(要还原数据并开始新游戏,请使用StartNewGame())
		/// </summary>
		public static void Start()
		{
			Globals.BasePoint = new GirdPoint(0,0);
			CanOp = true;
			State = GameStates.Playing;
			AllShapes.MakeNewShape();
			AllShapes.AutoDown(true);
			ClassMain.formMain.labelInfo.Text = "Playing....";
			
			if(Globals.IsPlayBackMusic)
			{
				Sound.PlayMusic(Globals.PathOfBackMusic,true);
			}
		}

		//开始新游戏前的数据还原
		private static void Ini()
		{
			//还原网格数组,还原背景方块，还原基础点
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
			//MakeNewViewShape(Globals.NextIndexOfShape);//显示预览形状
			//由于产生新形状时采用了AllShapes.Eddy(Globals.IndexOfCurrentShape);所以这里采用了下面的一句，而不是上面注释掉的
			AllShapes.MakeNewViewShape(AllShapes.Shapes[Globals.NextIndexOfShape].EddiedIndex);

		}

		/// <summary>
		/// 暂停游戏
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
		/// 恢复被暂停的游戏
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
		/// 结束游戏
		/// </summary>
		public static void Over()
		{
			//Sound.StopMusic();//停止不了,因为调用over的线程与音乐不在同一个线程上
			AllShapes.timer.Stop();
			State = GameStates.Stoped;
			CanOp = false;
			ClassMain.formMain.labelInfo.Text = "Game Over";
		}

		/// <summary>
		/// 加分
		/// </summary>
		/// <param name="i">所添加的分数值,请使用100的正整数倍</param>
		public static void AddScore(int i)
		{
			Score += i;
			ClassMain.formMain.labelScore.Text = Score.ToString();
			ClassMain.formMain.labelTempInfo.Text = "Goooooooood !!!";

			//每5000分升一级
			if(Score%5000 == 0 && Score != 0)
			{
				ClassMain.formMain.labelTempInfo.Text = "!!!   升级啦   !!!";

				ChangeLevel(SpeedLevel +1);

				System.Threading.ThreadStart ts = new System.Threading.ThreadStart(LevelSound);
				System.Threading.Thread  th = new System.Threading.Thread(ts);
				th.Start();
			
			}

		}

		//升级时播放音乐
		private static void LevelSound()
		{
			
			Sound.PlaySound(Application.StartupPath + @"\Sounds\Level.wav",IntPtr.Zero,1);//升级音乐
			AllShapes.AutoDown(false);
			CanOp = false;
			System.Threading.Thread.Sleep(7000);
			AllShapes.AutoDown(true);
			CanOp = true;
		}

		/// <summary>
		/// 改变游戏速度级别
		/// </summary>
		/// <param name="i">级别 ,[1,9]之间的整数</param>
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
