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
        private Graphics graphics;
        private int x = -1;
        private int y = -1;
        private int x2 = -1;
        private int y2 = -1;
        private Pen pen;
        private bool isLinesSaved = false;

        public Form1()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private List<Line> arrLines = new List<Line>();

        private void OnFileNewClicked(object sender, EventArgs e)
        {
            if (!isLinesSaved)
            {
                var resultAnswer = MessageBox.Show("Save graphic?", "Graphic Menu", MessageBoxButtons.YesNo);
                if (resultAnswer == DialogResult.Yes)
                {
                    OnFileSaveClicked(sender, e);
                }
            }
            // Clearing the drawings
            panel1.Invalidate();
        }

        private void OnFileOpenClicked(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                FileName = "Lines",
                DefaultExt = "xml"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                panel1.Refresh();
                arrLines.Clear();
                arrLines = SerializationManager.Deserialize(openFileDialog.FileName);
                foreach (var line in arrLines)
                {
                    // TODO: Fix open saved lines with specific color
                    pen.Color = ColorTranslator.FromHtml(line.HtmlColor);
                    graphics.DrawLine(pen, new Point(line.CoordX, line.CoordY),
                                        new Point(line.CoordX2, line.CoordY2));
                }
            }
        }

        private void OnFileSaveClicked(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "Lines",
                DefaultExt = "xml"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializationManager.Serialize(saveFileDialog.FileName, arrLines);
                isLinesSaved = true;
            }
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
            arrLines.Add(new Line(x, y, x2, y2, ColorTranslator.ToHtml(pen.Color)));
            x2 = -1;
            y2 = -1;
            panel1.Cursor = Cursors.Default;
        }
    }
}
