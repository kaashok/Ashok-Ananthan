using System;
using System.Text.RegularExpressions;

namespace GSS
{
    class GSSTest
    {
        static void Main(string[] args)
        {
            try
            {
                string[,] arrData = new string[,]
                {
                    {"a","b","d","c"},
                    { "d","b","a","f"},
                    { "c", "d", "h", "j"}
                };
                

                FindPosition(arrData, PrintArrayAndGetInput(arrData));

                Console.WriteLine();
                Console.WriteLine();
                arrData = new string[,]
                {
                    {"q","w","e","r","t"},
                    {"y","u","i","o","p" },
                    {"a","s","d","f","g" },
                    {"h","j","k","l","z" },
                    {"x","c","v","b","n" },
                    {"m","q","s","c","g" },
                    {"y","f","x","a","b" },
                };
                FindPosition(arrData, PrintArrayAndGetInput(arrData));


                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Print array and Get the input form user
        /// </summary>
        /// <param name="arrData"></param>
        /// <returns></returns>
        internal static string PrintArrayAndGetInput(string[,] arrData)
        {
            for (int iRowIndex = 0; iRowIndex < arrData.GetLength(0); iRowIndex++)
            {
                for (int iColIndex = 0; iColIndex < arrData.GetLength(1); iColIndex++)
                {
                    Console.Write(arrData[iRowIndex, iColIndex] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Enter the 2 characters for finding the position:");
            return Console.ReadLine();
        }

        /// <summary>
        /// find the position for given input
        /// </summary>
        /// <param name="arrData"></param>
        /// <param name="strInput"></param>
        internal static void FindPosition(string[,] arrData, string strInput)
        {

            bool bFound = false;

            if (strInput.Length == 2)
            {
                if (Regex.Matches(strInput, @"[a-zA-z]").Count == strInput.Length)
                {

                    for (int iRowIndex = 0; iRowIndex < arrData.GetLength(0); iRowIndex++)
                    {
                        for (int iColIndex = 0; iColIndex < arrData.GetLength(1); iColIndex++)
                        {
                            if (arrData[iRowIndex, iColIndex] == strInput.Substring(0, 1) && (iColIndex != arrData.GetLength(1) - 1))
                            {
                                if (arrData[iRowIndex, iColIndex + 1] == strInput.Substring(1, 1))
                                {
                                    bFound = true;
                                    Console.WriteLine("X value of {0}={1}, Y value of {0}={2}", strInput.Substring(0, 1), iRowIndex, iColIndex);
                                    Console.WriteLine("X value of {0}={1}, Y value of {0}={2}", strInput.Substring(1, 1), iRowIndex, iColIndex + 1);
                                }
                            }
                        }
                    }

                    if (!bFound)
                    {
                        Console.WriteLine("Position of given characters is not found in array");
                    }

                }
                else
                {
                    Console.WriteLine("Only string datatype supported.");
                }
            }
            else
            {
                Console.WriteLine("Character length should be 2");
            }
           
        }
    }
}

