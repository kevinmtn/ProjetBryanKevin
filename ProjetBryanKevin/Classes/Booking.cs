﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.Classes
{
    public class Booking
    {
        private int idBooking;
        private DateTime bookingDate;
        private Player booker;
        private VideoGame videoGame;

        public Booking(int idBooking, DateTime bookingDate, Player booker, VideoGame videoGame )
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
        public DateTime BookingDate {
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
    }
}