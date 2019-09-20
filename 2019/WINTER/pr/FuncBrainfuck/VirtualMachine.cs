using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public VirtualMachine(string program, int memorySize)
		{
            Instructions = program;
            InstructionPointer = 0;
            MemoryPointer = 0;
            Memory = new byte[memorySize];
		}
        // Добавление новой команды
		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
            commands.Add(symbol, execute);
		}
        // Словарь ключами, которого являются символы, по которым вызывается определенная команда
        private Dictionary<char, Action<IVirtualMachine>> commands = new Dictionary<char, Action<IVirtualMachine>>();
        // Список входных команд
		public string Instructions { get; }
        // Номер выполняемой в данный момент команды
        public int InstructionPointer { get; set; }
        // Массив памяти
        public byte[] Memory { get; }
        // Указатель на текущую ячейку памяти
        public int MemoryPointer { get; set; }

		public void Run()
		{
            // Пока не выполнится последняя входная команда
            while (Instructions.Length != InstructionPointer)
            {
                // Входной символ, который подразумевает под собой определенную команду
                var command = Instructions[InstructionPointer];
                // Если данная пара символ-команда были "зарегестрированы", то находим и выполняем соответ. команду
                if (commands.ContainsKey(command))
                    commands[command](this);
                InstructionPointer++;
            }
		}
	}
}