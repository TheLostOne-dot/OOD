using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_shelter
{
   public class Person
    {
        private int personId;
        private string firstname;
        private string lastname;
        private int telephone;
        private string email;

        // Constructor for the Person class with 4 parameters
        public Person(string firstname, string lastname, int phone, string email, int personId)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.telephone = phone;
            this.email = email;
            this.personId = personId;
        }

        public int PersonId { get; set; }
        // Properties for the Person
        public string ReturnEmail()
        {
            return this.email;
        }
        public int ReturnId()
        {
            return personId;
        }
    }
}
