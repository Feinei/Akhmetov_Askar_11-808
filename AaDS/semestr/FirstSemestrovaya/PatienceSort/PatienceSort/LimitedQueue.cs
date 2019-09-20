using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatienceSort
{
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
        // Очищает очередь
        public void Clear()
        {
            queue.Clear();
        }
        // Возвращает ср.ариф. элементов в очереди
        public double GetAverage()
        {
            return QueueSum / queue.Count;
        }
    }
}
