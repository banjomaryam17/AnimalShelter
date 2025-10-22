namespace AnimalShelter;

public abstract class Animal
{
    public int id;
    public string name;
    public int age;
    public string breed;
    public bool isVaccinated;
    public string location;
    public bool needsFoster;
    public bool isAvailaibleForAdoption;
    public string medicalNotes;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }
    public bool IsVaccinated
    {
        get { return isVaccinated; }
        set { isVaccinated = value; }
    }

    public bool IsAvailaibleForAdoption
    {
        get { return isAvailaibleForAdoption; }
        set { isAvailaibleForAdoption = value; }
    }

    public string MedicalNotes
    {
        get { return medicalNotes; }
        set { medicalNotes = value; }
    }

    public string Location
    {
        get { return location; }
        set { location = value; }
    }

    public bool NeedsFoster
    {
        get { return needsFoster; }
        set { needsFoster = value; }
    }

    protected Animal(int id, string name, int age, string breed, string location)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.breed = breed;
        this.location = location;
        isVaccinated = false;
        isAvailaibleForAdoption = true;
        medicalNotes = "";
        needsFoster = false;
    }

    public abstract string GetAnimalType();

    public void DisplayInfo()
    {
        Console.WriteLine();
        Console.WriteLine("=== " + GetAnimalType() + " INFORMATION ===");
        Console.WriteLine();
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age + " years old");
        Console.WriteLine("Breed: " + breed);
        Console.WriteLine("Location: " + location);

        if (isVaccinated)
        {
            Console.WriteLine("Vaccinated: Yes");
        }
        else
        {
            Console.WriteLine("Vaccinated: No");
        }

        if (isAvailaibleForAdoption)
        {
            Console.WriteLine("Availaible for Adoption: Yes");
        }
        else
        {
            Console.WriteLine("Availaible for Adoption: No");
        }

        if (medicalNotes != "" && medicalNotes != null)
        {
            Console.WriteLine("Medical Notes: " + medicalNotes);
        }

        Console.WriteLine("==============================================");
    }
    public void UpdateVaccination(bool vaccinated)
    {
        IsVaccinated = vaccinated;
        Console.WriteLine($"✓ {Name}'s vaccination status updated to: {(vaccinated ? "Vaccinated" : "Not Vaccinated")}");
    }

    public void AddMedicalNote(string note)
        {
            string dateStamp = DateTime.Now.ToString("yyyy-MM-dd");
            
            if (string.IsNullOrEmpty(MedicalNotes))
            {
                MedicalNotes = $"[{dateStamp}] {note}";
            }
            else
            {
                MedicalNotes += $"\n[{dateStamp}] {note}";
            }
            
            Console.WriteLine($"✓ Medical note added for {Name}");
        }
    
    }
