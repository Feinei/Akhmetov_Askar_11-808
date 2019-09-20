using System;
using System.Collections.Generic;
using System.Linq;

namespace yield
{
	public static class MovingMaxTask
	{
		public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
		{
            // Очередь максимальных значений
            var queueOfMax = new QueueOfMax(windowWidth);
			foreach (var origPoint in data)
            {
                queueOfMax.Add(origPoint.OriginalY);
                yield return new DataPoint
                {
                    OriginalY = origPoint.OriginalY,
                    MaxY = queueOfMax.GetMax(),
                    X = origPoint.X
                };
            }			
		}
	}
    // Узел
    class TwoLinkedNode<T>
    {
        public TwoLinkedNode<T> Next { get; set; }
        public TwoLinkedNode<T> Previos { get; set; }
        // Количество элементов, которое было удалено посредством появления этого элемента
        public int DeletedCount { get; set; }
        public T Value { get; set; }       
    }
    // Двусвязная очередь
    class LinkedQueue<T>
    {
        public TwoLinkedNode<T> Head { get; private set; }
        public TwoLinkedNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        // Добавление в очередь
        public void Enqueue(T value, int deletedCount)
        {
            var node = new TwoLinkedNode<T> { Value = value, DeletedCount = deletedCount };

            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previos = Tail;
            }
            Tail = node;
            Count++;
        }
        // Удаление первого элемента очереди
        public void DequeueHead()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (Count == 1)
                Head = Tail = null;
            else
            {
                Head = Head.Next;
                Head.Previos = null;
            }
            Count--;
        }
        // Удаление последнего элемента очереди
        public void DequeueTail()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (Count == 1)
                Head = Tail = null;
            else
            {
                Tail = Tail.Previos;
                Tail.Next = null;
            }
            Count--;
        }
    }
    // Ограниченная очередь для нахождения максимума
    // Головной элемент - максимум за последние limit элементов
    class QueueOfMax
    {
        LinkedQueue<double> queue = new LinkedQueue<double>();
        // Количество элементов, которые мы помещаем в очередь. Отличается от поля Count 
        // класса LinkedQueue тем, что здесь не учитываются элементы, которые были удалены с конца
        int imagineCount;
        
        int limit;
        public QueueOfMax(int limit)
        {
            this.limit = limit;
        }
        // Добавление в очередь
        public void Add(double value)
        {
            // Число удаленных элементов с конца
            int deletedCount = 0;
            if (queue.Count != 0)
            {
                // Если в очереди закончилось место И 
                // при этом перед головным элементом не стояло элементов, которые он "удалил"
                if (imagineCount == limit && queue.Head.DeletedCount == 0)
                {
                    queue.DequeueHead();
                    imagineCount--;
                }
                // Если перед головным элементом находились удаленные 
                else if (queue.Head.DeletedCount != 0)
                {
                    queue.Head.DeletedCount--;
                    imagineCount--;
                }
                // Пока новый эл. больше предыдущего И пока не кончатся элементы
                while (deletedCount != imagineCount && value > queue.Tail.Value)
                {
                    deletedCount += queue.Tail.DeletedCount + 1;
                    queue.DequeueTail();
                }
            }
            queue.Enqueue(value, deletedCount);
            imagineCount++;
        }
        // Возвращает максимальное значение
        // В результате работы алгоритма головной эл. всегда максимум, 
        // т.к. мы не храним в очереди элементы, которые точно не станут максимумом
        public double GetMax()
        {
            return queue.Head.Value;
        }
    }
}