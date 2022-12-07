using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Diagnostics;

namespace ProjetBryanKevin.DAO
{
    class DAO_Player : DAO_User<Player>
    {

        public DAO_Player()
        {

        }
        public override bool Create(Player player)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Player(pseudo,registrationDate,dateOfBirth, IdUser) VALUES (@pseudo,@registrationDate,@dateOfBirth,@idUser)", connection);
                    cmd.Parameters.AddWithValue("pseudo", player.Pseudo);
                    cmd.Parameters.AddWithValue("registrationDate", player.RegistrationDate);
                    cmd.Parameters.AddWithValue("dateOfBirth", player.DateOfBirth);
                    cmd.Parameters.AddWithValue("IdUser", player.Id);
    

                    connection.Open();

                    int result = cmd.ExecuteNonQuery();
                    success = result > 0;
                }

                return success;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Player", connection);
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Player WHERE idPlayer = @id", connection);
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

                throw new Exception("Une erreur sql est survenue !\n" + e.Message);
            }
            return player;
        }

        public override bool Update(Player updatedPlayer)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE dbo.Player SET pseudo = @pseudo, username = @username, password = @password," +
                        " registrationDate = @registrationDate, dateOfBirth = @dateOfBirth, credit = @credit WHERE idPlayer = @idPlayer");
                    command.Parameters.AddWithValue("idPlayer", updatedPlayer.Id);
                    command.Parameters.AddWithValue("pseudo", updatedPlayer.Pseudo);
                    command.Parameters.AddWithValue("username", updatedPlayer.UserName);
                    command.Parameters.AddWithValue("password", updatedPlayer.Password);
                    command.Parameters.AddWithValue("registrationDate", updatedPlayer.RegistrationDate);
                    command.Parameters.AddWithValue("dateOfBirth", updatedPlayer.DateOfBirth);
                    command.Parameters.AddWithValue("credit", updatedPlayer.Credit);
                    connection.Open();
                    bool isUpdated = command.ExecuteNonQuery() > 0 ? true : false ;
                    return isUpdated;
                }
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public override Player VerificationConnection(string pseudo, string password)
        {

            Player player = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Player WHERE pseudo = @pseudo AND password = @password", connection);
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
            catch (SqlException e)
            {
                throw new Exception("Une erreur SQL est survenue !\n" + e.Message);
            }

            return player;
        }
    }
}
