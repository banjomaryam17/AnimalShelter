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
                lines.Add("MedicalNote: " + animal.MedicalNotes);
                lines.Add("END_ANIMAL_INFO");
            }

            File.WriteAllLines(filename, lines);
            Console.WriteLine("Data successfully saved to " + filename);
            Console.WriteLine("Total animals saved: " + animals.Count);
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

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line == "START_ANIMAL")
                {
                    type = "";
                    id = 0;
                    name = "";
                    age = 0;
                    breed = "";
                    location = "";
                    isVaccinated = false;
                    needsFoster = false;
                    isAvailaibleForAdoption = false;
                    medicalNotes = "";
                }
                else if (line == "END_ANIMAL")
                {
                    Animal newAnimal = null;

                    if (type == "Dog")
                    {
                        newAnimal = new Dog(id, name, age, breed, location);
                    }
                    else if (type == "Cat")
                    {
                        newAnimal = new Cat(id, name, age, breed, location);
                    }

                    if (newAnimal != null)
                    {
                        newAnimal.IsVaccinated = isVaccinated;
                        newAnimal.NeedsFoster = needsFoster;
                        newAnimal.IsAvailaibleForAdoption = isAvailaibleForAdoption;
                        newAnimal.MedicalNotes = medicalNotes;

                        animals.Add(newAnimal);
                    }
                }
                else if (line.StartsWith("Type:"))
                {
                    type = line.Substring(5); // Get text after "Type:"
                }
                else if (line.StartsWith("Id:"))
                {
                    id = int.Parse(line.Substring(3));
                }
                else if (line.StartsWith("Name:"))
                {
                    name = line.Substring(5);
                }
                else if (line.StartsWith("Age:"))
                {
                    age = int.Parse(line.Substring(4));
                }
                else if (line.StartsWith("Breed:"))
                {
                    breed = line.Substring(6);
                }
                else if (line.StartsWith("Location:"))
                {
                    location = line.Substring(9);
                }
                else if (line.StartsWith("IsVaccinated:"))
                {
                    isVaccinated = bool.Parse(line.Substring(13));
                }
                else if (line.StartsWith("NeedsFoster:"))
                {
                    needsFoster = bool.Parse(line.Substring(12));
                }
                else if (line.StartsWith("IsAvailableForAdoption:"))
                {
                    isAvailaibleForAdoption = bool.Parse(line.Substring(23));
                }
                else if (line.StartsWith("MedicalNotes:"))
                {
                    medicalNotes = line.Substring(13);
                }
            }

            Console.WriteLine("Data Loaded sucessfully");
            Console.WriteLine("Total loaded: " + animals.Count);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error when loading file: " + e.Message);
        }

        return animals;
    }

}