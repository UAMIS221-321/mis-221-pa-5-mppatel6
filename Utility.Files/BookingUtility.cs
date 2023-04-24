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
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], DateOnly.Parse(temp[3]), int.Parse(temp[4]) , temp[5], temp[6], bool.Parse(temp[7]));
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void Book(Listing[] listings, Trainer[] trainers, Booking[] bookings){
            Console.Clear();
            Booking mybookings = new Booking();
            ListingUtility utilityListing = new ListingUtility(listings);
            utilityListing.GetAllListingsFromFile();

            ListingReport report = new ListingReport(listings);
            report.PrintOpenListing();
            int count = report.CountOpenListings();

            TrainerUtility trainerUtility = new TrainerUtility(trainers);
            trainerUtility.GetAllTrainersFromFile();

            if(count > 0){
                System.Console.WriteLine("");
                System.Console.WriteLine("Which listing would you like to book?\nPlease choose the listing ID");
                int searchVal = int.Parse(Console.ReadLine());
                int foundIndex = utilityListing.Find(searchVal);

                if(foundIndex != -1){
                    System.Console.WriteLine("What is the customers name?");
                    mybookings.SetCustomerName(Console.ReadLine());
                    System.Console.WriteLine("What is the customers email address?");
                    mybookings.SetCustomerEmail(Console.ReadLine());
                    mybookings.SetSessionID();
                    mybookings.SetTrainerName(listings[foundIndex].GetTrainerName());
                    mybookings.SetTrainingDate(listings[foundIndex].GetDate());
                    mybookings.SetStatus("Booked");
                    listings[foundIndex].SetTaken("Booked");

                    trainerUtility.Sort();
                    string name = listings[foundIndex].GetTrainerName();
                    int foundID = trainerUtility.BinaryFindTrainer(name);
                    mybookings.SetTrainerID(foundID);

                    bookings[Booking.GetCount()] = mybookings;
                    Booking.IncCount();

                    Save();
                    utilityListing.Save();
                    System.Console.WriteLine($"You have successfully booked your session!\nPlease Press any key to continue!");
                    Console.ReadKey();
                }
                else{
                    System.Console.WriteLine("Session not found\nPress a key to continue");
                    Console.ReadKey();
                }
            }
            else{
                System.Console.WriteLine("Sorry there are no sessions left to book\nPlease press a key to continue.");
                Console.ReadKey();
            }

            
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
                    string date = Console.ReadLine();
                    DateOnly parsedDate = DateOnly.Parse(date);
                    bookings[foundIndex].SetTrainingDate(parsedDate);
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
        public void Sort(){
            for(int i = 0; i < Booking.GetCount() - 1; i++){
                int min = i;
                for(int j = i + 1; j < Booking.GetCount(); j++){
                    if(bookings[min].GetCustomerName().CompareTo(bookings[j].GetCustomerName()) > 0 || (bookings[j].GetCustomerName() == bookings[min].GetCustomerName() && bookings[min].GetTrainingDate().CompareTo(bookings[j].GetTrainingDate()) > 0)){
                        min = j;
                    }
                }
                if(min != i){
                    Swap(min, i);
                }
            }
        }
        public void SortDate(){
            for(int i = 0; i < Booking.GetCount() - 1; i++){
                int min = i;
                for(int j = i + 1; j < Booking.GetCount(); j++){
                    if(bookings[min].GetTrainingDate().CompareTo(bookings[j].GetTrainingDate()) > 0 || (bookings[j].GetTrainingDate() == bookings[min].GetTrainingDate())){
                        min = j;
                    }
                }
                if(min != i){
                    Swap(min, i);
                }
            }
        }
        private void Swap(int x, int y){
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
    }
}