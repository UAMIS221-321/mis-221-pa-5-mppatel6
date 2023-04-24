using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings){
            this.listings = listings;
        }

        public void GetAllListingsFromFile(){
            StreamReader inFile = new StreamReader("listings.txt");
            
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], DateOnly.Parse(temp[2]), TimeOnly.Parse(temp[3]),int.Parse(temp[4]), temp[5], bool.Parse(temp[6]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void AddListing(){
            Listing mylistings = new Listing();
            
            mylistings.SetListingID();
            System.Console.WriteLine("Please enter the trainers name:");
            mylistings.SetTrainerName(Console.ReadLine());

    
            System.Console.WriteLine("Please enter the date of session:");
            string date = Console.ReadLine();
         
           
            System.Console.WriteLine("Please enter the time of session (Please enter in military time (+12 if after 12:00 PM)) (HH:MM):");
            string time = Console.ReadLine();
            

            DateOnly parsedDate = DateOnly.Parse(date);
            TimeOnly parsedTime = TimeOnly.Parse(time);

            mylistings.SetDate(parsedDate);
            mylistings.SetTime(parsedTime);

            System.Console.WriteLine("Please enter the cost of session:");
            mylistings.SetCost(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Is the session open or taken?");
            mylistings.SetTaken(Console.ReadLine());

            listings[Listing.GetCount()] = mylistings;
            Listing.IncCount();

            Save();
        }
        public int Find(int searchVal){
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetListingID() == searchVal){
                    return i;
                }
            }
            return -1;
        }
    
        public void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");
            for(int i = 0; i < Listing.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }
        public void UpdateListing(){
            System.Console.WriteLine("What's the ID of the listing you would like to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Which section of the line would you like to change\n1:  Trainer Name\n2:  Date of Session\n3:  Time of Session\n4:  Cost\n5:  Availability");
                string temp = Console.ReadLine();
                if(temp == "1"){
                    System.Console.WriteLine("Please enter the trainers name:");
                    listings[foundIndex].SetTrainerName(Console.ReadLine());
                }
                else if (temp == "2"){
                    System.Console.WriteLine("Please enter the date of session:");
                    string date = Console.ReadLine();
                    DateOnly parsedDate = DateOnly.Parse(date);
                    listings[foundIndex].SetDate(parsedDate);
                }
                else if(temp == "3"){
                    System.Console.WriteLine("Please enter the time of session (Please enter in military time (+12 if after 12:00)):");
                    string time = Console.ReadLine();
                    TimeOnly parsedTime = TimeOnly.Parse(time);
                    listings[foundIndex].SetTime(parsedTime);
                }
                else if(temp == "4"){
                    System.Console.WriteLine("Please enter the cost of session:");
                    listings[foundIndex].SetCost(int.Parse(Console.ReadLine()));
                }
                else if(temp == "5"){
                    System.Console.WriteLine("Is the session open or taken?");
                    listings[foundIndex].SetTaken(Console.ReadLine());
                }
                Save();
            }
            else{
                System.Console.WriteLine("Trainer not found.");
                Console.ReadKey();

            }
        }
        public void DeleteListing(){
            System.Console.WriteLine("What is the ID of the listing you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                listings[foundIndex].Delete();
                Save();

            }
            else{
                System.Console.WriteLine("Trainer not found.");
                Console.ReadKey();

            }
        }
        public void SortDate(){
            for(int i = 0; i < Booking.GetCount() - 1; i++){
                int min = i;
                for(int j = i + 1; j < Booking.GetCount(); j++){
                    if(listings[min].GetDate().CompareTo(listings[j].GetDate()) > 0 || (listings[j].GetDate() == listings[min].GetDate())){
                        min = j;
                    }
                }
                if(min != i){
                    Swap(min, i);
                }
            }
        }
        private void Swap(int x, int y){
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }
        public int BinaryFindMonth(int searchVal){

            int min = 0;
            int max = Listing.GetCount();
    
            while(min <= max){
                int middle = (max + min) / 2;
                DateOnly find = listings[middle].GetDate();

                if(searchVal == find.Month){
                    return(listings[middle].GetCost());
                }
                else if(searchVal.CompareTo(find.Month) == -1){
                    max = middle - 1;
                }
                else{
                    min = middle + 1; 
                }
            }
            return -1;
        }
        public int BinaryFindYear(int searchVal){

            int min = 0;
            int max = Listing.GetCount() - 1;
            SortDate();
    
            while(min <= max){
                int middle = (max + min) / 2;
                DateOnly find = listings[middle].GetDate();

                if(searchVal == find.Year){
                    return(listings[middle].GetCost());
                }
                else if(searchVal.CompareTo(find.Year) == -1){
                    max = middle - 1;
                }
                else{
                    min = middle + 1; 
                }
            }
            return -1;
        }
        
    }
}