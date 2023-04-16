using Application.Handler.Interface;
using Application.Handlers;
using Application.Repository.Interfaces;
using Domain.Models;
using Domain.States;
using Infrastructure.Persistence;
using OnlineQueue;

class Program
{
    static void Main(string[] args)
    {
        //ICategoryRepository category = new DbCategory();
        //ICategoryHandler categoryHandler = new CategoryHandler(category);
        //categoryHandler.InsertCategoryAsync(new()
        //{
        //    CategoryName = "Test111"
        //});
        //Console.ReadKey();
        DbContext dbContext = new DbContext();
      //  dbContext.CreateDb();
        //dbContext.InitializeTables();

        //TestPatient();
        //TestCategory();
        //TestHospital();
        //TestServingStatement();
        // TestPhycisian();
        //TestHospPhy();
        //TestWaitList();
         OnlineQueueUi.UI().Wait();
         Console.ReadKey();



    }

    private async static void TestServingStatement()
    {
        IServingStatementRepository repository1 = new DbServingStatement();
        IServingStatementHandler statementHandler = new ServingStatementHandler(repository1);
        List<ServingStatement> statements = await statementHandler.GetAllServingStatementAsync();
        int id = statements.Where(s => s.Patient.PatientId == 1)
                                                   .Select(s => (int)s.Id).FirstOrDefault();
        ServingStatement servingStatement = await statementHandler.GetByIdServingStatementAsync(id);
        servingStatement.EndTime = DateTime.Now;
        await statementHandler.UpdateServingStatementAsync(servingStatement);
    }

    private static async void TestWaitList()
    {
       IWaitListRepository repository = new DbWaitListRepo();
        IWaitListHandler waitListHandler = new WaitListHandler(repository);
        IPatientRepository repository1 = new DbPatient();
        IPatientHandler patientHandler = new PatientHandler(repository1);
        IPhysicianRepository repository2 = new DbPhysician();
        IPhysicianHandler physicianHandler = new PhysicianHandler(repository2);
        //await waitListHandler.InsertWaitListAsync(new()
        //{
        //    Physician = await physicianHandler.GetByIdPhysicianAsync(3),
        //    Patient = await patientHandler.GetByIdPatientAsync(2),
        //    JoinedTime= new DateTime()
        //});
        //List<WaitList> waitList = new List<WaitList>();
        //waitList = await waitListHandler.GetAllWaitListsAsync();
        //foreach(WaitList wait in waitList)
        //{
        //    Console.WriteLine(wait.Physician.PhoneNumber);
        //}
        await waitListHandler.DeleteWaitListByIdAsync(2);
    }

    private static async void TestHospPhy()
    {
        IHospitalPhysicianRepository repository = new DbHospitalPhysician();
        IHospitalPhysicianHandler hospitalPhysicianHandler = new HospitalPhysicianHandler(repository);
        IHospitalRepository repository1 = new DbHospital();
        IHospitalHandler hospitalHandler = new HospitalHandler(repository1);
        IPhysicianRepository repository2 = new DbPhysician();
        IPhysicianHandler physicianHandler = new PhysicianHandler(repository2);

        HospitalPhysician hospitalPhysician = new HospitalPhysician()
        {
            Hospital = await hospitalHandler.GetByIdHospitalAsync(3),
            Physician = await physicianHandler.GetByIdPhysicianAsync(2)
        };
        await hospitalPhysicianHandler.InsertHospitalPhysicianAsync(hospitalPhysician);

    }



    //private static void TestServingStatement()
    //{
    //    throw new NotImplementedException();
    //}

    private async static void TestHospital()
    {
        IHospitalRepository repository = new DbHospital();
        IHospitalHandler hospitalHandler = new HospitalHandler(repository);
      //   await hospitalHandler.InsertHospitalAsync(new() { Name = "MedicalCentre", HospitalRating = HospitalRating.Excellent});
     
        //await hospitalHandler.UpdateHospitalAsync(hospital);
    }

    private static async void TestPhycisian()
    {
        IPhysicianRepository repository = new DbPhysician();
        IPhysicianHandler physicianHandler = new PhysicianHandler(repository);
        Physician physician = await physicianHandler.GetByIdPhysicianAsync(2);
        Console.WriteLine(physician.Id);
        
        //await physicianHandler.DeletePhysicianByIdAsync(1);
        //await physicianHandler.InsertPhysicianAsync(new()
        //{
        //    Category = new()
        //    {
        //        CategoryId= 2,
        //    },
        //    FirstName = "Azamat",
        //    ExperienceYear = 3,
        //    LastName = "Abdullayev",
        //    PhoneNumber = "56545678",
        //    Rating = PhysicianRating.Competent


        //});
    }

    private static async void TestCategory()
    {
        ICategoryRepository repository = new DbCategory();
        ICategoryHandler categoryHandler = new CategoryHandler(repository);
        await categoryHandler.InsertCategoryAsync(new()
        {
            CategoryName = "Kardiolog"
        });
        //List<Category> categories = new List<Category>();
        //categories = await categoryHandler.GetAllCategoriesAsync();
        //foreach(Category category in categories)
        //{
        //    Console.WriteLine(category.CategoryName);
        //}
        Category category = await categoryHandler.GetByIdCategoryAsync(1);
        Console.WriteLine(category.CategoryId);
        //category.CategoryName = "Test";
        //await categoryHandler.DeleteCategoryByIdAsync(5);
        //await categoryHandler.UpdateCategoryAsync(category);
    }

    public static async void TestPatient()
    {
        IPatientRepository repository = new DbPatient();
        IPatientHandler patientHandler = new PatientHandler(repository);
        await patientHandler.InsertPatientAsync(new() { FirstName = "Feruz", LastName = "Qodirov", PhoneNumber = "+998912334678" });
        //Patient patient = await patientHandler.GetByIdPatientAsync(2);
        //patient.FirstName = "Maqsud";
        //patient.LastName = "Haydarov";
        //patient.PhoneNumber= "1234567890";
        //await patientHandler.UpdatePatientAsync(patient);
        //await patientHandler.DeletePatientByIdAsync(1);
        //List<Patient> patients = await patientHandler.GetAllPatientsAsync();
        //foreach (Patient patient in patients)
        //{
        //    Console.WriteLine(patient.FirstName + " " + patient.PhoneNumber);
        //}
    }
}