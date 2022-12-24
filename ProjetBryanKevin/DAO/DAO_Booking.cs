using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Printing.IndexedProperties;

namespace ProjetBryanKevin.DAO
{

    class DAO_Booking : DAO<Booking>
    {
        DAO_Player DAO_Player = new DAO_Player();
        DAO_VideoGame DAO_VideoGame = new DAO_VideoGame();
        public DAO_Booking() { }

        public override Booking Create(Booking book)
        {
            Booking newBooking = null;
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO dbo.Booking(idPlayer, idVideoGame, bookingDate) VALUES (@idPlayer, @idVideoGame,@bookingDate)", connection);
                    insertCmd.Parameters.AddWithValue("idPlayer", book.Booker.Id);
                    insertCmd.Parameters.AddWithValue("idVideoGame", book.VideoGame.IdVideoGame);
                    insertCmd.Parameters.AddWithValue("bookingDate", book.BookingDate);
                    connection.Open();
                    int result = insertCmd.ExecuteNonQuery();
                    success = result > 0;
                    if(success)
                    {
                        SqlCommand selectQuery = new SqlCommand("SELECT * FROM dbo.Booking WHERE idPlayer = @idPlayer AND idVideoGame = @idVideoGame", connection);
                        selectQuery.Parameters.AddWithValue("idPlayer", book.Booker.Id);
                        selectQuery.Parameters.AddWithValue("idVideoGame", book.VideoGame.IdVideoGame);
                        Debug.Print("booker.id: " + book.Booker.Id.ToString());
                        Debug.Print("videogame.id: " + book.VideoGame.IdVideoGame.ToString());
                        Debug.Print("bookingDate: " + book.BookingDate.ToString());
                        using(SqlDataReader reader = selectQuery.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                newBooking = new Booking(
                                    DAO_Player.Find(reader.GetInt32("idPlayer")),
                                    DAO_VideoGame.Find(reader.GetInt32("idVideoGame")),
                                    reader.GetDateTime("bookingDate")
                                    );
                                Debug.Print(newBooking.BookingDate.ToString());
                            }
                        }
                    }
                }
                return newBooking;
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Booking WHERE idPlayer = @idPlayer AND idVideoGame = @idVideoGame", connection);
                    cmd.Parameters.AddWithValue("idPlayer", booking.Booker.Id);
                    cmd.Parameters.AddWithValue("idVideoGame", booking.VideoGame.IdVideoGame);

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

        public override List<Booking> FindAll()
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
            }
            catch (SqlException e) { throw new Exception(e.Message); }
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Booking WHERE idPlayer = @idBooker, idVideoGame = @idVideoGame", connection);
                    command.Parameters.AddWithValue("idBooker", idBooker);
                    command.Parameters.AddWithValue("idVideoGame", idVideoGame);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
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
            }
            catch (SqlException e)
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
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public  List<Booking> FindBookingsByIdPlayer(Player play)
        {
            List<Booking> playerBookings = new List<Booking>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Booking WHERE idPlayer = @idPlayer", connection);
                    command.Parameters.AddWithValue("idPlayer", play.Id);
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