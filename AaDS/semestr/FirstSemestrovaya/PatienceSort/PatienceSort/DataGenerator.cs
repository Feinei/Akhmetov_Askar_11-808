using System;
using System.IO;
using System.Text;

namespace PatienceSort
{
    class DataGenerator
    {
        readonly int kitCount;
        private int kitSize;
        readonly int kitIncreaseSize;

        public DataGenerator(int kitCount, int kitStartSize, int kitIncreaseSize)
        {
            this.kitCount = kitCount;
            this.kitSize = kitStartSize;
            this.kitIncreaseSize = kitIncreaseSize;
        }

        public void Generate()
        {
            var wayToFile = @"C:\Users\Аскар\source\repos\PatienceSort\PatienceSort\Data.txt";

            Random random = new Random();
            var data = new StringBuilder();
            for (var kit = 0; kit < kitCount; kit++)
            {             
                for (var i = 0; i < kitSize; i++)
                {
                    data.Append(random.Next(-100,100));
                    data.Append(" ");
                }
                data.Append("\r\n");
                kitSize += kitIncreaseSize;
                Console.WriteLine(kit);
            }
            File.WriteAllText(wayToFile, data.ToString());
        }
    }
}
