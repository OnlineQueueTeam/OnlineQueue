using Application.Handler.Interface;
using Application.Handlers;
using Application.Repository.Interfaces;
using Domain.Models;
using Domain.States;
using Infrastructure.Persistence;

namespace OnlineQueue
{
    class OnlineQueueUi
    {
        public static string first_name, last_name, phone_number;
        public static double experience_year;
        public static PhysicianManager physicianManager = new PhysicianManager();
        public static ICategoryRepository repository = new DbCategory();
        public static ICategoryHandler categoryHandler = new CategoryHandler(repository);
        public static async Task UI()
        {
        MenuCommand1:
            Console.WriteLine("1.Doctor \n2.User");
            int option1;
            int.TryParse(Console.ReadLine(), out option1);
            switch (option1)
            {
                case 1:
                    {
                        //login admin
                        Console.WriteLine("1.sign up\n2.Login");
                        int option2;
                        int.TryParse(Console.ReadLine(), out option2);
                        switch (option2)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Choose category");
                                    List<Category> categories = await categoryHandler.GetAllCategoriesAsync();
                                    for (int i = 1; i<= categories.Count; i++)
                                    {
                                        Console.WriteLine($"{i}.{categories[i-1].CategoryName}");
                                    }
                                    Category category = null;
                                    int option3;
                                    int.TryParse(Console.ReadLine(), out option3);
                                    switch (option3)
                                    {
                                        case 1:
                                            {
                                                category = await categoryHandler.GetByIdCategoryAsync(1);

                                                PhysicianRating rating = PhysicianRating.Caring;
                                                Console.WriteLine("Choose your Rating");
                                                Console.WriteLine("1.Competent\n2.Professional\n3.Compassionate\n4.Caring\n5.Knowledgeable\n6.Skilled");
                                                int option4;
                                                int.TryParse(Console.ReadLine(), out option4);
                                                switch (option4)
                                                {
                                                    case 1:
                                                        {
                                                            rating = PhysicianRating.Competent;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 2:
                                                        {
                                                            rating = PhysicianRating.Professional;
                                                            Console.WriteLine("Enter your Firstname");
                                                            string first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            string last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            string phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            double experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 3:
                                                        {
                                                            rating = PhysicianRating.Compassionate;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 4:
                                                        {
                                                            rating = PhysicianRating.Caring;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 5:
                                                        {
                                                            rating = PhysicianRating.Knowledgeable;
                                                            Console.WriteLine("Enter your Firstname");
                                                            string first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            string last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            string phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            double experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 6:
                                                        {
                                                            rating = PhysicianRating.Skilled;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    default:
                                                        {
                                                            Console.WriteLine("Invalid physician rating.");
                                                            break;
                                                        }
                                                }
                                                break;

                                            }
                                        case 2:
                                            {

                                                category = await categoryHandler.GetByIdCategoryAsync(2);
                                                PhysicianRating rating = PhysicianRating.Caring;
                                                Console.WriteLine("Choose your Rating");
                                                Console.WriteLine("1.Competent\n2.Professional\n3.Compassionate\n4.Caring\n5.Knowledgeable\n6.Skilled");
                                                int option4;
                                                int.TryParse(Console.ReadLine(), out option4);
                                                switch (option4)
                                                {
                                                    case 1:
                                                        {
                                                            rating = PhysicianRating.Competent;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 2:
                                                        {
                                                            rating = PhysicianRating.Professional;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            Console.WriteLine("Enter your Experience year");
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 3:
                                                        {
                                                            rating = PhysicianRating.Compassionate;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 4:
                                                        {
                                                            rating = PhysicianRating.Caring;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 5:
                                                        {
                                                            rating = PhysicianRating.Knowledgeable;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 6:
                                                        {
                                                            rating = PhysicianRating.Skilled;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    default:
                                                        {
                                                            Console.WriteLine("Invalid physician rating.");
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                category = await categoryHandler.GetByIdCategoryAsync(2);
                                                PhysicianRating rating = PhysicianRating.Caring;
                                                Console.WriteLine("Choose your Rating");
                                                Console.WriteLine("1.Competent\n2.Professional\n3.Compassionate\n4.Caring\n5.Knowledgeable\n6.Skilled");
                                                int option4;
                                                int.TryParse(Console.ReadLine(), out option4);
                                                switch (option4)
                                                {
                                                    case 1:
                                                        {
                                                            rating = PhysicianRating.Competent;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 2:
                                                        {
                                                            rating = PhysicianRating.Professional;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 3:
                                                        {
                                                            rating = PhysicianRating.Compassionate;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 4:
                                                        {
                                                            rating = PhysicianRating.Caring;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 5:
                                                        {
                                                            rating = PhysicianRating.Knowledgeable;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    case 6:
                                                        {
                                                            rating = PhysicianRating.Skilled;
                                                            Console.WriteLine("Enter your Firstname");
                                                            first_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your Lastname");
                                                            last_name = Console.ReadLine();
                                                            Console.WriteLine("Enter your phonenumber");
                                                            phone_number = Console.ReadLine();
                                                            Console.WriteLine("Enter your Experience year");
                                                            experience_year = double.Parse(Console.ReadLine());
                                                            physicianManager.Signup(first_name, last_name, phone_number, category, experience_year, rating); break;
                                                        }
                                                    default:
                                                        {
                                                            Console.WriteLine("Invalid physician rating.");
                                                            break;
                                                        }

                                                }
                                                break;
                                            }
                                    }
                                    break;

                                }
                            case 2:
                                {
                                    IPhysicianRepository repository2 = new DbPhysician();
                                    IPhysicianHandler physicianHandler = new PhysicianHandler(repository2);
                                    Console.WriteLine("Enter your FirstName");
                                    string first_name = Console.ReadLine();
                                    Console.WriteLine("Enter your LastName");
                                    string last_name = Console.ReadLine();
                                    Console.WriteLine("Enter your phone number");
                                    string phone_number = Console.ReadLine();
                                    List<Physician> physicians = await physicianHandler.GetAllPhysiciansAsync();
                                    Physician physician = physicians.FirstOrDefault(p => p.PhoneNumber== phone_number);
                                    physicianManager.Login(first_name, last_name, phone_number).Wait();
                                    Console.WriteLine("1.Sizga tegishli bemorlar ro'yaxti");
                                    Console.WriteLine("2.Muolajani boshlash");
                                    Console.WriteLine("3.Muolajani Tugatish");
                                    int doctorSection;
                                    int.TryParse(Console.ReadLine(), out doctorSection);
                                    IWaitListRepository repository = new DbWaitListRepo();
                                    IWaitListHandler waitListHandler = new WaitListHandler(repository);
                                    IServingStatementRepository repository1 = new DbServingStatement();
                                    IServingStatementHandler statementHandler = new ServingStatementHandler(repository1);
                                    List<WaitList> waitlists = await waitListHandler.GetAllWaitListsAsync();
                                    List<ServingStatement> statements = await statementHandler.GetAllServingStatementAsync();
                                    List<Patient> patients = waitlists.Where(a => a.Physician.PhoneNumber == phone_number)
                                        .OrderBy(a => a.JoinedTime)
                                        .Select(a => a.Patient).ToList();
                                    List<Patient> patientsInServing = statements.Where(s=> s.Physician.PhoneNumber==phone_number)
                                        .OrderBy(s=> s.StartTime)
                                        .Select(s=>s.Patient).ToList();
                                    switch (doctorSection)
                                    {
                                        case 1:
                                            {
                                                foreach (Patient pat in patients)
                                                {
                                                    Console.WriteLine(pat);
                                                }
                                                break;
                                            }
                                        case 2:
                                            {

                                                Console.WriteLine("Bemoringiz..");
                                                Patient patientpat = patients.FirstOrDefault();
                                                await statementHandler.InsertServingStatementAsync(new() { Patient = patientpat, Physician = physician, StartTime = DateTime.Now });
                                                Console.WriteLine(patientpat);
                                                await waitListHandler.DeleteWaitListByIdAsync(patientpat.PatientId);
                                                break;

                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Muolaja qaysi bemor bilan tugaganini tanlang?");
                                                foreach(Patient pat in patientsInServing)
                                                {
                                                    Console.WriteLine(pat);
                                                }
                                                int EndPatient = int.Parse(Console.ReadLine());
                                                IPatientRepository repository5 = new DbPatient();
                                                IPatientHandler patientHandler = new PatientHandler(repository5);
                                                Patient patient = await patientHandler.GetByIdPatientAsync(EndPatient);
                                                int id = statements.Where(s=>s.Patient.PatientId == EndPatient)
                                                    .Select(s=>(int)s.Id).FirstOrDefault();
                                                ServingStatement servingStatement = await statementHandler.GetByIdServingStatementAsync(id);
                                                 servingStatement.EndTime = DateTime.Now;
                                                await statementHandler.UpdateServingStatementAsync(servingStatement);
                                                
                                                break;

                                            }
                                    }



                                    break;
                                }
                        }

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("1.Navbat olish\n2.Tekshirish");
                        int option5;
                        int.TryParse(Console.ReadLine(), out option5);
                        Console.Clear();
                        switch (option5)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Enter your first name");
                                    first_name = Console.ReadLine();
                                    Console.WriteLine("Enter your lastname");
                                    last_name = Console.ReadLine();
                                    Console.WriteLine("Enter your Phone Number");
                                    phone_number = Console.ReadLine();
                                    Patient patient = new() { FirstName = first_name, LastName = last_name, PhoneNumber = phone_number };
                                    Console.Clear();
                                    IPatientRepository repository = new DbPatient();
                                    IPatientHandler patientHandler = new PatientHandler(repository);
                                    patientHandler.InsertPatientAsync(patient).Wait();
                                    Console.WriteLine("Choose category");
                                    ICategoryRepository repository1 = new DbCategory();
                                    ICategoryHandler categoryHandler = new CategoryHandler(repository1);
                                    List<Category> categories = await categoryHandler.GetAllCategoriesAsync();
                                    int a;
                                    foreach (var category in categories)
                                    {
                                        Console.WriteLine($"{category.CategoryId}. {category.CategoryName}");
                                    }
                                    int.TryParse(Console.ReadLine(), out a);
                                    switch (a)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Choose Doctors");
                                                IPhysicianRepository repository3 = new DbPhysician();
                                                IPhysicianHandler physicianHandler = new PhysicianHandler(repository3);
                                                List<Physician> physicians = await physicianHandler.GetAllPhysiciansAsync();
                                                List<Physician> doctors = physicians.FindAll(x => x.Category.CategoryId == a);
                                                foreach (var doctor in doctors)
                                                {
                                                    Console.WriteLine($"{doctor.Id}. {doctor.FirstName} {doctor.LastName}");
                                                }
                                                int a1;
                                                int.TryParse(Console.ReadLine(), out a1);
                                                IWaitListRepository repository7 = new DbWaitListRepo();
                                                IWaitListHandler waitListHandler = new WaitListHandler(repository7);
                                                List<Patient> User = await patientHandler.GetAllPatientsAsync();
                                                Patient patient1 = User.FirstOrDefault(x => x.PhoneNumber == phone_number);
                                                WaitList waitList = new WaitList() { Patient = patient1, Physician = await physicianHandler.GetByIdPhysicianAsync(a1), JoinedTime= DateTime.Now };
                                                await waitListHandler.InsertWaitListAsync(waitList);


                                                break;

                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Choose Doctors");
                                                IPhysicianRepository repository3 = new DbPhysician();
                                                IPhysicianHandler physicianHandler = new PhysicianHandler(repository3);
                                                List<Physician> physicians = await physicianHandler.GetAllPhysiciansAsync();
                                                List<Physician> doctors = physicians.FindAll(x => x.Category.CategoryId == a);
                                                int j;
                                                foreach (var doctor in doctors)
                                                {
                                                    Console.WriteLine($"{doctor.Id}. {doctor.FirstName} {doctor.LastName}");
                                                }
                                                int a1;
                                                int.TryParse(Console.ReadLine(), out a1);
                                                IWaitListRepository repository7 = new DbWaitListRepo();
                                                IWaitListHandler waitListHandler = new WaitListHandler(repository7);
                                                List<Patient> User = await patientHandler.GetAllPatientsAsync();
                                                Patient patient1 = User.FirstOrDefault(x => x.PhoneNumber == phone_number);
                                                WaitList waitList = new WaitList() { Patient = patient1, Physician = await physicianHandler.GetByIdPhysicianAsync(a1), JoinedTime= DateTime.Now };
                                                await waitListHandler.InsertWaitListAsync(waitList);

                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("<<<WaitList>>>");
                                    IWaitListRepository repository6 = new DbWaitListRepo();
                                    IWaitListHandler waitListHandler = new WaitListHandler(repository6);
                                    List<WaitList> waitLists = await waitListHandler.GetAllWaitListsAsync();
                                    int i = 1;
                                    foreach (WaitList waitList in waitLists)
                                    {
                                        Console.WriteLine($"{i++}.Patient:{waitList.Patient.FirstName} {waitList.Patient.LastName} Doctor:{waitList.Physician.FirstName} {waitList.Physician.LastName} JoinedTime:{waitList.JoinedTime}");
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    goto MenuCommand1;
            }
        }
    }
}
