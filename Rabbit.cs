namespace AnimalShelter
{
    public class Rabbit:Animal
    {
        public Rabbit(int id, string name, int age, string breed, string location) : base(id, name, age, breed, location)
        {}

        public override string GetAnimalType()
        {
            return "Rabbit";
        }
    } 
}

