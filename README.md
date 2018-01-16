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

It is more efficient than a linear search, as that would check every element in the array for the target value until it finds it - which is inefficient and slow compared to a binary search.

Below is the explanation of how this search is implemented in C#

## Code in full

```cs


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

## Code "walk-through"

```cs

int[] valueArray ={ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int minvalue = 0;
int maxvalue = valueArray.Length+1;
int middlePoint = valueArray.Length / 2;
bool found = false;


```

This sets up a hard-coded integer array of 1-10 which is used for the search. The search will work provided that a sorted integer array is provided, so it could be improved by letting the user enter the numbers they want. However, as a demonstration of the algorithm, this array is a simple example to use.

The rest of the above code block is simple variable declaration:

* integer minvalue = a starting point of 0 (the first index) so the search can begin. This changes later on as the search is run.


* integer maxvalue = to begin with, this is just the length of the array, however this also changes as the array is split.


* integer middlePoint = to start, this is the length of the array divided by 2 to find the middle. As the search continues (as per the explanation above) this will also change


* boolean found = used later on in the while loop to state when the desired number has been found

Below is the user input

```cs
Console.WriteLine("Number To Find :");
int valueSearch = Convert.ToInt32(Console.ReadLine());

```

The program then asks the user for the number that they would like to find using a binary search and converts it to an integer - if the user enters a value that cannot be converted to an integer, the program will crash at this point. To improve, I could implement a way of catching any errors and/or not accepting any input until it can be converted fully to an integer.

Below is the main loop:

(WIP)


