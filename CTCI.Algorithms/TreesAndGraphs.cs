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

        /// <summary>
        /// Algorithm for representing levels of a Binary Tree as linked lists
        /// O(n) time and space
        /// </summary>
        /// <param name="root">BTNode<int></param>
        /// <returns>List<SLLNode></returns>
        public static List<SLLNode> ListOfDepths(BTNode<int> root)
        {
            if (root == null)
                return null;
            
            Dictionary<int, SLLNode> cache = new Dictionary<int, SLLNode>();
            cache[1] = new SLLNode(root.Data);
            ListOfDepthsHelper(root, 2, ref cache);

            List<SLLNode> levelList = new List<SLLNode>();
            foreach (KeyValuePair<int, SLLNode> pair in cache)
            {
                levelList.Add(pair.Value);
            }
            
            return levelList;
        }

        private static void ListOfDepthsHelper(BTNode<int> currNode, int currLevel, ref Dictionary<int, SLLNode> cache)
        {
            if (currNode.Left == null && currNode.Right == null)
                return;
            
            if (currNode.Left != null)
            {
                SLLNode leftNode = new SLLNode(currNode.Left.Data);
                if (currNode.Right != null)
                {
                    SLLNode rightNode = new SLLNode(currNode.Right.Data);
                    leftNode.Next = rightNode;
                }
                if (!cache.ContainsKey(currLevel))
                    cache[currLevel] = leftNode;
                else
                    ListOfDepthsAddToSLLHelper(cache[currLevel], leftNode);
            }
            else
            {
                SLLNode rightNode = new SLLNode(currNode.Right.Data);
                if (!cache.ContainsKey(currLevel))
                    cache[currLevel] = rightNode;
                else
                    ListOfDepthsAddToSLLHelper(cache[currLevel], rightNode);
            }

            int nextLevel = currLevel + 1;
            Console.WriteLine(currNode.Left.Data);
            if (currNode.Left != null)
                ListOfDepthsHelper(currNode.Left, nextLevel, ref cache);
            if (currNode.Right != null)
                ListOfDepthsHelper(currNode.Right, nextLevel, ref cache);
        }

        private static void ListOfDepthsAddToSLLHelper(SLLNode head, SLLNode tail)
        {
            while (head.Next != null)
                head = head.Next;
            head.Next = tail;
        }

        /// <summary>
        /// Algorithm for determining if a binary tree is balanced (diff between subtree heights is <= 1)
        /// O(n) time, space (call stack)
        /// </summary>
        /// <param name="root">BTNode<int></param>
        /// <returns>bool</returns>
        public static bool CheckBalanced(BTNode<int> root)
        {
            if (root == null)
                return false;
            if (root.Left == null && root.Right == null)
                return true;
            
            int leftHeight, rightHeight;
            if (root.Left == null)
                leftHeight = 0;
            else
                leftHeight = GetHeight(root.Left);
            if (root.Right == null)
                rightHeight = 0;
            else
                rightHeight = GetHeight(root.Right);

            return Math.Abs(leftHeight - rightHeight) <= 1;
        }

        private static int GetHeight(BTNode<int> node)
        {
            if (node.Left == null && node.Right == null)
                return 1;
            int leftHeight, rightHeight;
            
            if (node.Left == null)
                leftHeight = 0;
            else
                leftHeight = GetHeight(node.Left);

            if (node.Right == null)
                rightHeight = 0;
            else
                rightHeight = GetHeight(node.Right);
            
            int max;
            if (leftHeight >= rightHeight)
                max = leftHeight;
            else
                max = rightHeight;
            
            return max + 1;
        }


        /// <summary>
        /// Algorithm for validating if a Binary Tree is a Binary Search Tree
        /// O(n^2) time, space due to deep copy of cached lists
        /// </summary>
        /// <param name="root">BTNode<int></param>
        /// <returns>bool</returns>
        public static bool ValidateBST(BTNode<int> root)
        {
            if (root == null)
                return false;

            List<int> greaterThan = new List<int>();
            List<int> lessThan = new List<int>();
            return ValidateBST(root, greaterThan, lessThan);
        }

        private static bool ValidateBST(BTNode<int> node, List<int> greaterThan, List<int> lessThan)
        {
            if (node.Left == null && node.Right == null)
                return true;
            
            List<int> leftIsLessThan = new List<int>();
            List<int> leftIsGreaterThan = new List<int>();
            List<int> rightIsLessThan = new List<int>();
            List<int> rightIsGreaterThan = new List<int>();
            bool leftIsValid, rightIsValid;

            if (node.Left == null)
                leftIsValid = true;
            else
            {
                if (node.Left.Data > node.Data)
                    return false;
                foreach(int num in lessThan)
                {
                    if (node.Left.Data > num)
                        return false;
                    leftIsLessThan.Add(num);
                }
                leftIsLessThan.Add(node.Data);

                foreach(int num in greaterThan)
                {
                    if (node.Left.Data < num)
                        return false;
                    leftIsGreaterThan.Add(num);
                }
                leftIsValid = ValidateBST(node.Left, leftIsGreaterThan, leftIsLessThan);
            }

            if (node.Right == null)
                rightIsValid = true;
            else
            {
                if (node.Right.Data < node.Data)
                    return false;
                foreach (int num in greaterThan)
                {
                    if (node.Right.Data < num)
                        return false;
                    rightIsGreaterThan.Add(num);
                }
                rightIsGreaterThan.Add(node.Data);

                foreach(int num in lessThan)
                {
                    if (node.Right.Data > num)
                        return false;
                    rightIsLessThan.Add(num);
                }
                rightIsValid = ValidateBST(node.Right, rightIsGreaterThan, rightIsLessThan);
            }

            return leftIsValid && rightIsValid;
        }

        /// <summary>
        /// Algorithm that returns the next sequential node (ascending) when given a binary search tree node. Nodes in the tree have access to parent.
        /// O(n) time, O(1) space
        /// </summary>
        /// <param name="node">BSTPNode</param>
        /// <returns>BSTPNode</returns>
        public static BSTPNode Successor(BSTPNode node)
        {
            if (node == null)
                return null;
            
            if (node.Right != null)
            {
                BSTPNode currChild = (BSTPNode)node.Right;
                while (currChild.Left != null)
                    currChild = (BSTPNode)currChild.Left;
                return currChild;
            }
            
            BSTPNode currParent = node.Parent;
            if (currParent == null)
                return null;
            while (currParent != null && currParent.Data < node.Data)
                currParent = currParent.Parent;
            return currParent;
        }

        /// <summary>
        /// Algorithm that uses breadth first search to determine a build order given list of projects and list of tuples representing dependencies
        /// O(nLogn) run time, O(n) space
        /// </summary>
        /// <param name="projects">List<char></param>
        /// <param name="dependencies">List<Tuple<char, char>></param>
        /// <returns>List<char></returns>
        public static List<char> BuildOrder(List<char> projects, List<Tuple<char, char>> dependencies)
        {
            if (projects == null || dependencies == null)
                throw new Exception("Missing projects or dependencies");
            
            Dictionary<char, List<char>> projectsWithDependencies = new Dictionary<char, List<char>>();
            Dictionary<char, List<char>> projectsWithDependents = new Dictionary<char, List<char>>();
            List<char> projectsWithNoDependenciesOrDependents = new List<char>();
            List<char> projectsWithDependentsButNoDependencies = new List<char>();

            foreach (Tuple<char, char> pair in dependencies)
            {
                char dependent = pair.Item2;
                char dependency = pair.Item1;
                
                if (projectsWithDependencies.ContainsKey(dependent))
                    projectsWithDependencies[dependent].Add(dependency);
                else
                    projectsWithDependencies[dependent] = new List<char> { dependency };

                if (projectsWithDependents.ContainsKey(dependency))
                    projectsWithDependents[dependency].Add(dependent);
                else
                    projectsWithDependents[dependency] = new List<char> { dependent };
            }

            foreach (char project in projects)
            {
                if (!projectsWithDependencies.ContainsKey(project) && !projectsWithDependents.ContainsKey(project))
                    projectsWithNoDependenciesOrDependents.Add(project);
                if (!projectsWithDependencies.ContainsKey(project) && projectsWithDependents.ContainsKey(project))
                    projectsWithDependentsButNoDependencies.Add(project);
            }

            List<char> buildOrder = new List<char>();
            Queue<char> buildQueue = new Queue<char>();
            HashSet<char> alreadyQueued = new HashSet<char>();
            HashSet<char> alreadyBuilt = new HashSet<char>();
            foreach (char project in projectsWithDependentsButNoDependencies)
            {
                buildQueue.Enqueue(project);
                alreadyQueued.Add(project);
            }
            foreach (char project in projectsWithNoDependenciesOrDependents)
            {
                buildQueue.Enqueue(project);
                alreadyQueued.Add(project);
            }
            while(buildQueue.Count > 0)
            {
                char project = buildQueue.Dequeue();
                if (alreadyBuilt.Contains(project))
                    throw new Exception("Invalid build order, circular dependency");
                if (projectsWithDependents.ContainsKey(project))
                {
                    foreach(char dependent in projectsWithDependents[project])
                    {
                        if (alreadyBuilt.Contains(dependent))
                            throw new Exception("Invalid build order, circular dependency");
                        if (!alreadyQueued.Contains(dependent))
                        {
                            buildQueue.Enqueue(dependent);
                            alreadyQueued.Add(dependent);
                        }
                    }
                }
                buildOrder.Add(project);
                alreadyBuilt.Add(project);
            }

            foreach(char project in projects)
            {
                if (!alreadyBuilt.Contains(project))
                    throw new Exception("Invalid build order, not all dependencies are built.");
            }

            return buildOrder;
        }

        /// <summary>
        /// Algorithm for getting first common ancestor in binary tree for 2 nodes. Uses post-order traversal depth first search
        /// O(2^n) runtime, O(n) space
        /// </summary>
        /// <param name="root">BTNode<int></param>
        /// <param name="nodeA">BTNode<int></param>
        /// <param name="nodeB">BTNode<int></param>
        /// <returns></returns>
        public static BTNode<int> FirstCommonAncestor(BTNode<int> root, BTNode<int> nodeA, BTNode<int> nodeB)
        {
            if (root == null || nodeA == null || nodeB == null)
                return null;
            
            BTNode<int> fcaInLeft = FirstCommonAncestor(root.Left, nodeA, nodeB);
            if (fcaInLeft != null)
                return fcaInLeft;
            BTNode<int> fcaInRight = FirstCommonAncestor(root.Right, nodeA, nodeB);
            if (fcaInRight != null)
                return fcaInRight;
            
            if ((ChildFound(root.Left, nodeA) && ChildFound(root.Right, nodeB)) || (ChildFound(root.Left, nodeB) && ChildFound(root.Right, nodeA)))
                return root;

            return null;
        }

        private static bool ChildFound(BTNode<int> currNode, BTNode<int> child)
        {
            if (currNode == null)
                return false;
            if (currNode == child)
                return true;
            
            return ChildFound(currNode.Left, child) || ChildFound(currNode.Right, child);
        }

        /// <summary>
        /// Algorithm for checking if one binary tree is a subtree of another
        /// O(n + km) runtime, where m is number of nodes in second tree, and k is number of nodes in bigger tree where node == root of second tree. O(log(n)) space
        /// </summary>
        /// <param name="root1">BTNode<int></param>
        /// <param name="root2">BTNode<int></param>
        /// <returns>bool</returns>
        public static bool CheckSubtree(BTNode<int> root1, BTNode<int> root2)
        {
            if (root1 == null || root2 == null)
                return false;
            
            if (root1.Data == root2.Data)
            {
                bool validSubtree = ValidateSubtree(root1, root2);
                if (validSubtree)
                    return true;
            }

            bool checkLeft = CheckSubtree(root1.Left, root2);
            bool checkRight = CheckSubtree(root1.Right, root2);
            if (checkLeft || checkRight)
                return true;
            return false;
        }

        private static bool ValidateSubtree(BTNode<int> root1, BTNode<int> root2)
        {
            if (root2.Left != null || root2.Right != null)
            {
                if (root1.Left.Data != root2.Left.Data || root1.Right.Data != root2.Right.Data)
                    return false;
                
                bool leftMatch, rightMatch;
                if (root2.Left == null && root1.Left == null)
                    leftMatch = true;
                else
                    leftMatch = ValidateSubtree(root1.Left, root2.Left);
                if (root2.Right == null & root1.Right == null)
                    rightMatch = true;
                else
                    rightMatch = ValidateSubtree(root1.Right, root2.Right);
                return leftMatch && rightMatch;
            }

            return root1.Data == root2.Data;
        }

        /// <summary>
        /// Algorithm for getting all possible paths in a binary tree that add up to a given sum
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static int PathsWithSum(BTNode<int> root, int sum)
        {
            if (root == null)
                return 0;
            
            Dictionary<int, int> cache = new Dictionary<int, int>();
            GetAllSums(root, new List<int>(), ref cache);
            if (!cache.ContainsKey(sum))
                return 0;
            
            return cache[sum];
        }

        private static void GetAllSums(BTNode<int> currNode, List<int> prevSums, ref Dictionary<int, int> cache)
        {
            if (currNode == null)
                return;
            
            List<int> currSums = new List<int>();
            foreach(int prevSum in prevSums)
            {
                int currSum = prevSum + currNode.Data;
                if (!cache.ContainsKey(currSum))
                    cache.Add(currSum, 1);
                else
                    cache[currSum] ++;
                currSums.Add(currSum);
            }

            if (!cache.ContainsKey(currNode.Data))
                cache.Add(currNode.Data, 1);
            else
                cache[currNode.Data] ++;
            currSums.Add(currNode.Data);

            GetAllSums(currNode.Left, currSums, ref cache);
            GetAllSums(currNode.Right, currSums, ref cache);
        }
    }
}