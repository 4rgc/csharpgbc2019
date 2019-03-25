//Rafed Fareed 101205956
//Tuan Hai Phung 101170570
//Andrii Bohdan 101171640
using System;
using System.IO;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int questionNumber = 20;
            try
            {
                using (StreamReader sr = new StreamReader("testdata.txt"))
                {
                    string ans = sr.ReadLine();
                    //Check if the answer key line is correct
                    if (String.IsNullOrEmpty(ans) || ans.Length != questionNumber)
                    {
                        Console.WriteLine("The answer key line was empty or incorrect!");
                        return;
                    }
                    Console.WriteLine("Correct answers: " + ans + '\n');

                    int students = 0;
                    //Array for question statistics
                    int[] rightAnswers = new int[questionNumber];
                    do
                    {
                        string read = sr.ReadLine();

                        //Check for EOF, either actual, or arranged (0 at the end)
                        if (read?.StartsWith("0") == true)
                        {
                            break;
                        }
                        //Check for errors in student answer line
                        if (String.IsNullOrEmpty(read) || read.Length != questionNumber + 5)
                        {
                            Console.WriteLine($"Line {students + 2} cannot be processed");
                            return;
                        }
                        //Split the student string into two parts: student ID, and their answers
                        string[] splitted = read.Split(' ');
                        //The line has correct format so we can increase the student counter
                        students++;
                        int studentId = Convert.ToInt32(splitted[0]), points = 0;
                        //Process the answers
                        for (int i = 0; i < ans.Length; i++)
                        {
                            //If no answer was entered
                            if (splitted[1][i] == 'X')
                            {
                                continue;
                            }
                            //If the answer was correct
                            if (splitted[1][i] == ans[i])
                            {
                                rightAnswers[i] += 1;
                                points += 4;
                                continue;
                            }
                            //If the answer was incorrect
                            if (splitted[1][i] == 'A' || splitted[1][i] == 'B' ||
                                splitted[1][i] == 'C' || splitted[1][i] == 'D' ||
                                splitted[1][i] == 'E')
                            {
                                points -= 1;
                                continue;
                            }
                            //If there was an unexpected character in the answers
                            Console.WriteLine($"Line {students + 1} had incorrect format!");
                            return;
                        }
                        Console.WriteLine($"Student number: {studentId} got {points} points");
                    } while (true);
                    Console.WriteLine($"Total number of students: {students}");
                    //Print the answer statistics in readable format
                    for (int c = 0; c < questionNumber / 10; c++)
                    {
                        Console.Write("\nQuestions:\t");
                        for (int i = c * 10 + 1; i < (c * 10 + 1) + 10; i++)
                        {
                            Console.Write(i + "\t");
                        }
                        Console.Write("\nAnswers:\t");
                        for (int i = c * 10; i < (c * 10) + 10; i++)
                        {
                            Console.Write(rightAnswers[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"An IO exception occured: \n{e.Message}\n\nStack trace: \n{e.StackTrace}");
            }
        }
    }
}