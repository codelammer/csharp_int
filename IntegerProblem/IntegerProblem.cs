using System;

namespace CsharpInterview
{
    public class IntegerProblem
    {
        public static void descendingNonDuplicateList()
        {
            //get input and it should be separated by spaces
            Console.WriteLine("Enter a list of integers separated by spaces:");
            string? input = Console.ReadLine();

            if (input != null)
            {
                //this is easier --> just split map each by parsing to int and convert it back to list
                List<int> integerList = input.Split(" ")
                                             .Select(int.Parse)
                                             .ToList();

                //remove duplicate values and orderByDes and back to list
                List<int> uniqueList = integerList.Distinct()
                                                  .OrderByDescending(x => x)
                                                  .ToList();

                Console.WriteLine("Showing list sorted in Descending and non-duplicate ");
                foreach (int number in uniqueList)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No input provided.");
            }
        }
    }
}