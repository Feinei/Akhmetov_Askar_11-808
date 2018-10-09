using System;
using System.Collections.Generic;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names)
        {
            // Ось X
            var namesAxes = GetNames();
            // Данные для гитстограммы 
            var dataForHistogram = new double[namesAxes.Length];

            // Проходит по базе данных
            foreach (var human in names)
                // Проходит по заданным именам 
                for (int i = 0; i < namesAxes.Length; i++)
                    // Если имя в базе данных совпадает с заданным нами, то ++ в соответствующую колонку
                    if (human.Name == namesAxes[i])
                        dataForHistogram[i]++;

            return new HistogramData(" ", namesAxes, dataForHistogram);
        }
        // Создает массив с именами, которые вводит пользователь 
        public static string [] GetNames()
        {
            int namesCount = int.Parse(Console.ReadLine());
            var names = new string[namesCount];
            for (int i = 0; i < namesCount; i++)
                names[i] = Console.ReadLine();
            return names;
        }
    }
}