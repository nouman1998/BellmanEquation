using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelmanFordRouting
{
    public class Path
    {
        public string From;
        public string To;
        public int Cost;

        public Path(string from, string to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }
    }
    public class Program
    {
        public static string[] vertices = { "U", "V", "W", "X", "Y", "Z" };

        public static List<Path> graph = new List<Path>()
        {
            new Path("U", "X", 5),
            new Path("U", "W", 3),
            new Path("U", "V", 7),
            new Path("X", "W", 4),
            new Path("X", "Z", 9),
            new Path("X", "Y", 7),
            new Path("W", "Y", 8),            new Path("W", "V", 3),
            new Path("V", "Y", 4),
            new Path("Y", "Z", 2)
        };

        public static Dictionary<string, int> tempCost = new Dictionary<string, int>()
        {
            { "U", 0 },
            { "V", int.MaxValue },
            { "W", int.MaxValue },
            { "X", int.MaxValue },
            { "Y", int.MaxValue },
            { "Z", int.MaxValue }
        };

        public static bool BellmanAlgo()
        {
            bool flag = false;

            foreach (var fromVertex in vertices)
            {
                Path[] edges = graph.Where(x =>  x.From == fromVertex).ToArray();
                foreach (var edge in edges)
                {
                    int potentialCost = tempCost[edge.From] == int.MaxValue ? int.MaxValue : tempCost[edge.From] + edge.Cost;
                    if (potentialCost < tempCost[edge.To])
                    {
                        tempCost[edge.To] = potentialCost;
                        flag = true;
                    }
                }
            }
            return flag;
        }

        static void Main()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                if (!BellmanAlgo())
                    break;
            }

            foreach (var keyValue in tempCost)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
            Console.ReadLine();
        }
    }
}