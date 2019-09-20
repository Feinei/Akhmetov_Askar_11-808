using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SemestrTask
{
    class Task
    {
        TwoThreeTree<string> dictionary;

        public void CheckText(string text)
        {
            foreach (var word in Regex.Split(text, @"\W+"))
                if (dictionary.SearchWithOneMistake(dictionary.Root, word))
                    Console.WriteLine("Ошибка в слове: " + word);
                else
                    dictionary.Insert(word);
        }

        public void FillDict(string text)
        {
            dictionary = new TwoThreeTree<string>();           
            foreach (var word in Regex.Split(text, @"\W+"))
                dictionary.Insert(word);
        }
    }

    public static class TwoThreeTreeExtends
    {
        public static bool SearchWithOneMistake(this TwoThreeTree<string> tree, TwoThreeNode<string> node, string value)
        {
            if (node.Type == NodeType.TwoNode)
                return SearchExt2(tree, node, value);
            else if (node.Type == NodeType.ThreeNode)
                return SearchExt3(tree, node, value);

            return false;
        }

        private static bool SearchExt2(this TwoThreeTree<string> tree, TwoThreeNode<string> node, string value)
        {
            if (node.Val1.CompareTo(value) == 0 || LevenshteinDistance(node.Val1, value) == 1)
                return true;

            if (node.Val1.CompareTo(value) > 0)
            {
                if (node.Left != null)
                    return SearchWithOneMistake(tree, node.Left, value);
                else
                    return false;
            }
            else
            {
                if (node.Right != null)
                    return SearchWithOneMistake(tree, node.Right, value);
                else
                    return false;
            }
        }

        private static bool SearchExt3(this TwoThreeTree<string> tree, TwoThreeNode<string> node, string value)
        {
            if (node.Val1.CompareTo(value) == 0 || LevenshteinDistance(node.Val1, value) == 1)
                return true;

            if (node.Val2.CompareTo(value) == 0 || LevenshteinDistance(node.Val2, value) == 1)
                return true;

            if (node.Val1.CompareTo(value) > 0)
            {
                if (node.Left != null)
                    return SearchWithOneMistake(tree, node.Left, value);
                else
                    return false;
            }
            else if (node.Val2.CompareTo(value) < 0)
            {
                if (node.Right != null)
                    return SearchWithOneMistake(tree, node.Right, value);
                else
                    return false;
            }
            else
            {
                if (node.Middle1 != null)
                    return SearchWithOneMistake(tree, node.Middle1, value);
                else
                    return false;
            }
        }

        private static int LevenshteinDistance(string first, string second)
        {
            var opt = new int[first.Length + 1, second.Length + 1];

            for (var i = 0; i <= first.Length; ++i)
                opt[i, 0] = i;
            for (var i = 0; i <= second.Length; ++i)
                opt[0, i] = i;

            for (var i = 1; i <= first.Length; ++i)
                for (var j = 1; j <= second.Length; ++j)
                {
                    if (first[i - 1] == second[j - 1])
                        opt[i, j] = opt[i - 1, j - 1];
                    else
                        opt[i, j] = 1 + Math.Min(opt[i, j - 1], Math.Min(opt[i - 1, j], opt[i - 1, j - 1]));
                }

            return opt[first.Length, second.Length];
        }
    }
}
