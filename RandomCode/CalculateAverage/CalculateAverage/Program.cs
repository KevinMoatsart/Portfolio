//Author: Kevin Moats
//Program: CalculateAverage
//Last Updated: 5/6/2016
//Purpose: To calcute and display the average for numbers in an array

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            int average = 0;

            Console.WriteLine("Please enter how many numbers you would like in the array.");
            int numsInArr = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[numsInArr];

            array = myProgram.GetArray(numsInArr);

            average = myProgram.GetAverage(array);

            myProgram.DisplayArray(array);
            myProgram.Print(average);


            Console.ReadLine();
        }
        //gets an array from the user
        public int[] GetArray(int size)
        {
            int[] newArr = new int[size];
            Console.WriteLine("Please enter the numbers.");

            int count = 0;
            while(count < newArr.Length)
            {
                newArr[count] = Convert.ToInt32(Console.ReadLine());
                count++;
            }

            return newArr;
        }
        //performs an average of integers in an array
        public int GetAverage(int[] arrayToAverage)
        {
            int num = 0;

            int count = 0;
            while(count < arrayToAverage.Length)
            {
                num += arrayToAverage[count];
                count++;
            }

            num /= arrayToAverage.Length;

            return num;
        }
        //displays a given array and prints the index of each value
        public void DisplayArray(int[] array)
        {
            Console.WriteLine("----------");
            for(int x = 0; x < array.Length; x++)
            {
                Console.WriteLine("The value in index[" + x + "] is: " + array[x]);
            }
        }
        //simply prints the average
        public void Print(int toPrint)
        {
            Console.WriteLine("----------");
            Console.WriteLine("The average is: " + toPrint);
        }


    }
}
