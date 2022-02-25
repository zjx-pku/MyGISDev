using System;
using System.Windows.Forms;
using System.IO;


namespace Tetris2
{
	/// <summary>
	/// ������Ϸ����Ͷ�ȡ
	/// </summary>
	public class SaveOrOpen
	{
		/// <summary>
		/// ������Ϸ�浵�ļ����ļ���
		/// </summary>
		public static string Directory = Application.StartupPath + @"\Save\";




		/// <summary>
		/// ������Ϸ
		/// </summary>
		/// <param name="fileName">�ļ���,������չ��</param>
		/// <returns></returns>
		public static bool SaveGame(string fileName)
		{
			try
			{
				StreamWriter sWriter = 
					new StreamWriter(Directory + fileName +".dt",false,System.Text.Encoding.Default, 100);

				//д���ٶȼ���
				sWriter.WriteLine(Game.SpeedLevel.ToString());

				//д�����
				sWriter.WriteLine(Game.Score.ToString());

				//д�뱳������״̬
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
				MessageBox.Show("δ�ܱ���!\nԭ����:\n"+ex.Message);
				return false;
			}

			return true;
		}

		/// <summary>
		/// ����ָ������Ϸ�浵
		/// </summary>
		/// <param name="fileName">�浵���ļ���,������׺</param>
		/// <returns></returns>
		public static bool LoadGame(string fileName)
		{
			try
			{
				StreamReader sReader =
					new StreamReader(fileName,System.Text.Encoding.Default,false,100);

                //������Ϸ�ٶ�
				string strSpeedLevel = sReader.ReadLine();
				Game.ChangeLevel(int.Parse(strSpeedLevel));

				//������Ϸ����
				string strScore = sReader.ReadLine();
				Game.Score = 0;
				Game.AddScore(int.Parse(strScore));

				//������Ϸ����״̬
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
				MessageBox.Show("������Ϸʧ��\nԭ����:\n"+ex.Message);
				return false;
			}

			return true;
		}


	}

}
