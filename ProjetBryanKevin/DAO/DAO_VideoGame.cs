using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ProjetBryanKevin.DAO
{
    class DAO_VideoGame : DAO<VideoGame>
    {
        public DAO_VideoGame()
        {

        }
        public override VideoGame Create(VideoGame videoGame)
        {
            bool success;
            VideoGame newVideoGame = null; 
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO dbo.VideoGame(name,creditCost,console) VALUES (@name,@creditCost,@console)", connection);
                    insertCmd.Parameters.AddWithValue("name", videoGame.Name);
                    insertCmd.Parameters.AddWithValue("creditCost", videoGame.CreditCost);
                    insertCmd.Parameters.AddWithValue("console", videoGame.Console);
                    connection.Open();
                    int result = insertCmd.ExecuteNonQuery();
                    success = result > 0;
                    connection.Close();
                    if (success)
                    {
                        SqlCommand queryCmd = new SqlCommand("SELECT * FROM dbo.VideoGame WHERE name = @name AND console = @console", connection);
                        queryCmd.Parameters.AddWithValue("name", videoGame.Name);
                        queryCmd.Parameters.AddWithValue("console", videoGame.Console);
                        connection.Open();
                        using (SqlDataReader reader = queryCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                newVideoGame = new VideoGame(
                                    reader.GetInt32("idVideoGame"),
                                    reader.GetString("name"),
                                    reader.GetInt32("creditCost"),
                                    reader.GetString("console"));
                            }
                        }
                    }
                    return newVideoGame;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public override bool Delete(VideoGame videoGame)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.VideoGame WHERE idVideoGame=@id", connection);
                    cmd.Parameters.AddWithValue("id", videoGame.IdVideoGame);

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
                throw new Exception(e.Message);
            }
        }

        public override List<VideoGame> FindAll()
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
                            VideoGame vg = new VideoGame(
                                reader.GetInt32("idVideoGame"),
                                reader.GetString("name"),
                                reader.GetInt32("creditCost"),
                                reader.GetString("console")
                                );
                            videoGames.Add(vg);
                        }

                    }
                }
            }
            catch (SqlException e)
            {

                throw new Exception("Une erreur sql est survenue !\n" + e.Message );
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGame WHERE idVideoGame = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    { 
                        while (reader.Read())
                        {
                            videoGame = new VideoGame(
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
                throw new Exception("Une erreur sql est survenue !\n" + e.Message);
            }
            return videoGame;
        }

        public override bool Update(VideoGame updatedVideoGame)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE dbo.VideoGame " +
                        "SET name = @name, creditCost = @creditCost, console = @console " +
                        "WHERE idVideoGame = @idVideoGame", connection);
                    command.Parameters.AddWithValue("idVideoGame", updatedVideoGame.IdVideoGame);
                    command.Parameters.AddWithValue("name", updatedVideoGame.Name);
                    command.Parameters.AddWithValue("creditCost", updatedVideoGame.CreditCost);
                    command.Parameters.AddWithValue("console", updatedVideoGame.Console);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    bool isUpdated = rowsAffected > 0 ? true : false;
                    return isUpdated;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }


        internal int CheckDuplicate(VideoGame videoGame)
        {
        try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.VideoGame WHERE name = @name AND console = @console", connection);
                    command.Parameters.AddWithValue("name", videoGame.Name);
                    command.Parameters.AddWithValue("console", videoGame.Console);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return reader.GetInt32("creditCost") != 0 ? 2 : 1;
                        }
                        return 0;
                    }
                }
            }
            catch(SqlException e) 
            { 
                throw new Exception(e.Message); 
            }   
        }
        
        public VideoGame FindVideoGameById(int idVideoGame)
        {
            VideoGame videoGame = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.VideoGame WHERE idVideoGame = @idVideoGame", connection);
                    command.Parameters.AddWithValue("idVideoGame", idVideoGame);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                             videoGame = new VideoGame(
                               reader.GetInt32("idVideoGame"),
                                reader.GetString("name"),
                                reader.GetInt32("creditCost"),
                                reader.GetString("console")
                                );
                            
                        }
                    }
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return videoGame;
        }

        internal object FindCopyAvailable(VideoGame videoGame)
        {
            DAO_Player dao_player = new DAO_Player();
            Copy copyAvailable = null;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.VideoGame vg JOIN dbo.Copy cp ON vg.idVideoGame = cp.idVideoGame JOIN dbo.Loan l ON cp.idCopy = l.idCopy WHERE vg.idVideoGame = @idVideoGame AND l.ongoing = 0", connection);
                    command.Parameters.AddWithValue("idVideoGame", videoGame.IdVideoGame);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            copyAvailable = new Copy(
                                this.FindVideoGameById(reader.GetInt32("idVideoGame")),
                                dao_player.Find(reader.GetInt32("idPlayer"))
                                );
                        }
                    }
                }
                return copyAvailable;
            }
            catch(SqlException e) { throw new Exception(e.Message + Environment.NewLine + e.StackTrace); }
        }

        internal Booking FindBookingByUserId(VideoGame videoGame, int idPlayer)
        {
            DAO_Player dao_player = new DAO_Player();
            Booking booking = null;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.VideoGame vg JOIN dbo.Booking bk ON vg.idVideoGame = bk.idVideoGame WHERE vg.idVideoGame = @idVideoGame AND bk.idPlayer = @idPlayer", connection);
                    command.Parameters.AddWithValue("idVideoGame", videoGame.IdVideoGame);
                    command.Parameters.AddWithValue("idPlayer", idPlayer);
                    connection.Open() ;
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            booking = new Booking(
                                dao_player.Find(reader.GetInt32("idPlayer")),
                                this.Find(reader.GetInt32("idVideoGame")),
                                reader.GetDateTime("bookingDate")
                                );
                            Debug.Print(booking.VideoGame.Name);
                        }
                    }
                }
                return booking;
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message+Environment.NewLine + e.StackTrace);
            }
        }

        internal List<VideoGame> FindLoanedVideoGames( int idPlayer)
        {
            try
            {
                List<VideoGame> loanedGames = new List<VideoGame>();
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.VideoGame vg " +
                        "JOIN dbo.Copy c ON vg.idVideoGame = c.idVideoGame " +
                        "JOIN dbo.Loan l ON c.idCopy = l.idCopy " +
                        "WHERE l.ongoing = 1 " +
                        "AND l.idBorrower <> @idPlayer", connection);
                    command.Parameters.AddWithValue("idPlayer", idPlayer);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VideoGame tmpVideoGame = new VideoGame(
                                reader.GetInt32("idVideoGame"),
                                reader.GetString("name"),
                                reader.GetInt32("creditCost"),
                                reader.GetString("console")
                                );
                            loanedGames.Add(tmpVideoGame);
                        }
                    }

                }
                return loanedGames;
            }
            catch(SqlException e) { throw new Exception(e.Message); }
        }
    }
}