using System;

namespace SemestrTask
{
    public class TwoThreeTree<T> where T : IComparable
    {
        public TwoThreeNode<T> Root { get; private set; }

        public TwoThreeTree()
        {
            Root = null;
        }

        public T GetMin(T minValue)
        {
            TwoThreeNode<T> node = FindNode(Root, minValue);
            return node.Val1;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new TwoThreeNode<T>(null, null, null, value);
                return;
            }

            if (!Search(Root, value))
            {
                var node = FindNode(Root, value);
                if (node == Root && node.Type == NodeType.TwoNode)
                    Root = CreateAThreeNode(node, value);
                else if (node == Root && node.Type == NodeType.ThreeNode)
                {
                    Root = CreateAFourNode(node, value);
                    Root = Split(Root);
                }
                else if (node.Type == NodeType.TwoNode)
                    node = CreateAThreeNode(node, value);
                else if (node.Type == NodeType.ThreeNode)
                {
                    node = CreateAFourNode(node, value);
                    TwoThreeNode<T> inCase = Split(node);

                    if (inCase.Parent == null)
                        Root = inCase;
                }
            }
        }

        public bool Search(TwoThreeNode<T> node, T value)
        {
            if (node.Type == NodeType.TwoNode)
                return Search2(node, value);
            else if (node.Type == NodeType.ThreeNode)
                return Search3(node, value);

            return false;
        }

        private bool Search2(TwoThreeNode<T> node, T value)
        {
            if (node.Val1.CompareTo(value) == 0)
                return true;

            if (node.Val1.CompareTo(value) > 0)
            {
                if (node.Left != null)
                    return Search(node.Left, value);
                else
                    return false;
            }
            else
            {
                if (node.Right != null)
                    return Search(node.Right, value);
                else
                    return false;
            }
        }

        private bool Search3(TwoThreeNode<T> node, T value)
        {
            if (node.Val1.CompareTo(value) == 0)
                return true;

            if (node.Val2.CompareTo(value) == 0)
                return true;

            if (node.Val1.CompareTo(value) > 0)
            {
                if (node.Left != null)
                    return Search(node.Left, value);
                else
                    return false;
            }
            else if (node.Val2.CompareTo(value) < 0)
            {
                if (node.Right != null)
                    return Search(node.Right, value);
                else
                    return false;
            }
            else
            {
                if (node.Middle1 != null)
                    return Search(node.Middle1, value);
                else
                    return false;
            }
        }
 
        private TwoThreeNode<T> FindNode(TwoThreeNode<T> node, T value)
        {
            if (node.Type == NodeType.TwoNode)
                return FindNode2(node, value);
            else if (node.Type == NodeType.ThreeNode)
                return FindNode3(node, value);

            return null;
        }

        private TwoThreeNode<T> FindNode2(TwoThreeNode<T> node, T value)
        {
            if (node.Val1.CompareTo(value) == 0)
                return node;

            if (node.Val1.CompareTo(value) > 0)
            {
                if (node.Left != null)
                    return FindNode(node.Left, value);
                else
                    return node;
            }
            else
            {
                if (node.Right != null)
                    return FindNode(node.Right, value);
                else
                    return node;
            }
        }

        private TwoThreeNode<T> FindNode3(TwoThreeNode<T> node, T value)
        {
            if (node.Val1.CompareTo(value) > 0)
            {
                if (node.Left != null)
                    return FindNode(node.Left, value);
                else
                    return node;
            }
            else if (node.Val2.CompareTo(value) < 0)
            {
                if (node.Right != null)
                    return FindNode(node.Right, value);
                else
                    return node;
            }
            else
            {
                if (node.Middle1 != null)
                    return FindNode(node.Middle1, value);
                else
                    return node;
            }
        }

