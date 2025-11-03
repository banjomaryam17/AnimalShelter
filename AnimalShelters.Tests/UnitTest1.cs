using AnimalShelter;

namespace AnimalShelters.Tests;

public class ShelterManagerTests
{
    [Test]
    public void AddANIMAL_increaseCount()
    {
        ShelterManager manager = new ShelterManager();
        Dog dog = new Dog(1, "Test", 3, "Labrador", "Dublin");
        manager.AddAnimal(dog);
        
        Assert.AreEqual(1, manager.GetAllAnimals().Count);
    }
    [Test]
    public void GetAnimalById_ReturnsCorrectAnimal()
    {
        ShelterManager manager = new ShelterManager();
        Dog dog = new Dog(1, "Buddy", 3, "Labrador", "Dublin");
        manager.AddAnimal(dog);
        
        Animal result = manager.GetAnimalById(1);
        Assert.IsNotNull(result);
        Assert.AreEqual("Buddy", result.Name);
    }
    [Test]
    public void GetAnimalsNeedingFoster_ReturnsOnlyFosterAnimals()
    {
        ShelterManager manager = new ShelterManager();
        Dog dog1 = new Dog(1, "Max", 5, "Beagle", "Cork");
        dog1.NeedsFoster = true;
        Dog dog2 = new Dog(2, "Luna", 2, "Poodle", "Dublin");
        dog2.NeedsFoster = false;
            
        manager.AddAnimal(dog1);
        manager.AddAnimal(dog2);
      
        List<Animal> result = manager.GetAnimalsNeedingFoster();
     
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Max", result[0].Name);
    }

    [Test]
    public void FilterByType_ReturnsOnlyDogs()
    {
        ShelterManager manager = new ShelterManager();
        manager.AddAnimal(new Dog(1, "Rex", 4, "Husky", "Galway"));
        manager.AddAnimal(new Cat(2, "Whiskers", 3, "Siamese", "Cork"));
        
        List<Animal> result = manager.FilterByType("Dog");
        
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Rex", result[0].Name);
    }
    [Test]
    public void SearchByName_FindsPartialMatch()
    {
        ShelterManager manager = new ShelterManager();
        manager.AddAnimal(new Dog(1, "Buddy", 3, "Labrador", "Dublin"));
        manager.AddAnimal(new Cat(2, "Mittens", 2, "Persian", "Cork"));
        
        List<Animal> result = manager.SearchByName("bu");
        
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Buddy", result[0].Name);
    }
}