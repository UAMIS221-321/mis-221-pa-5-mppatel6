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

        public void IndividualReport(){
            System.Console.WriteLine("What is the email you are searching for?");
            string email = Console.ReadLine();

            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetCustomerEmail() == email){
                    System.Console.WriteLine(bookings[i].ToString());
                }
            }

            System.Console.WriteLine("Those are all the sessions for the specific email.");
            Console.ReadLine();
        }
        public void MonthlyReport(Listing[] listings){
            ListingUtility utility = new ListingUtility(listings);
            utility.GetAllListingsFromFile();


            System.Console.WriteLine("What month's revenue would you like to see (Please enter month #):");
            int month = int.Parse(Console.ReadLine());
            System.Console.WriteLine("What year do you want to see that month's revenue?");
            int year = int.Parse(Console.ReadLine());
            double sum = 0;

            for(int i = 0; i < Booking.GetCount(); i++){
                DateOnly date = bookings[i].GetTrainingDate();
                if(date.Month == month && date.Year == year){
                    int foundSum = utility.BinaryFindMonth(date.Month);
                    sum += foundSum;
                }
            }
            

            System.Console.WriteLine("Here is your month's revenue");
            System.Console.WriteLine(sum.ToString("C"));
            Console.ReadKey();
        }

        public void YearlyReport(Listing[] listings){
            ListingUtility utility = new ListingUtility(listings);
            utility.GetAllListingsFromFile();

            System.Console.WriteLine("What year's revenue would you like to see:");
            int year = int.Parse(Console.ReadLine());
            double sum = 0;

            for(int i = 0; i < Booking.GetCount(); i++){
                DateOnly date = bookings[i].GetTrainingDate();
                if(date.Year == year){
                    int foundSum = utility.BinaryFindYear(date.Year);
                    sum += foundSum;
                }
            }

            System.Console.WriteLine("Here is your year's revenue");
            System.Console.WriteLine(sum.ToString("C"));
            Console.ReadKey();
        }

        public void CombinedReport(Listing[] listings){
            ListingUtility utility = new ListingUtility(listings);
            utility.GetAllListingsFromFile();

            BookingUtility bookingUtility = new BookingUtility(bookings);
            bookingUtility.SortDate();

            DateOnly month = bookings[0].GetTrainingDate();
            int currMonth = month.Month;
            int currYear = month.Year;
            double sum = utility.BinaryFindMonth(month.Month);
            double yearSum = utility.BinaryFindMonth(month.Month);
            
            Console.Clear();
            System.Console.WriteLine($"Revenue  {currYear}");
            for(int i = 1; i < Booking.GetCount(); i++){
                DateOnly nextMonth = bookings[i].GetTrainingDate();
                int secondMonth = nextMonth.Month;
                int secondYear = nextMonth.Year;

                if(currMonth == secondMonth){
                    sum += utility.BinaryFindMonth(nextMonth.Month);
                    if(currYear == secondYear){
                        yearSum += utility.BinaryFindMonth(nextMonth.Month);
                    }
                    else if(currYear != secondYear){
                        System.Console.WriteLine($"{currYear} : {yearSum.ToString("C")}");
                        yearSum = 0;
                        currYear = secondYear;
                        System.Console.WriteLine("");
                        System.Console.WriteLine($"Revenue {currYear}");
                    }
                }
                else{
                    ProcessBreak(ref currMonth, ref sum, i, listings);
                    if(currYear == secondYear){
                        yearSum += utility.BinaryFindMonth(nextMonth.Month);
                    }
                    else if(currYear != secondYear){
                        System.Console.WriteLine($"{currYear} : {yearSum.ToString("C")}");
                        yearSum = utility.BinaryFindMonth(nextMonth.Month);
                        currYear = secondYear;
                        System.Console.WriteLine("");
                        System.Console.WriteLine($"Revenue {currYear}");
                    }
                }
            }

            

            ProcessBreak(ref currMonth, ref sum, 0, listings);
            System.Console.WriteLine($"{currYear} : {yearSum.ToString("C")}");
            System.Console.WriteLine("");
            System.Console.WriteLine("Press a key to continue!");
            Console.ReadKey();
        }
        public void ProcessBreak(ref int currMonth, ref double sum, int i, Listing[] listings){
            string month = "";
            if(currMonth == 1){
                month = "Janurary";
            }
            if(currMonth == 2){
                month = "Feburary";
            }
            if(currMonth == 3){
                month = "March";
            }
            if(currMonth == 4){
                month = "April";
            }
            if(currMonth == 5){
                month = "May";
            }
            if(currMonth == 6){
                month = "June";
            }
            if(currMonth == 7){
                month = "July";
            }
            if(currMonth == 8){
                month = "August";
            }
            if(currMonth == 9){
                month = "September";
            }
            if(currMonth == 10){
                month = "October";
            }
            if(currMonth == 11){
                month = "November";
            }
            if(currMonth == 12){
                month = "December";
            }

            System.Console.WriteLine($"{month} : {sum.ToString("C")}");

            ListingUtility utility = new ListingUtility(listings);
            DateOnly newMonth = bookings[i].GetTrainingDate();
            currMonth = newMonth.Month;
            sum = utility.BinaryFindMonth(newMonth.Month);
        }
        public void PrintCustomerSessions(){
            BookingUtility utility = new BookingUtility(bookings);
            utility.GetAllTransactionsFromFile();
            utility.Sort();
            
            // int count = 0;
            string curr = bookings[0].GetCustomerName();
            int session = 0;
            // System.Console.WriteLine(bookings[count].ToString());

            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetCustomerName() == curr){
                    System.Console.WriteLine(bookings[i].ToString());
                    session++;
                }
                else{
                    ProcessBreak2(ref curr, ref session, i);
                }
            }
            System.Console.WriteLine($"{curr} : {session}");
            
        }
        public void ProcessBreak2(ref string curr, ref int session, int i){
            System.Console.WriteLine($"{curr} : {session}");
            System.Console.WriteLine("");
            System.Console.WriteLine(bookings[i].ToString());
            curr = bookings[i].GetCustomerName();
            session = 1;
        }
    }
}