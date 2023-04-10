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
                                  DO $$
                                    BEGIN
                                      IF NOT EXISTS (
                                        SELECT 1 FROM pg_type WHERE typname = 'rating'
                                      ) THEN
                                        CREATE TYPE rating AS ENUM ('Competent','Professional','Compassionate','Caring','Knowledgeable','Skilled');
                                      END IF;
                                    END$$;


                     create table if not exists patient (
                    patient_id serial primary key,
                    first_name varchar(50),
                    last_name varchar(50),
                    phone_number varchar(50)
                  );
                  CREATE TYPE rating_hospital AS ENUM (
                   'Competent',
                   'Professional',
                   'Compassionate',
                   'Caring',
                   'Knowledgeable',
                   'Skilled'
                   );

                create table if not exists category (
                    category_id serial primary key,
                    category_name varchar(100)
                  );
                  create table if not exists hospital (
                    hospital_id serial primary key,
                    name varchar(100),
                    rating rating_hospital
                    );
                  
                  create table if not exists physician (
                  physician_id serial primary key,
                  category_id int references category(category_id),
                  first_name varchar(50),
                  last_name varchar(50),
                  phone_number varchar(50),
                  experience_year float,
                  rating rating 
                  );
                    create table if not exists hospital_physician (
                    id serial primary key,
                    hospital_id int references hospital(hospital_id),
                    physician_id int references physician(physician_id)
                    );
                  create table if not exists wait_list (
                    id serial primary key,
                    patient_id int references patient(patient_id) unique ,
                    physician_id int references physician(physician_id) unique,
                    joined_time timestamp default now()
                  );
                  create table if not exists serving_statement (
                    id serial primary key,
                    patient_id int references wait_list(patient_id),
                    physician_id int references wait_list(physician_id),
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

