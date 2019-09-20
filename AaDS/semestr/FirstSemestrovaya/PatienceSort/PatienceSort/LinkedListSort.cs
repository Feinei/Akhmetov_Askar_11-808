using System.Collections.Generic;

namespace PatienceSort
{
    class LinkedListSort
    {
        private LinkedList<int> list;
        private List<Stack<int>> piles;

        public LinkedListSort(LinkedList<int> list)
        {
            this.list = list;
        }
        // Сортировка
        public void Sort()
        {
            Division();

            list = new LinkedList<int>();
            while (piles.Count != 0)
                list.AddLast(GetMin());
        }
        // Сортирует стопки так, чтобы левее находилась стопка, верхний эл. которой минимален
        private void SortPiles(int index)
        {
            while (2 * index + 1 < piles.Count)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                int j = left;
                if (right < piles.Count && piles[right].Peek() <= piles[left].Peek())
                    j = right;

                if (piles[index].Peek() <= piles[j].Peek())
                    break;

                var temp = piles[index];
                piles[index] = piles[j];
                piles[j] = temp;
                index = j;
            }
        }
        // Минимум всегда сверху левой стопки 
        private int GetMin()
        {
            var min = piles[0].Pop();
            if (piles[0].Count == 0)
                piles.RemoveAt(0);
            else
                SortPiles(0);
            return min;

        }
        // Разделяем на стопки входные данные с использованием бин.поиска. О(n*log(n))
        private void Division()
        {
            piles = new List<Stack<int>>();
            foreach (var element in list)
            {
                int leftBorder = BinarySearch(element);

                if (leftBorder == piles.Count)
                {
                    piles.Add(new Stack<int>());
                    leftBorder = piles.Count - 1;
                }
                piles[leftBorder].Push(element);
            }
        }
        // Бинарный поиск самой левой подходящей стопки. O(log(n))
        private int BinarySearch(int value)
        {
            int left = 0;
            int rigth = piles.Count - 1;
            while (left <= rigth)
            {
                int mid = (left + rigth) / 2;
                if (piles[mid].Peek() >= value)
                    rigth = mid - 1;
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
