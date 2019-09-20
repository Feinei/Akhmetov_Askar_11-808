using System;

namespace SemestrTask
{
    public class TwoThreeNode<T>
    {
        public TwoThreeNode<T> Left { get; set; }
        public TwoThreeNode<T> Right { get; set; }
        public TwoThreeNode<T> Middle1 { get; set; }
        public TwoThreeNode<T> Middle2 { get; set; }
        public TwoThreeNode<T> Parent { get; set; }
        public T Val1 { get; set; }
        public T Val2 { get; set; }
        public T Val3 { get; set; }
        public NodeType Type { get; set; }
       
        public TwoThreeNode(TwoThreeNode<T> left, TwoThreeNode<T> right, TwoThreeNode<T> middle1, TwoThreeNode<T> middle2, TwoThreeNode<T> parent, T val1, T val2, T val3)
        {
            Left = left;
            Right = right;
            Middle1 = middle1;
            Middle2 = middle2;
            Parent = parent;
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
            Type = NodeType.FourNode;
        }

        public TwoThreeNode(TwoThreeNode<T> left, TwoThreeNode<T> right, TwoThreeNode<T> parent, T val1)
        {
            Left = left;
            Right = right;
            Parent = parent;
            Val1 = val1;
            Type = NodeType.TwoNode;

        }

        public TwoThreeNode(TwoThreeNode<T> left, TwoThreeNode<T> middle1, TwoThreeNode<T> right, TwoThreeNode<T> parent, T val1, T val2)
        {
            Left = left;
            Middle1 = middle1;
            Right = right;
            Parent = parent;
            Val1 = val1;
            Val2 = val2;
            Type = NodeType.ThreeNode;
        }

        public TwoThreeNode(NodeType type)
        {
            Type = type;
        }

        public TwoThreeNode(T val1)
        {
            Val1 = val1;
            Type = NodeType.TwoNode;
        }
        public TwoThreeNode(T val1, T val2)
        {
            Val1 = val1;
            Val2 = val2;
            Type = NodeType.ThreeNode;
        }

        public TwoThreeNode(T val1, T val2, T val3)
        {
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
            Type = NodeType.FourNode;
        }
    }
}