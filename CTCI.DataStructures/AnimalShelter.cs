using System;

namespace CTCI.DataStructures
{
    /// <summary>
    /// Class representing queues of dogs and cats in an animal shelter
    /// </summary>
    public class AnimalShelter
    {
        public Animal NextAnimal { get; set; }
        public Dog NextDog { get; set; }
        public Cat NextCat { get; set; }

        public AnimalShelter()
        {
            NextAnimal = null;
            NextDog = null;
            NextCat = null;
        }

        /// <summary>
        /// Adds animal to back of animal queue, adds to dog queue if a dog or cat queue if a cat
        /// O(n) time, O(1) space
        /// </summary>
        /// <param name="animal">Animal</param>
        public void Enqueue(Animal animal)
        {
            if (NextAnimal == null)
                NextAnimal = animal;
            else
            {
                Animal currAnimal = NextAnimal;
                while (currAnimal.NextAnimal != null)
                    currAnimal = currAnimal.NextAnimal;
                currAnimal.NextAnimal = animal;
            }
            if (animal.Type == "Dog")
            {
                if (NextDog == null)
                    NextDog = (Dog)animal;
                else
                {
                    Dog currDog = NextDog;
                    while (currDog.NextDog != null)
                        currDog = currDog.NextDog;
                    currDog.NextDog = (Dog)animal;
                }
            }
            else
            {
                if (NextCat == null)
                    NextCat = (Cat)animal;
                else
                {
                    Cat currCat = NextCat;
                    while (currCat.NextCat != null)
                        currCat = currCat.NextCat;
                    currCat.NextCat = (Cat)animal;
                }
            }
        }

        /// <summary>
        /// Dequeues from animal queue, removes from dog queue if a dog, cat queue if a cat
        /// O(n) time, O(1) space
        /// </summary>
        /// <returns>Animal</returns>
        public Animal DequeueAny()
        {
            if (NextAnimal == null)
                return null;
            
            Animal animal = NextAnimal;
            NextAnimal = NextAnimal.NextAnimal;
            if (animal.Type == "Dog")
                NextDog = NextDog.NextDog;
            else
                NextCat = NextCat.NextCat;
            
            return animal;
        }

        /// <summary>
        /// Removes from dog queue, and removes from animal queue as well
        /// O(n) time, O(1) space
        /// </summary>
        /// <returns>Dog</returns>
        public Dog DequeueDog()
        {
            if (NextAnimal == null)
                return null;
            if (NextDog == null)
                return null;
            
            Dog dog;
            if (NextAnimal.Type == "Dog")
            {
                dog = (Dog)DequeueAny();
                return dog;
            }
            Animal currAnimal = NextAnimal;
            while (currAnimal.NextAnimal.Type != "Dog")
                currAnimal = currAnimal.NextAnimal;
            currAnimal.NextAnimal = currAnimal.NextAnimal.NextAnimal;
            dog = NextDog;
            NextDog = NextDog.NextDog;

            return dog;
        }

        /// <summary>
        /// Removes from cat queue, and removes from animal queue as well
        /// O(n) time, O(1) space
        /// </summary>
        /// <returns>Cat</returns>
        public Cat DequeueCat()
        {
            if (NextAnimal == null)
                return null;
            if (NextCat == null)
                return null;
            
            Cat cat;
            if (NextAnimal.Type == "Cat")
            {
                cat = (Cat)DequeueAny();
                return cat;
            }
            Animal currAnimal = NextAnimal;
            while (currAnimal.NextAnimal.Type != "Cat")
                currAnimal = currAnimal.NextAnimal;
            currAnimal.NextAnimal = currAnimal.NextAnimal.NextAnimal;
            cat = NextCat;
            NextCat = NextCat.NextCat;

            return cat;
        }
    }

    /// <summary>
    /// Abstract generic animal class
    /// </summary>
    public abstract class Animal
    {
        public string Type { get; set; }
        public Animal NextAnimal { get; set; }

        public Animal()
        {
            NextAnimal = null;
        }
    }

    /// <summary>
    /// Animal class representing dog
    /// </summary>
    public class Dog : Animal
    {
        public Dog NextDog { get; set; }
        public Dog() : base()
        {
            Type = "Dog";
            NextDog = null;
        }
    }

    /// <summary>
    /// Animal class representing cat
    /// </summary>
    public class Cat : Animal
    {
        public Cat NextCat { get; set; }
        public Cat() : base()
        {
            Type = "Cat";
            NextCat = null;
        }
    }
}