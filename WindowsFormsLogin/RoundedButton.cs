using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLogin
{
    class RoundedButton : Button
    {
        // This class is used to create a button with rounded corners
        private int _cornerRadius = 20;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            GraphicsPath graphicsPath = new GraphicsPath();
            int radius = _cornerRadius;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Top-left corner
            graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            // Top-right corner
            graphicsPath.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            // Bottom-right corner
            graphicsPath.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            // Bottom-left corner
            graphicsPath.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            graphicsPath.CloseFigure();

            this.Region = new Region(graphicsPath);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.FillPath(new SolidBrush(this.BackColor), graphicsPath);
            pevent.Graphics.DrawPath(new Pen(this.ForeColor), graphicsPath);

            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            pevent.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), ClientRectangle, stringFormat);
        }
    }
}
