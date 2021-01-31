using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Question 1

                Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
                int n = Convert.ToInt32(Console.ReadLine());
                printTriangle(n);
            }
            catch (Exception)  
                {
                    Console.WriteLine("Enter a valid number");
                }
            try
            {
                //Question 2 

                Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
                int n2 = Convert.ToInt32(Console.ReadLine());
                printPellSeries(n2);
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid number");
            }           
            //Question 3

                Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
                int n3 = Convert.ToInt32(Console.ReadLine());
                bool flag = squareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                }
            //Question 4

            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            //Question 5

            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);
            //Question 6 

            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" }, { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        private static void printTriangle(int n)
        {
            try
            {
                if (n>0)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        //printing spaces
                        for (int j = 1; j <= n - i; j++)
                            Console.Write(" ");
                        //Printing stars
                        for (int k = 1; k <= ((2 * i) - 1); k++)
                            Console.Write("*");
                        Console.Write("\n");
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
             {
                Console.WriteLine("Enter a valid number");
             }
        }
        private static void printPellSeries(int n2)
        {
            try
            {
                int a = 0, b = 1, c;
                if (n2 == 1)
                {
                    Console.WriteLine(a); // pell series for input 1 
                }
                else if(n2 == 0) //Message is displayed for input 0
                    {
                    Console.WriteLine("Enter a valid number");
                    }
                else
                {
                    Console.Write(a + " " + b + " ");
                }

                for (int i = 2; i < n2; i++)
                {
                    c = ((b * 2) + a); // logic to calculate next term in series
                    Console.Write(c + " ");
                    a = b; 
                    b = c;
                }
                Console.WriteLine("\n");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static bool squareSums(int n3)
        {
            try
            {
                for (int i = 0; i <= n3; i++)
                {
                    for (int j = i + 1; j <= n3; j++)
                    {
                        if ((i * i) + (j * j) == n3) // logic to check if sum of squares is equal to given input
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                int x = nums.Length;
                int sum = 0;
                for (int i = 0; i < x; i++)
                {
                    for (int j = i + 1; j < x; j++)
                    {
                        if (nums[j] - nums[i] == k) //values of array are checked with absolute difference
                        {
                            sum++;
                        }
                    }
                }
                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }
        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                HashSet<string> count = new HashSet<string>(); //used hash set for unique values
                string local1 = "";
                string local2 = "";
                foreach (var email in emails)
                {
                    string[] Uemail = email.Split("@"); //used split function for email
                    if (Uemail[0].Contains("+"))
                    {
                        local1 = Uemail[0].Remove(Uemail[0].IndexOf("+")); // string after '+' sign is removed
                    }
                    if (local1.Contains("."))
                    {
                        local2 = local1.Replace(".", ""); // '.' is replaced with space
                    }
                    string mail = local2.Trim() + "@" + Uemail[1].Trim(); //concatination of string and trimmed at end
                    count.Add(mail); 
                }
                return count.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private static string DestCity(string[,] paths)
        {
            string x = "";
            try
            {
                string[] s = { paths[0, 0], paths[1, 0], paths[2, 0] }; // s contains source cities
                string[] d = { paths[0, 1], paths[1, 1], paths[2, 1] }; // d contains destination cities
                IEnumerable<string> result = d.Except(s);
                foreach (var i in result)
                {
                    x = i;
                }
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
