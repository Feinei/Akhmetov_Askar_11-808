using System;
using System.Collections.Generic;
using System.Linq;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
        {        
            // Добавление команд вывода и записи с помощью функ. write и read
            vm.RegisterCommand('.', vMachine => write((char)vMachine.Memory[vMachine.MemoryPointer]));
            vm.RegisterCommand(',', vMachine => vMachine.Memory[vMachine.MemoryPointer] = (byte)read());
            // Добавление остальных команд
            RegisterIncNDec(vm);
            RegisterRigthSNLefthift(vm);
            RegisterConstants(vm);
        }
        // Увеличение/уменьшение байта памяти, на который указывает указатель
        private static void RegisterIncNDec(IVirtualMachine vm)
        {
            vm.RegisterCommand('+', vMachine =>
            {
                // Если значение байта максимально, то при увеличении значение становится 0
                if (vMachine.Memory[vMachine.MemoryPointer] == 255)
                    vMachine.Memory[vMachine.MemoryPointer] = 0;
                else
                    vMachine.Memory[vMachine.MemoryPointer]++;
            });

            vm.RegisterCommand('-', vMachine =>
            {               
                if (vMachine.Memory[vMachine.MemoryPointer] == 0) // Аналогично инкрименту
                    vMachine.Memory[vMachine.MemoryPointer] = 255;
                else
                    vMachine.Memory[vMachine.MemoryPointer]--;
            });
        }
        // Сдвинуть указатель памяти вправо/влево на 1 байт
        private static void RegisterRigthSNLefthift(IVirtualMachine vm)
        {
            vm.RegisterCommand('>', vMachine =>
            {
                // Если указатель памяти указывает на последнюю ячейку памяти, то ставим его в начало
                if (vMachine.MemoryPointer + 1 == vMachine.Memory.Length)
                    vMachine.MemoryPointer = 0;
                else
                    vMachine.MemoryPointer++;
            });

            vm.RegisterCommand('<', vMachine =>
            {
                if (vMachine.MemoryPointer == 0) // Аналогично сдвигу вправо
                    vMachine.MemoryPointer = vMachine.Memory.Length - 1;
                else
                    vMachine.MemoryPointer--;
            });
        }

        static readonly char[] consts = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();
        // Добавление констант
        private static void RegisterConstants(IVirtualMachine vm)
        {
            foreach (var c in consts)
            {
                vm.RegisterCommand(c, vMachine => vMachine.Memory[vMachine.MemoryPointer] = (byte)c);
            }
        }
    }
}