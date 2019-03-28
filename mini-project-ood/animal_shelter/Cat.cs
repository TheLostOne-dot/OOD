using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_shelter
{
    public class Cat:Animal
    {
        private string extraInfo;

        // Constructor inherited from the parent class
        public Cat(string tag, string description, DateTime date, string location) : base(tag, description, date, location)
        {

        }
        // Concatinates more info to the extraInfo property
        public void AddExtraInfo(string extraInfo)
        {
            this.extraInfo  += " " + this.extraInfo;
        }

        public override string Info()
        {
            return base.Info() + "type: cat";
        }

    }
}
