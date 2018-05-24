using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics graphics;

        int x = -1;
        int y = -1;
        int x2 = -1;
        int y2 = -1;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Draw(object sender, PaintEventArgs e)
        {
           // e.Graphics.FillEllipse(Brushes.Olive, 10, 10, 100, 100);
        }

        private void TestColor()
        {
    
        }
        
        private void OnFileNewClicked(object sender, EventArgs e)
        {
            // Clearing the drawings
            panel1.Invalidate();  
        }

        private void OnFileOpenClicked(object sender, EventArgs e)
        {

        }

        private void OnFileSaveClicked(object sender, EventArgs e)
        {
           
        }

        private void OnPictureBoxClicked(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;

        }

        private void OnCanvasMouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void OnCanvasMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void OnCanvasMouseUp(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            graphics.DrawLine(pen, new Point(x, y), new Point(x2, y2));
            x2 = -1;
            y2 = -1;
            panel1.Cursor = Cursors.Default;
        }
    }
}
