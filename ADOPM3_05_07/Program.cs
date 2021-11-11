using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_05_07
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] musos = { "Roger Waters", "David Gilmour", "Rick Wright", "Nick Mason" };

            musos.OrderBy(m => m.Split().Last()) // SubQuery: Split() creates a list of strings. Last() return last string in the list
                                                 // Split() and Last() extends the inner query.
                                                 // OrderBy extends the outer query
                .ToList().ForEach(m => Console.WriteLine(m)); // m is locally scoped in a LE, no conflict
        }

        //Exercise:
        //1.    Demonstrate deferred execution by modifying the code and separate query creation and execution. After query creations, 
        //      but before query execution, insert another name in "musos". What happens?
        //2.    Use Linq Operator Last() on the outer query 
    }
}
