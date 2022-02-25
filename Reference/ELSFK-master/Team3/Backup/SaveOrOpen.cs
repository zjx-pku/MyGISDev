using System;
using System.Windows.Forms;
using System.IO;


namespace Tetris2
{
	/// <summary>
	/// 负责游戏保存和读取
	/// </summary>
	public class SaveOrOpen
	{
		/// <summary>
		/// 保存游戏存档文件的文件夹
		/// </summary>
		public static string Directory = Application.StartupPath + @"\Save\";




		/// <summary>
		/// 保存游戏
		/// </summary>
		/// <param name="fileName">文件名,不含扩展名</param>
		/// <returns></returns>
		public static bool SaveGame(string fileName)
		{
			try
			{
				StreamWriter sWriter = 
					new StreamWriter(Directory + fileName +".dt",false,System.Text.Encoding.Default, 100);

				//写入速度级别
				sWriter.WriteLine(Game.SpeedLevel.ToString());

				//写入分数
				sWriter.WriteLine(Game.Score.ToString());

				//写入背景网格状态
				for(int i=0; i<Globals.CountOfRow; i++)
				{
					for(int j=0; j<Globals.CountOfTier; j++)
					{
						sWriter.Write(Globals.GirdArray[i,j].ToString());
					}
				}

				sWriter.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("未能保存!\n原因是:\n"+ex.Message);
				return false;
			}

			return true;
		}

		/// <summary>
		/// 载入指定的游戏存档
		/// </summary>
		/// <param name="fileName">存档的文件名,不含后缀</param>
		/// <returns></returns>
		public static bool LoadGame(string fileName)
		{
			try
			{
				StreamReader sReader =
					new StreamReader(fileName,System.Text.Encoding.Default,false,100);

                //加载游戏速度
				string strSpeedLevel = sReader.ReadLine();
				Game.ChangeLevel(int.Parse(strSpeedLevel));

				//加载游戏分数
				string strScore = sReader.ReadLine();
				Game.Score = 0;
				Game.AddScore(int.Parse(strScore));

				//加载游戏网格状态
				char[] buffer = new char[1];
				for(int i=0; i<Globals.CountOfRow; i++)
				{
					for(int j=0; j<Globals.CountOfTier; j++)
					{
						sReader.Read(buffer,0,1);
						Globals.GirdArray[i,j] = int.Parse(buffer[0].ToString());
						if(Globals.GirdArray[i,j]==1)
						{
							Globals.BackBlocks[i,j].BackColor = Globals.ColorOfFixedBlock;
						}
						else
						{
							Globals.BackBlocks[i,j].BackColor = Globals.ColorOfBackBlock;
						}
					}
				}

				sReader.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("加载游戏失败\n原因是:\n"+ex.Message);
				return false;
			}

			return true;
		}


	}

}
