using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using animal_shelter;

namespace MiniProjectTest
{
    [TestClass]
    public class MiniProjectTest
    {
        [TestMethod]
        public void TestGetPersonByEmail()
        {
            //Arrange
            AnimalShelter ashelter;
            ashelter = new AnimalShelter("Shelter", "Nowhere", 0881256,"shelter@mail.com");
            ashelter.RegisterPerson("Stefan", "Rachev", 4513215, "stef_rachev@abv.bg");
            ashelter.RegisterPerson("Angel", "Mishkov", 2511563, "lasmirant@mail.com");

            //Act
            ashelter.GetPersonIdByEmail("stef_rachev@abv.bg");

            //Assert
            Assert.AreEqual(ashelter.GetPersonIdByEmail("lasmirant@mail.com"),102);


        }

        [TestMethod]
        public void TestClaimPrice()
        {
            //Arrange
            AnimalShelter shelter;
            shelter = new AnimalShelter("Name", "Address", 666666, "email@.email.io");
            shelter.Register("111", "Purple Cat", DateTime.Now, "Location1", "Dog");
            

            //Act
            shelter.ClaimtAnimalPrice(shelter.GetListAnimals[0]);

            //Assert
            Assert.IsNotNull(shelter.GetListAnimals);
            Assert.AreEqual(shelter.ClaimtAnimalPrice(shelter.GetListAnimals[0]), 10);
            


        }
        [TestMethod]
        public void TestRegister()
        {
            //Arrange
            string tag = "3r2k";
            string description = "a good doggo";
            DateTime now = DateTime.Now;
            string location = "Eindhoven";
            string type = "Dog";

            AnimalShelter animalShelter = new AnimalShelter("TestShelter", "Somewhere", 098908, "google@gmail.com");
            List<Animal> listofall = new List<Animal>();
            int count1 = listofall.Count;

            //Act
            animalShelter.Register(tag, description, now, location, type);
            listofall = animalShelter.GetAnimals();
            int count2 = listofall.Count;
            //Assert
            Assert.AreEqual(count2, count1 + 1);

        }

    }
}
