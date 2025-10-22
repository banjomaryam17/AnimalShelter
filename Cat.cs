namespace AnimalShelter
{
    public class Cat:Animal
    {
       
            public Cat(int id, string name, int age, string breed, string location) : base(id, name, age, breed, location)
            {}

            public override string GetAnimalType()
            {
                return "Cat";
            }
        
    }
}

