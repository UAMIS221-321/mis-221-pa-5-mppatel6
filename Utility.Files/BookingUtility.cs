using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class BookingUtility
    {
        private Booking[] bookings;
        Listing[] listings;
        Trainer[] trainers;

        public BookingUtility(Booking[] bookings){
            this.bookings = bookings;
        }

        public void GetAllTransactionsFromFile(){
            StreamReader inFile = new StreamReader("transaction.txt");
            
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]) , temp[5], temp[6], bool.Parse(temp[7]));
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void AddTransaction(){
            Booking mybookings = new Booking();

            mybookings.SetSessionID();
            System.Console.WriteLine("Please enter the customer's name:");
            mybookings.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the customer's email:");
            mybookings.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("Please enter the training date:");
            mybookings.SetTrainingDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer ID:");
            mybookings.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the trainers name:");
            mybookings.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Is the session Booked, Completed, or Cancelled:");
            mybookings.SetStatus(Console.ReadLine());

            bookings[Booking.GetCount()] = mybookings;
            Booking.IncCount();

            Save();
        }

        public static void Book(Listing[] listings, Trainer[] trainers){
            ListingReport report = new ListingReport(listings);
            report.PrintAllListings();
        }

        public int Find(int searchVal){
            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetSessionID() == searchVal){
                    return i;
                }
            }
            return -1;
        }
        public void Save(){
            StreamWriter outFile = new StreamWriter("transaction.txt");
            for(int i = 0; i < Booking.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }
        public void UpdateTransaction(){
            System.Console.WriteLine("What's the ID of the session you would like to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Which section of the line would you like to change?\n1:  Customer Name\n2:  Customer Email\n3:  Training Date\n4:  Trainer ID\n5:  Trainer Name\n6:  Status");
                string temp = Console.ReadLine();
                if(temp == "1"){
                    System.Console.WriteLine("Please enter the customer's name: ");
                    bookings[foundIndex].SetCustomerName(Console.ReadLine());
                }
                else if(temp == "2"){
                    System.Console.WriteLine("Please enter the customer's email address: ");
                    bookings[foundIndex].SetCustomerEmail(Console.ReadLine());
                }
                else if(temp == "3"){
                    System.Console.WriteLine("Please enter the training date: ");
                    bookings[foundIndex].SetTrainingDate(Console.ReadLine());
                }
                else if(temp == "4"){
                    System.Console.WriteLine("Please enter the trainer's ID:");
                    bookings[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));
                }
                else if(temp == "5"){
                    System.Console.WriteLine("Please enter the trainer's name:");
                    bookings[foundIndex].SetTrainerName(Console.ReadLine());
                }
                else if(temp == "6"){
                    System.Console.WriteLine("Please enter if the session is Booked, Completed, or Cancelled:");
                    bookings[foundIndex].SetStatus(Console.ReadLine());
                }
                Save();
            }
            else{
                System.Console.WriteLine("Trainer not found.");
                Console.ReadKey();
            }
        }
        public void DeleteTransaction(){
            System.Console.WriteLine("What is the ID of the booking you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                bookings[foundIndex].Delete();
                Save();

            }
            else{
                System.Console.WriteLine("Trainer not found.");
                Console.ReadKey();

            }
        }
        // public void IndividualReport(){
        //     System.Console.WriteLine("What is the email of the customer you would like to see the reports about");
        //     string searchVal = Console.ReadLine();
        //     string foundIndex = FindEmail(searchVal);

            
        // }
        // public string FindEmail(string searchVal){
        //     for(int i = 0; i < Booking.GetCount(); i++){
        //         if(bookings[i].GetCustomerEmail() == searchVal){
        //             return bookings[i];
        //         }
        //     }
        //     return "";
        // }
    }
}