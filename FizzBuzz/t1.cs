/*
Write a program that outputs the string representation of numbers from 1 to n.

But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”.

Example:

n = 15,

Return:
[
    "1",
    "2",
    "Fizz",
    "4",
    "Buzz",
    "Fizz",
    "7",
    "8",
    "Fizz",
    "Buzz",
    "11",
    "Fizz",
    "13",
    "14",
    "FizzBuzz"
]
*/
// Comment: Easy. Not worth.
public class Solution {
    public IList<string> FizzBuzz(int n) {
        var ans = new List<string>(n);
        for(int i=1; i<=n; i++) {
            bool isThree = i % 3 == 0;
            bool isFive = i%5 == 0;
            if (isThree && isFive) 
                ans.Add("FizzBuzz");
            else if (isThree)
                ans.Add("Fizz");
            else if (isFive)
                ans.Add("Buzz");
            else
                ans.Add(i.ToString());
        }
        return ans;
    }
}

