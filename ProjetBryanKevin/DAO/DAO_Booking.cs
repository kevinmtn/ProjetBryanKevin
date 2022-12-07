using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjetBryanKevin.DAO
{

    class DAO_Booking : DAO<Booking>
    {
        DAO_Player DAO_Player = new DAO_Player();
        DAO_VideoGame DAO_VideoGame = new DAO_VideoGame();
        public DAO_Booking() { }

        public override bool Create(Booking book)
        {
            bool success = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Booking(idPlayer, idVideoGame, bookingDate) VALUES (@idPlayer, @idVideoGame,@bookingDate)", connection);
                    cmd.Parameters.AddWithValue("idPlayer", book.Booker.Id);
                    cmd.Parameters.AddWithValue("idVideoGame", book.VideoGame.IdVideoGame);
                    cmd.Parameters.AddWithValue("bookingDate", book.BookingDate);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    success = result > 0;
                }
                return success;
            }
            catch (SqlException e)
            {
                throw new Exception( e.Message);
            }
        }

        public bool DeleteBooking(int idPlayer, int idVideoGame)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Booking WHERE idPlayer = @idPlayer AND idVideoGame = @idVideoGame", connection);
                    cmd.Parameters.AddWithValue("idPlayer", idPlayer);
                    cmd.Parameters.AddWithValue("idVideoGame", idVideoGame);
                    connection.Open();

                    bool isDeleted = cmd.ExecuteNonQuery() > 0 ? true : false;

                    return isDeleted;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public override bool Delete(Booking booking)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Booking WHERE idBooking=@id", connection);
                    cmd.Parameters.AddWithValue("id", booking.IdBooking);

                    connection.Open();

                    bool isDeleted = cmd.ExecuteNonQuery() > 0 ? true : false;

                    return isDeleted;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public override List<Booking> DisplayAll()
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Booking", connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking temporaryBooking = new Booking(
                                DAO_Player.Find(reader.GetInt32("idPlayer")),
                                DAO_VideoGame.Find(reader.GetInt32("idVideoGame")),
                                reader.GetDateTime("bookingDate")
                                );
                            bookings.Add(temporaryBooking);
                        }
                    }
                }
            }catch (SqlException e) { throw new Exception(e.Message); }
            return bookings;
        }

        public override Booking Find(int id)
        {
            throw new NotImplementedException();
        }

        public Booking Find(int idBooker, int idVideoGame)
        {
            Booking booking = null;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Booking WHERE idPlayer = @idBooker, idVideoGame = @idVideoGame", connection);
                    command.Parameters.AddWithValue("idBooker", idBooker);
                    command.Parameters.AddWithValue("idVideoGame", idVideoGame);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            booking = new Booking(
                                DAO_Player.Find(reader.GetInt32("idPlayer")),
                                DAO_VideoGame.Find(reader.GetInt32("idVideoGame")),
                                reader.GetDateTime("bookingDate"));
                        }
                    }
                }
            }catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            return booking;
        }

        public override bool Update(Booking updatedBooking)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                { 
                    SqlCommand command = new SqlCommand("UPDATE dbo.Booking SET bookingDate = @bookingDate WHERE idPlayer = @idPlayer AND idVideoGame = @idVideoGame", connection);
                    command.Parameters.AddWithValue("idPlayer", updatedBooking.Booker.Id);
                    command.Parameters.AddWithValue("idVideoGame", updatedBooking.VideoGame.IdVideoGame);
                    command.Parameters.AddWithValue("bookingDate", updatedBooking.BookingDate);
                    connection.Open();
                    bool isUpdated = command.ExecuteNonQuery() > 0 ? true : false;
                    return isUpdated;
                }
            }
            catch(SqlException e) { 
            throw new Exception(e.Message); }
        }

        public override Booking VerificationConnection(string username, string password)
        {
            return null;
        }

        public List<Booking> FindBookingsByIdPlayer(int idPlayer)
        {
            List<Booking> playerBookings = new List<Booking>();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Booking WHERE idPlayer = @idPlayer", connection);
                    command.Parameters.AddWithValue("idPlayer", idPlayer);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking temporaryBooking = new Booking(
                                DAO_Player.Find(reader.GetInt32("idPlayer")),
                                DAO_VideoGame.Find(reader.GetInt32("idVideoGame")),
                                reader.GetDateTime("bookingDate")
                                );
                            playerBookings.Add(temporaryBooking);
                        }
                    }
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return playerBookings;
        }
    }
}

