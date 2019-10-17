using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        LinkedList<T> stack = new LinkedList<T>();
        // Вместимость стэка
        private int limit;
        public LimitedSizeStack(int limit)
        {
            this.limit = limit;
        }

        public void Push(T item)
        {
            // Если в стэке максимум элементов, удаляем первый
            if (stack.Count == limit)
            {
                stack.RemoveFirst();
            }
            stack.AddLast(item);
        }

        public T Pop()
        {
            // Если в стэке нет эл., недопустимая операция
            if (stack.Count == 0) throw new InvalidOperationException();
            var popResult = stack.Last();
            stack.RemoveLast();
            return popResult;
        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }
    }
}
