using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class BookingReport
    {
        Booking[] bookings;

        public BookingReport(Booking[] bookings){
            this.bookings = bookings;
        }

        public void PrintAllBookings(){
            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetDeleted() == false){
                    System.Console.WriteLine(bookings[i].ToString());
                }
            }
        }
    }
}