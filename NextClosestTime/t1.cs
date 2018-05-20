/*
Given a time represented in the format "HH:MM", form the next closest time by reusing the current digits. There is no limit on how many times a digit can be reused.
You may assume the given input string is always valid. For example, "01:34", "12:09" are all valid. "1:34", "12:9" are all invalid.
Example 1: 
Input: "19:34"
Output: "19:39"
Explanation: The next closest time choosing from digits 1, 9, 3, 4, is 19:39, which occurs 5 minutes later.  It is not 19:33, because this occurs 23 hours and 59 minutes later.

Example 2: 
Input: "23:59"
Output: "22:22"
Explanation: The next closest time choosing from digits 2, 3, 5, 9, is 22:22. It may be assumed that the returned time is next day's time since it is smaller than the input time numerically.
*/
// Comment:
// Key idea is to convert h:m to min to easily compare time. For borrow (over the day), add 1440min(60*24) to subtract the time (minute).
// Regarding recursion, we might consider skipping duplication of iteration. But not much worth since the iteration space is simply 4 ^ 4.
// 
public class Solution
{

   int minDiff;
   char[] minTime;
   int currMin; // converted minute

   char[] tempTime;
   char[] digits;

   int conv2Min(char[] time)
   {
      int h = (int)(time[0] - '0') * 10 + (int)(time[1] - '0');
      int m = (int)(time[2] - '0') * 10 + (int)(time[3] - '0');
      return h * 60 + m;
   }

   bool isValid(char[] time)
   {
      int h = (int)(time[0] - '0') * 10 + (int)(time[1] - '0');
      if (h < 0 || h > 23) return false;
      int m = (int)(time[2] - '0') * 10 + (int)(time[3] - '0');
      if (m < 0 || m > 59) return false;
      return true;
   }
   int getMinDiff(int min)
   {
      if (min > currMin)
         return min - currMin;
      return min + 1440 - currMin;
   }

   public string NextClosestTime(string time)
   {
      minDiff = Int32.MaxValue;
      minTime = new char[4];
      tempTime = new char[4];

      // Initialize digits and currMin
      digits = new char[4];
      digits[0] = time[0];
      digits[1] = time[1];
      digits[2] = time[3];
      digits[3] = time[4];
      currMin = conv2Min(digits);

      // Main recursion
      Rec(0);

      // Output the answer
      char[] ans = new char[5];
      ans[0] = minTime[0];
      ans[1] = minTime[1];
      ans[2] = ':';
      ans[3] = minTime[2];
      ans[4] = minTime[3];
      return new string(ans);
   }

   void Rec(int depth)
   {
      if (depth >= 4)
      {
         if (isValid(tempTime))
         {
            int min = conv2Min(tempTime);
            int diff = getMinDiff(min);
            if (diff < minDiff)
            {
               Array.Copy(tempTime, minTime, 4);
               minDiff = diff;
            }
         }
         return;
      }

      foreach (var c in digits)
      {
         tempTime[depth] = c;
         Rec(depth + 1);
      }
   }
}
