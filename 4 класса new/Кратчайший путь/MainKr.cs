using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_класса_new
{
   public class MainKr
    { public void MainKrr()
        {
			int[] ms1 = { };
			string str1 = "";

			int[,] mas;
			int raz1 = 0, d = 0;

			using (StreamReader sr = new StreamReader(@"vvodMinRasstoyanie.csv"))
			{

				sr.ReadLine();
				int totalNodes = Convert.ToInt32(sr.ReadLine());
				str1 = sr.ReadToEnd();


				string[] st = str1.Split('\n');
				raz1 = st.Length;

				ms1 = Array.ConvertAll(st[0].Split(';'), int.Parse);
				d = ms1.Length;
				mas = new int[raz1, d];
				for (int i = 0; i < raz1; i++)
				{
					ms1 = Array.ConvertAll(st[i].Split(';'), int.Parse);
					for (int j = 0; j < d; j++)
					{
						mas[i, j] = ms1[j];

					}
				}

				int[,] distanceGraph = mas;

				
				int startNodeIndex = 1;
				while (startNodeIndex < 1 || startNodeIndex > totalNodes)
				{
					Console.WriteLine("Start Node is not present. Please re enter starting node");
					startNodeIndex = Convert.ToInt32(Console.ReadLine());
				}
				List<Node> resultSet = new Algorithm().DijkstraAlgo(distanceGraph, totalNodes, startNodeIndex - 1);
				using (StreamWriter sw = new StreamWriter(@"vivodMinRasstoyanie.csv", false, Encoding.Default, 10))
				{

					sw.WriteLine(resultSet.ToStringTable(new[] { "Узел", "Родитель", "Общее расстояние", "Путь" }, a => a.Index + 1, a => a.Parent + 1, a => a.TotalDistance, a => a.PathToString ?? "No Way"));

				}

				Console.WriteLine(resultSet.ToStringTable(new[] { "Узел", "Родитель", "Общее расстояние", "Путь" }, a => a.Index + 1, a => a.Parent + 1, a => a.TotalDistance, a => a.PathToString ?? "No Way"));
				Console.ReadLine();
			}
		}
    }
}
