//Rafed Fareed 101205956
//Tuan Hai Phung 101170570
//Andrii Bohdan 101171640

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
		static void Main(string[] args)
		{
			
			FileStream fs = File.Open("testdata.txt", FileMode.Open);
			using (StreamReader sr = new StreamReader(fs))
			{
				
				string ans = sr.ReadLine();

			    Console.WriteLine(ans + '\n');

				string read = sr.ReadLine();
				int students = 0;
				int[] rightAnswers = new int[20];
				while (read != "0")
				{
					students++;
					string[] splitted = read.Split(' ');
					read = sr.ReadLine();
					int count = 0;
					for (int x = 0; x < ans.Length; x++)
					{
						if (splitted[1][x] == 'X')
						{
							continue;
						}
						if (splitted[1][x] == ans[x])
						{
							rightAnswers[x] +=1 ;
							count += 4;
						}
						else
						{
							count -= 1;
						}
					}
				    Console.WriteLine($"Student number: {splitted[0]} got {count} points");
				}
                            
				Console.WriteLine($"Total number of students: {students}");

				Console.Write("Questions:\t");
				for (int i = 1; i <= rightAnswers.Length; i++) {
					Console.Write(i + "\t");
				}
				Console.WriteLine();
				Console.Write("Answers: \t");
				for (int i = 0; i < rightAnswers.Length; i++)
                {
                    Console.Write(rightAnswers[i] + "\t");
                }
			}         
		}
        
    }
}
