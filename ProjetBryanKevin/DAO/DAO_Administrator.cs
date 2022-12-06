﻿using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;

namespace ProjetBryanKevin.DAO
{
    class DAO_Administrator : DAO<Administrator>
    {
        public DAO_Administrator() { }

        public override bool Create (Administrator admin)
        {
            return false;
        }

        public override bool Delete (Administrator admin)
        {
            return false;
        }

        public override List<Administrator> DisplayAll()
        {
            List<Administrator> administrators = new List<Administrator>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Administrator");
                  
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Administrator administrator = new Administrator(
                                 reader.GetInt32("idAdministrator"),
                                reader.GetString("username"),
                                reader.GetString("password")
                                );
                        }
                    }
                }
            }
            catch (SqlException e)
            {

                throw new Exception("Une erreur sql est survenue !");
            }

            return administrators;
        }

        public override List<Administrator> DisplayForAPlayer(Player play)
        {
            throw new NotImplementedException();
        }

        public override Administrator Find(int id)
        {
            Administrator administrator = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Administrator WHERE idAdministrator = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            administrator = new Administrator(
                                reader.GetInt32("idAdministrator"),
                                reader.GetString("username"),
                                reader.GetString("password")
                                );
                        }
                    }
                }
            }
            catch (SqlException e)
            {

                throw new Exception("Une erreur sql est survenue !");
            }

            return administrator;
        }


        public override bool Update(Administrator admin)
        {
            return false;
        }

        public override Administrator VerificationConnection(string username, string password)
        {
            Administrator administrator = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Administrator WHERE username = @username AND password = @password", connection);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            administrator = new Administrator
                            (
                                reader.GetInt32("idAdministrator"),
                                reader.GetString("username"),
                                reader.GetString("password")
                                
                            );
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new Exception("Une erreur SQL est survenue !");
            }

            return administrator;
        }
    }
}
