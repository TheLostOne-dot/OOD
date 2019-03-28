using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_shelter
{
    public abstract class Animal
    {
        // Fields for the Animal class
        private string tag;
        private string description;
        private DateTime registerDate;
        private string location;
        private int personId;
        public bool adopted;

        // Constructor for the Animal class taking 4 parameters
        public Animal(string tag, string description, DateTime date, string location)
        {
            this.tag = tag;
            this.description = description;
            this.registerDate = date;
            this.location = location;
        }
        // Properties for the Animal class
        public string ReturnTag()
        {
            return this.tag;
        }
        public DateTime GetRegisterDate()
        {
            return this.registerDate;
        }
        public void SetAnimalPersonId(int id)
        {
            this.personId = id;
        }

        public int GetAnimalPersonId()
        {
            return this.personId;
        }
        public virtual string Info()
        {
            return "Tag: " + this.tag + " Description: " + this.description + " RegisterDate: " + this.registerDate + " Location: " + this.location;
        }
    }
}
