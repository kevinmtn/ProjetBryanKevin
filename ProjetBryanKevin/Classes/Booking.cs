using ProjetBryanKevin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetBryanKevin.Classes
{
    public class Booking
    {
        private int idBooking;
        private DateTime bookingDate;
        private Player booker;
        private VideoGame videoGame;

        public Booking(Player booker, VideoGame videoGame)
        {
            this.booker = booker;
            this.videoGame = videoGame;
        }

        public Booking(Player booker, VideoGame videoGame, DateTime bookingDate)
        {
            this.booker = booker;
            this.videoGame = videoGame;
            this.bookingDate = bookingDate;
        }

        public Booking(int idBooking, DateTime bookingDate, Player booker, VideoGame videoGame)
        {
            this.bookingDate = bookingDate;
            this.idBooking = idBooking;
            this.booker = booker;
            this.videoGame = videoGame;
        }

        public int IdBooking
        {
            get { return idBooking; }
            set { idBooking = value; }
        }
        public DateTime BookingDate
        {
            get { return this.bookingDate; }
            set { this.bookingDate = value; }
        }

        public Player Booker
        {
            get { return this.booker; }
            set { this.booker = value; }
        }

        public VideoGame VideoGame
        {
            get { return this.videoGame; }
            set { this.videoGame = value; }
        }

        public Booking Insert()
        {
            DAO_Booking dAO_Booking = new DAO_Booking();
            return dAO_Booking.Create(this);
        }

        public static List<Booking> GetBooking()
        {
            DAO_Booking dao_booking = new DAO_Booking();
            return dao_booking.FindAll();
        }

        public bool Delete()
        {
            DAO_Booking dao_Booking = new DAO_Booking();
            return dao_Booking.Delete(this);
        }


        public static List<Booking> GetPlayerBookings(Player play)
        {
            DAO_Booking dao_booking = new DAO_Booking();
            return dao_booking.FindBookingsByIdPlayer(play);
        }

        internal Booking GetPriorityBooking(Booking booking)
        {
            int credComparison = this.Booker.Credit - booking.Booker.Credit;
            if(credComparison > 0)
            {
                return this;
            }
            else if(credComparison < 0)
            {
                return booking;
            }
            else
            {
                int bookingDateComparison = DateTime.Compare(this.bookingDate, booking.bookingDate);
                if(bookingDateComparison < 0) {
                    return this;
                }
                else if(bookingDateComparison > 0){
                    return booking;
                }
                else
                {
                    int registrationDateComparison = DateTime.Compare(this.Booker.RegistrationDate, booking.Booker.RegistrationDate);
                    if(registrationDateComparison < 0)
                    {
                        return this;
                    }
                    else if(registrationDateComparison > 0)
                    {
                        return booking;
                    }
                    else
                    {
                        int ageComparison = DateTime.Compare(this.Booker.DateOfBirth, booking.Booker.DateOfBirth);
                        if(ageComparison < 0)
                        {
                            return this;
                        }
                        else if(registrationDateComparison > 0)
                        {
                            return booking;
                        }
                        else{
                            Random random = new Random();
                            if(random.Next(1,3) == 1)
                            {
                                return this;
                            }
                            else
                            {
                                return booking;
                            }
                        }
                    }
                }
            }
            
        }
    }
}