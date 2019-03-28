using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animal_shelter
{
    public partial class Form1 : Form
    {
        AnimalShelter ashelter;
        List<Animal> animals;
        Animal a;
        int price = 0;
        bool owner = true;

        public Form1()
        {
            InitializeComponent();
            ashelter = new AnimalShelter("Eindhoven Animal Shelter", "Rachelsmolen 1, 5612 MA Eindhoven",555-55506,"eshelter@mail.com");
            this.addAnimals();
            this.ShowAnimals();
            this.addPeople();
            this.animals = ashelter.GetAnimals();
            this.Text = ashelter.Name;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void ShowAnimals()
        {
            foreach (Animal a in ashelter.GetAnimals())
            {
                lbAnimals.Items.Add(a.Info());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOwnedAnimals_Click(object sender, EventArgs e)
        {
            lbOwnedAnimals.Items.Clear();
            List<Animal> temp = this.ashelter.GetPersonsAnimals(tbEmailToCheckAnimals.Text);
            foreach(Animal a in temp)
            {
                lbOwnedAnimals.Items.Add(a.Info());

            }
        }

        private void btnCheckPerson_Click(object sender, EventArgs e)
        {
            if (ashelter.CheckIfPersonIsRegistered(tbCheckEmail.Text))
            {
                MessageBox.Show("The person is registered in the shelter");
            }
            else
            {
                MessageBox.Show("The person is not registered in the shelter");
            }
            tbCheckEmail.Text = "";
        }

        private void btnRegisterPerson_Click(object sender, EventArgs e)
        {
            ashelter.RegisterPerson(tbFirstname.Text, tbLastnamePerson.Text, Convert.ToInt32(tbPhone.Text), tbEmailPerson.Text);
            MessageBox.Show("Person was successfuly registered");
            tbFirstname.Text = "";
            tbLastnamePerson.Text = "";
            tbPhone.Text = "";
            tbEmailPerson.Text = "";

        }

        private void btnCheckAnimal_Click(object sender, EventArgs e)
        {
            if (ashelter.CheckIfRegistered(tbAnimalTag.Text))
            {
                MessageBox.Show("The animal is registered in the shelter");
            }
            else
            {
                MessageBox.Show("The animal is not registered in the shelter");
            }
            tbAnimalTag.Text = "";
        }

        private void btnRegisterAnimal_Click(object sender, EventArgs e)
        {
            ashelter.Register(tbTag.Text, tbDescription.Text,dateTimePicker1.Value, tbLocation.Text,cbType.Text);
            MessageBox.Show("Animal was successfuly registered");
            tbLocation.Text = "";
            tbTag.Text = "";
            tbDescription.Text = "";
            cbType.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnWalk_Click(object sender, EventArgs e)
        {
            try
            {
                string tag = tbDogTag.Text;
                Dog walkdog = ashelter.GetDog(tag);
                walkdog.Walk();
                MessageBox.Show("Dog walked");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid tag");
            }
        }

        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string tag = tbCatTag.Text;
                Cat c = ashelter.GetCat(tag);
                c.AddExtraInfo(tbExtraInfo.Text);
                MessageBox.Show("Extra info was added");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid tag");
            }
        } 

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            ashelter.GenerateReport();
        }

        private void btnShowAdopted_Click(object sender, EventArgs e)
        {
            lbAnimals.Items.Clear();
            foreach (Animal a in ashelter.AdoptedAnimals())
            {
                lbAnimals.Items.Add(a.Info());
            }
        }

        private void btnNotAdopted_Click(object sender, EventArgs e)
        {
            lbAnimals.Items.Clear();
            foreach (Animal a in ashelter.NotAdoptedAnimals())
            {
                lbAnimals.Items.Add(a.Info());
            }
        }

        private void btnAdoptClaim_Click(object sender, EventArgs e)
        {
            try
            {
                this.a = this.animals[lbAnimals.SelectedIndex];
                if (a.adopted == false)
                {
                    if (this.ashelter.CheckIfOwner(a, tbAdopterEmail.Text))
                    {
                        price = this.ashelter.ClaimtAnimalPrice(a);
                        tbFeeForAnimal.Text = price.ToString();
                        this.owner = true;
                    }
                    else
                    {
                        if (this.ashelter.AdoptAnimalPrice(a) != -1)
                        {
                            price = this.ashelter.AdoptAnimalPrice(a);
                            tbFeeForAnimal.Text = price.ToString();
                            this.owner = false;
                        }
                        else
                        {
                            MessageBox.Show("The animal can not be adopted");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The animal is already adopted");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select an animal from the list");
            }

        }

        private void btnPayFee_Click(object sender, EventArgs e)
        {
            if (this.owner)
            {
                tbFeeForAnimal.Text = "";
                tbAdopterEmail.Text = "";
                MessageBox.Show("Payment successful");
            }
            else
            {
                this.ashelter.AdoptAnimal(a, tbAdopterEmail.Text);
                tbAdopterEmail.Text = "";
                tbFeeForAnimal.Text = "";
                MessageBox.Show("Payment successful");
            }
        }

        public void addAnimals()
        {
            this.ashelter.Register("1", "black", new DateTime(1981, 03, 01), "eindhoven", "Cat");
            this.ashelter.Register("2", "white", new DateTime(1981, 03, 01), "amsterdam", "Dog");
            this.ashelter.Register("3", "red", new DateTime(1981, 03, 01), "eindhoven", "Dog");
            this.ashelter.Register("4", "purple", new DateTime(1981, 03, 01), "amsterdam", "Cat");
            this.ashelter.Register("5", "grey", DateTime.Now, "eindhoven", "Cat");
            this.ashelter.Register("6", "orange", DateTime.Now, "amsterdam", "Dog");
            this.ashelter.Register("7", "blue", new DateTime(1981, 03, 01), "eindhoven", "Cat");
        }
        public void addPeople()

        {
            this.ashelter.RegisterPerson("John", "Smith", 0612938373, "johnsmith@gmail.com");
            this.ashelter.RegisterPerson("Loran", "Cool", 0612938373, "lorancool@gmail.com");
            this.ashelter.RegisterPerson("Mark", "Walberg", 0612938373, "markwalberg@gmail.com");
            this.ashelter.RegisterPerson("Ben", "Huck", 0612938373, "benhuck@gmail.com");
            this.ashelter.RegisterPerson("Jack", "Wee", 0612938373, "jackwee@gmail.com");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
