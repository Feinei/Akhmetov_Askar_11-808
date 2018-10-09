using System;

namespace Names
{
    internal static class HeatmapTask
    {
        // Возвращает массивы имен для осей 
        public static string[] GetNamesAxis(int arrayLength, string check)
        {
            // В случае с днями нам нужно исключить первый день месяца, поэтому нумерация начинается 2
            int turn;
            if (check == "days")
                turn = 2;
            else
                turn = 1;

            var names = new string[arrayLength];
            for (int i = 0; i < names.Length; i++)
                names[i] = (i + turn).ToString();
            return names;
        }

        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var heatmap = new double[30, 12];
            // Проходит по базе данных по каждому человеку
            foreach (var human in names)
                // Исключаем тех, у кого д.р. первого числа
                if (human.BirthDate.Day > 1)
                    // Число рождения - 2, т.к. нумерация массива с 0, а числа с 2 (месяца аналогично)
                    heatmap[human.BirthDate.Day - 2, human.BirthDate.Month - 1]++;

            return new HeatmapData("Карта интенсивностей", heatmap,
                                   GetNamesAxis(30, "days"), GetNamesAxis(12, "months"));
        }
    }
} 