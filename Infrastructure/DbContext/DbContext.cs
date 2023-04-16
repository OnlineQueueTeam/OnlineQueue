using Domain.Models;
using Infrastructure.Connection;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class DbContext
    {

        public static string? conString = GetConnection.Connection();

        public void InitializeTables()
        {

            using NpgsqlConnection connection = new(conString);
            connection.Open();

            string query = @"  
                     create table if not exists patient (
                    patient_id serial primary key,
                    first_name varchar(50),
                    last_name varchar(50),
                    phone_number varchar(50)
                  );

                create table if not exists category (
                    category_id serial primary key,
                    category_name varchar(100)
                  );
                  create table if not exists hospital (
                    hospital_id serial primary key,
                    name varchar(100),
                    rating varchar(50)
                    );
                 create table contact_info
                 (
                 id serial primary key,
                 hospital_id int references hospital(hospital_id),
	             address varchar(250),
	             location varchar(250),
	             phone_number varchar(250),
	             social_media varchar(250)
                  );
                  
                  create table if not exists physician (
                  physician_id serial primary key,
                  category_id int references category(category_id),
                  first_name varchar(50),
                  last_name varchar(50),
                  phone_number varchar(50),
                  experience_year float,
                  rating varchar(50)
                  );
                    create table if not exists hospital_physician (
                    id serial primary key,
                    hospital_id int references hospital(hospital_id),
                    physician_id int references physician(physician_id)
                    );
                  create table if not exists wait_list (
                    id serial primary key,
                    patient_id int references patient(patient_id) ,
                    physician_id int references physician(physician_id),
                    joined_time timestamp default now()
                  );
                  create table if not exists serving_statement (
                    id serial primary key,
                    patient_id int references patient(patient_id),
                    physician_id int references physician(physician_id),
                    start_time timestamp default now(),
                    end_time timestamp 
                  )";

            NpgsqlCommand command = new(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void CreateDb()
        {

            NpgsqlConnection connection = new NpgsqlConnection(conString.Replace(GetConnection.DatabaseName(), "postgres"));
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = $"create database {GetConnection.DatabaseName()}";
            cmd.Connection= connection;
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public Patient? Patient { get; set; }
        public Physician? Physician { get; set; }
        public Category? Category { get; set; }
        public WaitList? WaitList { get; set; }
        public ServingStatement? Serving { get; set; }


    }
}

