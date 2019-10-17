using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace TodoApplication
{
    public class ListModel<TItem>
    {
        // Ограниченный стэк последних событий <удаленное ли дело, дело>
        LimitedSizeStack<Tuple<bool, TItem>> lastActions;
        public List<TItem> Items { get; }
        public int Limit;       

        public ListModel(int limit)
        {
            lastActions = new LimitedSizeStack<Tuple<bool, TItem>>(limit);
            Items = new List<TItem>();
            Limit = limit;
        }
        // Добавление дела
        public void AddItem(TItem item)
        {
            // В стэк кладется дело и false - событие добавления
            lastActions.Push(Tuple.Create(false, item));
            Items.Add(item);
        }
        // Удаление события
        public void RemoveItem(int index)
        {
            // В стэк кладется дело и true - событие удаления
            lastActions.Push(Tuple.Create(true, Items[index]));
            Items.RemoveAt(index);
        }

        public bool CanUndo()
        {
            return lastActions.Count != 0;
        }

        public void Undo()
        {
            var undoAction = lastActions.Pop();
            // Если последнее событие это удаление, то возращаем дело обратно
            if (undoAction.Item1)
                Items.Add(undoAction.Item2);
            // Если добавление, то удаляем 
            else
                Items.Remove(undoAction.Item2);
        }
    }
}
