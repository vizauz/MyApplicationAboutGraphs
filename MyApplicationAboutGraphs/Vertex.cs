using System.Drawing;
using System.Collections.Generic;

using System;
namespace MyApplicationAboutGraphs
{
    public class Vertex : IDisposable
    {
        public Rectangle Rect { get; set; }
        public Point Pos { get; set; }
        public bool Visited { get; set; }
        public string Label { get; set; }
        public bool Marked { get; set; }
        public bool Plotted { get; set; }
        public Vertex Parent { get; set; }
        public int Degree { get; set; }


        public LinkedList<Vertex> neighbors = new LinkedList<Vertex>();

        public Size size = new Size(24, 24);

        private SolidBrush fill = new SolidBrush(Color.DarkOliveGreen);
        private SolidBrush fillMarked = new SolidBrush(Color.SteelBlue);
        private SolidBrush plott = new SolidBrush(Color.LightCoral);


        public Vertex(Point p, string n)
        {
            Pos = p;
            Rect = new Rectangle(new Point(p.X - size.Width / 2, p.Y - size.Height / 2), size);
            Label = n;
            Visited = false;
        }

        public void Draw(Graphics g)
        {
            if (this.Marked)
            {
                g.FillRectangle(this.fillMarked, this.Rect);
            }
            else if (this.Plotted)
            {
                g.FillRectangle(this.plott, this.Rect);
            }
            else
            {
                g.FillRectangle(this.fill, this.Rect);
            }

            g.DrawString(
                this.Label.ToUpper(),
                new Font("consolas", 14), new SolidBrush(Color.White),
                new PointF(this.Pos.X - this.Rect.Width / 2, this.Pos.Y - this.Rect.Height / 2)
                );
        }

        public void Dispose()
        {
            neighbors.Clear();
        }
    }
}