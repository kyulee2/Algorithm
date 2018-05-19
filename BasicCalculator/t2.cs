
// Comment: Use excpetion to search naively all possible cases, which are extremely slow.
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

   class Expr : IExpr
   {
      IExpr left;
      Operator op;
      IExpr right;
      public Expr(IToken[] tokens, int i, int j)
      {
         for (int k = i + 1; k <= j - 1; k++)
            if (tokens[k] is Operator)
            {
               try
               {
                  left = new Expr(tokens, i, k - 1);
                  op = tokens[k] as Operator;
                  right = new ExprP(tokens, k + 1, j);
                  return;
               }
               catch (Exception ) { }
            }

         left = new ExprP(tokens, i, j);
      }
      public int evaluate()
      {
         int l = left.evaluate();
         if (op != null)
         {
            int r = right.evaluate();
            return op is Plus ? l + r : l - r;
         }
         return l;
      }

   }
   // Expr = Expr +/- ExprP
   // Expr = ExprP

   // ExprP = (Expr)
   // ExprP = ID
   class ExprP : IExpr
   {
      IExpr e;
      public ExprP(IToken[] tokens, int i, int j)
      {
         if (i == j)
         {
            if (!(tokens[i] is ID))
               throw new Exception();
            e = (tokens[i] as IExpr);
         }
         else if (tokens[i] is Left && tokens[j] is Right)
            e = new Expr(tokens, i + 1, j - 1);
         else
            throw new Exception();

      }
      public int evaluate()
      {
         return e.evaluate();
      }
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
      Expr e = new Expr(arr, 0, arr.Length - 1);
      return e.evaluate();
   }

   public static void Main()
   {
      Solution s = new Solution();
      //int ans = s.Calculate("(3-(5-(8)-(2+(9-(0-(8-(2))))-(4))-(4)))");
      int ans = s.Calculate("(3-(5-(8)))");
      Console.WriteLine(ans);
   }
}