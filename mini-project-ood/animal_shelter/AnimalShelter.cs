using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_shelter
{
    public class AnimalShelter
    {

        // fields for the Animal Shelter
        private string name;
        private string address;
        private int telephone;
        private string email;
        private List<Animal> listAnimals; // contains all the animals in the shelter
        private List<Person> listOwners;   // contains all the persons registered in the animal shelter
        private int id=100;

        public List<Animal> GetListAnimals { get { return this.listAnimals; }}
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public AnimalShelter(string name,string address,int telephone, string email)
        {
            this.Name = name;
            this.address = address;
            this.telephone = telephone;
            this.email = email;
            listAnimals = new List<Animal>();
            listOwners = new List<Person>();
        }

        // methods for the Animal Shelter

        // return if the person with :email is the owner of the animal or not
        public bool CheckIfOwner(Animal animal, string email)
        {
            int personId = this.GetPersonIdByEmail(email);
            int animalPersonId = animal.GetAnimalPersonId();
            if (personId == animalPersonId)
                return true;
            else
                return false;
        }
        // Returns if the animal with :tag is registered int the shelter
        public bool CheckIfRegistered(string tag)
        {
            bool registered = false;
            foreach (Animal a in this.listAnimals)
            {
                if (a.ReturnTag() == tag)
                    registered = true;
            }
            return registered;
        }
        // Returns if the person with :email is registered
        public bool CheckIfPersonIsRegistered(string email)
        {
            bool registeredPerson = false;
            foreach (Person p in this.listOwners)
            {
                if (p.ReturnEmail() == email)
                    registeredPerson = true;
            }
            return registeredPerson;
        }

        public List<Animal> GetAnimals()
        {
            return this.listAnimals;
        }
        // Registers the animal with the given values
        public void Register(string tag, string description, DateTime date, string location, string type)
        {
            Animal a = null;
            if (type == "Dog")
            {
                a = new Dog(tag, description, date, location);
            }
            else if (type == "Cat")
            {
                a = new Cat(tag, description, date, location);
            }
            this.listAnimals.Add(a);
        }
        // Registers person with the given values
        public void RegisterPerson(string firstname, string lastname, int phone, string email)
        {
           
            if (listOwners==null)
            {
                Person p = new Person(firstname, lastname, phone, email, id);
                this.listOwners.Add(p);
                this.id = 100;
            }
            else
            {
                Person p = new Person(firstname, lastname, phone, email, id+1 );                
                this.listOwners.Add(p);
                this.id += 1;
            }
           
        }
        // Returns the fee for the animal provided if the person is Adopter
        public int AdoptAnimalPrice(Animal animal)
        {
            if ((DateTime.Now - animal.GetRegisterDate()).TotalDays > 20)
            {
                if (animal is Dog)
                    return 20;
                else
                    return 25;
            }
            return -1;
        }
        //Returns the fee for the animal provided if the person is Owner
        public int ClaimtAnimalPrice(Animal animal)
        {
            if (animal is Dog)
                return Convert.ToInt32((DateTime.Now - animal.GetRegisterDate()).TotalDays) * 2 + 10;
            else
                return 15;
        }
        // Changes the personId of the Animal to the new person who adopts it
        public void AdoptAnimal(Animal animal, string email)
        {
            int personId = this.GetPersonIdByEmail(email);
            animal.SetAnimalPersonId(personId);
            animal.adopted = true;
        }
        // Returns the person based on their email
        public int GetPersonIdByEmail(string email)
        {
            int id = 0;
            foreach (Person p in this.listOwners)
            {
                if (p.ReturnEmail() == email)
                    id = p.ReturnId();
            }
            return id;
        }
        // Returns all the animals that are adopted
        public List<Animal> AdoptedAnimals()
        {
            List<Animal> adopted = new List<Animal>();
            foreach (Animal a in this.listAnimals)
            {
                if (a.adopted == true) { adopted.Add(a); }
            }
            return adopted;
        }
        // Returns all the animals that are not adopted
        public List<Animal> NotAdoptedAnimals()
        {
            List<Animal> notadopted = new List<Animal>();
            foreach (Animal a in this.listAnimals)
            {
                if (a.adopted == false)
                    notadopted.Add(a); 
            }
            return notadopted;
        }
        // Generates report for the dat with statistics for the animals and persons registrated in the animal shelter
        public void GenerateReport()
        {
            int allAnimals = this.listAnimals.Count;
            int nrcats = 0;
            int nrdogs = 0;
            int nrpeople = this.listOwners.Count;
            int adoptedAnimals = this.AdoptedAnimals().Count;
            int notAdoptedAnimals = this.NotAdoptedAnimals().Count;
            DateTime dateOfReport = DateTime.Now;

            foreach (Animal a in this.listAnimals)
            {
                if (a is Dog)  nrdogs++; 
                if (a is Cat)  nrcats++; 
            }
            
            FileStream fs = null;
            StreamWriter tw = null;

            try
            {
                fs = new FileStream("report.txt", FileMode.OpenOrCreate, FileAccess.Write);
                tw = new StreamWriter(fs);

                tw.WriteLine("Daily report");
                tw.WriteLine("date: " + dateOfReport);
                tw.WriteLine("");
                tw.WriteLine("Number of animals in the shelter: " + allAnimals);
                tw.WriteLine("Number of dogs: " + nrdogs + "    " + "Number of cats:" + nrcats);
                tw.WriteLine("Number of people registrated in the shelter:" + nrpeople);
                tw.WriteLine("Number of adopted animals: " + adoptedAnimals);
                tw.WriteLine("Number of not adopted animals: " + notAdoptedAnimals);
                tw.WriteLine("--------------------------------------------------------------------------");
                tw.WriteLine();
                tw.Close();
            }
            catch (IOException)
            {
                throw new IOException();
            }
            finally
            {
                if (tw != null) { tw.Close(); }
            }
        }
        public Dog GetDog(string tag)
        {
            Dog dog;
            foreach(Animal a in this.listAnimals)
            {
                if (a is Dog)
                {
                    if (a.ReturnTag() == tag)
                    {
                        dog = (Dog)a;
                        return dog;
                    }
                }   
            }
            return null;
        }
        public Cat GetCat(string tag)
        {
            Cat cat;
            foreach (Animal c in this.listAnimals)
            {
                if (c is Cat)
                {
                    if (c.ReturnTag() == tag)
                    {
                        cat = (Cat)c;
                        return cat;
                    }
                }
            }
            return null;
        }
        public List<Animal> GetPersonsAnimals(string email)
        {
            List<Animal> temp = new List<Animal>();
            int personid = this.GetPersonIdByEmail(email);
            foreach(Animal a in this.listAnimals)
            {
               if(a.GetAnimalPersonId() == personid)
                {
                    temp.Add(a);
                }
            }
            return temp;
        }
    }
}
