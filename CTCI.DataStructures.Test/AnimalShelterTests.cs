using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCI.DataStructures.Test
{
    [TestClass]
    public class AnimalShelterTests
    {
        [TestMethod]
        public void TestAnimalShelterMethods()
        {
            // Arrange
            AnimalShelter emptyShelter = new AnimalShelter();

            AnimalShelter noCatsShelter = new AnimalShelter();

            AnimalShelter noDogsShelter = new AnimalShelter();

            AnimalShelter shelter = new AnimalShelter();
            Dog d1 = new Dog();
            Cat c1 = new Cat();
            Cat c2 = new Cat();
            Dog d2 = new Dog();
            Dog d3 = new Dog();
            Cat c3 = new Cat();

            // Act
            Animal emptyShelterDequeueAnyResult = emptyShelter.DequeueAny();

            noCatsShelter.Enqueue(new Dog());
            Cat noCatsShelterDequeueCatResult = noCatsShelter.DequeueCat();

            noDogsShelter.Enqueue(new Cat());
            Dog noDogsShelterDequeueDogResult = noDogsShelter.DequeueDog();

            shelter.Enqueue(d1);
            shelter.Enqueue(c1);
            shelter.Enqueue(c2);
            shelter.Enqueue(d2);
            shelter.Enqueue(d3);
            shelter.Enqueue(c3);
            shelter.DequeueCat();
            shelter.DequeueAny();
            shelter.DequeueDog();

            // Assert
            Assert.IsNull(emptyShelterDequeueAnyResult);
            Assert.IsNull(noCatsShelterDequeueCatResult);
            Assert.IsNull(noDogsShelterDequeueDogResult);

            Animal currAnimal = shelter.NextAnimal;
            Assert.AreEqual(c2, currAnimal);
            currAnimal = currAnimal.NextAnimal;
            Assert.AreEqual(d3, currAnimal);
            currAnimal = currAnimal.NextAnimal;
            Assert.AreEqual(c3, currAnimal);
            currAnimal = currAnimal.NextAnimal;
            Assert.IsNull(currAnimal);

            Dog currDog = shelter.NextDog;
            Assert.AreEqual(d3, currDog);
            currDog = currDog.NextDog;
            Assert.IsNull(currDog);

            Cat currCat = shelter.NextCat;
            Assert.AreEqual(c2, currCat);
            currCat = currCat.NextCat;
            Assert.AreEqual(c3, currCat);
            currCat = currCat.NextCat;
            Assert.IsNull(currCat);
        }
    }
}