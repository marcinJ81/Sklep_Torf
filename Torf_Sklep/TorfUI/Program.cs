using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            InsertTest testinsert = new InsertTest();
            var result = testinsert.MultipleInsertToDataBaseInFile();
            foreach (var i in result)
            {
                Console.WriteLine(i.user_id.ToString() + " " + i.user_name + " " + i.user_sname + " " + i.user_email + " " + i.user_login);
            }
            Console.ReadLine();
        }
    }
}
