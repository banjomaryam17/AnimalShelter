namespace AnimalShelter;

class Program
{
   private static ShelterManager manager = new ShelterManager();

   private static void Main(string[] args)
   {
      Console.WriteLine("ANIMAL SHELTER MANAGEMENT SYSTEM");
      Console.WriteLine();
      Console.WriteLine("Loading data from file...");
      manager.LoadFromFile();

      bool active = true;
      while (active)
      {
          active = DisplayMainMenu();
      }
      Console.WriteLine("Thank you for using the Animal Shelter Management System");
   }

   private static bool DisplayMainMenu()
   {
       Console.WriteLine(" Main Menu:");
       Console.WriteLine("Select your option:");
       Console.WriteLine("1. Add New Animal");
       Console.WriteLine("2. View & Update Animal Records as a Vet");
       Console.WriteLine("3. View Animals Needing a Foster Home");
       Console.WriteLine("4. View All Animals");
       Console.WriteLine("5. View Animals for Adoption");
       Console.WriteLine("6. Exit");
       Console.WriteLine("Enter your choice (1-6): ");
       
       
       string option = Console.ReadLine();


       switch (option)
       {
           case "1":
               AddAnimal();
               break;
           case "2":
               UpdateAnimal();
               break;
           case "3":
               FosterAnimal();
               break;
           case "4":
               ViewAllAnimals();
               break;
           case "5":
               AdoptedAnimals();
               break;
           case "6":
               return false;
           default: Console.WriteLine("Unknown option");
               break;
       }

       return true;
           
       }

   static void AddAnimal()
        {
            Console.WriteLine("ADD NEW ANIMAL");
            
            Console.WriteLine("What type of animal?");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.Write("Enter choice (1-2): ");
            string Choice = Console.ReadLine();

           
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter breed: ");
            string breed = Console.ReadLine();

            Console.Write("Enter location: ");
            string location = Console.ReadLine();
            
            Console.Write("Is vaccinated?  ");
            string vaccinatedInput = Console.ReadLine();
            bool isVaccinated = (vaccinatedInput.ToLower() == "yes");
            
            Console.Write("Needs foster home? ");
            string fosterInput = Console.ReadLine();
            bool needsFoster = (fosterInput.ToLower() == "yes");

       
            Animal newAnimal = null;
            int newId = manager.GetNextId();

            if (Choice == "1")
            {
                newAnimal = new Dog(newId, name, age, breed, location);
            }
            else if (Choice == "2")
            {
                newAnimal = new Cat(newId, name, age, breed, location);
            }
            else
            {
                Console.WriteLine("Invalid type choice!");
                return;
            }

         
            newAnimal.IsVaccinated = isVaccinated;
            newAnimal.NeedsFoster = needsFoster;

            manager.AddAnimal(newAnimal);
            Console.WriteLine("Animal added successfully!");
        }

        static void UpdateAnimal()
        {
            Console.WriteLine("View and Update Animal Records as a Vet");

            Console.WriteLine("Current animals in shelter:");
            List<Animal> allAnimals = manager.GetAllAnimals();

            foreach (Animal animal in allAnimals)
            {
                Console.WriteLine("ID: " + animal.Id + " - " + animal.Name + " (" + animal.GetAnimalType() + ")");
            }

            Console.Write("Enter animal ID to view: ");
            int id = int.Parse(Console.ReadLine());

            Animal selectedAnimal = manager.GetAnimalById(id);

            if (selectedAnimal == null)
            {
                Console.WriteLine("Animal not found!");
                return;
            }

            selectedAnimal.DisplayInfo();

            Console.WriteLine("WHAT DO YOU WANT TO DO TODAY?");
            Console.WriteLine("1. Update vaccination status");
            Console.WriteLine("2. Add medical note");
            Console.WriteLine("3. Go back");
            Console.Write("Enter choice (1-3): ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Is animal vaccinated? ");
                string vaccinated = Console.ReadLine();
                selectedAnimal.UpdateVaccination(vaccinated.ToLower() == "yes");
            }
            else if (option == "2")
            {
                Console.Write("Enter medical note: ");
                string note = Console.ReadLine();
                selectedAnimal.AddMedicalNote(note);
            }
        }

        static void FosterAnimal()
            {
                Console.WriteLine("Foster Care Options");
            
                List<Animal> fosterAnimals = manager.GetAnimalsNeedingFoster();
                manager.DisplayAnimalList(fosterAnimals);

                if (fosterAnimals.Count > 0)
                {
                    Console.WriteLine("Contact the shelter to arrange fostering!");
                }
            }

            static void ViewAllAnimals()
            {
                Console.WriteLine("ALL ANIMALS IN SHELTER");
                List<Animal> allAnimals = manager.GetAllAnimals();
                manager.DisplayAnimalList(allAnimals);
            }
            
            static void AdoptedAnimals()
            {
                Console.WriteLine("ANIMALS AVAILABLE FOR ADOPTION");
                Console.WriteLine("1. View all available animals");
                Console.WriteLine("2. Filter by type (Dog/Cat)");
                Console.WriteLine("3. Filter by vaccination status");
                Console.WriteLine("4. Filter by location");
                Console.Write("Enter choice (1-4): ");
                string choice = Console.ReadLine();

                List<Animal> animalsToShow = manager.GetAvailableForAdoption();

                if (choice == "2")
                {
                    Console.Write("Enter type (Dog/Cat): ");
                    string type = Console.ReadLine();
                    animalsToShow = manager.FilterByType(type);
                
                
                    List<Animal> availableOnly = new List<Animal>();
                    foreach (Animal animal in animalsToShow)
                    {
                        if (animal.isAvailaibleForAdoption)
                        {
                            availableOnly.Add(animal);
                        }
                    }
                    animalsToShow = availableOnly;
                }
                else if (choice == "3")
                {
                    Console.Write("Show vaccinated animals? (yes/no): ");
                    string vaccinated = Console.ReadLine();
                    bool isVaccinated = (vaccinated.ToLower() == "yes");
                    animalsToShow = manager.FilterByVaccination(isVaccinated);
                    
                    List<Animal> availableOnly = new List<Animal>();
                    foreach (Animal animal in animalsToShow)
                    {
                        if (animal.IsAvailaibleForAdoption)
                        {
                            availableOnly.Add(animal);
                        }
                    }
                    animalsToShow = availableOnly;
                }
                else if (choice == "4")
                {
                    Console.Write("Enter location: ");
                    string location = Console.ReadLine();
                    animalsToShow = manager.FilterByLocation(location);
                
                    List<Animal> availableOnly = new List<Animal>();
                    foreach (Animal animal in animalsToShow)
                    {
                        if (animal.IsAvailaibleForAdoption)
                        {
                            availableOnly.Add(animal);
                        }
                    }
                    animalsToShow = availableOnly;
                }

                manager.DisplayAnimalList(animalsToShow);
            }

         
           
    }
        