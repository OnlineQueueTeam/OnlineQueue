using Domain.Models;
using Infrastructure.Persistence;

class Program
{
    static void Main(string[] args)
    {
        DbPatient dbPatient = new DbPatient();
        TestServing();
        Console.ReadKey();
    }

    private async static void TestServing()
    {
        DbServing dbServing = new DbServing();
        //await dbServing.AddAsync(new Serving() { PatientId = 3, PhysicianId = 3, ServedTime = DateTime.Now });
        //await dbServing.DeleteAsync(2);
        //Serving serving = new Serving()
        //{
        //    Id= 1
        //    PatientId = 2,
        //    PhysicianId = 5,
        //}
        //await dbServing.UpdateAsync()
    }

    private async static void TestWaiting()
    {
       DbWaitListRepo dbWaitListRepo = new DbWaitListRepo();

        await dbWaitListRepo.AddAsync(new WaitList()
        {
            PatientId = 3,
            PhysicianId = 3,
            JoinedTime = DateTime.Now,

        });
    }

    private async static void TestPhysician()
    {
        DbPhysician physician = new DbPhysician();
        DbContext dbContext = new DbContext();
        //await physician.AddAsync(new Physician()
        //{
        //    CategoryId = new Category { CategoryId = 2 },
        //    FirstName = "Test",
        //    LastName = "Test1",
        //    PhoneNumber = "901234567",
        //    ExperienceYear = 1,
        //    Rating = Domain.States.Rating.Knowledgeable
        //});

        //var list = await physician.GetAllAsync();
        //foreach ( var item in list )
        //{
        //    Console.WriteLine(item.FirstName);
        //}
        // DbPhysician dbPhysician = new DbPhysician();
        //await physician.DeleteAsync(2);

        await physician.UpdateAsync(new Physician()
        {
            Id = 5,
            CategoryId = 3,
            FirstName = "Test",
            LastName = "Test1",
            PhoneNumber = "901234567",
            ExperienceYear = 111,
            Rating = Domain.States.Rating.Caring
        });

    }

    private static void Test2()
    {
      
    }

    private async static void Test1()
    {
        DbCategory dbCategory = new DbCategory();
        Category category = new Category()
        {
            CategoryName = "Test3"
        };
        var list = await dbCategory.GetAllAsync();
        foreach(var item in list)
        {
            Console.WriteLine(item.CategoryName);
        }
        
    }

    public static async void Test()
    {
        DbPatient dbPatient = new DbPatient();
        Patient patient = new()
        {
            FirstName = "Test1",
            LastName = "Test2",
            PhoneNumber = "Test3",
        };
        //var patients = await dbPatient.GetAllAsync();
        //foreach (Patient patient1 in patients)
        //{
        //    Console.WriteLine(patient1);
        //}
        Patient patient1 = await dbPatient.GetByIdAsync(2);
        Console.WriteLine(patient1);
        //Patient patient1 = await dbPatient.GetByIdAsync(2);
        //patient1.FirstName = "aa";
        //patient1.LastName = "bbb";
        //patient.PhoneNumber = "12345";
        //await dbPatient.UpdateAsync(patient1);

    }
}