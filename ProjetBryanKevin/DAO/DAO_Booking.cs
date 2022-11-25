using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.DAO
{
    class DAO_Booking : DAO<Booking>
    {
        public DAO_Booking() { }

        public override bool Create(Booking book)
        {
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
                    if(result < 0)
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
                throw new Exception( e.Message.ToString());
            }
        }

        public override bool Delete(Booking obj)
        {
            return false;
        }

        public override List<Booking> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Booking Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Booking obj)
        {
            throw new NotImplementedException();
        }
    }
}

/*

public override List<Booking> DisplayAll()
{
    List<Booking> bookings = new List<Booking>();

    try
    {
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Booking", connection);
            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Booking booking = new Booking
                    (
                        reader.GetInt32("idBooking"),
                        reader.GetDateTime("bookingDate"),
                        reader.GetValue("idPlayer"),
                        reader.GetInt32("idVideoGame")


                  );
                    bookings.Add(booking);

                }
            }
        }
    }
        }
*/