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
}