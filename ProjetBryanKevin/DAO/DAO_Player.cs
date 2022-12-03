using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;


namespace ProjetBryanKevin.DAO
{
    class DAO_Player : DAO<Player>
    {

        public DAO_Player()
        {

        }
        public override bool Create(Player player)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Users(pseudo,registrationDate,dateOfBirth, IdUser) VALUES (@pseudo,@registrationDate,@dateOfBirth,@idUser)", connection);
                    cmd.Parameters.AddWithValue("pseudo", player.Pseudo);
                    cmd.Parameters.AddWithValue("registrationDate", player.RegistrationDate);
                    cmd.Parameters.AddWithValue("dateOfBirth", player.DateOfBirth);
                    cmd.Parameters.AddWithValue("IdUser", player.Id);
    

                    connection.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public override bool Delete(Player obj)
        {
            return false;
        }

        public override List<Player> DisplayAll()
        {
            List<Player> players = new List<Player>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Users", connection);
                    
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                           Player player = new Player(
                                reader.GetInt32("idPlayer"),
                                reader.GetString("userName"),
                                reader.GetString("password"),
                                reader.GetInt32("credit"),
                                reader.GetString("pseudo"),
                                reader.GetDateTime("registrationDate"),
                                reader.GetDateTime("dateOfBirth")
                               
                                );
                            players.Add(player);
                        }
                    }
                }
            }
            catch (SqlException e)
            {

                throw new Exception("Une erreur sql est survenue !");
            }

            return players;
        }


        public override Player Find(int id)
        {
            Player player = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Users WHERE idPlayer = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()){

                            player = new Player(
                                reader.GetInt32("idPlayer"),
                                reader.GetString("userName"),
                                reader.GetString("password"),
                                reader.GetInt32("credit"),
                                reader.GetString("pseudo"),
                                reader.GetDateTime("registrationDate"),
                                reader.GetDateTime("dateOfBirth")
                                );
                        }
                    }
                }
            }
            catch (SqlException e)
            {

                throw new Exception("Une erreur sql est survenue !");
            }

            return player;
        }

        public override bool Update(Player obj)
        {
            return false;
        }

        public override Player VerificationConnection(string pseudo, string password)
        {

            Player player = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Users WHERE pseudo = @pseudo AND password = @password", connection);
                    cmd.Parameters.AddWithValue("pseudo", pseudo);
                    cmd.Parameters.AddWithValue("password", password);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            player = new Player
                            (
                                reader.GetInt32("idPlayer"),
                                reader.GetString("username"),
                                reader.GetString("password"),
                                reader.GetInt32("credit"),
                                reader.GetString("pseudo"),
                                reader.GetDateTime("registrationDate"),
                                reader.GetDateTime("dateOfBirth")
                            );
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new Exception("Une erreur SQL est survenue !");
            }

            return player;
        }
    }
}
