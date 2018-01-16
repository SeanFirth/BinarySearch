# Binary Search
**By Sean Firth** - 
*Programmed in C#*


## How a binary search works

To understand how (and why) the code works, it is crucial to understand how a binary search works in practice.

Say there is an ordered array of integers, 1 through 10, and we want to find the number 9.

1,2,3,4,**5**,6,7,8,9,10

We'd start by splitting the array into half, so there are two distinct sections. Note the midpoint, 5, in bold.

Now we know that 5<9 so we can disregard the left side of the array, and focus on just the side that is greater than 5.

6,7,**8**,9,10

We know that 8<9 so we can also disregard the left hand side, just like before, leaving us with.

9,10

Which leaves us with the result of 9, as 10>9, so it must fall to the other value.

Below is the explanation of how this search is implemented in C#

## Code in full

```cs


namespace BinarySearch {
    class Program {
        static void Main(string[] args) {


            int[] valueArray ={ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int minvalue = 0;
            int maxvalue = valueArray.Length;
            bool found = false;
            int middlePoint = valueArray.Length / 2;
            

            Console.WriteLine("Number To Find :");
            int valueSearch = Convert.ToInt32(Console.ReadLine());

            while (!found) {

                //Console.WriteLine(Environment.NewLine);
                //Console.WriteLine("Array split, the middle point of the array is: " + middlePoint.ToString());
                

                if (valueSearch == middlePoint) {
                    found = true;
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Found In Location " + middlePoint + " In Array");
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
```
