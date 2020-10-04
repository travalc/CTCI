using CTCI.DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CTCI.Algorithms
{
    public static class TreesAndGraphs
    {
        /// <summary>
        /// Given 2 DirectedGraphNodes, uses BFS algorithm to determine if a route exists from source node to destination node
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="source">DirectedGraphNode</param>
        /// <param name="dest">DirectedGraphNode</param>
        /// <returns>bool</returns>
        public static bool RouteExists(DirectedGraphNode source, DirectedGraphNode dest)
        {
            if (source == null || dest == null)
                return false;
            if (source == dest)
                return true;
            
            Queue<DirectedGraphNode> nodeQueue = new Queue<DirectedGraphNode>();
            HashSet<DirectedGraphNode> visitedNodes = new HashSet<DirectedGraphNode>();
            nodeQueue.Enqueue(source);
            while (nodeQueue.Count > 0)
            {
                DirectedGraphNode currNode = nodeQueue.Dequeue();
                if (currNode == dest)
                    return true;
                visitedNodes.Add(currNode);
                foreach(DirectedGraphNode node in currNode.Children)
                {
                    if (!visitedNodes.Contains(node))
                        nodeQueue.Enqueue(node);
                }
            }

            return false;
        }
    }
}