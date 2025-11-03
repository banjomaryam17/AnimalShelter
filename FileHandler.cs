namespace AnimalShelter;

public class FileHandler
{
    private string filename;
    public FileHandler(string filename)
    {
        this.filename = filename;
    }

    public void SaveAnimals(List<Animal> animals)
    {
        try
        {
List<string> lines = new List<string>();

foreach (Animal animal in animals)
{
    lines.Add("START_ANIMAL_INFO");
    lines.Add("Type: " + animal.GetAnimalType());
    lines.Add("Id:" + animal.Id);
    lines.Add("Name: " + animal.Name);
    lines.Add("Age: " + animal.Age);
    lines.Add("Breed:" + animal.Breed);
    lines.Add("Location: " + animal.Location);
    lines.Add("Vaccinated: " + animal.IsVaccinated);
    lines.Add("AdoptionStatus: " + animal.IsAvailaibleForAdoption);
    lines.Add("FosterCareAvailability: " + animal.NeedsFoster);
    lines.Add("MedicalNote: "+ animal.MedicalNotes);
    lines.Add("END_ANIMAL_INFO");
}
File.WriteAllLines(filename, lines);
Console.WriteLine("Data successfully saved to " + filename);
Console.WriteLine("Total animals saved: "+ animals.Count);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error saving animals: " + e.Message);
        }
    }

    public List<Animal> LoadAnimals()
    {
        List<Animal> animals = new List<Animal>();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("No saved file found. Starting with empty shelter.");
                return animals;
            }

            string[] lines = File.ReadAllLines(filename);
            
            string type = "";
            int id = 0;
            string name = "";
            int age = 0;
            string breed = "";
            string location = "";
            bool isVaccinated = false;
            bool needsFoster = false;
            bool isAvailaibleForAdoption = false;
            string medicalNotes = "";
        }
    }
}