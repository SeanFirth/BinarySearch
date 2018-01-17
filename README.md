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

It is more efficient than a linear search, as that would check every element in the array for the target value until it finds it (or it runs out of elements to check, determining that the value cannot be found) - which is inefficient and slow compared to a binary search.

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

The program then asks the user for the number that they would like to find using a binary search and converts it to an integer (*valueSearch*) - if the user enters a value that cannot be converted to an integer, the program will crash at this point. To improve, I could implement a way of catching any errors and/or not accepting any input until it can be converted fully to an integer.

Below is the main loop:

```cs
 while (!found) {

        //Console.WriteLine(Environment.NewLine);
        //Console.WriteLine("Array split, the middle point of the array is: " + middlePoint.ToString());


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
```

This is the section of the code that actuall performs the full binary search and states whether the number was found or not - if the desired value is equal to the integer variable "middlePoint", then the number has been found. The array will keep halving in size until either it can be determined that the value cannot be found, or that it has been found.

```cs
//Console.WriteLine(Environment.NewLine);
//Console.WriteLine("Array split, the middle point of the array is: " + middlePoint.ToString());
```

As seen above, this section of code starts with two comments, that, when "uncommented", will show an output trace of the code, showing the middle point. This will allow you to see the way that is "splits" the array by only looking where it has to, making it an efficient search.

```cs
if (valueSearch == middlePoint) {

    found = true;
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("Found!");
    
}
```

This is the first if statement; note that it is still inside the while loop.

It checks to see if the desired value, *valueSearch*, is equal to the middle point. If it is, then it will set the boolean value to true (in order to break out of the loop) then outputs a message to the user saying that the value has been found.

Below is the next if statement.

```cs
 else if (valueSearch < middlePoint & valueSearch > minvalue) {
 
    // disregard everything larger than middle point
    maxvalue = middlePoint;
    middlePoint = (maxvalue - minvalue) / 2;

}
```

This checks to see if the desired value is less than the original value, therefore disregarding every value greater than the middle point. 

Going back to the original example:

1,2,3,4,**5**,6,7,8,9,10

This would only leave:

1,2,3,4,5

It acheives this by setting the maximum value to the middle point (so that any further searches could not go further than the original middle point) then setting the new middle point to match the actual middle point in the part of the array that it is searching.

These new values, for both the maximum value and the middle point, can then be used again to perform the next step of the search (as it is in a while loop), if necessary (if the value has not been found). The minimum value is unchanged.

The next if statement deals with the chance that the desired value is greater than the original middle point:

```cs
else if (valueSearch > middlePoint & valueSearch < maxvalue) {

    // disregard everything smaller than middle point
    minvalue = middlePoint;
    middlePoint = (maxvalue - minvalue) / 2 + minvalue;
    
}
```

This code is similar to the other "else if" statement above, however this will disregard the other half of the array to begin with.

Going back to the original example:

1,2,3,4,**5**,6,7,8,9,10

This statement would essentially leave:

5,6,7,8,9,10

It does this by setting the minimum value to the old middle point, then determining a new middle point to look for; the maximum remains unchanged, at least on the first pass, as this will still be the end of the array.

If the loop has to be run multiple times, then the first "else if" statement may need to be called, in which case the maximum value will change then.

Finally, below, is the "else" statement that will catch any problems, if the number cannot be found. This could be called if the desired value is greater than the maximum possible value, or if less than the minimum value.

```cs
else {
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("Number Not Found");
    break;
}
```

It will output a message to the user that the desired number could not be found, then breaks out of the loop so as not to result in an endless cycle.

Finally, the braces from earlier code close and there is a *Console.ReadLine();* to keep the text on screen until the user presses a key or closes the program.

## Conclusion

Overall, this is a short program that performs an efficient binary search by changing which sections of the array to search in. Crucially, it does not split the array, or move the values to a temporary array, but just changes where it has to look inside the first, hard-coded array.

To improve, I could:

* Let the user enter the array

* Generate the array randomly, then sort it before running the binary search

* Catch any errors with the array before a crash - for example, if it is not an integer array

* Catch any errors at the point of entering the desired value - if it cannot be converted to an integer using *Convert.ToInt32(Console.ReadLine());* then the program will crash.

* Have a full output trace, showing after each pass, the new minimum value, the new middle point, and the new maximum value, so the user can see exactly how a binary search works. This could be acheived by adding *Console.WriteLine();* statements inside the else if statements.

Despite this, the program still executes a binary search given a hard-coded array of sorted integers.
