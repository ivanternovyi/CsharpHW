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
        private bool dragging = false;
        private bool isLinesSaved = false;
        private List<Line> arrLines = new List<Line>();
        private Point lineLocation;
        private Line currentLine;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(this.OnCanvasDragDrop);
            this.DragEnter += new DragEventHandler(this.OnCanvasDragEnter);
            graphics = panel1.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void OnFileNewClicked(object sender, EventArgs e)
        {
            if (!isLinesSaved)
            {
                var resultAnswer = MessageBox.Show("Save graphic?", "Graphic Menu", MessageBoxButtons.YesNo);
                if (resultAnswer == DialogResult.Yes)
                {
                    OnFileSaveClicked(sender, e);
                }
                arrLines.Clear();
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
                    pen.Color = ColorTranslator.FromHtml(line.HtmlColor);
                    graphics.DrawLine(pen, new Point(line.CoordX, line.CoordY),
                                        new Point(line.CoordX2, line.CoordY2));
                }
                pen.Color = Color.Black;
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

        private bool CheckIfPointLaysOnLine(Point point, Line obj)
        {
            var AB = Math.Sqrt(Math.Pow((point.X - obj.CoordX), 2) +
                  Math.Pow((point.Y - obj.CoordY), 2));
            var AC = Math.Sqrt(Math.Pow((point.X - obj.CoordX2), 2) +
                  Math.Pow((point.Y - obj.CoordY2), 2));
            var BC = Math.Sqrt(Math.Pow((obj.CoordX - obj.CoordX2), 2) +
                  Math.Pow((obj.CoordY - obj.CoordY2), 2));
            return BC == AB + AC;
        }

        private void OnCanvasMouseDown(object sender, MouseEventArgs e)
        {
            foreach (var line in arrLines)
            {
                if (CheckIfPointLaysOnLine(new Point(e.X, e.Y), line))
                {
                    this.currentLine = line;
                    dragging = true;
                    break;
                }
            }
            panel1.Cursor = Cursors.Hand;
            if (!dragging)
            {
                x = e.X;
                y = e.Y;
                panel1.Cursor = Cursors.Cross;
            }
        }

        private void OnCanvasMouseUp(object sender, MouseEventArgs e)
        {
            if (!dragging)
            {
                x2 = e.X;
                y2 = e.Y;
                graphics.DrawLine(pen, new Point(x, y), new Point(x2, y2));
                arrLines.Add(new Line(x, y, x2, y2, ColorTranslator.ToHtml(pen.Color)));
                x2 = -1;
                y2 = -1;
            }
            dragging = false;
            panel1.Cursor = Cursors.Default;
        }

        private void OnCanvasDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    this.currentLine = arrLines[0];
                    this.lineLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                try
                {
                    this.currentLine = (Line)e.Data.GetData(DataFormats.Bitmap);
                    this.lineLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            this.Invalidate();
        }

        private void OnCanvasDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
                e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

    }
}
