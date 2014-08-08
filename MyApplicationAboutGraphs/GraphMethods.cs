//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MyApplicationAboutGraphs
//{
//    public partial class Graph
//    {
//        #region Find cycles
//        public void FindCycles()
//        {
//            foreach (Vertex v in _vertices)
//            {
//                if (!v.WasVisited)
//                    DFS(v, false, processEdgeForBackEdge);
//            }
//        }

//        private void processEdgeForBackEdge(Vertex parent, Vertex child)
//        {
//            if (parent == null || child == null) return;
           
//            if (child.parent.Label != parent.Label)
//            {
//                Console.WriteLine("<{0},{1}> - back edge", child.Label, parent.Label);
//            }
//        }

//        private void DFSForCycles(Vertex v, Vertex u)
//        {
//            v.WasVisited = true;

//            foreach (Vertex n in v.neighbors)
//            {
//                if (!n.WasVisited)
//                {
//                    DFSForCycles(n, v);
//                }
//                else
//                {
//                    if (!n.Label.Equals(u.Label))
//                    {
//                        Console.WriteLine("Has cycle");
//                        Console.WriteLine("<{0}, {1}>", v.Label, n.Label);
//                    }
//                }
//            }
//        } 
//        #endregion

//        #region ColorizeGraph
//        public void ColorizeGraph()
//        {
//            Bipartite = true;

//            foreach (Vertex v in _vertices)
//            {
//                if (!v.WasVisited)
//                    DFSForColorizeGraph(v);
//            }
//        }

//        private void DFSForColorizeGraph(Vertex v)
//        {
//            v.WasVisited = true;
//            foreach (Vertex n in v.neighbors)
//            {
//                if (!n.WasVisited)
//                {
//                    n.Color = !v.Color;
//                    DFSForColorizeGraph(n);
//                }
//                else if (n.Color == v.Color)
//                {
//                    Bipartite = false;
//                }
//            }
//        }

//        public void ShowColors()
//        {
//            foreach (Vertex v in _vertices)
//            {
//                if (v.Color)
//                {
//                    Console.WriteLine("{0} is white", v.Label);
//                }
//                else
//                {
//                    Console.WriteLine("{0} is black", v.Label);
//                }
//            }
//        }
//        #endregion
//    }
//}
