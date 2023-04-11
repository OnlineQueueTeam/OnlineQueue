using Application.Handler.Interface;
using Application.Handlers;
using Application.Repository.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;

class Program
{
    static void Main(string[] args)
    {
        ICategoryRepository catRepo = new DbCategory();
        ICategoryHandler categoryHandler = new CategoryHandler(catRepo);
        categoryHandler.InsertCategoryAsync(new Category() { CategoryName = "Lor" }).Wait();

    }

    //private static void TestHospital()
    //{
    //    IHospitalRepository repository = new DbHospital();
    //    IHospitalHandler hospitalHandler = new HospitalHandler(repository);
    //    hospitalHandler
    //}

    private static async void TestPhycisian()
    {
        //IPhysicianRepository repository = new DbPhysician();
        //IPhysicianHandler physicianHandler = new PhysicianHandler(repository);
        //await physicianHandler.InsertPhysicianAsync(new()
        //{
        //    Category = new()
        //    {
        //        CategoryId= 1,
        //    },
        //    FirstName = "Feruz",
        //    Hospital = 
            
        //});
    }

    private static async void TestCategory()
    {
        ICategoryRepository repository = new DbCategory();
        ICategoryHandler categoryHandler = new CategoryHandler(repository);
        await categoryHandler.InsertCategoryAsync(new()
        {
            CategoryName = "Lor"
        });
        //List<Category> categories = new List<Category>();
        //categories = await categoryHandler.GetAllCategoriesAsync();
        //foreach(Category category in categories)
        //{
        //    Console.WriteLine(category.CategoryName);
        //}
        //Category category = await categoryHandler.GetByIdCategoryAsync(1);
        //category.CategoryName = "Test";
        //await categoryHandler.DeleteCategoryByIdAsync(5);
        //await categoryHandler.UpdateCategoryAsync(category);
    }

    public static async void TestPatient()
    {
        IPatientRepository repository = new DbPatient();
        IPatientHandler patientHandler = new PatientHandler(repository);
        //await patientHandler.InsertPatientAsync(new() { FirstName = "Feruz", LastName = "Hamroyev", PhoneNumber = "+998934765950" });
        Patient patient = await patientHandler.GetByIdPatientAsync(2);
        patient.FirstName = "Maqsud";
        await patientHandler.UpdatePatientAsync(patient);
        //await patientHandler.DeletePatientByIdAsync(1);
        //List<Patient> patients = await patientHandler.GetAllPatientsAsync();
        //foreach (Patient patient in patients)
        //{
        //    Console.WriteLine(patient.FirstName + " " + patient.PhoneNumber);
        //}
    }
}