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
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 30;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);
                path.AddLine(CornerRadius, 0, this.Width - CornerRadius, 0);
                path.AddArc(new Rectangle(this.Width - CornerRadius, 0, CornerRadius, CornerRadius), -90, 90);
                path.AddLine(this.Width, CornerRadius, this.Width, this.Height - CornerRadius);
                path.AddArc(new Rectangle(this.Width - CornerRadius, this.Height - CornerRadius, CornerRadius, CornerRadius), 0, 90);
                path.AddLine(this.Width - CornerRadius, this.Height, CornerRadius, this.Height);
                path.AddArc(new Rectangle(0, this.Height - CornerRadius, CornerRadius, CornerRadius), 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
                e.Graphics.DrawPath(Pens.Transparent, path);
            }
        }
    }
}
