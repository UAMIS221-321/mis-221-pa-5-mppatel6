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
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3],int.Parse(temp[4]), temp[5], bool.Parse(temp[6]));
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
            mylistings.SetDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the time of session:");
            mylistings.SetTime(Console.ReadLine());
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
                    listings[foundIndex].SetDate(Console.ReadLine());
                }
                else if(temp == "3"){
                    System.Console.WriteLine("Please enter the time of session:");
                    listings[foundIndex].SetTime(Console.ReadLine());
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
    }
}