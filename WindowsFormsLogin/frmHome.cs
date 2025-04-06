using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace WindowsFormsLogin
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Remove the default border
            this.Load += FrmHome_Load;
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
           SetRoundedCorners(30); // Set the radius for the rounded corners
        }

        private void SetRoundedCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddLine(radius, 0, this.Width - radius, 0);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), -90, 90);
            path.AddLine(this.Width, radius, this.Width, this.Height - radius);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddLine(this.Width - radius, this.Height, radius, this.Height);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            loadForm(new frmItems());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            loadForm(new frmOrders());
        }

        private void loadForm(Form frm)
        {
            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.RemoveAt(0);
            }
            frm.Show();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(frm);
        }

    }
}
