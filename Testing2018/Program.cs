using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Armour ar = new Armour("Jorma", "Kokkeli", 20, 2, 2);
            Console.WriteLine(ar.getLevel());
        }
    }
}
