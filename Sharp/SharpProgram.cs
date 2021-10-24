using System;

namespace Sharp
{
  class SharpProgram
  {
    static void Main(string[] args)
    {
      for (int i = 0; i < 20; i++)
        Console.WriteLine("Cyklus {0:d3} {0:x04} {1}", i, i.ToString("x08"));

      Console.WriteLine(123);
      Console.WriteLine((123).ToString("x"));
      Console.WriteLine(123.ToString("x".ToUpper()));

      Console.WriteLine(args.GetType());
    }
  }
}
