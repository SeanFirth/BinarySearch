using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch {
    class Program {
        static void Main(string[] args) {


            int[] valueArray ={ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int minvalue = 0;
            int maxvalue = valueArray.Length+1;
            int middlePoint = valueArray.Length / 2;
            bool found = false;
            
            

            Console.WriteLine("Number To Find :");
            int valueSearch = Convert.ToInt32(Console.ReadLine());

            while (!found) {

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Array split, the middle point of the array is: " + middlePoint.ToString());
                

                if (valueSearch == middlePoint) {
                    found = true;
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Found!");
                }
                else if (valueSearch < middlePoint & valueSearch > minvalue) {
                    // disregard everything larger than middle point
                    maxvalue = middlePoint;
                    middlePoint = (maxvalue - minvalue) / 2;

                }
                else if (valueSearch > middlePoint & valueSearch < maxvalue) {
                    // disregard everything smaller than middle point
                    minvalue = middlePoint;
                    middlePoint = (maxvalue - minvalue) / 2 + minvalue;
                }
                else {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Number Not Found");
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
