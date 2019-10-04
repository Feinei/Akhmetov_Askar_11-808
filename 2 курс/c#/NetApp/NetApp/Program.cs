using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDataByTagsAsync("https://ulearn.me/", "<img", "src=\"");
            DownloadSiteAndNeigh("https://ulearn.me/");
            Console.Read();
        }

        static void GetDataByTagsAsync(string url, string tag, string inTag = null)
        {
            WebClient client = new WebClient();

            foreach (var inUrl in GetDataByTags(url, tag, inTag))
                client.DownloadFile(inUrl, "info.txt");

            Console.WriteLine("Изображения загружены");
        }

        static List<string> GetDataByTags(string url, string tag, string inTag = null)
        {
            var result = new List<string>();
            WebClient client = new WebClient();

            using (Stream stream = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                    if (line.Contains(tag))
                    {
                        if (inTag == null)
                            inTag = tag;

                        line = line.Substring(line.IndexOf(inTag) + inTag.Length);
                        result.Add(line.Substring(0, line.IndexOf("\"")));
                    }
            }
            return result;
        }

        static void DownloadSiteAndNeigh(string url)
        {
            WebClient client = new WebClient();

            client.DownloadFile(url, "info.txt");
            foreach (var inUrl in GetDataByTags(url, "src=\""))
                client.DownloadFile(inUrl, "info.txt");

            Console.WriteLine("Файлы загружены");
        }
    }
}
