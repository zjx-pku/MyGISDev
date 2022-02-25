using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace Tetris2
{
	/// <summary>
	/// 负责播放声音的类
	/// </summary>
	public class Sound
	{
		/// <summary>
		/// 播放声音,只能是wav格式,如果Globals.HasSound为false(用户禁止播放声音时),此函数将没有作用,返回false
		/// </summary>
		/// <param name="pszSound">声音文件路径</param>
		/// <param name="hmod">IntPtr.Zero</param>
		/// <param name="fdwSound"></param>
		/// <returns>如果Globals.HasSound为false(用户禁止播放声音时),此函数将没有作用,返回false</returns>
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
		/// 播放音乐
		/// </summary>
		/// <param name="path">音乐文件路径,可以是mp3,wav,wmv,wma,mid格式</param>
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
		/// 停止正在播放的音乐
		/// </summary>
		public static void StopMusic()
		{
			Sound.mciSendString("stop music", "", 0, 0);
		}


		/// <summary>
		/// 暂停正在播放的音乐
		/// </summary>
		public static void PauseMusic()
		{
			Sound.mciSendString("pause music", "", 0, 0);
		}

		/// <summary>
		/// 设置音量
		/// </summary>
		/// <param name="i">0->1000</param>
		public static void SetVolume(int i)
		{
			Sound.mciSendString("setaudio music volume to "+i.ToString(),"", 0, 0);
		}


		/// <summary>
		/// 恢复正在播放的音乐
		/// </summary>
		public static void ResumeMusic()
		{
			Sound.mciSendString("resume music", " ", 0, 0);
		}

		[DllImport("winmm.dll", EntryPoint="PlaySound")]//**
		private static extern bool pSound(string pszSound, IntPtr hmod, int fdwSound);


		[DllImport("winmm.dll", EntryPoint="mciSendString", CharSet = CharSet.Auto)]
		private static extern int mciSendString (

			//lpstrCommand，mci指令
			string lpstrCommand,

			string lpstrReturnString,	

			//uReturnLength参数,缓冲区的大小,就是字符变量的长度.
			int uReturnLength,
			
			//回调方式,一般设为零.(*函数执行成功返回零,否则返回错误代码)
			int hwndCallback
			);


		
	}
}