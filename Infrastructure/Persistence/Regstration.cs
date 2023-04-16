using Application.Handler.Interface;
using Application.Handlers;
using Application.Repository.Interfaces;
using Domain.Models;
using Domain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class PhysicianManager
    {

        // Physician Sign up method
        public async void Signup(string first_name, string last_name, string phone_number, Category category, double experience_year, PhysicianRating rating)
        {
            Physician newPhysician = new Physician() { FirstName = first_name, PhoneNumber = phone_number, Category = category, LastName = last_name, ExperienceYear = experience_year, Rating = rating};
            IPhysicianRepository repository = new DbPhysician();
            IPhysicianHandler physicianHandler = new PhysicianHandler(repository);
            await physicianHandler.InsertPhysicianAsync(newPhysician);
            Console.WriteLine("Physician successfully signed up.");
        }

        // Physician Login method
        public async Task<bool> Login(string first_name, string last_name,string phone_number)
        {
            IPhysicianRepository repository = new DbPhysician();
            IPhysicianHandler physicianHandler = new PhysicianHandler(repository);
            List<Physician> physicians = await physicianHandler.GetAllPhysiciansAsync();
            Physician physician = physicians.Find(x => x.FirstName == first_name && x.LastName == last_name && x.PhoneNumber == phone_number);
            if(physician != null)
            {
                Console.WriteLine("Successfully Logged in");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or phonenumber.");
                return false;
            }
        }
    }
}
