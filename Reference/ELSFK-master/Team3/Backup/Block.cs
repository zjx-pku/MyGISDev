using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tetris2
{
	/// <summary>
	///������״�ķ��飬�̳���Label��ע�⣺����� �������� ���������
	/// </summary>
	public class Block:Label
	{
		
		private GirdPoint gLocation;// ��������
        
		/// <summary>
		/// ָʾ�����Ƿ��ǻ��
		/// </summary>
        public  bool IsAlive = true;

		/// <summary>
		///��ȡ������ ��������ֵ�������ã���ô������������Զ��仯Ϊ��Ӧֵ��
		/// </summary>
		public GirdPoint GLocation
		{
			get
			{
				return this.gLocation;
			}
			set
			{
				this.gLocation = value;
				this.Location = new Point( Globals.ToPCoordinate(this.gLocation.X),
					Globals.ToPCoordinate(this.gLocation.Y));
			}
		}

		/// <summary>
		/// �����Ը�Block����,�������꣨0��0�� ����ɫblack��BorderStyle Ϊ BorderStyle.None
		/// </summary>
		public Block()
		{
			this.gLocation = new GirdPoint(0,0);
			this.Location = new Point(0,0);
			this.BackColor = Color.Black;
			this.BorderStyle = BorderStyle.None;
			this.Size = new Size(Globals.WidthOfGird,Globals.WidthOfGird);
		}

		/// <summary>
		/// �����Ը�Block����
		/// </summary>
		/// <param name="gX">ʹ����������ĺ�����</param>
		/// <param name="gY">ʹ�����������������</param>
		/// <param name="backColor">����ɫ</param>
		public Block(int gX, int gY, Color backColor)
		{
			this.gLocation = new GirdPoint(gX, gY);
			this.Location = new Point(Globals.ToPCoordinate(gX), Globals.ToPCoordinate(gY));
			this.BackColor = backColor;
			this.BorderStyle = BorderStyle.None;
			this.Size = new Size(Globals.WidthOfGird,Globals.WidthOfGird);
		}

		/// <summary>
		/// �����Ը�Block����
		/// </summary>
		/// <param name="gX">ʹ����������ĺ�����</param>
		/// <param name="gY">ʹ�����������������</param>
		/// <param name="backColor">����ɫ</param>
		/// <param name="style">BorderStyle��ʽ</param>
		public Block(int gX, int gY, Color backColor, BorderStyle style)
		{
			this.gLocation = new GirdPoint(gX, gY);
			this.Location = new Point(Globals.ToPCoordinate(gX), Globals.ToPCoordinate(gY));
			this.BackColor = backColor;
			this.BorderStyle = style;
			this.Size = new Size(Globals.WidthOfGird,Globals.WidthOfGird);
		}

		/// <summary>
		/// ����ĳ��Block��������һ��һ���Ķ���
		/// </summary>
		/// <param name="oldBlock">������������һ����ĳ��Block����</param>
		public Block(Block oldBlock)
		{
			this.gLocation = oldBlock.gLocation;
			this.Location  = oldBlock.Location;
			this.BackColor = oldBlock.BackColor;
			this.BorderStyle = oldBlock.BorderStyle;
			this.Size = oldBlock.Size;
		}

		/// <summary>
		/// ���Լ���ӵ�ĳ��Panel������Ļ����
		/// </summary>
		/// <param name="panelScreen">ĳ��Panel������Ļ��</param>
		public void AddToPanel(Panel panelScreen)
		{
			panelScreen.Controls.Add(this);
		}


		
	}
}
