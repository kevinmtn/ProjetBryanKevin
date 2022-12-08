using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProjetBryanKevin.DAO
{
    class DAO_Copy : DAO<Copy>
    {
        DAO_VideoGame DAO_VideoGame = new DAO_VideoGame();
        DAO_Player DAO_Player = new DAO_Player();
        public DAO_Copy()
        {

        }
        public override bool Create(Copy copy)
        {
            bool success= false;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Copy(idVideoGame, idPlayer) VALUES (@idVideoGame, @idPlayer)", connection);
                    cmd.Parameters.AddWithValue("idVideoGame", copy.VideoGame.IdVideoGame);
                    cmd.Parameters.AddWithValue("idPlayer", copy.Player.Id);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    success = result > 0;
                }
                return success;

            }catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public override bool Delete(Copy copy)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Copy WHERE idCopy = @idCopy", connection);
                    connection.Open();
                    int rowsAfffected = cmd.ExecuteNonQuery();
                    return rowsAfffected > 0;
                }
            }
            catch(SqlException e) {
                throw new Exception(e.Message);
            }
        }

        public override List<Copy> DisplayAll()
        {
            List<Copy> copyList = new List<Copy>();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Copy");
                    connection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {
                            Copy temporaryCopy = new Copy(
                                reader.GetInt32("idCopy"),
                                DAO_VideoGame.Find(reader.GetInt32("idVideoGame")),
                                DAO_Player.Find(reader.GetInt32("idPlayer")));
                            copyList.Add(temporaryCopy);
                        }
                    }
                    
                }
            }
            catch(SqlException e) { throw new Exception(e.Message); }
            return copyList;
        }

        public override Copy Find(int id)
        {
            Copy copy = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Copy WHERE idCopy = @idCopy");
                    command.Parameters.AddWithValue("idCopy", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            copy = new Copy(
                                reader.GetInt32("idCopy"),
                                DAO_VideoGame.Find(reader.GetInt32("idVideoGame")),
                                DAO_Player.Find(reader.GetInt32("idPlay")));
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            return copy;
        }



        public override bool Update(Copy copy)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE dbo.Copy SET idVideoGame = @idVideoGame, idPlayer = @idPlayer WHERE idCopy = @idCopy");
                    command.Parameters.AddWithValue("idCopy", copy.IdCopy);
                    command.Parameters.AddWithValue("idVideoGame", copy.VideoGame.IdVideoGame);
                    command.Parameters.AddWithValue("idPlayer", copy.Player.Id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            } catch (SqlException e) { throw new Exception(e.Message); }
        }
    }
}
