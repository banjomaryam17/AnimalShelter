namespace AnimalShelter
{
    public class Dog : Animal
    {
        public Dog(int id, string name, int age, string breed, string location) : base(id, name, age, breed, location)
        {}

        public override string GetAnimalType()
        {
            return "Dog";
        }
    }
}



