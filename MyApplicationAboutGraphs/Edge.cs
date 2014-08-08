using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyApplicationAboutGraphs
{
    public class Edge
    {

        public Vertex startVertex;
        public Vertex endVertex;
        public Pen stroke = Pens.Black;
        public int Weight { get; set; }

        public Edge(Vertex v1, Vertex v2)
        {
            startVertex = v1;
            endVertex = v2;

            int dx = startVertex.Pos.X - endVertex.Pos.X;
            int dy = startVertex.Pos.Y - endVertex.Pos.Y;

            Weight = (int)Math.Sqrt(dx * dx - dy * dy) % 50;
        }

        public void Draw(Graphics g)
        {
            Point labelPos = new Point(
                (startVertex.Pos.X + endVertex.Pos.X) / 2,
                (startVertex.Pos.Y + endVertex.Pos.Y) / 2
                );
                

            g.DrawLine(this.stroke, startVertex.Pos, endVertex.Pos);
            g.DrawString(
                Weight.ToString(),
                new Font("consolas", 10), new SolidBrush(Color.White),
                labelPos
                );
        }

    }
}
