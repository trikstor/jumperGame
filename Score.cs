using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public class Score
    {
        public static string Path = Environment.CurrentDirectory + "/scores.json";
        private ScoresLibrary library = new ScoresLibrary();

        public enum sortType
        {
            byDate,
            byScore
        }

        class ScoresLibrary : IEnumerable
        {
            private List<TabData> books = new List<TabData>();

            public void Add(string date, int score)
            {
                books.Add(new TabData { Date = date, Score = score });
            }

            public int Length
            {
                get { return books.Count; }
            }

            public TabData this[int index]
            {
                get
                {
                    return books[index];
                }
                set
                {
                    books[index] = value;
                }
            }

            public void SortResults(sortType type)
            {
                List<TabData> result = books;
                if (type == sortType.byScore)
                    books = result.OrderByDescending(pair => pair.Score).ToList();
                else
                    books = result.OrderByDescending(pair => pair.Date).ToList();
            }

            // возвращаем перечислитель
            IEnumerator IEnumerable.GetEnumerator()
            {
                return books.GetEnumerator();
            }
        }

        class ControlData
        {
            public TabData Request { get; set; }
        }

        class TabData
        {
            public string Date { get; set; }
            public int Score { get; set; }
        }

        private void GetScores()
        {
            string json;
            int i = 0;

            StreamReader sr = new StreamReader(Path);

            while (!sr.EndOfStream)
            {
                json = sr.ReadLine();
                ControlData Info = JsonConvert.DeserializeObject<ControlData>(json);

                library.Add(Info.Request.Date, Info.Request.Score);
            }

            sr.Close();
        }

        public static void AddScore(int currScore)
        {
            string json;

            ControlData myCollection = new ControlData();

            StreamWriter sw = new StreamWriter(Path);

            myCollection.Request = new TabData
            {
                Date = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss"),
                Score = currScore
            };
            json = JsonConvert.SerializeObject(myCollection);

            sw.WriteLine(json);
            sw.Close();
        }

        public string[] PrintScores(sortType srtype)
        {
            GetScores();
            library.SortResults(srtype);

            var count = library.Length;
            string[] result = new string[count];
            var i = 0;

            foreach (TabData dataScore in library)
            {
                result[i] = dataScore.Date + " Счет: " + dataScore.Score;
                i++;
            }

            return result;
        }
    }
}
