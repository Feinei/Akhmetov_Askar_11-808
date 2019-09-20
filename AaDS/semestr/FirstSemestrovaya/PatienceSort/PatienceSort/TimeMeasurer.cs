using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PatienceSort
{
    class TimeMeasurer
    {
        // Замеренное время на различных наборах
        public List<TimeSpan> ArraySortMeasureInfo = new List<TimeSpan>();
        public List<TimeSpan> ListSortMeasureInfo = new List<TimeSpan>();

        readonly int kitCount;
        private int kitSize;
        readonly int kitIncreaseSize;

        readonly static string wayToFile = @"C:\Users\Аскар\source\repos\PatienceSort\PatienceSort\Data.txt";
        readonly static FileStream data = new FileStream(wayToFile, FileMode.Open);
        readonly static StreamReader dataReader = new StreamReader(data);

        public TimeMeasurer(int kitCount, int kitStartSize, int kitIncreaseSize)
        {
            this.kitCount = kitCount;
            this.kitSize = kitStartSize;
            this.kitIncreaseSize = kitIncreaseSize;
        }
        // Замеряет время 
        public void Measure()
        {
            var watch = new Stopwatch();
            var watch1 = new Stopwatch();
            for (var kit = 0; kit < kitCount; kit++)
            {
                var array = new int[kitSize];
                var list = new LinkedList<int>();
                ReadData(array, list);
                var arrayToSort = new ArraySort(array);
                var listToSort = new LinkedListSort(list);

                watch.Start();
                arrayToSort.Sort();
                watch.Stop();
                ArraySortMeasureInfo.Add(watch.Elapsed);

                watch1.Start();
                listToSort.Sort();
                watch1.Stop();
                ListSortMeasureInfo.Add(watch.Elapsed);

                kitSize += kitIncreaseSize;
            }

            for (var i = 0; i < 0; i++)
            {
                ListSortMeasureInfo[i] = new TimeSpan(0);
            }
        }
        // Считывает информацию с файла
        private void ReadData(int[] array, LinkedList<int> list)
        {
            for (var i = 0; i < kitSize; i++)
            {
                var value = dataReader.Read();
                array[i] = value;
                list.AddLast(value);
            }
        }
    }
}
