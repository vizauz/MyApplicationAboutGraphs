using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyApplicationAboutGraphs
{
    public partial class Form1 : Form
    {
        public List<Rectangle> rects = new List<Rectangle>();
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();
        public Queue<Vertex> markedVertices = new Queue<Vertex>();
        public List<Edge> minSpanTree = new List<Edge>();
        public List<Edge> shortPath = new List<Edge>();

        public bool plotLine = false;
        public Vertex tmpVertex = null;
        public Edge plotEdge = null;

        public string[] labels = new string[] { 
        "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "m", "n", "b", "v", "c", "x", "z"
        };

        public int labelCount = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            vertices.Clear();
            edges.Clear();
            minSpanTree.Clear();
            shortPath.Clear();
            labelCount = 0;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {

            Bitmap tmp = new Bitmap(canvas.Width, canvas.Height);
            Graphics g = Graphics.FromImage(tmp);

            if (edges.Count > 0)
            {
                foreach (Edge ed in edges)
                {
                    ed.Draw(g);
                }
            }

            if (minSpanTree.Count > 0)
            {
                foreach (Edge ed in minSpanTree)
                {
                    g.DrawLine(Pens.Red, ed.startVertex.Pos, ed.endVertex.Pos);
                }
            }

            if (shortPath.Count > 0)
            {
                foreach (Edge ed in shortPath)
                {
                    g.DrawLine(Pens.WhiteSmoke, ed.startVertex.Pos, ed.endVertex.Pos);
                }
            }

            if (vertices.Count > 0)
            {
                foreach (Vertex v in vertices)
                {
                    v.Draw(g);
                }
            }
            if (plotEdge != null)
                g.DrawLine(Pens.Gold, plotEdge.startVertex.Pos, plotEdge.endVertex.Pos);

            labelVertices.Text = "Vertices: " + vertices.Count.ToString();
            labelEdges.Text = "Edges: " + edges.Count.ToString();
            labelPossibleEdges.Text = "Possible edges: " + (vertices.Count * (vertices.Count - 1) / 2).ToString();

            canvas.Image = tmp;
            g.Dispose();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    foreach (Vertex v in vertices)
                    {
                        if (e.X > v.Rect.X &&
                            e.X < v.Rect.X + v.Rect.Width &&
                            e.Y > v.Rect.Y &&
                            e.Y < v.Rect.Y + v.Rect.Height)
                        {
                            v.Marked = true;
                            markedVertices.Enqueue(v);
                            if (markedVertices.Count == 3)
                            {
                                markedVertices.Peek().Marked = false;
                                markedVertices.Dequeue();
                            }
                        }
                    }
                }
                else
                {
                    foreach (Vertex v in vertices)
                    {
                        if (e.X > v.Rect.X &&
                            e.X < v.Rect.X + v.Rect.Width &&
                            e.Y > v.Rect.Y &&
                            e.Y < v.Rect.Y + v.Rect.Height)
                        {
                            return;
                        }
                    }
                    if (labelCount < 25)
                    {
                        vertices.Add(new Vertex(new Point(e.X, e.Y), labels[labelCount]));
                    }
                    else
                    {
                        vertices.Add(new Vertex(new Point(e.X, e.Y), labels[labelCount % labels.Length] + labels[labelCount % labels.Length]));
                    }
                    labelCount++;
                } 
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (Vertex v in vertices)
                {
                    if (e.X > v.Rect.X &&
                        e.X < v.Rect.X + v.Rect.Width &&
                        e.Y > v.Rect.Y &&
                        e.Y < v.Rect.Y + v.Rect.Height)
                    {
                        plotLine = true;
                        tmpVertex = v;
                        v.Plotted = true;
                    }
                }
            }
            canvas.Refresh();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (plotLine)
                {
                    foreach (Vertex v in vertices)
                    {
                        if (e.X > v.Rect.X &&
                            e.X < v.Rect.X + v.Rect.Width &&
                            e.Y > v.Rect.Y &&
                            e.Y < v.Rect.Y + v.Rect.Height)
                        {
                            if (v != tmpVertex)
                            {
                                edges.Add(new Edge(tmpVertex, v));
                                v.Plotted = false;
                            }
                        }
                    }
                }
            }

            if (tmpVertex != null && tmpVertex.Plotted)
                tmpVertex.Plotted = false;
            plotEdge = null;
            plotLine = false;
            canvas.Refresh();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (plotLine)
            {
                plotEdge = new Edge(tmpVertex, new Vertex(new Point(e.X, e.Y), string.Empty));
                foreach (Vertex v in vertices)
                {
                    if (e.X > v.Rect.X &&
                        e.X < v.Rect.X + v.Rect.Width &&
                        e.Y > v.Rect.Y &&
                        e.Y < v.Rect.Y + v.Rect.Height)
                    {
                        if (v != tmpVertex)
                        {
                            v.Plotted = true;
                        }
                    }
                    else
                    {
                        if (v != tmpVertex)
                        {
                            v.Plotted = false;
                        }
                    }
                }
            }
        }

        private void buttonMinSpanTree_Click(object sender, EventArgs e)
        {
            minSpanTree.Clear();
            shortPath.Clear();
            Graph g = new Graph();
            foreach (Vertex v in vertices)
            {
                g.AddVertex(v);
            }

            foreach (Edge ed in edges)
            {
                g.AddEdge(ed.startVertex.Label, ed.endVertex.Label);
            }

            g.ShowGraph();

            if (markedVertices.Count > 0)
            {
                minSpanTree = g.MinSpannigTree(markedVertices.Peek().Label);
            }
            g.Dispose();
        }

        private void buttonFindPath_Click(object sender, EventArgs e)
        {
            shortPath.Clear();
            minSpanTree.Clear();

            Graph g = new Graph();
            foreach (Vertex v in vertices)
            {
                g.AddVertex(v);
            }

            foreach (Edge ed in edges)
            {
                g.AddEdge(ed.startVertex.Label, ed.endVertex.Label);
            }

            g.ShowGraph();

            if (markedVertices.Count == 2)
            {
                string start = markedVertices.Peek().Label;
                markedVertices.Enqueue(markedVertices.Dequeue());
                string end = markedVertices.Peek().Label; 
                markedVertices.Enqueue(markedVertices.Dequeue());

                shortPath = g.Path(start, end);
            }

            foreach (Edge ed in shortPath)
            {
                Console.WriteLine("<{0},{1}>", ed.startVertex.Label, ed.endVertex.Label);
            }
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shortPath.Clear();
            minSpanTree.Clear();
            markedVertices.Clear();

            foreach (Vertex v in vertices)
            {
                if (v.Marked)
                    v.Marked = !v.Marked;
            }

            canvas.Refresh();
        }

        private void saveGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Graph files (*.gr)|*.gr";
            DialogResult result = sfd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {

                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    if (vertices.Count > 0)
                    {
                        sw.WriteLine("Vertices");
                        foreach (Vertex v in vertices)
                        {
                            sw.WriteLine(String.Format("{0} {1} {2}", v.Label, v.Pos.X, v.Pos.Y));
                        }
                    }

                    if (edges.Count > 0)
                    {
                        sw.WriteLine("Edges");
                        foreach (Edge ed in edges)
                        {
                            sw.WriteLine(String.Format("{0} {1}", ed.startVertex.Label, ed.endVertex.Label));
                        } 
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graph files (*.gr) | *.gr";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                vertices.Clear();
                edges.Clear();

                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    
                    string str = String.Empty;
                    bool v = false, ed = false;

                    while ((str = sr.ReadLine()) != null)
                    {
                        if (v)
                        {
                            
                            string[] tmpVertex = sr.ReadLine().Trim(new char[] { ' ' }).Split(new char[] { ' ' });
                            if (tmpVertex.Length == 3)
                            {
                                vertices.Add(new Vertex(new Point(Int32.Parse(tmpVertex[1]), Int32.Parse(tmpVertex[2])), tmpVertex[0]));
                            }
                        }

                        if (ed)
                        {
                            
                            string[] tmpEdge = sr.ReadLine().Trim(new char[] { ' ' }).Split(new char[] { ' ' });
                            foreach (Vertex v1 in vertices)
                            {
                                if (v1.Label.Equals(tmpEdge[0]))
                                {
                                    foreach (Vertex v2 in vertices)
                                    {
                                        if (v2.Label.Equals(tmpEdge[1]))
                                        {
                                            edges.Add(new Edge(v1, v2));
                                        }
                                    }
                                }
                            }
                        }

                        if (str == "Vertices")
                        {
                            v = true;
                        }

                        if (str == "Edges")
                        {
                            v = false;
                            ed = true;
                        }
                            
                    }
                }
            }
            canvas.Refresh();
        }
    }
}