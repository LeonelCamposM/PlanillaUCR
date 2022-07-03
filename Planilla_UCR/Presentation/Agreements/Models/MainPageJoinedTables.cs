using System;

namespace Presentation.Agreements.Models
{
    internal class MainPageJoinedTables
    {

        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Email { get; set; }
        public int Ssn { get; set; }
        public string FullName { get; set; }


        public MainPageJoinedTables()
        {
            this.Name = "";
            this.LastName1 = "";
            this.LastName2 = "";
            this.Email = "";
            this.Ssn = 0;
            this.FullName = "";
        }

        public MainPageJoinedTables(string Name, string LastName1, string LastName2, string Email, int Ssn)
        {
            this.Name = Name;
            this.LastName1 = LastName1;
            this.LastName2 = LastName2;
            this.Email = Email;
            this.Ssn = Ssn;
            this.FullName = Name + " " + LastName1 + " " + LastName2;
        }
    }
}