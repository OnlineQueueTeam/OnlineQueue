using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQueue.QueueUI
{
    public  class Presentation
    {
       public static void UI()
        {
            MenuCommand1:
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.User");
            int option1;
            int.TryParse(Console.ReadLine(), out option1);
            Console.Clear();


            switch(option1)
            {
                case 1:
                    {
                        Console.WriteLine("1.Administrator");
                        Console.WriteLine("2.Doctor");
                        int option2;
                        int.TryParse(Console.ReadLine(), out option2);
                        Console.Clear();

                        switch (option2)
                        {
                            case 1:
                                {
                                    Administrator();
                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine("**Patients List**");

                                    // Here is patients from waitlist
                                    //Doctor receive them one by one
                                    break;
                                }
                        }

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("1. Line in queue");
                        Console.WriteLine("2. Check queue");
                        int option5;
                        int.TryParse(Console.ReadLine(),out option5);

                        switch (option5)
                        {
                            case 1:
                                {
                                    //Adding user to waitlist 
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Enter your registered phone number: ");
                                    string? phone=Console.ReadLine();
                                    Console.Clear();

                                    //Showing names of patients from waitlist for his doctor  according to user phone number
                                     
                                    break;
                                }
                        }                        

                        
                        break;
                    }
                default: goto MenuCommand1;
            }

        }

        static void Administrator()
        {
            MenuCommand2:
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Categories");
            Console.WriteLine("3. Patients");
            Console.WriteLine("4. HospitalInfo");
            int option3;
            int.TryParse(Console.ReadLine(),out option3);
            Console.Clear();

            switch (option3)
            {
                case 1:
                    {
                        
                        Console.WriteLine("****CRUD on Physicians****");
                        Console.WriteLine("1. INSERT");
                        Console.WriteLine("2. READ");
                        Console.WriteLine("3. DELETE");
                        Console.WriteLine("4. UPDATE");
                        int option4;
                        int.TryParse(Console.ReadLine(),out option4);
                        Console.Clear();

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("****CRUD on Category****");
                        Console.WriteLine("1. INSERT");
                        Console.WriteLine("2. READ");
                        Console.WriteLine("3. DELETE");
                        Console.WriteLine("4. UPDATE");
                        int option4;
                        int.TryParse(Console.ReadLine(), out option4);
                        Console.Clear();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("****CRUD on Patients****");
                        Console.WriteLine("1. INSERT");
                        Console.WriteLine("2. READ");
                        Console.WriteLine("3. DELETE");
                        Console.WriteLine("4. UPDATE");
                        int option4;
                        int.TryParse(Console.ReadLine(), out option4);
                        Console.Clear();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("****CRUD on ContactInfo****");
                        Console.WriteLine("1. INSERT");
                        Console.WriteLine("2. READ");
                        Console.WriteLine("3. DELETE");
                        Console.WriteLine("4. UPDATE");
                        int option4;
                        int.TryParse(Console.ReadLine(), out option4);
                        Console.Clear();
                        break;
                    }
                default: goto MenuCommand2;
            }
           
            
           

        }
    }
}
