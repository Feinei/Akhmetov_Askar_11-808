using System;
using System.Collections.Generic;

namespace yield
{
	public static class MovingAverageTask
	{
		public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
		{
            // Предыдущие Y координаты точек 
            var previousData = new LimitedQueue(windowWidth);
            foreach (var origPoint in data)
            {
                // Добавляем Y координату текущей точки 
                previousData.Add(origPoint.OriginalY);
                // Получаем ср.ариф. Y координат (n-1) предыдущих точек и текущей точки
                yield return new DataPoint
                {
                    OriginalY = origPoint.OriginalY,
                    AvgSmoothedY = previousData.GetAverage(),
                    X = origPoint.X
                };
            }
		}
	}
    // Узел
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
    // Очередь
    class Queue<T>
    {
        Node<T> head;
        Node<T> tail;
       
        public int Count { get; private set; }
        // Добавление в очередь
        public void Enqueue(T value)
        {                  
            var node = new Node<T>(value);
            Node<T> tempNode = tail;
            tail = node;
            if (Count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            Count++;
        }
        // Удаление из очереди
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            Count--;
            return result;
        }
    }   
    // Ограниченная очередь для чисел
    class LimitedQueue
    {
        Queue<double> queue = new Queue<double>();
        // Сумма всех элементов в очереди
        public double QueueSum { get; private set; } 
       
        int limit;
        public LimitedQueue(int limit)
        {
            this.limit = limit;
        }
        // Добавление в очередь
        public void Add(double value)
        {
            QueueSum += value;
            // Если в очереди кончилось место, выкидываем первый элемент, также вычитаем его из суммы
            if (queue.Count == limit)
                QueueSum -= queue.Dequeue();
            queue.Enqueue(value);
        }
        // Возвращает ср.ариф. элементов в очереди
        public double GetAverage()
        {
            return QueueSum / queue.Count;
        }
    }
}