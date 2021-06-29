using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperLibrary
{
    public class DeveloperContent
    {
        //Properties
        public string Name { get; set; }
        public int IdNumber { get; set; }
        public bool PluralsightAccess { get; set; }

        //Construtor Empty
        public DeveloperContent() { }
        //Constructor Full
        public DeveloperContent(string name, int idNumber, bool pluralsightAccess)
        {
            Name = name;
            IdNumber = idNumber;
            PluralsightAccess = pluralsightAccess;
        }
    }
}
