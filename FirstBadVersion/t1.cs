/*
You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which will return whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.

Example:

Given n = 5, and version = 4 is the first bad version.

call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true

Then 4 is the first bad version. 
*/
// Comment: Easy. check the prior boundary condition 
// The first one is easier. Bookkeep qualified answer right away.
// O(nlogn)
/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int i  =1, j=n;
        var ans = n;
        while(i<=j) {
            int m = i + (j-i)/2;
            if (IsBadVersion(m)) {
                ans = m;
                j = m-1;
            } else {
                i = m + 1;
            }
        }
        return ans;
    }
}

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int i = 1, j=n;
        while(i<=j) {
            int m = i + (j-i)/2;
            if (IsBadVersion(m)) {
                if (m-1<i || !IsBadVersion(m-1))
                    return m;
                j = m-1;
            } else {
                i = m + 1;
            }
        }
        return -1;
    }
}
