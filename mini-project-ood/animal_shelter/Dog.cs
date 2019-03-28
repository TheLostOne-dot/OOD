using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_shelter
{
   public class Dog:Animal
    {
        private DateTime lastWalk;

        // Constructor inherited from the parent class
        public Dog(string tag, string description, DateTime date, string location) :base(tag, description, date, location)
        {

        }
        // Method which sets the :lastWalk to Now
        public void Walk()
        {
            this.lastWalk = DateTime.Now;
        }

        public override string Info()
        {
            return base.Info() + "type: dog";
        }
    }
}
