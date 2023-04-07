using Domain.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbContext
    {

        public static string conString = File.ReadAllText(@"..\..\..\..\..\OnlineQueue\Infrastructure\AppConfig.txt");

        public void InitializeTables()
        {
            try
            {
                using NpgsqlConnection connection = new(conString);
                connection.Open();
                string query = @"  create table if not exists patient (
                    patient_id serial primary key,
                    first_name varchar(50),
                    last_name varchar(50),
                    phone_number varchar(50)
                  );
                create table if not exists category(
                    category_id serial primary key,
                    category_name varchar(100)
                  );
                  
                  create table if not exists physician(
                  physician_id serial primary key,
                  category_id int references category(category_id),
                  first_name varchar(50),
                  last_name varchar(50),
                  phone_number varchar(50),
                  experience_year float,
                  rating int
                  );
                  create table if not exists wait_list(
                    id serial primary key,
                    patient_id int references patient(patient_id) unique,
                    physician_id int references physician(physician_id) unique,
                    joined_time timestamp default now()
                  );
                  create table if not exists serving(
                    id serial primary key,
                    patient_id int references wait_list(patient_id) unique,
                    physician_id int references wait_list(physician_id) unique,
                    served_time interval
                  );
                  create table if not exists history_patients(
                    id serial primary key,
                    patient_id int references serving(patient_id),
                    physician_id int  references serving(physician_id),
                    last_visit timestamp default now() 
                  );
                               ";

                NpgsqlCommand command = new(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public void CreateDb()
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(conString);
                connection.Open();
                connection.Close();
            }
            catch (NpgsqlException e)
            {
                if (e.Message.Contains("does not exist", StringComparison.OrdinalIgnoreCase))
                {
                    string con = conString.Replace("onlinequeue", "postgres");
                    using NpgsqlConnection connection = new(con);
                    connection.Open();
                    string query = "create database onlinequeue";
                    NpgsqlCommand command = new(query, connection);
                    command.ExecuteNonQuery();
                    InitializeTables();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public Patient Patient { get; set; }
        public Physician Physician { get; set; }
        public Category Category { get; set; }
        public WaitList WaitList { get; set; }
        public Serving Serving { get; set; }

       
    }
}

