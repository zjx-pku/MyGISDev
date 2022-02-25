using System;
using System.Windows.Forms;

namespace Team3
{
	/// <summary>
	///含有主函数的类
	/// </summary>
	public class ClassMain
	{
		/// <summary>
		/// 应用程序主窗口对象
		/// </summary>
		public static FormMain formMain = new FormMain();

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.Run(formMain);
		}
	}
}
