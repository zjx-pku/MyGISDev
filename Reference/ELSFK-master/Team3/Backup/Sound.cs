using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace Tetris2
{
	/// <summary>
	/// ���𲥷���������
	/// </summary>
	public class Sound
	{
		/// <summary>
		/// ��������,ֻ����wav��ʽ,���Globals.HasSoundΪfalse(�û���ֹ��������ʱ),�˺�����û������,����false
		/// </summary>
		/// <param name="pszSound">�����ļ�·��</param>
		/// <param name="hmod">IntPtr.Zero</param>
		/// <param name="fdwSound"></param>
		/// <returns>���Globals.HasSoundΪfalse(�û���ֹ��������ʱ),�˺�����û������,����false</returns>
		public static bool PlaySound(string pszSound, IntPtr hmod, int fdwSound)
		{
			if(Globals.HasSound && File.Exists(pszSound) )
			{
				pSound( pszSound, hmod,  fdwSound);
				return true;
			}
			return false;
		}



		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="path">�����ļ�·��,������mp3,wav,wmv,wma,mid��ʽ</param>
		public static void PlayMusic(string path, bool repeat)
		{
			Sound.mciSendString("close all", "", 0, 0);
			Sound.mciSendString("open \""+path+"\" alias music", "", 0, 0);
			if(repeat)
			{
				Sound.mciSendString("play music repeat", "", 0, 0);
			}
			else
			{
				Sound.mciSendString("play music", "", 0, 0);
			}
			Sound.mciSendString("Setaudio music volume to "+Globals.SoundLevel,"", 0,0);
		}

		/// <summary>
		/// ֹͣ���ڲ��ŵ�����
		/// </summary>
		public static void StopMusic()
		{
			Sound.mciSendString("stop music", "", 0, 0);
		}


		/// <summary>
		/// ��ͣ���ڲ��ŵ�����
		/// </summary>
		public static void PauseMusic()
		{
			Sound.mciSendString("pause music", "", 0, 0);
		}

		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="i">0->1000</param>
		public static void SetVolume(int i)
		{
			Sound.mciSendString("setaudio music volume to "+i.ToString(),"", 0, 0);
		}


		/// <summary>
		/// �ָ����ڲ��ŵ�����
		/// </summary>
		public static void ResumeMusic()
		{
			Sound.mciSendString("resume music", " ", 0, 0);
		}

		[DllImport("winmm.dll", EntryPoint="PlaySound")]//**
		private static extern bool pSound(string pszSound, IntPtr hmod, int fdwSound);


		[DllImport("winmm.dll", EntryPoint="mciSendString", CharSet = CharSet.Auto)]
		private static extern int mciSendString (

			//lpstrCommand��mciָ��
			string lpstrCommand,

			string lpstrReturnString,	

			//uReturnLength����,�������Ĵ�С,�����ַ������ĳ���.
			int uReturnLength,
			
			//�ص���ʽ,һ����Ϊ��.(*����ִ�гɹ�������,���򷵻ش������)
			int hwndCallback
			);


		
	}
}