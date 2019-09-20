using System.Collections.Generic;

namespace func.brainfuck
{
	public class BrainfuckLoopCommands
	{
        // Словарь ключ которого - индекс откр.скобки, а значение - индекс соответ.закр.скобки 
        private static Dictionary<int, int> loopIndexesFromStart = new Dictionary<int, int>();
        private static Dictionary<int, int> loopIndexesFromEnd = new Dictionary<int, int>(); // Наоборот
        // Заполение словарей
        public static void FillDict(IVirtualMachine vm)
        {
            var openBracketIndexes = new Stack<int>();
            var index = 0;
            // Проходим по строке инструкций и записываем в словарь индексы откр./закр. скобок
            foreach (var c in vm.Instructions)
            {
                switch (c)
                {
                    case '[':
                        openBracketIndexes.Push(index);
                        break;
                    case ']':
                        var lastOpenBracketIndex = openBracketIndexes.Pop();
                        loopIndexesFromStart[lastOpenBracketIndex] = index;
                        loopIndexesFromEnd[index] = lastOpenBracketIndex;
                        break;
                }
                index++;
            }
        }
        // Добавление команд
        public static void RegisterTo(IVirtualMachine vm)
        {
            FillDict(vm);

            vm.RegisterCommand('[', vMachine =>
            {
                // Если текущая яч.памяти = 0, то перескакиваем на соответ.закр.скобку (получаем индекс по словарю)
                if (vMachine.Memory[vMachine.MemoryPointer] == 0)
                    vMachine.InstructionPointer = loopIndexesFromStart[vMachine.InstructionPointer];
            });

            vm.RegisterCommand(']', vMachine =>
            {
                if (vMachine.Memory[vMachine.MemoryPointer] != 0) // Наоборот с закр.скобкой: если != 0 
                    vMachine.InstructionPointer = loopIndexesFromEnd[vMachine.InstructionPointer];
            });        
		}
	}
}