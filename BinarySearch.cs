using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch {
    class Program {
        static void Main(string[] args) {

            // Step 1 - return an array of n length
            // Step 2 - find length of array and middle of array


            int[] valueArray = new int[52];
            int minvalue = 0;
            int maxvalue = valueArray.Length;
            bool found = false;
            int middlePoint = valueArray.Length / 2;
            bool Input = true;
            int i = 0;

            Console.WriteLine("Input Numbers Wanted : ");
            while(Input) {

                int InputNumber = Convert.ToInt32(Console.ReadLine());
                valueArray[i] = InputNumber;
                i++;

                if (InputNumber == 1000000) {
                    Input = false;
                }
            }

            //for (int i = 0; i < valueArray.Length; i++) {
                //valueArray[i] = i;
            //}

            Console.WriteLine("Number To Find :");
            int valueSearch = Convert.ToInt32(Console.ReadLine());

            while (!found) {
                //Console.WriteLine(middlePoint.ToString());
                if (valueSearch == middlePoint) {
                    found = true;
                    Console.WriteLine("Found In Location " + middlePoint + " In Array");
                } else if (valueSearch < middlePoint & valueSearch > minvalue) {
                    // disregard everything larger than middle point
                    maxvalue = middlePoint;
                    middlePoint = (maxvalue - minvalue) / 2;
                        
                } else if (valueSearch > middlePoint & valueSearch < maxvalue) {
                    // disregard everything smaller than middle point
                    minvalue = middlePoint;
                    middlePoint = (maxvalue - minvalue) / 2 + minvalue;
                } else {
                    Console.WriteLine("Number Not Found");
                    found = true;
                }
            }

            Console.ReadLine();
        }
    }
}
