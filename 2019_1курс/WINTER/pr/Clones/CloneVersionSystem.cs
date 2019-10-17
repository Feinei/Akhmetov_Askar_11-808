using System;
using System.Collections;
using System.Collections.Generic;

namespace Clones
{
    public class CloneVersionSystem : ICloneVersionSystem
    {
        // Список всех клонов
        List<Cloner> clones = new List<Cloner>();
        // Изначально 1 клон
        public CloneVersionSystem()
        {
            clones.Add(new Cloner(1));
        }
        // Определяет входную команду
        public string Execute(string query)
        {
            // 0 - команда, 1 - номер клона, 2 - программа (для learn)
            var partsOfQuery = query.Split(' ');
            // Номер клона, к которому применяется команда
            var cloneNumber = int.Parse(partsOfQuery[1]) - 1;
            if (partsOfQuery[0] == "learn")
            {
                clones[cloneNumber].Learn(partsOfQuery[2]);
            }
            else if (partsOfQuery[0] == "rollback")
            {
                clones[cloneNumber].Rollback();
            }
            else if (partsOfQuery[0] == "relearn")
            {
                clones[cloneNumber].Relearn();
            }
            else if (partsOfQuery[0] == "clone")
            {
                // Создаем клона со новым номером
                clones.Add(clones[cloneNumber].Clone(cloneNumber + 1));
            }
            else if (partsOfQuery[0] == "check")
            {
                return clones[cloneNumber].Check();
            }
            return null;
        }
    }
    // Клон
    public class Cloner
    {
        // Стэки выученных, откаченных программ, номер клона
        LinkedStack<string> learnedProg = new LinkedStack<string>();
        LinkedStack<string> cancelProg = new LinkedStack<string>();
        private readonly int number;

        public Cloner(int number)
        {
            this.number = number;
        }
        // Обучение программе
        public void Learn(string program)
        {
            learnedProg.Add(program);
        }
        // Откат программы
        public void Rollback()
        {
            var lastProg = learnedProg.GetLastNode();
            learnedProg.Remove();
            cancelProg.Add(lastProg);
        }
        // Переусвоение последнего отката клона
        public void Relearn()
        {
            var lastRollbackProg = cancelProg.GetLastNode();
            cancelProg.Remove();
            learnedProg.Add(lastRollbackProg);
        }
        // Возвращает уже клонированого клона
        public Cloner Clone(int newCloneNumber)
        {
            return new Cloner(newCloneNumber)
            {
                learnedProg = (LinkedStack<string>)learnedProg.Clone(),
                cancelProg = (LinkedStack<string>)cancelProg.Clone()
            };
        }
        // Возвращает последнюю освоенную программу
        public string Check()
        {
            if (learnedProg.IsEmpty)
                return "basic";
            return learnedProg.GetLastNode();
        }
    }
    // Узел 
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
    // Односвязный стэк
    public class LinkedStack<T> : ICloneable
    {
        Node<T> head;
        public bool IsEmpty { get { return head == null; } }
        // Добавление элемента
        public void Add(T value)
        {
            if (head == null)
                head = new Node<T> { Value = value, Next = null };
            else
            {
                var newNode = new Node<T> { Value = value, Next = head };
                head = newNode;
            }
        }
        // Удаление элемента 
        public void Remove()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            else
                head = head.Next;
        }
        // Возвращает последний элемент
        public T GetLastNode()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            else
                return head.Value;
        }
        // Возвращает скопированый стэк для нового клона
        public object Clone()
        {
            var newCloneStack = new LinkedStack<T>();
            newCloneStack.head = head;
            return newCloneStack;
        }
    }
}