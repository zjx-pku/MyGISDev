using System;
using System.Windows.Forms;

namespace Team3
{
	/// <summary>
	///��������������
	/// </summary>
	public class ClassMain
	{
		/// <summary>
		/// Ӧ�ó��������ڶ���
		/// </summary>
		public static FormMain formMain = new FormMain();

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.Run(formMain);
		}
	}
}
