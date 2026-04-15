using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class DataEntry
    {
        public int Score {  get; set; }
        public string Username {  get; set; }
        public int Rank {  get; set; }
        public DataEntry() { }
        public DataEntry(int score, string username, int rank)
        {
            Score = score;
            Username = username;
        }

        public static List<DataEntry> Sort(List<DataEntry> list)
        {
            // Chatgpt anfang
            // prompt: public static List<DataEntry> Sort(List<DataEntry> list) { return list; }
            // //ich bekomme eine liste, diese liste wird nach score sortiert, angeordnet und dann soll der rank angepasst werden, Dataentry hat username, score und rank
            var sorted = list
                .OrderByDescending(x => x.Score)
                .ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                sorted[i].Rank = i + 1;
            }

            return sorted;
            // ende
        }
    }
}
