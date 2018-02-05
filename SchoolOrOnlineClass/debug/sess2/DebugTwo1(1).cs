// Program compares your name to the name of your boss
using System;
using static System.Console;
class DebugTwo1
{
   static void Main()
   {
      string name, bossName;
      bool areNamesTheSame;
      WriteLine("Enter your name");
      name = readLine();
      WriteLine("Hello {0}! Enter the name of your boss", name);
      name = ReadLine();
      areNamesTheSame = name == bossName;
      WriteLine("It is {0} that you are your own boss", areNamesTheSame);
   }
}

//Changed Boolean to bool
//Added semicolen to line 9
//added quotes to line 10 method
