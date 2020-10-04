using System.Collections.Generic;

namespace CTCI.DataStructures
{
    /// <summary>
    /// Class representing a directed (unidirectional) graph using an adjacency list
    /// </summary>
    public class DirectedGraph
    {

        public List<DirectedGraphNode> Nodes { get; set; }

        public DirectedGraph(List<DirectedGraphNode> nodes)
        {
            Nodes = nodes;
        }
    }

    /// <summary>
    /// Class representing a directed (unidirectional) graph node. An Adjacency list is used to represent edges.
    /// </summary>
    public class DirectedGraphNode
    {
        public int Data { get; set; }
        public List<DirectedGraphNode> Children { get; set; }
        public DirectedGraphNode(int data)
        {
            Data = data;
            Children = new List<DirectedGraphNode>();
        }
    }
}