        private TwoThreeNode<T> CreateAThreeNode(TwoThreeNode<T> node, T value)
        {
            TwoThreeNode<T> newThreeNode;
            if (node.Val1.CompareTo(value) < 0)
            {
                newThreeNode = new TwoThreeNode<T>(node.Val1, value) { Parent = node.Parent };
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                        node.Parent.Left = newThreeNode;
                    else if (node.Parent.Right == node)
                        node.Parent.Right = newThreeNode;
                    else
                        node.Parent.Middle1 = newThreeNode;
                }
            }
            else
            {
                newThreeNode = new TwoThreeNode<T>(value, node.Val1) { Parent = node.Parent };
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                        node.Parent.Left = newThreeNode;
                    else if (node.Parent.Right == node)
                        node.Parent.Right = newThreeNode;
                    else
                        node.Parent.Middle1 = newThreeNode;
                }
            }           
            return newThreeNode;
        }

        private TwoThreeNode<T> CreateAFourNode(TwoThreeNode<T> node, T value)
        {
            TwoThreeNode<T> newFourNode;
            if (node.Val1.CompareTo(value) > 0)
            {
                newFourNode = new TwoThreeNode<T>(value, node.Val1, node.Val2) { Parent = node.Parent };
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                        node.Parent.Left = newFourNode;
                    else if (node.Parent.Right == node)
                        node.Parent.Right = newFourNode;
                    else
                        node.Parent.Middle1 = newFourNode;                   
                }
            }
            else if (node.Val2.CompareTo(value) < 0)
            {
                newFourNode = new TwoThreeNode<T>(node.Val1, node.Val2, value) { Parent = node.Parent }; 
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                        node.Parent.Left = newFourNode;
                    else if (node.Parent.Right == node)
                        node.Parent.Right = newFourNode;
                    else
                        node.Parent.Middle1 = newFourNode;
                }
            }
            else
            {
                newFourNode = new TwoThreeNode<T>(node.Val1, value, node.Val2) { Parent = node.Parent };
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                        node.Parent.Left = newFourNode;
                    else if (node.Parent.Right == node)
                        node.Parent.Right = newFourNode;
                    else
                        node.Parent.Middle1 = newFourNode;                   
                }
            }
            return newFourNode;
        }
 
        private TwoThreeNode<T> Split(TwoThreeNode<T> node)
        {
            var a = new TwoThreeNode<T>(node.Left, node.Middle1, node.Parent, node.Val1);
            var b = new TwoThreeNode<T>(node.Middle2, node.Right, node.Parent, node.Val3);
            TwoThreeNode<T> x;
            if (node.Parent == null)
            {
                x = new TwoThreeNode<T>(a, b, null, node.Val2);
                a.Parent = x; b.Parent = x;
                return x;
            }
            else if (node.Parent.Type == NodeType.TwoNode)
            {
                x = new TwoThreeNode<T>(NodeType.ThreeNode) { Parent = node.Parent.Parent };
                a.Parent = x; b.Parent = x;
                if (node.Parent.Right == node)
                {
                    x.Left = node.Parent.Left; x.Middle1 = a; x.Right = b;
                    x.Val1 = node.Parent.Val1; x.Val2 = node.Val2;
                }
                else
                {
                    x.Left = a; x.Middle1 = b; x.Right = node.Parent.Right;
                    x.Val1 = node.Val2; x.Val2 = node.Parent.Val1;
                }
                node.Parent = x;
                return x;
            }
            else
            {
                x = new TwoThreeNode<T>(NodeType.FourNode) { Parent = node.Parent.Parent };
                a.Parent = x; b.Parent = x;
                if (node.Parent.Right == node)
                {
                    x.Left = node.Parent.Left; x.Middle1 = node.Parent.Middle1; x.Middle2 = a; x.Right = b;
                    x.Val1 = node.Parent.Val1; x.Val2 = node.Parent.Val2; x.Val3 = node.Val2;
                }
                else if (node.Parent.Left == node)
                {
                    x.Right = node.Parent.Right; x.Middle1 = b; x.Middle2 = node.Parent.Middle1; x.Left = a;           
                    x.Val1 = node.Val2; x.Val2 = node.Parent.Val1; x.Val3 = node.Parent.Val2;
                }
                else
                {
                    x.Left = node.Parent.Left; x.Middle1 = a; x.Middle2 = b; x.Right = node.Parent.Right;
                    x.Val1 = node.Parent.Val1; x.Val2 = node.Val2; x.Val3 = node.Parent.Val2;
                }
                node.Parent = x;
                return Split(x);
            }
        }
    }
}