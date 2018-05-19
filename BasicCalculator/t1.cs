/*
Implement a basic calculator to evaluate a simple expression string.
The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .
Example 1:
Input: "1 + 1"
Output: 2
Example 2:
Input: " 2-1 + 2 "
Output: 3
Example 3:
Input: "(1+(4+5+2)-3)+(6+8)"
Output: 23
*/

// Comment: Initial attempt was t2.cs which is slow
// The follwing IExpr is not actually needed.
// Wrapping integer with ID is not for performance but readable since it's a token like operator.
// The key idea is that tokenize the input, and then do reduction.
// Basically, keep two stacks -- value and operator. 
// When ")" right operator, matches "(" left and do reduction. Otherwise "+"/"-", simple push it to operator.
// For ID (value), always push it to value stack.
// The reduction operation is in while loop. As long as "+"/"-" operation in the top, consume two values and push back the result.

// t3.cs is an extended version that does for mul/div over add/sub
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Solution
{
   interface IToken { }
   interface IExpr
   {
      int evaluate();
   }

   class Operator : IToken { }
   class Plus : Operator { }
   class Minus : Operator { }
   class Left : Operator { }
   class Right : Operator { }
   class ID : IToken, IExpr
   {
      int val;
      public ID(int v)
      {
         val = v;
      }
      public int evaluate() { return val; }
   }

   public int Calculate(string s)
   {
      List<IToken> l = new List<IToken>();
      int Len = s.Length;
      for (int i = 0; i < Len; i++)
      {
         char c = s[i];
         switch (c)
         {
            case ' ': break;
            case '+': l.Add(new Plus()); break;
            case '-': l.Add(new Minus()); break;
            case '(': l.Add(new Left()); break;
            case ')': l.Add(new Right()); break;
            default:
               {
                  int j = i;
                  int sum = 0;
                  while (j < Len && s[j] >= '0' && s[j] <= '9')
                  {
                     sum *= 10;
                     sum += (int)(s[j] - '0');
                     j++;
                  }
                  l.Add(new ID(sum));
                  i = --j;
                  break;
               }
         }
      }
      IToken[] arr = l.ToArray();
      return process(arr);
   }

   int process(IToken[] tokens)
   {
      Stack<int> Val = new Stack<int>();
      Stack<Operator> Op = new Stack<Operator>();
      foreach(var t in tokens)
      {
         if (t is Operator)
         {
            if (t is Right)
            {
               Debug.Assert(Op.Peek() is Left);
               Op.Pop();
            } else
            {
               Op.Push(t as Operator);
               continue;
            }
         }
         else
         {
            Debug.Assert(t is ID);
            Val.Push((t as ID).evaluate());
         }

         // Reduction
         while(Op.Count != 0 && !(Op.Peek() is Left)) {
            Operator p = Op.Pop();
            int right = Val.Pop();
            int left = Val.Pop();
            int S = p is Plus ? left + right : left - right;
            Val.Push(S);
         }
      }

      return Val.Count == 0 ? 0 : Val.Pop();
   }
}