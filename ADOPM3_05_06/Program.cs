using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_05_06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deferred execution
            int[] numbers = { 1, 2 };

            int factor = 10;
            IEnumerable<int> query = numbers.Select(n => n * factor); // Update query

            // Remember: captured variables by LE are evaluated at execution time
            factor = 20; 
            foreach (int i in query) Console.WriteLine(i); // Execute my query: 20, 40


            // Deferred execution in for loops as iteration variables are capured by LE as scoped outside the loop
            IEnumerable<char> query1 = "!A simple_ _sentence?";
            
            //"Now, let's remove everything expect !_? by updating our query
            string remove = "!_?";

            for (int i = 0; i < remove.Length; i++)
                query1 = query1.Where(c => c != remove[i]);   // Update query

            foreach (char c in query1) Console.Write(c); //Execute my query: 
                                                          //Expected Output: A simple sentence
        }
    }
    //Exercise:
    //1.    Use the debugger to step through the program and analyze the Error. 
    //      Where does it happen? why?
    //2.    Modify the code so that it works
}
