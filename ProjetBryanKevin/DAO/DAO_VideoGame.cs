using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.DAO
{
    class DAO_VideoGame : DAO<VideoGame>
    {
        public DAO_VideoGame()
        {

        }
        public override bool Create(VideoGame videoGame)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.VideoGame(name,creditCost,console) VALUES (@name,@creditCost,@console)", connection);
                    cmd.Parameters.AddWithValue("name", videoGame.Name);
                    cmd.Parameters.AddWithValue("creditCost", videoGame.CreditCost);
                    cmd.Parameters.AddWithValue("dateOfBirth", videoGame.Console);
                    
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

   

        public override bool Delete(VideoGame obj)
        {
            throw new NotImplementedException();
        }


        public override List<VideoGame> DisplayAll()
        {
            List<VideoGame> videoGames = new List<VideoGame>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGame", connection);

                    connection.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VideoGame videoGame = new VideoGame
                                (
                                 reader.GetInt32("idVideoGame"),
                                 reader.GetString("name"),
                                 reader.GetInt32("creditCost"),
                                 reader.GetString("console")
                                 );
                            videoGames.Add(videoGame);
                        }

                    }
                }
            }
            catch (SqlException e)
            {

                throw new Exception("Une erreur sql est survenue !");
            }

            return videoGames;
        }


        public override VideoGame Find(int id)
        {
            VideoGame videoGame = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGame WHERE idVideoGame=@id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                             videoGame = new VideoGame
                                (
                                 reader.GetInt32("idVideoGame"),
                                 reader.GetString("name"),
                                 reader.GetInt32("creditCost"),
                                 reader.GetString("console")
                                 );   
                        }
                    }
                }
            }
            catch (SqlException e)
            {

                throw new Exception("Une erreur sql est survenue !");
            }

            return videoGame;
        }

        public override bool Update(VideoGame obj)
        {
            throw new NotImplementedException();
        }
    }
}
