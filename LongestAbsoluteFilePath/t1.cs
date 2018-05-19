/*
Suppose we abstract our file system by a string in the following manner:
The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:
dir
    subdir1
    subdir2
        file.ext
The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.
The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:
dir
    subdir1
        file1.ext
        subsubdir1
    subdir2
        subsubdir2
            file2.ext
The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.
We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).
Given a string representing the file system in the above format, return the length of the longest absolute path to file in the abstracted file system. If there is no file in the system, return 0.
Note:
The name of a file contains at least a . and an extension.
The name of a directory or sub-directory will not contain a ..

Time complexity required: O(n) where n is the size of the input string.
Notice that a/aa/aaa/file1.txt is not the longest file path, if there is another path aaaaaaaaaaaaaaaaaaaaa/sth.png.Suppose we abstract our file system by a string in the following manner:
The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:
dir
    subdir1
    subdir2
        file.ext
The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.
The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:
dir
    subdir1
        file1.ext
        subsubdir1
    subdir2
        subsubdir2
            file2.ext
The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.
We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).
Given a string representing the file system in the above format, return the length of the longest absolute path to file in the abstracted file system. If there is no file in the system, return 0.
Note:
The name of a file contains at least a . and an extension.
The name of a directory or sub-directory will not contain a ..

Time complexity required: O(n) where n is the size of the input string.
Notice that a/aa/aaa/file1.txt is not the longest file path, if there is another path aaaaaaaaaaaaaaaaaaaaa/sth.png.
 */

// Comment:
// 1. Initially I thought to implement Node in a way to contain child as well as parent references. This way we can traverse backward/forward. But it's unnecessary for this problem which requires only the max length. 

// Spoiler:
// 1. Both spaces and \t are considered to compute the child depth. Other than max child spaces (from the current parent despaces) should be included into file name. Note \t == 4 spaces
// 2. getDepth() below can return 0, which is actually still valid when root directory is removed. See the example in the main. So, there were two special cases where the stack is empty. The better solution should include a hypothetical root directory in the beginning to ensure the stack is never empty. This way we cano remove the special code.
// 3. IsFile check is required before checking the max length of path since the problem is given for file name only (containing '.') not directory. It would be nice if we can update max automatically when a Node is inserted.
public class Solution
{
   class Node
   {
      public Node(string n, int len, int dep)
      {
         name = n;
         length = len;
         depth = dep;
      }
      public int getLen()
      {
         return length;
      }
      public int getDepth()
      {
         return depth;
      }
      public bool isFile()
      {
         return name.IndexOf('.') != -1;
      }
      string name; /* optional for debugging*/
      int length; // all path length
      int depth;
      /* Child/Parent node links are optional */
   }

   class FileSystem
   {
      int max;
      Stack<Node> s;
      string input;
      int i;
      public FileSystem(string str)
      {
         max = 0;
         s = new Stack<Node>();
         input = str;

         // initalize root
         string n = parseName();
         if (n == null) return;
         int length = n.Length;
         Node t = new Node(n, length, 0);
         if (t.isFile()) max = length;
         s.Push(t);

         // main loop. match depth and name
         while (!isEnd())
         {
            int depth = parseDepth();
            while (s.Count != 0 && depth <= s.Peek().getDepth())
               s.Pop();

            string name = parseName();
            if (name == null) break;
	    int len = name.Length;
	    if (s.Count != 0) // non-root case
               len += s.Peek().getLen() + 1 /* slash */;
            Node node = new Node(name, len, depth);
            if (node.isFile() && max < len) max = len;
            s.Push(node);
         }
      }

      public int getMax()
      {
         return max;
      }
      bool isEnd()
      {
         return input == null || i >= input.Length;
      }
      int parseDepth()
      {
         if (isEnd()) return 0;
         if (input[i] != '\n') return 0;
         i++;
         int spacecnt = 0;
         int maxchildspace = (s.Peek().getDepth() + 1) * 4;
         while (!isEnd() && (input[i] == '\t' || input[i] == ' ') && spacecnt < maxchildspace)
         {
            if (input[i] == '\t') spacecnt += 4;
            else spacecnt++;
            i++;
         }

         // Reverse space back to be part of file name
         int rem = spacecnt % 4;
         while (rem-- != 0) --i;

         // Return the number of tab (or equivalent spaces)
         return spacecnt / 4;
      }
      string parseName()
      {
         if (isEnd()) return null;
         int start = i;
         int cnt = 0;
         while (!isEnd() && input[i] != '\n')
         {
            cnt++;
            i++;
         }
         return input.Substring(start, cnt);
      }
   }
   public int LengthLongestPath(string input)
   {
      FileSystem fs = new FileSystem(input);
      return fs.getMax();

   }
   public static void Main()
   {
      Solution s = new Solution();
      int len = s.LengthLongestPath(
"a\n\tb.txt\na2\n\tb2.txt");
      Console.WriteLine(len);

   }
}
