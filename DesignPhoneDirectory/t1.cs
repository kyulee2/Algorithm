/*
Design a Phone Directory which supports the following operations:

get: Provide a number which is not assigned to anyone.
check: Check if a number is available or not.
release: Recycle or release a number.

Example: 
// Init a phone directory containing a total of 3 numbers: 0, 1, and 2.
PhoneDirectory directory = new PhoneDirectory(3);

// It can return any available phone number. Here we assume it returns 0.
directory.get();

// Assume it returns 1.
directory.get();

// The number 2 is available, so return true.
directory.check(2);

// It returns 2, the only number that is left.
directory.get();

// The number 2 is no longer available, so return false.
directory.check(2);

// Release number 2 back to the pool.
directory.release(2);

// Number 2 is available again, return true.
directory.check(2);
*/
// Comment: Simple. Not much interesting. If we allow to get a random number from get(),
// then it becomes a bit better -- have similar problem.
public class PhoneDirectory
{
    List<int> available;
    HashSet<int> used;
    /** Initialize your data structure here
        @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
    public PhoneDirectory(int maxNumbers)
    {
        available = new List<int>();
        used = new HashSet<int>();
        for (int i = 0; i < maxNumbers; i++)
            available.Add(i);
    }

    /** Provide a number which is not assigned to anyone.
        @return - Return an available number. Return -1 if none is available. */
    public int Get()
    {
        int len = available.Count;
        if (len == 0) return -1;
        int ans = available[len - 1];
        available.RemoveAt(len - 1);
        used.Add(ans);
        return ans;
    }

    /** Check if a number is available or not. */
    public bool Check(int number)
    {
        return !used.Contains(number);
    }

    /** Recycle or release a number. */
    public void Release(int number)
    {
        if (used.Contains(number))
        {
            used.Remove(number);
            available.Add(number);
        }
    }
}

/**
 * Your PhoneDirectory object will be instantiated and called as such:
 * PhoneDirectory obj = new PhoneDirectory(maxNumbers);
 * int param_1 = obj.Get();
 * bool param_2 = obj.Check(number);
 * obj.Release(number);
 */

