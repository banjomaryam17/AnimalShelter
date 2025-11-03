
namespace AnimalShelter;

public class ShelterManager
{
    private List<Animal> animals;
    private int nextId;
    private FileHandler fileHandler;

    public ShelterManager()
    {
        animals = new List<Animal>();
        nextId = 1;
        fileHandler = new FileHandler("animalsInfo.txt");
    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
        Console.WriteLine("Animal added successfully!");
        Console.WriteLine("Id: " + animal.id + ", Name: " + animal.name);
    }

    public int GetNextId()
    {
        int id = nextId;
        nextId++;
        return id;
    }

    public List<Animal> GetAllAnimals()
    {
        return animals;
    }

    public Animal GetAnimalById(int id)
    {
        foreach (Animal animal in animals )
        {
            if (animal.id == id)
            {
                return animal;
            } 
        }

        return null;
    }

    public List<Animal> GetAnimalsNeedingFoster()
    {
        List<Animal> fosterAnimals = new List<Animal>();
        foreach (Animal animal in animals )
        {
            if (animal.needsFoster == true) 
            {
                fosterAnimals.Add(animal);
            }
        }
        return fosterAnimals;
    }

    public List<Animal> GetAvailableForAdoption()
    {
        List<Animal> adoptableAnimals = new List<Animal>();

        foreach (Animal animal in animals)
        {
            if (animal.isAvailaibleForAdoption == true)
            {
                adoptableAnimals.Add(animal);
            }
        }

        return adoptableAnimals;
    }

    public List<Animal> FilterByType(string type)
    {
        List<Animal> filteredAnimals = new List<Animal>();
        foreach (Animal animal in animals)
        {
            if (animal.GetAnimalType() == type)
            {
                filteredAnimals.Add(animal);
            }
        }
        return filteredAnimals;
    }

    public List<Animal> FilterByVaccination(bool vaccinated)
    {
        List<Animal> filteredAnimals = new List<Animal>();

        foreach (Animal animal in animals )
        {
            if (animal.isVaccinated== vaccinated)
            {
              filteredAnimals.Add(animal);
            } 
        }
        return filteredAnimals;
    }
    public List<Animal> FilterByLocation(string location)
    {
        List<Animal> filteredAnimals = new List<Animal>();
            
        foreach (Animal animal in animals)
        {
            if (animal.Location == location)
            {
                filteredAnimals.Add(animal);
            }
        }
            
        return filteredAnimals;
    }
    public void DisplayAnimalList(List<Animal> animalList)
    {
        if (animalList.Count == 0)
        {
            Console.WriteLine("No animals found.");
            return;
        }

        Console.WriteLine("ANIMAL LIST");
        Console.WriteLine("Total animals: " + animalList.Count);
        Console.WriteLine();

        foreach (Animal animal in animalList)
        {
            animal.DisplayInfo();
        }
    }
    public void LoadSampleData()
    {
        Dog dog1 = new Dog(GetNextId(), "Buddy", 3, "Golden Retriever", "Dublin");
        dog1.IsVaccinated = true;
        dog1.isAvailaibleForAdoption = true;
        AddAnimal(dog1);

        Dog dog2 = new Dog(GetNextId(), "Max", 5, "German Shepherd", "Cork");
        dog2.IsVaccinated = true;
        dog2.NeedsFoster = true;
        AddAnimal(dog2);

        Dog dog3 = new Dog(GetNextId(), "Luna", 2, "Beagle", "Dublin");
        dog3.IsVaccinated = false;
        dog3.isAvailaibleForAdoption = true;
        AddAnimal(dog3);
        
        Cat cat1 = new Cat(GetNextId(), "Whiskers", 4, "Siamese", "Galway");
        cat1.IsVaccinated = true;
        cat1.isAvailaibleForAdoption = true;
        AddAnimal(cat1);

        Cat cat2 = new Cat(GetNextId(), "Mittens", 1, "Persian", "Cork");
        cat2.IsVaccinated = false;
        cat2.NeedsFoster = true;
        AddAnimal(cat2);

        Cat cat3 = new Cat(GetNextId(), "Shadow", 6, "Tabby", "Dublin");
        cat3.IsVaccinated = true;
        cat3.IsAvailaibleForAdoption = false;  
        AddAnimal(cat3);

        Console.WriteLine("Sample data loaded successfully!");
        Console.WriteLine("Total animals in shelter: " + animals.Count);
    }

}