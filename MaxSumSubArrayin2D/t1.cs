/* From amazon, geeksforgeeks.org
Maximum sum rectangle in a 2D matrix | DP-27
Given a 2D array, find the maximum sum subarray in it. For example, in the following 2D array, the maximum sum subarray is highlighted with blue rectangle and sum of this subarray is 29.
*/
// Comment: Similar to find max sum of subarray in 1D.
// Compute row sum in between any c1, c2 column and apply 1D algorithm above.
// O(n^3) time and O(n^2) space
using System;

class Test
{
 int getMaxSum(int[,] matrix) {
   int Row = matrix.GetLength(0);
   int Col = matrix.GetLength(1);
   int max = Int32.MinValue;
   var rsum = new int[Row,Col];
   // build up rsum O(n^2)
   for(int i=0; i<Row; i++) {
    int S = 0;
    for(int j=0; j<Col; j++) {
      S += matrix[i,j];
      rsum[i,j] = S;
    }
   }
  
   // main loop O(n^3)
   var t = new int[Row];
   for(int i=0; i<Col; i++) {
     for(int j=i; j<Col; j++) {
        // build t[] for each row that sums of i~j column
	for(int k=0; k<Row; k++)
	  t[k] = rsum[k,j] - (i==0? 0 : rsum[k,i-1]);
	// Find max of sum of subarray t[]
        int sum = t[0];
	max = Math.Max(sum, max);
        for(int k=1; k<Row; k++) {
	    if (sum < 0) {
		sum = t[k];
	    } else {
		sum += t[k];
	    }
	    max = Math.Max(sum, max);
	}
     }
   }

   return max;
 }
 public static void Main() {
  var m = new int[4,5]{{1,2,-1,-4,-20},
		       {-8,-3,4,2,1},
		       {3,8,10,1,3},
		       {-4,-1,1,7,-6}};
  Test t = new Test();
  Console.WriteLine("max sum of 2d subarray: {0}", t.getMaxSum(m));
 }
}
