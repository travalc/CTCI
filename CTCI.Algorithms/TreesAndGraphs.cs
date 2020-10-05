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

        /// <summary>
        /// Method for constructing binary search tree from sorted ascending list of integers
        /// O(log n) time, O(n) space
        /// </summary>
        /// <param name="list">List<int></param>
        /// <returns>BSTNode</returns>
        public static BSTNode MinimalTree(List<int> list)
        {
            if (list == null || list.Count == 0)
                return null;
            if (list.Count == 1)
                return new BSTNode(list[0]);

            BSTNode node;
            if (list.Count == 2)
            {
                node = new BSTNode(list[list.Count - 1]);
                BSTNode leftChild = new BSTNode(list[0]);
                node.Left = leftChild;
                return node;
            }

            int mid = list.Count / 2;
            List<int> leftList = Helper.Slice(list, 0, mid);
            List<int> rightList = Helper.Slice(list, mid + 1, list.Count);
            node = new BSTNode(list[mid]);
            node.Left = MinimalTree(leftList);
            node.Right = MinimalTree(rightList);

            return node;
        }
    }
}