using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatienceSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Кол-во наборов. Начальный размер набора. Увелечение размера набора
            var kitCount = 100;
            var kitSize = 100;
            var kitIncreaseSize = 100;

            GenerateData(kitCount, kitSize, kitIncreaseSize);
            BuildChart(kitCount, kitSize, kitIncreaseSize);          
        }
   
        static void GenerateData(int kitCount, int kitSize, int kitIncreaseSize)
        {
            var generator = new DataGenerator(kitCount, kitSize, kitIncreaseSize);
            generator.Generate();
        }

        static void BuildChart(int kitCount, int kitSize, int kitIncreaseSize)
        {
            var measureTime = new TimeMeasurer(kitCount, kitSize, kitIncreaseSize);
            measureTime.Measure();

            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            
            var arrayRaw = new Series();
            var kitSizeTemp = kitSize;
            var coef = 100;
            foreach (var time in measureTime.ArraySortMeasureInfo)
            {
                arrayRaw.Points.Add(new DataPoint(kitSizeTemp / coef, time.Ticks / coef));
                kitSizeTemp += kitIncreaseSize;
            }
            
            var listRaw = new Series();
            kitSizeTemp = kitSize;
            foreach (var time in measureTime.ListSortMeasureInfo)
            {
                listRaw.Points.Add(new DataPoint(kitSizeTemp / coef, time.Ticks / coef));
                kitSizeTemp += kitIncreaseSize;
            }
        
            arrayRaw.ChartType = SeriesChartType.FastLine;
            arrayRaw.Color = Color.Red;
            listRaw.ChartType = SeriesChartType.FastLine;
            listRaw.Color = Color.Blue;

            chart.Series.Add(arrayRaw);
            chart.Series.Add(listRaw);
            chart.Dock = System.Windows.Forms.DockStyle.Fill;

            var form = new Form();
            form.Controls.Add(chart);
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);
        }
    }
}
