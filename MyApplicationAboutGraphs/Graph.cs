using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace MyApplicationAboutGraphs
{
    public partial class Graph : IDisposable
    {
        private int _edges;
        private LinkedList<Vertex> _vertices = new LinkedList<Vertex>();

        public delegate void ProcessEdge(Vertex v1, Vertex v2);

        public delegate void ProcessVertex(Vertex v);

        public int Edges {
            get { return _edges; }
            private set { _edges = value; }
        }

        public bool Bipartite { get; set; }

        //public static Graph CreateGraphFromFile(string fileName) {
        //    Graph g = new Graph();

        //    if (!string.IsNullOrEmpty(fileName)) {
        //        using (StreamReader sr = new StreamReader(fileName)) {
        //            string str = sr.ReadLine();
        //            foreach (string s in str.Trim(new char[] { ' ' }).Split(new char[] { ' ' })) {
        //                g.AddVertex(s);
        //            }

        //            while ((str = sr.ReadLine()) != null) {
        //                if (!String.IsNullOrEmpty(str)) {
        //                    string[] tmp = str.Split(new char[] { ' ' });
        //                    if (tmp[2] == "@")
        //                        g.AddDirectEdge(tmp[0], tmp[1]);
        //                    else
        //                        g.AddEdge(tmp[0], tmp[1]);
        //                }
        //            }
        //        }
        //    }

        //    return g;
        //}

        public static void ShowEdges(List<Edge> edges) {
            foreach (Edge ed in edges) {
                Console.WriteLine("<{0}, {1}>", ed.startVertex.Label, ed.endVertex.Label);
            }
        }

        public void AddDirectEdge(string label1, string label2) {
            Vertex v1 = null, v2 = null;
            foreach (Vertex v in _vertices) {
                if (v.Label.Equals(label1))
                    v1 = v;
                if (v.Label.Equals(label2))
                    v2 = v;
            }
            AddDirectEdge(v1, v2);
            Edges++;
        }

        public void AddEdge(string label1, string label2) {
            Vertex startVertex = null, endVertex = null;

            foreach (Vertex v in _vertices) {
                if (v.Label.Equals(label1))
                    startVertex = v;
                if (v.Label.Equals(label2))
                    endVertex = v;
            }

            AddDirectEdge(startVertex, endVertex);
            AddDirectEdge(endVertex, startVertex);
            Edges++;
        }

        public void AddVertex(string label, Point pos) {
            _vertices.AddLast(new Vertex(pos, label));
        }

        public void AddVertex(Vertex v)
        {
            _vertices.AddLast(v);
        }

        public bool BFS(
            string startVertex,
            bool clear,
            ProcessEdge processEdge = null,
            ProcessVertex before = null,
            ProcessVertex after = null
            ) {
            Vertex sv = GetVertexByName(startVertex);

            if (sv == null) return false;

            if (BFS(sv, clear, processEdge, before, after))
                return true;

            return false;
        }

        public bool DFS(
            string startVertex,
            bool clear,
            ProcessEdge processEdge = null,
            ProcessVertex before = null,
            ProcessVertex after = null
            ) {
            Vertex sv = null;

            sv = GetVertexByName(startVertex);

            if (sv == null) return false;

            if (DFS(sv, clear, processEdge, before, after))
                return true;

            return false;
        }

        public List<Edge> MinSpannigTree(string startVertex) {
            Vertex sv = GetVertexByName(startVertex);
            Vertex currentVertex = null;
            Stack<Vertex> s = new Stack<Vertex>();
            List<Edge> edges = new List<Edge>();

            sv.Visited = true;
            s.Push(sv);

            while (s.Count > 0) {
                currentVertex = s.Peek();
                Vertex v = GetAdjUnvisitedVertex(currentVertex);

                if (v == null)
                    s.Pop();
                else {
                    v.Visited = true;
                    s.Push(v);
                    edges.Add(new Edge(v, currentVertex));
                }
            }
            ClearAllVertices();
            return edges;
        }

        public List<Edge> Path(string startVertex, string endVertex) {
            Vertex sv = GetVertexByName(startVertex);
            Vertex ev = GetVertexByName(endVertex);
            List<Edge> path = new List<Edge>();
            Stack<Edge> edges = new Stack<Edge>();

            if (sv.Label.Equals(ev.Label))
                Console.WriteLine(sv.Label);

            if (BFS(sv, false)) {
                while (ev.Parent != null) {
                    edges.Push(new Edge(ev, ev.Parent));
                    ev = ev.Parent;
                }
            }

            while (edges.Count > 0) {
                path.Add(edges.Pop());
            }

            ClearAllVertices();

            return path;
        }

        public void ShowGraph() {
            foreach (Vertex v in _vertices) {
                Console.Write("Vertex {0} => [ ", v.Label);

                foreach (Vertex n in v.neighbors)
                    Console.Write("{0} ", n.Label);

                Console.Write("]");
                Console.WriteLine();
            }
        }

        private void AddDirectEdge(Vertex startVertex, Vertex endVertex) {
            startVertex.neighbors.AddLast(endVertex);
            startVertex.Degree++;
        }

        private bool BFS(
            Vertex sv,
            bool clear,
            ProcessEdge processEdge = null,
            ProcessVertex before = null,
            ProcessVertex after = null
            ) {
            Queue<Vertex> q = new Queue<Vertex>();

            sv.Visited = true;
            if (sv.neighbors.Count <= 0)
                return false;
            else {
                q.Enqueue(sv);
                while (q.Count > 0) {
                    Vertex v = q.Dequeue();

                    if (before != null) before(v);

                    foreach (Vertex n in v.neighbors) {
                        if (n.Visited == false) {
                            // ???????????
                            n.Visited = true;
                            n.Parent = v;
                            // ?????????????????
                            if (processEdge != null) processEdge(v, n);
                            q.Enqueue(n);
                        }
                    }

                    if (after != null) after(v);
                }
            }

            if (clear)
                ClearAllVertices();
            return true;
        }

        private void ClearAllVertices() {
            foreach (Vertex v in _vertices) {
                v.Visited = false;
                v.Parent = null;
            }
        }

        private bool DFS(
            Vertex sv,
            bool clear,
            ProcessEdge processEdge = null,
            ProcessVertex before = null,
            ProcessVertex after = null
            ) {
            sv.Visited = true;

            if (sv.neighbors.Count <= 0)
                return false;
            else {
                if (before != null) before(sv);

                foreach (Vertex n in sv.neighbors) {
                    if (n.Visited == false) {
                        n.Parent = sv;
                        if (processEdge != null) processEdge(sv, n);
                        DFS(n, false, processEdge, before, after);
                    }
                }

                if (after != null) after(sv);
            }

            if (clear)
                ClearAllVertices();
            return true;
        }

        private Vertex GetAdjUnvisitedVertex(Vertex v) {
            if (v.neighbors.Count > 0) {
                foreach (Vertex n in v.neighbors) {
                    if (n.Visited == false)
                        return n;
                }
            }
            return null;
        }

        private Vertex GetVertexByName(string startVertex) {
            foreach (Vertex v in _vertices)
                if (v.Label.Equals(startVertex))
                    return v;
            return null;
        }

        public bool HasEdge(string v, string u) {
            Vertex vv = GetVertexByName(v);
            Vertex vu = GetVertexByName(u);
            return HasEdge(vv, vu);
        }

        private bool HasEdge(Vertex v, Vertex u) {
            foreach (Vertex vv in _vertices) {
                if (vv.Label.Equals(v.Label)) {
                    foreach (Vertex vu in _vertices) {
                        if (vu.Label.Equals(u.Label))
                            return true;
                    }
                }
            }
            return false;
        }

        public void Dispose()
        {
            foreach (Vertex v in _vertices)
            {
                v.Dispose();
            }
        }
    }
}