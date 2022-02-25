using System;
using System.Windows.Forms;
using System.Drawing;

namespace Team3
{
	/// <summary>
	///构成形状的方块，继承于Label，注意：请采用 网格坐标 操作其对象
	/// </summary>
	public class Block:Label
	{
		
		private GirdPoint gLocation;// 网格坐标
        
		/// <summary>
		/// 指示方块是否是活动的
		/// </summary>
        public  bool IsAlive = true;

		/// <summary>
		///获取或设置 网格坐标值（若设置，那么其象素坐标会自动变化为相应值）
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
		/// 生成以各Block对象,网格坐标（0，0） 背景色black，BorderStyle 为 BorderStyle.None
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
		/// 生成以各Block对象
		/// </summary>
		/// <param name="gX">使用网格坐标的横坐标</param>
		/// <param name="gY">使用网格坐标的纵坐标</param>
		/// <param name="backColor">背景色</param>
		public Block(int gX, int gY, Color backColor)
		{
			this.gLocation = new GirdPoint(gX, gY);
			this.Location = new Point(Globals.ToPCoordinate(gX), Globals.ToPCoordinate(gY));
			this.BackColor = backColor;
			this.BorderStyle = BorderStyle.None;
			this.Size = new Size(Globals.WidthOfGird,Globals.WidthOfGird);
		}

		/// <summary>
		/// 生成以各Block对象
		/// </summary>
		/// <param name="gX">使用网格坐标的横坐标</param>
		/// <param name="gY">使用网格坐标的纵坐标</param>
		/// <param name="backColor">背景色</param>
		/// <param name="style">BorderStyle样式</param>
		public Block(int gX, int gY, Color backColor, BorderStyle style)
		{
			this.gLocation = new GirdPoint(gX, gY);
			this.Location = new Point(Globals.ToPCoordinate(gX), Globals.ToPCoordinate(gY));
			this.BackColor = backColor;
			this.BorderStyle = style;
			this.Size = new Size(Globals.WidthOfGird,Globals.WidthOfGird);
		}

		/// <summary>
		/// 按照某个Block对象生成一个一样的对象
		/// </summary>
		/// <param name="oldBlock">用于生成与其一样的某个Block对象</param>
		public Block(Block oldBlock)
		{
			this.gLocation = oldBlock.gLocation;
			this.Location  = oldBlock.Location;
			this.BackColor = oldBlock.BackColor;
			this.BorderStyle = oldBlock.BorderStyle;
			this.Size = oldBlock.Size;
		}

		/// <summary>
		/// 将自己添加到某个Panel对象（屏幕）中
		/// </summary>
		/// <param name="panelScreen">某个Panel对象（屏幕）</param>
		public void AddToPanel(Panel panelScreen)
		{
			panelScreen.Controls.Add(this);
		}


		
	}
}
